using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GuldkortetServer.Models
{
    public class tcpServer
    {
        // We create our datatypes
        private int portAdress { get; set;}
        private TcpListener Host { get; set; }
        
        public TcpListener host { get { return Host; } set { Host = value; } }
        public Db _db = new Db();

        public tcpServer()
        { // Constructor

            portAdress = 12345;
            try
            {
                Host = new TcpListener(IPAddress.Any, portAdress);
            } catch (Exception er) { MessageBox.Show("Kunde inte starta server, vänligen kontakta admin.Felkod:" + er.Message, "Error!"); }
            
            
        }
        TcpClient client = new TcpClient();
        public async Task ListenAsync() 
        {
            // check if we are already connected or not
            if (!client.Connected)
            {
                client = await Host.AcceptTcpClientAsync();
                await HandleClient(client);
            } else { await HandleClient(client); }
        }

        public async Task HandleClient(TcpClient client)
        {
          
                try
                {
                    using (NetworkStream ns = client.GetStream())
                    {
                        using (StreamReader reader = new StreamReader(ns))
                        {
                            using (StreamWriter writer = new StreamWriter(ns))
                            {
                                byte[] clientMsg = new byte[1024];
                                await ns.ReadAsync(clientMsg, 0, clientMsg.Length);
                                string line = Encoding.Unicode.GetString(clientMsg);

                                // Separate the string with the - 
                                string[] elements = line.Split('-');

                                // Check our user table
                                string userID = elements[0].Trim();
                                User user = await _db.userInDb(userID); // We compare with the DB table

                            if (user == null) // If user does not exist we send error to client.

                            {
                                byte[] userByte = new byte[1024];
                                userByte = Encoding.Unicode.GetBytes("Användare eller Kort stämde inte.");
                                await ns.WriteAsync(userByte, 0, userByte.Length);                             
                                await ListenAsync();
                            }
                            else // if user exist we continue
                            {

                                // Add to our generic user list
                                users.Add(user);
                                // Check our cardNr table
                                string cardNumber = elements[1].Trim();
                                Card card = await _db.cardInDb(cardNumber); // We compare card with winning cards in DB

                                if (card != null)
                                {
                                    byte[] responseByte = new byte[1024];
                                    responseByte = Encoding.Unicode.GetBytes(card.ToString());
                                    await ns.WriteAsync(responseByte, 0, responseByte.Length);
                                    await ListenAsync();
                                }
                                else
                                {
                                    byte[] responseByte = new byte[1024];
                                    responseByte = Encoding.Unicode.GetBytes(card.ToString());
                                    await ns.WriteAsync(responseByte, 0, responseByte.Length);
                                    await ListenAsync();
                                }
                            }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tappade anslutning till klient.");
                    await ListenAsync();
                }
            await ListenAsync();
        } 

        public string StartServer() 
        {
            // Start server and return state
            try
            {
                Host.Start();
                return "Server igång!";
            } catch (Exception ex) { 
                
                MessageBox.Show("Kunde inte starta server, Felkod: " + ex.Message, "error");
                return "Server kunde inte starta...";
                
            }
        }

        private List<User> users = new List<User>();
        public List<User> Users { get { return users; } }
    }

}

       



