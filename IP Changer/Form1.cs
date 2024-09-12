using SimpleWifi;
using System.Net.NetworkInformation;

namespace IP_Changer
{
    public partial class Form1 : Form
    {

        private static Wifi wifi;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAdaptadores(comboBox_Adaptador);
        }

        public static void GetAdaptadores(ComboBox comboBox_Adaptador)
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            comboBox_Adaptador.Items.Clear(); // Clear existing items

            foreach (NetworkInterface adapter in adapters)
            {
                if (adapter.OperationalStatus == OperationalStatus.Up)
                {
                    comboBox_Adaptador.Items.Add(adapter.Name);
                }
            }
        }

        private void comboBox_Adaptador_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAdapter = comboBox_Adaptador.SelectedItem.ToString();
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in adapters)
            {
                if (adapter.Name == selectedAdapter && adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    comboBox_Red.Enabled = true;
                    GetRedes(comboBox_Red); // Pass comboBox_Red to GetRedes
                    return;
                }
            }

            comboBox_Red.Enabled = false; // Disable comboBox_Red if no Wi-Fi adapter is selected
        }

        public static void GetRedes(ComboBox comboBox_Red)
        {
            wifi = new Wifi();
            var accessPoints = wifi.GetAccessPoints();

            comboBox_Red.Items.Clear(); // Clear existing items

            foreach (var accessPoint in accessPoints)
            {
                comboBox_Red.Items.Add(accessPoint.Name);
            }
        }

        public static void ConnectToNetwork(string ssid, string password)
        {
            var accessPoint = wifi.GetAccessPoints().FirstOrDefault(ap => ap.Name == ssid);
            if (accessPoint != null)
            {
                var authRequest = new AuthRequest(accessPoint);
                authRequest.Password = password;
                accessPoint.Connect(authRequest);
            }
        }

        private void comboBox_Red_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable the text boxes
            textBox_IP.Enabled = true;
            textBox_Mask.Enabled = true;
            textBox_Gateway.Enabled = true;
        }

        private void button_Saved_Click(object sender, EventArgs e)
        {

        }
    }
}
