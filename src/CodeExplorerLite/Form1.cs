using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeExplorerLite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CustomInitialize();
        }

        /// <summary>
        /// Customize the UI
        /// </summary>
        private void CustomInitialize()
        {
            richTextBox1.Text = @"Working on a new project can be difficult. You have to find out how it works. You are bored of bad architecture, outdated documentation, workarounds.
It is the time to find the truth!

1) A new project named ""LoggingSystem"" will be added to your solution. 
2) In all other projects a referince to the loggong System will be automaticaly added.
3) In every method in your project code will be inserted a line of additional code that will write to the log file information about the function beeing executed.
This line starts with: /*LoggingSystem to be removed from production code*/ just to remind you that it is not part of the production code. It is recomanded to work on a copy of your project to keep your original safe.
4) A folder called ""Logs"" will be added to drive C: if not exist. There will be stored the log files.
4) Now you can compile and start your project. Some code might have some errors and you have to delete the inserted lines from static methods, structures or other missplaced occurences.
5) Clean your logging file before the action you realy want to log
6) Perform the specific action (use your application)
7) Analize the log
8) View the analized files";
        }

        /// <summary>
        /// Create a copy of the Logging System project into the project you want to analyze
        /// </summary>
        /// <param name="destinationPath">Path to the folder containing the project solution</param>
        private void CopyLoggingDirectory(string destinationPath)
        {
            string sourcePath = Directory.GetCurrentDirectory();
            sourcePath = sourcePath.Substring(0, sourcePath.LastIndexOf("\\"));
            sourcePath = sourcePath.Substring(0, sourcePath.LastIndexOf("\\"));
            sourcePath = sourcePath.Substring(0, sourcePath.LastIndexOf("\\"));
            sourcePath = sourcePath + "\\LoggingSystem";

            
            destinationPath = destinationPath + "\\LoggingSystem";
            //Directory.CreateDirectory();
            //Now Create all of the directories
            if (Directory.Exists(destinationPath))
            {
                return;
            }
            
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourcePath, destinationPath));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(sourcePath, destinationPath), true);
        }

        /// <summary>
        /// Method numbers will be assigned as a identitfier for each method. It is easier to find the method
        /// </summary>
        private static int MethodNumber = 1;
        private string loggigLine
        {
            get
            {
                return "/*LoggingSystem to be removed from production code*/ LoggingSystem.MyLogger.Log(new LoggingSystem.LoggingElement(){ Nr= " +
                (MethodNumber++) +
                ", Namespace = this.GetType().Namespace, Class = this.GetType().Name, Method = new System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name });";
            }
        }

        /// <summary>
        /// Start searching for the project to be analized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                comboBoxProjectRoot.Items.Add(folderBrowserDialog1.SelectedPath);
                comboBoxProjectRoot.SelectedIndex = comboBoxProjectRoot.Items.Count - 1;
            }
        }

        /// <summary>
        /// Process current directory recursive
        /// </summary>
        /// <param name="path"></param>
        private void ProcessDirectory(string path)
        {

            foreach (string d in Directory.GetDirectories(path))
            {
                foreach (string f in Directory.GetFiles(d))
                {
                    FileInfo myFileInfo = new FileInfo(f);
                    if (myFileInfo.Extension.Equals(".csproj"))
                    {
                        InsertLoggerReference(myFileInfo);
                    }
                    if (myFileInfo.Extension.Equals(".sln"))
                    {
                        InsertLoggerProject(myFileInfo);
                    }
                    if (myFileInfo.Name.Equals("MyLog.cs") || myFileInfo.FullName.Contains("LoggingSystem") || (!myFileInfo.Name.EndsWith(".cs")))
                    {
                        continue;
                    }
                    InsertLoogingRequests(myFileInfo);
                }
                ProcessDirectory(d);
            }
        }

        /// <summary>
        /// Creste the Logging System into your project
        /// </summary>        
        private void InsertLoggingSystem()
        {
            string path = comboBoxProjectRoot.SelectedItem.ToString();
            try
            {
                CopyLoggingDirectory(path);
                Directory.CreateDirectory("C:\\Log");

                foreach (string f in Directory.GetFiles(path))
                {
                    FileInfo myFileInfo = new FileInfo(f);
                    if (myFileInfo.Extension.Equals(".csproj"))
                    {
                        InsertLoggerReference(myFileInfo);
                    }
                    if (myFileInfo.Extension.Equals(".sln"))
                    {
                        InsertLoggerProject(myFileInfo);
                    }
                    if (myFileInfo.Name.Equals("MyLog.cs") || myFileInfo.FullName.Contains("LoggingSystem") || (!myFileInfo.Name.EndsWith(".cs")))
                    {
                        continue;
                    }
                    InsertLoogingRequests(myFileInfo);
                }
                ProcessDirectory(path);
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        /// <summary>
        /// Add logger project to your solution
        /// </summary>
        /// <param name="myFileInfo"></param>
        private void InsertLoggerProject(FileInfo myFileInfo)
        {
            List<string> linesCsproj = File.ReadAllLines(myFileInfo.FullName, Encoding.UTF8).ToList();

            int locationOfReferinces = 0;
            int locationOfConfiguration = 0;
            bool alreadyReference = false;

            for (int i = 0; i < linesCsproj.Count; i++)
            {
                if (linesCsproj[i].Contains("Project(\"{"))
                {
                    locationOfReferinces = i;
                }
                if (linesCsproj[i].Contains("GlobalSection(ProjectConfigurationPlatforms)"))
                {
                    locationOfConfiguration = i+1;
                }
                if (linesCsproj[i].Contains("LoggingSystem.csproj"))
                {
                    alreadyReference = true;
                }
            }
            if (!alreadyReference)
            {
                linesCsproj.Insert(locationOfReferinces + 1, @"Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""LoggingSystem"", ""LoggingSystem\LoggingSystem\LoggingSystem.csproj"", ""{81C1F29B-D20E-4678-B603-38DC15DCC1s5}""
EndProject");
                
		linesCsproj.Insert(locationOfConfiguration + 1, @" {81C1F29B-D20E-4678-B603-38DC15DCC1s5}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{81C1F29B-D20E-4678-B603-38DC15DCC1s5}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{81C1F29B-D20E-4678-B603-38DC15DCC1s5}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {81C1F29B-D20E-4678-B603-38DC15DCC1s5}.Release|Any CPU.Build.0 = Release|Any CPU");
                File.WriteAllLines(myFileInfo.FullName, linesCsproj, Encoding.UTF8);
            }
        }

        /// <summary>
        /// Insert a referince to the Logging System project in all other projects
        /// </summary>
        /// <param name="myFileInfo"></param>
        private void InsertLoggerReference(FileInfo myFileInfo)
        {
            if (!myFileInfo.FullName.Contains("LoggingSystem"))
            {
                List<string> linesCsproj = File.ReadAllLines(myFileInfo.FullName, Encoding.UTF8).ToList();

                int locationOfReferinces = 0;
                bool alreadyReference = false;
                bool alreadyReferenceSystem = false;

                for (int i = 0; i < linesCsproj.Count; i++)
                {
                    if (linesCsproj[i].Contains("<ItemGroup>"))
                    {
                        locationOfReferinces = i;
                    }
                    if (linesCsproj[i].Contains("<ProjectReference Include=\"..\\LoggingSystem\\LoggingSystem\\LoggingSystem.csproj\">"))
                    {
                        alreadyReference = true;
                    }
                    if (linesCsproj[i].Contains("<Reference Include=\"System\">"))
                    {
                        alreadyReferenceSystem = true;
                    }
                }

                if (!alreadyReferenceSystem)
                {
                    linesCsproj.Insert(locationOfReferinces + 1, @"    <Reference Include=""System"">
      <Name>System</Name>
    </Reference>");
                }
                if (!alreadyReference)
                {
                    linesCsproj.Insert(locationOfReferinces + 1, @"    <ProjectReference Include=""..\LoggingSystem\LoggingSystem\LoggingSystem.csproj"">
      <Project>{81C1F29B-D20E-4678-B603-38DC15DCC1C5}</Project>
      <Name>LoggingSystem</Name>
    </ProjectReference>");
                    File.WriteAllLines(myFileInfo.FullName, linesCsproj, Encoding.UTF8);
                }
            }
        }

        /// <summary>
        /// Add the code to each method. At this step some errors might occure in your project. Because the algorithm to find the begining of each function is not smart
        /// </summary>
        /// <param name="myFileInfo"></param>
        private void InsertLoogingRequests(FileInfo myFileInfo)
        {
            bool changed = false;


            //byte[] ansiBytes = File.ReadAllBytes(myFileInfo.FullName.Replace("DE - Kopie", "DE"));
            //var utf8String = Encoding.Default.GetString(ansiBytes);
            //File.WriteAllText(myFileInfo.FullName.Replace("DE - Kopie", "DE"), utf8String);
            List<string> lines = File.ReadAllLines(myFileInfo.FullName /*.Replace("Kopie2", "Kopie")*/, Encoding.GetEncoding(1252)).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Trim().StartsWith("public ") || lines[i].Trim().StartsWith("protected ") || lines[i].Trim().StartsWith("private ") || lines[i].Trim().StartsWith("internal "))
                {
                    if (lines[i].Contains("(") && lines[i].Contains(")") && (lines[i].IndexOf("(") < lines[i].IndexOf(")")))
                    {
                        if (i < lines.Count - 1)
                        {
                            if (lines[i + 1].Trim().Equals("{"))
                            {
                                if (!lines[i].Contains("/*LoggingSystem to be removed from production code*/"))
                                {
                                    if (!lines[i].Contains(" static "))
                                    {
                                        lines.Insert(i + 2, loggigLine);
                                        changed = true;
                                    }
                                }
                                else
                                {

                                }
                            }
                        }
                    }
                }
            }
            if (changed)
            {
                File.WriteAllLines(myFileInfo.FullName, lines, Encoding.GetEncoding(1252));
            }
        }

        /// <summary>
        /// Start inserting the Logging System. No tests for existence of a Logging System are made in this version.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInstertLoggingSystem_Click(object sender, EventArgs e)
        {
            InsertLoggingSystem();
        }

        /// <summary>
        /// open log with the default browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonViewLog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Log\\Log.html");
        }

        /// <summary>
        /// Delete the log file. It will be recreated by the logging system of your application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEraseLog_Click(object sender, EventArgs e)
        {
            File.Delete("C:\\Log\\Log.html");
        }

        /// <summary>
        /// Start analizing the log file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAnalyzeLog_Click(object sender, EventArgs e)
        {
            AnalyzeLastLog();
            System.Diagnostics.Process.Start("C:\\Log\\A.html");
        }


        /// <summary>
        /// Sort method hits by different criteria like number of hits and time measurements
        /// </summary>
        private void AnalyzeLastLog()
        {

            List<string> linesCsproj = File.ReadAllLines("C:\\Log\\Log.html", Encoding.UTF8).ToList();
            List<MethodHitInfo> times = new List<MethodHitInfo>();
            foreach (string line in linesCsproj)
            {
                if (line.Length < 10)
                {
                    continue;
                }
                string pLine = line;
                MethodHitInfo tn = new MethodHitInfo();
                tn.Namespace = pLine.Substring(0, pLine.IndexOf("</span>"));
                tn.Namespace = tn.Namespace.Substring(tn.Namespace.LastIndexOf(">") + 1);
                pLine = pLine.Substring(pLine.IndexOf("</span>") + 7);
                tn.Class = pLine.Substring(0, pLine.IndexOf("</span>"));
                tn.Class = tn.Class.Substring(tn.Class.LastIndexOf(">") + 1);
                pLine = pLine.Substring(pLine.IndexOf("</span>") + 7);
                tn.Method = pLine.Substring(0, pLine.IndexOf("</b>"));
                tn.Method = tn.Method.Substring(tn.Method.LastIndexOf(">") + 1);
                pLine = pLine.Substring(pLine.IndexOf("</span>") + 7);
                string milisecondsString = "";
                int miliseconds = 0;
                milisecondsString = pLine.Substring(0, pLine.IndexOf("</span>"));
                milisecondsString = milisecondsString.Substring(milisecondsString.LastIndexOf(">") + 1);
                if (int.TryParse(milisecondsString, out miliseconds))
                {
                    tn.Time = tn.Time += miliseconds;
                    // no error reported. This method might be not accurate
                }
                pLine = pLine.Substring(pLine.IndexOf("</span>") + 7);
                tn.Number = pLine.Substring(0, pLine.IndexOf("</span>"));
                tn.Number = tn.Number.Substring(tn.Number.LastIndexOf(">") + 1);

                MethodHitInfo timeName = MethodHitInfo.GetMethodByNumber(times, tn.Number);

                if (timeName != null)
                {
                    timeName.Time += tn.Time;
                    timeName.Hits++;
                    if (timeName.Min > tn.Time)
                    {
                        timeName.Min = tn.Time;
                    }
                    if (timeName.Max < tn.Time)
                    {
                        timeName.Max = tn.Time;
                    }
                }
                else
                {
                    if (tn.Number.Equals("6159"))
                    {

                    }
                    tn.Hits = 1;
                    tn.Max = tn.Time;
                    tn.Min = tn.Time;
                    times.Add(tn);
                }
            }

            // Compute Average time per hit
            foreach (MethodHitInfo ob in times)
            {
                ob.Average = ob.Time / ob.Hits;
            }
            //times.Sort();

            foreach (string sortType in new string[] { "A", "B", "C", "D", "E" })
            {
                List<MethodHitInfo> listTimeName = new List<MethodHitInfo>();
                listTimeName.AddRange(times);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(@"<style>.CSSTableGenerator {
	margin:0px;padding:0px;
	width:100%;
	box-shadow: 10px 10px 5px #888888;
	border:1px solid #000000;
	
	-moz-border-radius-bottomleft:0px;
	-webkit-border-bottom-left-radius:0px;
	border-bottom-left-radius:0px;
	
	-moz-border-radius-bottomright:0px;
	-webkit-border-bottom-right-radius:0px;
	border-bottom-right-radius:0px;
	
	-moz-border-radius-topright:0px;
	-webkit-border-top-right-radius:0px;
	border-top-right-radius:0px;
	
	-moz-border-radius-topleft:0px;
	-webkit-border-top-left-radius:0px;
	border-top-left-radius:0px;
}.CSSTableGenerator table{
    border-collapse: collapse;
        border-spacing: 0;
	width:100%;
	height:100%;
	margin:0px;padding:0px;
}.CSSTableGenerator tr:last-child td:last-child {
	-moz-border-radius-bottomright:0px;
	-webkit-border-bottom-right-radius:0px;
	border-bottom-right-radius:0px;
}
.CSSTableGenerator table tr:first-child td:first-child {
	-moz-border-radius-topleft:0px;
	-webkit-border-top-left-radius:0px;
	border-top-left-radius:0px;
}
.CSSTableGenerator table tr:first-child td:last-child {
	-moz-border-radius-topright:0px;
	-webkit-border-top-right-radius:0px;
	border-top-right-radius:0px;
}.CSSTableGenerator tr:last-child td:first-child{
	-moz-border-radius-bottomleft:0px;
	-webkit-border-bottom-left-radius:0px;
	border-bottom-left-radius:0px;
}.CSSTableGenerator tr:hover td{
	
}
.CSSTableGenerator tr:nth-child(odd){ background-color:#ffaa56; }
.CSSTableGenerator tr:nth-child(even)    { background-color:#ffffff; }.CSSTableGenerator td{
	vertical-align:middle;
	
	
	border:1px solid #000000;
	border-width:0px 1px 1px 0px;
	text-align:left;
	padding:7px;
	font-size:10px;
	font-family:Arial;
	font-weight:normal;
	color:#000000;
}.CSSTableGenerator tr:last-child td{
	border-width:0px 1px 0px 0px;
}.CSSTableGenerator tr td:last-child{
	border-width:0px 0px 1px 0px;
}.CSSTableGenerator tr:last-child td:last-child{
	border-width:0px 0px 0px 0px;
}
.CSSTableGenerator tr:first-child td{
		background:-o-linear-gradient(bottom, #ff7f00 5%, #bf5f00 100%);	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #ff7f00), color-stop(1, #bf5f00) );
	background:-moz-linear-gradient( center top, #ff7f00 5%, #bf5f00 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr=""#ff7f00"", endColorstr=""#bf5f00"");	background: -o-linear-gradient(top,#ff7f00,bf5f00);

	background-color:#ff7f00;
	border:0px solid #000000;
	text-align:center;
	border-width:0px 0px 1px 1px;
	font-size:14px;
	font-family:Arial;
	font-weight:bold;
	color:#ffffff;
}
.CSSTableGenerator tr:first-child:hover td{
	background:-o-linear-gradient(bottom, #ff7f00 5%, #bf5f00 100%);	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #ff7f00), color-stop(1, #bf5f00) );
	background:-moz-linear-gradient( center top, #ff7f00 5%, #bf5f00 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr=""#ff7f00"", endColorstr=""#bf5f00"");	background: -o-linear-gradient(top,#ff7f00,bf5f00);

	background-color:#ff7f00;
}
.CSSTableGenerator tr:first-child td:first-child{
	border-width:0px 0px 1px 0px;
}
.CSSTableGenerator tr:first-child td:last-child{
	border-width:0px 0px 1px 1px;
}</style>");
                sb.AppendLine("<h2>Sorted by ");
                switch (sortType)
                {
                    case "A":
                        sb.Append("Cumulated Time");
                        break;
                    case "B":
                        sb.Append("Hits number");
                        break;
                    case "C":
                        sb.Append("Average Time");
                        break;
                    case "D":
                        sb.Append("Max Time");
                        break;
                    case "E":
                        sb.Append("Min Time");
                        break;
                }
                sb.Append("</h2><br>");
                //sb.AppendLine("Sort By: <a href='a.html'>Cumulated Time</a> | <a href='b.html'>Hits number</a> | <a href='c.html'>Average Time</a> | <a href='d.html'>Max Time</a> <br> ");
                sb.AppendLine("<div class=\"CSSTableGenerator\"><table>");
                sb.AppendLine("<tr><th><a href='b.html'>Hits</a></td><td><a href='a.html'>Total</a></td><td><a href='e.html'>Min</a></td><td><a href='c.html'>Med</a></td><td><a href='d.html'>Max</a></td><td>Ns</td><td>Class</td><td>Method</td><td>Id</td></tr>");
                while (listTimeName.Count > 0)
                {
                    MethodHitInfo element = null;
                    int positon = -1;
                    for (int i = 0; i < listTimeName.Count; i++)
                    {

                        if (element == null)
                        {
                            element = listTimeName[i];
                            positon = i;
                        }
                        else
                        {
                            switch (sortType)
                            {
                                case "A":
                                    if (element.Time < listTimeName[i].Time)
                                    {
                                        element = listTimeName[i];
                                        positon = i;
                                    }
                                    break;
                                case "B":
                                    if (element.Hits < listTimeName[i].Hits)
                                    {
                                        element = listTimeName[i];
                                        positon = i;
                                    }
                                    break;
                                case "C":
                                    if (element.Average < listTimeName[i].Average)
                                    {
                                        element = listTimeName[i];
                                        positon = i;
                                    }
                                    break;
                                case "D":
                                    if (element.Max < listTimeName[i].Max)
                                    {
                                        element = listTimeName[i];
                                        positon = i;
                                    }
                                    break;
                                case "E":
                                    if (element.Min > listTimeName[i].Min)
                                    {
                                        element = listTimeName[i];
                                        positon = i;
                                    }
                                    break;
                            }
                        }
                    }
                    listTimeName.RemoveAt(positon);
                    string toLog = "\n<br> <span style='color: blue'>" +
                         element.Hits + "</span> <span style='color: silver'>" +
                         element.Namespace + "</span> <span style='color: orange'>" +
                         element.Class + "</span> <span style='color: blue'>" +
                         element.Method + "</b></span>";
                    toLog += "<span style='color: red'>" +
                        element.Min + "-" + element.Time + "-" + element.Max + "</span> <span style='color: silver'>" + element.Number + "</span>";

                    toLog = "<tr><td>" + element.Hits + "</td><td>" + element.Time + "</td><td>" + element.Min + "</td><td>" + element.Average + "</td><td>" + element.Max + "</td><td>" + element.Namespace + "</td><td>" + element.Class + "</td><td>" + element.Method + "</td><td>" + element.Number + "</td></tr>";
                    sb.AppendLine(toLog);
                }
                sb.AppendLine("</table></div>");
                File.WriteAllText("C:\\Log\\" + sortType + ".html", sb.ToString(), Encoding.UTF8);
            }
        }

        /// <summary>
        /// Visit git page on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/startflorin/Code-Explorer/");
        }

        private void buttonViewAsGraph_Click(object sender, EventArgs e)
        {
            DiagramSourceWriter dsw = new DiagramSourceWriter();
            dsw.ToDiagram();
                       
            if (File.Exists(@"C:\Program Files (x86)\Graphviz2.39\bin\dot.exe"))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"C:\Program Files (x86)\Graphviz2.39\bin\dot.exe";
                startInfo.Arguments = @"-Tpng -o C:\Log\diagram.png C:\Log\diagram.gv";
                Process.Start(startInfo);
                Process.Start("C:\\Log\\diagram.png");
            }
        }
    }
}
