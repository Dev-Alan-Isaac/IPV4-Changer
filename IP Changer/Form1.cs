using SimpleWifi;
using System.Diagnostics;
using System.Net;
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

        private void comboBox_Red_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable the text boxes
            textBox_IP.Enabled = true;
            textBox_Mask.Enabled = true;
            textBox_Gateway.Enabled = true;
        }

        private void button_Saved_Click(object sender, EventArgs e)
        {
            // Retrieve and display the text from the text boxes
            string ipAddress = textBox_IP.Text;
            string subnetMask = textBox_Mask.Text;
            string gateway = textBox_Gateway.Text;

            string selectedNetwork = comboBox_Red.SelectedItem.ToString();
            string savedPassword = "your_saved_password"; // Replace with your method to retrieve the saved password

            // Validate IP address
            if (!IPAddress.TryParse(ipAddress, out _))
            {
                MessageBox.Show("Invalid IP address.");
                return;
            }

            // Validate subnet mask
            if (!IsValidSubnetMask(subnetMask))
            {
                MessageBox.Show("Invalid subnet mask.");
                return;
            }

            // Validate gateway
            if (!IPAddress.TryParse(gateway, out _))
            {
                MessageBox.Show("Invalid gateway.");
                return;
            }

            // Connect to the network
            ConnectToNetwork(selectedNetwork, savedPassword);

            // Set the static IP configuration
            string adapterName = comboBox_Adaptador.SelectedItem.ToString();
            SetIPV4(adapterName, ipAddress, subnetMask, gateway);

            MessageBox.Show("Network adapter settings updated.");
        }


        private bool IsValidSubnetMask(string subnetMask)
        {
            if (!IPAddress.TryParse(subnetMask, out IPAddress mask))
            {
                return false;
            }

            byte[] bytes = mask.GetAddressBytes();
            bool foundZero = false;

            foreach (byte b in bytes)
            {
                for (int i = 7; i >= 0; i--)
                {
                    bool bit = (b & (1 << i)) != 0;
                    if (foundZero && bit)
                    {
                        return false;
                    }
                    if (!bit)
                    {
                        foundZero = true;
                    }
                }
            }

            return true;
        }

        private void button_Revert_Click(object sender, EventArgs e)
        {
            string adapterName = comboBox_Adaptador.SelectedItem.ToString();

            // Set the IP address to be obtained automatically (DHCP)
            ExecuteNetshCommand($"interface ipv4 set address name=\"{adapterName}\" source=dhcp");

            MessageBox.Show("Network adapter settings reverted to DHCP.");
        }

        public static void ConnectToNetwork(string ssid, string password)
        {
            var accessPoint = wifi.GetAccessPoints().FirstOrDefault(ap => ap.Name == ssid);
            if (accessPoint != null)
            {
                // Check if already connected
                if (accessPoint.IsConnected)
                {
                    MessageBox.Show("Already connected to " + ssid);
                    return;
                }

                // Attempt to connect with the provided password
                var authRequest = new AuthRequest(accessPoint)
                {
                    Password = password
                };

                bool success = accessPoint.Connect(authRequest);
                if (success)
                {
                    MessageBox.Show("Successfully connected to " + ssid);
                }
                else
                {
                    MessageBox.Show("Failed to connect to " + ssid + ". Please check the password and try again.");
                }
            }
            else
            {
                MessageBox.Show("Network " + ssid + " not found.");
            }
        }

        public void SetIPV4(string adapterName, string IP, string MASK, string GATEWAY)
        {
            // Set the static IP address
            ExecuteNetshCommand($"interface ipv4 set address name=\"{adapterName}\" static {IP} {MASK} {GATEWAY}");

            // Optionally, set the DNS server (if needed)
            // ExecuteNetshCommand($"interface ip set dns \"{adapterName}\" static 8.8.8.8");

            Console.WriteLine("IP configuration updated.");
        }

        private void ExecuteNetshCommand(string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo("netsh", arguments)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(psi))
            {
                process.WaitForExit();
            }
        }
    }
}
