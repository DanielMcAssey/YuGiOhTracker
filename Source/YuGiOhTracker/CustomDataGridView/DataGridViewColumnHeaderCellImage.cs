using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YuGiOhTracker.CustomDataGridView
{
	public class DataGridViewColumnHeaderCellImage : System.Windows.Forms.DataGridViewColumnHeaderCell
	{
		public System.Drawing.Image HeaderImage { get; set; }

		protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState,
	object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
	DataGridViewPaintParts paintParts)
		{
			// Outside header or without an image, use default painting
			if ((rowIndex != -1) || (HeaderImage == null))
			{
				base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
				return;
			}

			// Borders, background, focus selection can remain the same
			// But Foreground will have different image
			base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle,
				advancedBorderStyle, paintParts & ~DataGridViewPaintParts.ContentForeground);

			// Repainting of content background (that's where we want to place our image)
			if ((paintParts & DataGridViewPaintParts.ContentBackground) != DataGridViewPaintParts.None)
			{
				// +4 is hardcoded margin 
				Point bounds = new Point(cellBounds.X + 4, cellBounds.Y);

				// Handle vertical alignment correctly
				switch (cellStyle.Alignment)
				{
					// Top
					case DataGridViewContentAlignment.TopLeft:
					case DataGridViewContentAlignment.TopCenter:
					case DataGridViewContentAlignment.TopRight:
						// Already set
						break;

					// Middle
					case DataGridViewContentAlignment.MiddleLeft:
					case DataGridViewContentAlignment.MiddleCenter:
					case DataGridViewContentAlignment.MiddleRight:
						bounds.Y = cellBounds.Y + (cellBounds.Height - HeaderImage.Height) / 2;
						break;

					// Bottom
					case DataGridViewContentAlignment.BottomLeft:
					case DataGridViewContentAlignment.BottomCenter:
					case DataGridViewContentAlignment.BottomRight:
						bounds.Y = cellBounds.Y + (cellBounds.Height - HeaderImage.Height);
						break;

				}
				graphics.DrawImage(HeaderImage, bounds);
			}

			// Foreground should be shifted by left image margin + image.width + right 
			// image margin and of course target spot should be a bit smaller
			if ((paintParts & DataGridViewPaintParts.ContentForeground) != DataGridViewPaintParts.None)
			{
				Rectangle newCellBounds = new Rectangle(cellBounds.X + 4 + HeaderImage.Width + 4, cellBounds.Y, cellBounds.Width - HeaderImage.Width - 8, cellBounds.Height);
				base.Paint(graphics, clipBounds, newCellBounds, rowIndex, dataGridViewElementState, value, formattedValue, errorText, cellStyle,
					advancedBorderStyle, DataGridViewPaintParts.ContentForeground);
			}

		}

		protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
		{
			// Load up original image
			Size original = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);

			// Ensure the image is set and that we are working on header
			if ((rowIndex != -1) || (HeaderImage == null))
			{
				return original;
			}

			// -1 is reserved value
			if (original.Width < 0)
			{
				return original;
			}
			return new Size(original.Width + HeaderImage.Width + 4, original.Height);
		}
	}
}
