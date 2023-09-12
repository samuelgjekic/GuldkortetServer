using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GuldkortetKlient
{
    public partial class mainForm : Form
    {

        public string sendData;
        public TcpClient client;
        private bool isConnected;
        private string serverIPAddress = "127.0.0.1";
        private int serverPortNumber = 12345;
        public mainForm()
        {
            InitializeComponent();
        }
        FileLines readFiles;
        private void mainForm_Load(object sender, EventArgs e)
        {
            readFiles = new FileLines(); // We create a new FileLines object
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            //client = new TcpClient(); // We start the tcp client
            //await client.ConnectAsync(IPAddress.Parse("127.0.0.1"), 12345);
            ConnectToServer();
            if (client.Connected)
            {
                btnStart.Enabled = false;
                btnStart.BackColor = Color.Green;
                btnStart.Text = "Ansluten";
            }
            else
            {
                btnStart.BackColor = Color.Red;
                btnStart.Text = "Kunde inte Ansluta.";
            }

        }
        private async void btnSendBothCorrect_Click(object sender, EventArgs e)
        {


            string Användare = readFiles.GetRandomLine("D:\\Users\\sami4\\source\\repos\\GuldkortetServer\\GuldkortetKlient\\kundlista.txt");
            string KortId = readFiles.GetRandomLine("D:\\Users\\sami4\\source\\repos\\GuldkortetServer\\GuldkortetKlient\\kortlista.txt");
            // We get 2 random lines from our files which are correct
            sendData = Användare + "-" + KortId;
            await SendToServer(sendData);




        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Title text only
        }

        private void btnSendRightCard_Click(object sender, EventArgs e)
        {
            string Användare = "A9999999";
            string KortId = readFiles.GetRandomLine("D:\\Users\\sami4\\source\\repos\\GuldkortetServer\\GuldkortetKlient\\kortlista.txt");
            // We generate a random correct card but not a correct user
            sendData = Användare + "-" + KortId;



        }

        private void btnSendrightuser_Click(object sender, EventArgs e)
        {

            string Användare = readFiles.GetRandomLine("D:\\Users\\sami4\\source\\repos\\GuldkortetServer\\GuldkortetKlient\\kundlista.txt");
            string KortId = "K999999999";
            // We get a correct user id but send the wrong card nr
            sendData = Användare + "-" + KortId;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            string Användare = "A9999999";
            string KortId = "K999999999";
            // We send both wrong user and card
            sendData = Användare + "-" + KortId;

        }


        public async Task SendToServer(string _input)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] data = Encoding.Unicode.GetBytes(_input);
                    await stream.WriteAsync(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errror while sending data: {ex.Message}");
            }
        }

        private void btnStopConnection_Click(object sender, EventArgs e)
        {
            // Stäng anslutning
            isConnected = false;
            client.Close();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kontrollera att anslutningen är stängd när klienten stängs
            if (client != null)
            {
                isConnected = false;
                client.Close();
            }
        }
    

    private async void ConnectToServer()
        {
            client = new TcpClient();
            try
            {
                await client.ConnectAsync(serverIPAddress, serverPortNumber);
                isConnected = true;

                while (isConnected)
                {
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;

                    // Read data from server
                    while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        // Convert message to bytes
                        string message = Encoding.Unicode.GetString(buffer, 0, bytesRead);
                        Invoke(new Action(() => txtRecieve.Text = message));
                    }

                    await Task.Delay(10); // ge andra trådar möjlighet att köra
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
                // Ange texten när anslutningen misslyckades
                Console.WriteLine($"Errror: {ex.Message}");
            }
        }
    }
}