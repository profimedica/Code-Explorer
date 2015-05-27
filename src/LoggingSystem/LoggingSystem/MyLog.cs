using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;

namespace LoggingSystem
{
    public class MyLogger
    {
        static Stopwatch sw = new Stopwatch();

        static MyLogger()
        {
            sw.Start();
        }

        public static void LogParam(object parameterInfo)
        {
            File.AppendAllText("C:\\Log\\Log.html", "\n\t<br> - " + parameterInfo.ToString() + " ");
        }
        public static Method Log(LoggingElement element)
		{
            sw.Stop();
            try
            {
                string toLog = "\n<br> <span style='color: silver'>" +
                    element.Namespace + "</span> <span style='color: orange'>" +
                    element.Class + "</span> <span style='color: blue'>" +
                    //element.MethodObject.Name + "</span> <span style='color: blue'><b>" +
                    element.Method + "</b></span>";
                if (element.MethodObject != null)
                {
                    toLog += " (";
                    foreach (MyParameterInfo pi in element.MethodObject.Parameters)
                    {
                        toLog += " <span style='color: silver'>" + pi.Type + "</span> <span style='color: blue'>" + pi.Name + "</span>";
                        if (pi.Value != null)
                        {
                            toLog += " <span style='color: silver'> = </span> <span style='color: red'>" + pi.Value.ToString() + "</span>";
                        }
                    }
                    toLog += ")";
                }
                toLog += "<span style='color: red'>" +
                    sw.Elapsed.Milliseconds + "</span> <span style='color: silver'>"+ element.Nr +"</span>";
                File.AppendAllText("C:\\Log\\Log.html", toLog);
                
            }
            catch (Exception xc)
            {
                
            };
            sw.Start();
            return element.MethodObject;
        }

        private static string myColor = "orange";

        public static void LogSQL(string Statement, string ProviderName, bool WantDataReader)
        {
            try
            {
                File.AppendAllText(
                    "C:\\Log\\Log.html",
                    "<br> <span style='color: green'><b>" +
                    Statement + "</b></span> <span style='color: gray'>" +
                    ProviderName + "</span>\n");
                File.AppendAllText(
                    "C:\\Log\\SQL.html",
                    "<br> <span style='color: " + myColor + "'><b>" +
                    Statement + "</b></span> <span style='color: gray'>" +
                    ProviderName + "</span>\n");
                myColor = myColor == "orange" ? "red" : "orange";
            }
            catch (Exception)
            {
            };
        }
    }
	
	public class LoggingElement
	{
        public int Nr { get; set; }
        public string Namespace { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public Method MethodObject { get; set; }

    }

    public class Method
    {
        public Method(System.Reflection.MethodBase method)
        {
            Name = method.Name;

            for (int i = 0; i < method.GetParameters().Length; i++)
            {
                ParameterInfo parameterInfo = (ParameterInfo)method.GetParameters().GetValue(i);
                MyParameterInfo pi = new MyParameterInfo()
                {
                    Type = parameterInfo.ParameterType.Name,
                    Name = parameterInfo.Name
                };
                Parameters.Add(pi);
            }
        }
        public Method(System.Reflection.MethodBase method, object[] values)
        {
            Name = method.Name;

            for (int i = 0; i < method.GetParameters().Length; i++)
            {
                ParameterInfo parameterInfo = (ParameterInfo)method.GetParameters().GetValue(i);
                MyParameterInfo pi = new MyParameterInfo()
                {
                    Type = parameterInfo.ParameterType.Name,
                    Name = parameterInfo.Name,
                    Value = values[i] != null? values[i].ToString() : "null"
                };
                Parameters.Add(pi);
            }
        }
        public string Name;
        public List<MyParameterInfo> Parameters = new List<MyParameterInfo>();
    }

    public class MyParameterInfo
    {
        public string Type;
        public string Name;
        public string Value;
    }
}
