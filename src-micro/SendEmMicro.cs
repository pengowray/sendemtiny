using System.Windows.Forms;

namespace sendemmicro {
    class SendEmMicro {
        static void Main(string[] args) {

            string appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName; // the name of the application (without the path nor ".exe")

            // Take everything after: "U+" or "U" or "U-"
            int index = appName.LastIndexOf('U');
            if (index == -1)
                return;

            index += (appName[index + 1] == '+' || appName[index + 1] == '-') ? 2 : 1;

            string codePoint = appName.Substring(index);
            
            //MessageBox.Show(codePoint, "Debug output", MessageBoxButtons.OK, MessageBoxIcon.Information); // use for debugging

            int code = int.Parse(codePoint, System.Globalization.NumberStyles.HexNumber); // Convert hex
            string unicodeString = char.ConvertFromUtf32(code); // Create a Unicode character string

            SendKeys.SendWait(unicodeString); // Send it
        }
    }
}