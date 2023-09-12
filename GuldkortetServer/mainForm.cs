using GuldkortetServer.Models;
using System.Diagnostics.Eventing.Reader;

namespace GuldkortetServer
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        tcpServer server;
        Db _db = new Db();

        private async void mainForm_Load(object sender, EventArgs e)
        {
            // start the server on program startup.
            server = new tcpServer();
            txtStatus.Text = server.StartServer();
            await server.ListenAsync();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            listUsers.Items.Clear();
            foreach(User item in server.Users) { listUsers.Items.Add(item.UserName + " / " + item.UserKommun + " / " + item.UserId); }
        }
    }
}
