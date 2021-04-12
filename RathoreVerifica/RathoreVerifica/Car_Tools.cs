using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RathoreVerifica
{
    public class Car_Tools
    {
        public const string WORKINGPATH = @"C:\Users\Rathore\Desktop\RathoreVerifica\";  /// Creare una cartella su C:\data--> FormulaOne--> countries.sql
        public const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+WORKINGPATH+@"CarShop.mdf;Integrated Security = True; Connect Timeout = 30";
    
        
        public List<string> getCars()
        {
            List<string> retVal = new List<string>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\n Query data example: ");
                Console.WriteLine("========================================");
                string sqlcommand = "SELECT * FROM Automobili ORDER BY Prezzo DESC";
                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int  Id = reader.GetInt32(0);
                            string marca = reader.GetString(1);
                            string modello = reader.GetString(2);
                            char alimentazione = reader.GetChar(3);
                            int cavalli = reader.GetInt32(4);
                            int isAutomatica = reader.GetInt32(5);
                            string NumTelaio = reader.GetString(6);
                            float prezzo = reader.GetFloat(7);
                            retVal.Add(Id + " - " + marca+" - "+modello+" - "+alimentazione+" - "+cavalli+" - "+isAutomatica+" - "+NumTelaio+" - "+prezzo);
                        }
                    }
                }
            }

            return retVal;
        }

        public List<string> GetFilteredCar()
        {
            List<string> retVal = new List<string>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\n Query data example: ");
                Console.WriteLine("========================================");
                string sqlcommand = "SELECT * FROM Automobili AS a  WHERE a.Marca = 'BMW' AND a.Alimentazione = 'B' AND a.IsAutomatica= true   ORDER BY Prezzo DESC";
                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string marca = reader.GetString(1);
                            string modello = reader.GetString(2);
                            char alimentazione = reader.GetChar(3);
                            int cavalli = reader.GetInt32(4);
                            int isAutomatica = reader.GetInt32(5);
                            string NumTelaio = reader.GetString(6);
                            float prezzo = reader.GetFloat(7);
                            retVal.Add(Id + " - " + marca + " - " + modello + " - " + alimentazione + " - " + cavalli + " - " + isAutomatica + " - " + NumTelaio + " - " + prezzo);
                        }
                    }
                }
            }

            return retVal;
        }
    }
}
