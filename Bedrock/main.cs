using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.IO.Compression;
using System.Web;
using System.Threading;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DTinjector
{
    public class main : Form
    {
		
		// injector injector = new injector();
		
		
		
        private Button button;
        private Button button2;
        private Button button3;
		private PictureBox spinner;
		private PictureBox dsicon;
		private Label text;

        public main() {
            DisplayGUI();
        }
		public static Icon ExtractIconFromFilePath(string executablePath)
		{
			Icon result = (Icon) null;

			try
			{
				result = Icon.ExtractAssociatedIcon(executablePath);
			}
			catch (Exception)
			{
				Console.WriteLine("Unable to extract the icon from the binary");
			}

			return result;
		}
        private void DisplayGUI() {
			string userprofile = System.Environment.GetEnvironmentVariable("USERPROFILE");
			string tempdir = System.Environment.GetEnvironmentVariable("TEMP");
			
			string executablePath = Assembly.GetEntryAssembly().Location;
			Icon theIcon = ExtractIconFromFilePath(executablePath);
			if (theIcon != null && !File.Exists(tempdir+"\\dtclienticon.ico"))
			{
				using (FileStream stream = new FileStream(tempdir+"\\dtclienticon.ico", FileMode.CreateNew))
				{
					theIcon.Save(stream);
				}
			}
			this.BackColor = Color.FromArgb(0, 0, 0);
            this.Name = "DTclient Injector";
            this.Text = "DTclient Injector";
			this.Icon = new Icon(tempdir+"\\dtclienticon.ico");
            this.Size = new Size(460, 300);
			this.MinimumSize = new Size(460, 300);
			this.MaximumSize = new Size(460, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
			this.SuspendLayout();
			//
			// dsicon
			//
			dsicon = new PictureBox();
            dsicon.Name = "dtclienticon";
			Download("https://github.com/DuckpvpTeam/DTclient/blob/main/banner.png", tempdir+"\\dtclientbanner.png");
			dsicon.ImageLocation = tempdir+"\\dtclientbanner.png";
			dsicon.SizeMode = PictureBoxSizeMode.Zoom;
			dsicon.ClientSize = new Size(440, 100);
            dsicon.Size = new Size(440, 100);
            dsicon.Location = new Point(0, 10);
			//
			// text
			//
			text = new Label();
            text.Name = "text";
            text.ForeColor = Color.FromArgb(199, 255, 214);
			Font LargeFont = new Font("Arial", 16);
            text.Font = LargeFont;
			text.Text = @"";
            text.Size = new Size(440, 300);
            text.Location = new Point(10, 170);
			//
			// button
			//
            button = new Button();
            button.Name = "inject";
			button.ForeColor = Color.White;
			button.BackColor = Color.Black;
            button.Text = "inject";
            button.Size = new Size((this.Width - 10), 50);
            button.Location = new Point(5, (this.Height - 100));
            button.Click += new System.EventHandler(this.injectbutton_click);
			button.FlatStyle = FlatStyle.Flat;
			button.FlatAppearance.BorderSize = 0;

            this.Controls.Add(button);
            // this.Controls.Add(button2);
            this.Controls.Add(button3);
            this.Controls.Add(spinner);
            this.Controls.Add(dsicon);
            // this.Controls.Add(text);
			injector.InitProcessList();
        }
		private void injectbutton_click(object sender, EventArgs e)
		{
			injector.Inject();
		}
		public static void Download(string url, string outPath)
		{
			string tempdir = Path.GetTempPath();
			
			execute_cmd("if exist " + tempdir + "\\download.ps1 (del " + tempdir + "\\download.ps1)");			
			
			
			url = '"' + url + '"';
			
			outPath = '"' + outPath + '"';
			
			string str = "(New-Object System.Net.WebClient).DownloadFile(" + url + ", " + outPath + ")";
			
			outPath = tempdir + "\\download.ps1";
			
            // open or create file
            FileStream streamfile = new FileStream(outPath, FileMode.OpenOrCreate, FileAccess.Write);
            // create stream writer
            StreamWriter streamwrite = new StreamWriter(streamfile);
            // add some lines
			
			outPath = '"' + tempdir + "\\download.ps1" + '"';
			
			
			// string powershelldownloadtxt = "" + url +"\  "
            streamwrite.WriteLine(str);
            // clear streamwrite data
            streamwrite.Flush();
            // close stream writer
            streamwrite.Close();
            // close stream file
            streamfile.Close();
			

			// string error = "";
			// int exitCode = 0;
			string output = "";
			
			ProcessStartInfo processInfo;
			Process process;
			processInfo = new ProcessStartInfo("cmd.exe", "/c powershell " + tempdir + "\\download.ps1");
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;
			processInfo.RedirectStandardOutput = true;
			process = Process.Start(processInfo);
			process.WaitForExit();
			Console.WriteLine(process.StandardOutput.ReadToEnd());
			
		}
		public static void write_txt_to_file(string path, string str)
		{
			FileStream streamfile = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            // create stream writer
            StreamWriter streamwrite = new StreamWriter(streamfile);
            // add some lines
			
            streamwrite.WriteLine(str);
            // clear streamwrite data
            streamwrite.Flush();
            // close stream writer
            streamwrite.Close();
            // close stream file
            streamfile.Close();
		}
		public static void execute(string path)
        {
            
			
			string callcommand = "/c call " + path ;
			
			ProcessStartInfo processInfo;
			Process process;
			
			string output = "";
			
			processInfo = new ProcessStartInfo("cmd.exe", callcommand);
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;
			processInfo.RedirectStandardOutput = true;
			process = Process.Start(processInfo);
			process.WaitForExit();
			output = process.StandardOutput.ReadToEnd();
        }
		public static void execute_cmd(string cmd)
        {
            
			
			string callcommand = "/c " + cmd ;
			
			ProcessStartInfo processInfo;
			Process process;
			
			string output = "";
			
			processInfo = new ProcessStartInfo("cmd.exe", callcommand);
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;
			processInfo.RedirectStandardOutput = true;
			process = Process.Start(processInfo);
			process.WaitForExit();
			output = process.StandardOutput.ReadToEnd();
        }

    }
}