using System.Windows.Forms;

namespace sendemtiny {
    class Program {
        static void Main(string[] args) {

            string appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName; // the name of the application (without the path nor ".exe")
            string codePoint = appName.Substring(appName.LastIndexOf('U') + 1); // Take everything after a capital U
            int code = int.Parse(codePoint, System.Globalization.NumberStyles.HexNumber); // Convert the hex to an int
            string unicodeString = char.ConvertFromUtf32(code); // Create a Unicode character string

            SendKeys.SendWait(unicodeString); // Send it
        }
    }
}