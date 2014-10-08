using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace YuGiOhTracker
{
	public partial class frmAbout : Form
	{
		public frmAbout()
		{
			InitializeComponent();
		}

		private void frmAbout_Load(object sender, EventArgs e)
		{
			if(File.Exists("LICENSE"))
			{
				txtLicence.Text = File.ReadAllText("LICENSE");
			}
			else
				txtLicence.Text = "MIT License should be here. :(" + Environment.NewLine + "Cant load 'LICENSE' file.";
		}

		private void lnklblGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			lnklblGitHub.LinkVisited = true;
			System.Diagnostics.Process.Start("https://github.com/DanielMcAssey/YuGiOhTracker");    
		}
	}
}
