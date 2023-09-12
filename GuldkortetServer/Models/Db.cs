using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuldkortetServer.Models
{
    public class Db
    {
        public bool userExists;
        private string user_connection_string = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Users\\sami4\\source\\repos\\GuldkortetServer\\GuldkortetServer\\Data\\Kundregister.mdf;Integrated Security=True";
        private string card_connection_string = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Users\\sami4\\source\\repos\\GuldkortetServer\\GuldkortetServer\\Data\\Kortregister.mdf;Integrated Security=True";
        public Db()
        {
            // Constructor code
        }

        public async Task<User> userInDb(string username) 
        {
            using (SqlConnection connection = new SqlConnection(user_connection_string)) 
            {
                // We create the SQL connection
                await connection.OpenAsync();
                string sqlQuery = "SELECT * FROM Kunder WHERE AnvändarNr = @användarID";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@användarID", username);
                // We read the table Kunder and find the row where AnvändarNr matches username(string from client)
                 SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows) 
                {
                    // We read the rows
                    reader.Read();
                    // Where username matches row we get all the items and store them as a new user.
                    string userID = reader.GetString(reader.GetOrdinal("AnvändarNr"));
                    string userName = reader.GetString(reader.GetOrdinal("Namn"));
                    string userKommun= reader.GetString(reader.GetOrdinal("Kommun"));
                    User newUser = new User(userID,userName,userKommun);
                    return newUser; // Return the user
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Card> cardInDb(string cardnr)
        {
            using (SqlConnection connection = new SqlConnection(card_connection_string))
            {
                // We create the SQL connection
                await connection.OpenAsync();
                string sqlQuery = "SELECT * FROM Kort WHERE KortNr = @kortID";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@kortID", cardnr);
                // We read the table Kort and find the row where KortNr matches cardNr(string from client)
                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    // We read the rows
                    reader.Read();
                    // Where kortnr matches row we get all the itmes and store them as a new card based on the type.
                    string cardID = reader.GetString(reader.GetOrdinal("KortNr"));
                    string cardType = reader.GetString(reader.GetOrdinal("KortTyp"));
                    Card newCard;
                    switch (cardType) 
                    {
                        case "Dunderkatt":
                            newCard = new Dunderkatt(cardID);
                            return newCard;
                        case "Kristallhäst":
                            newCard = new Kristallhäst(cardID);
                            return newCard;
                            
                        case "Överpanda":
                            newCard = new Överpanda(cardID);
                            return newCard;
                        case "Eldtomat":
                            newCard = new Eldtomat(cardID);
                            return newCard;
                        default:
                            newCard = new Card(cardID);
                            return newCard;

                    }
                }
                else
                {
                     Card newCard = new Card(cardnr);
                    return newCard;
                }
            }
        }
    }
}     
    
