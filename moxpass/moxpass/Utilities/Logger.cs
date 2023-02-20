using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace moxpass.Utilities
{
    public static class Logger
    {
        private static readonly Stopwatch _stopwatch = new();
        private static string? logfileDir;

        public static void Initialize()
        {
            _stopwatch.Start();
            string timestamp = DateTime.Now.ToString("yyyyMMdd_hhmmss");
            string logname = "moxpass_dev_" + timestamp + ".log";
            logfileDir = Path.Join("C:", "users", Environment.UserName, "moxpass", logname);
            var listener = new TextWriterTraceListener(new FileStream(logfileDir, FileMode.Create));
            Trace.Listeners.Add(listener);
        }

        public static void Log(string message,
            [CallerMemberName] string memberName = ""
            )
        {
            string timestamp = _stopwatch.ElapsedMilliseconds.ToString();
            Trace.Write("[");
            Trace.Write(timestamp);
            Trace.Write("ms] ");
            Trace.Write("<");
            Trace.Write(memberName);
            Trace.Write("> ");
            Trace.WriteLine(message);

        }

        public static void StopLogging()
        {
            Trace.Flush();
            string timestamp = _stopwatch.ElapsedMilliseconds.ToString();
            Console.Write("[");
            Console.Write(timestamp);
            Console.Write("ms] ");
            Console.Write("<");
            Console.Write("moxpass.exe");
            Console.Write("> ");
            Console.WriteLine($"Exited, see log file here:");
            if (logfileDir is not null)
            {
                string formatedDir = logfileDir.Replace("\\", "/");
                Console.WriteLine($"file://{formatedDir}");
            }
        }
    }
}