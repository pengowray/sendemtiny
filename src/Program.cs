using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Threading;

namespace sendemtiny {
    class Program {
        static void Main(string[] args) {
            string appName = Process.GetCurrentProcess().ProcessName; // the name of the application (without the path nor ".exe")
            new Program().ParseAndRun(appName);
        }


        string sendText = "";

        public void ParseAndRun(string command) { 
            var regex = new Regex(@"[Uu][+-]?(?<hex>[0-9A-Fa-f]{2,})|say\W(?<say>.*)|type\W(?<type>.*)|(?<entity>&(?:[a-z\d]+|#\d+|#x[a-f\d]+);)|(?<time>(?<num>\d+(?:\.\d+)?)\W*(?<unit>s|ms))");
            var matches = regex.Matches(command);

            foreach (Match match in matches) {
                if (TryGetGroupValue(match, "hex", out var hex))
                    sendText += HexToUnicode(hex);

                if (TryGetGroupValue(match, "entity", out var entity))
                    sendText += WebUtility.HtmlDecode(entity);

                if (TryGetGroupValue(match, "say", out var say))
                    sendText += say;

                if (TryGetGroupValue(match, "time", out var time)) {
                    TryGetGroupValue(match, "num", out var num);
                    TryGetGroupValue(match, "unit", out var unit);

                    //send buffer before waiting
                    SendText();

                    //sendText += $"{num} {unit}"; // debug
                    double number = double.Parse(num);
                    if (unit == "s") {
                        TimeSpan timespan = TimeSpan.FromSeconds(number);
                        Thread.Sleep(timespan);
                    } else {
                        TimeSpan timespan = TimeSpan.FromMilliseconds(number);
                        Thread.Sleep(timespan);
                    }
                }

                if (TryGetGroupValue(match, "type", out var filepath)) {  
                    string exepath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);
                    var fullpath = Path.GetFullPath(Path.Combine(exepath, filepath));

                    if (!fullpath.Contains(exepath)) {
                        // don't allow to go read files higher than this exe's path
                        return;
                    }

                    if (!File.Exists(fullpath))
                        continue;

                    string readText = File.ReadAllText(fullpath);
                    sendText += readText;
                }
            }

            SendText();
        }

        public void SendText() {
            if (!string.IsNullOrEmpty(sendText)) {
                SendKeys.SendWait(sendText);
                SendKeys.Flush(); // might not be needed?
            }
            sendText = "";
        }

        static bool TryGetGroupValue(Match match, string group, out string value) {
            if (match.Groups[group].Success) {
                value = match.Groups[group].Value;
                return true;
            }

            value = null;
            return false;
        }

        static string HexToUnicode(string codePoint) {
            int code = int.Parse(codePoint, NumberStyles.HexNumber);
            string unicodeString = char.ConvertFromUtf32(code);
            return unicodeString;
        }
    }
}