﻿using System;
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
    static class Program
    {
        [STAThread]
        static void Main()
        {
			ServicePointManager.Expect100Continue = true; 
			ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc00);
			
			
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new main());
        }
    }
}