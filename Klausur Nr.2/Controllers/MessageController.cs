using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace Klausur_Nr._2.Controllers
{
    public class MessageController : ApiController
    {
        #region Eigenschaften
        private Controller _verwalter;


        #endregion
        //
        #region Accessoren/Modifier
        public Controller Verwalter { get => _verwalter; set => _verwalter = value; }

        #endregion

        #region Konstruktoren
        public MessageController() : base()
        {
            Verwalter = Global.Verwalter;
        }
        #endregion

        #region Worker
        // GET: api/Message
        public List<Dozent> Get()
        {
            List<Dozent> Liste = new List<Dozent>();

            string connectionstring = "Server=localhost;Port=3307;Database=klausurNr2; Uid =user;Password=user";

            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = "select * from Dozent;";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlstring, conn);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string id = reader.GetValue(0).ToString();
                        string x1 = reader.GetValue(1).ToString();
                        string x2 = reader.GetValue(2).ToString();
                        Dozent value1 = new Dozent(Convert.ToInt32(id), x1, x2);
                        Liste.Add(value1);
                    }
                }
                
                else
                { }
            }
            catch (Exception)
            {
                return new List<Dozent>();
            }
            conn.Close();

            return Liste;
        }

        // GET: api/Message/5
        public Dozent Get(int id)
        {
            Dozent ergebnis = null;
            string connectionstring = "Server=localhost;Port=3307;Database=klausurNr2; Uid =user;Password=user";

            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = "select * from Dozent where id=" +id;
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlstring, conn);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string id1 = reader.GetValue(0).ToString();
                        string x1 = reader.GetValue(1).ToString();
                        string x2 = reader.GetValue(2).ToString();
                        Dozent value1 = new Dozent(Convert.ToInt32(id1), x1, x2);
                    }
                }
                else
                { }
            }
            catch (Exception)
            {
                return null;
            }
            conn.Close();

            return ergebnis;
        }

        // POST: api/Message
        public void Post([FromBody] string value)
        {

            Dozent value1 = (Dozent)JsonConvert.DeserializeObject(value, typeof(Dozent));

            string connectionstring = "Server=localhost;Port=3307;Database=klausurNr2; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = "INSERT INTO `Dozent`(`name`, `fach`) VALUES ('" + value1.Name+ "','" + value1.Fach + "')";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlstring, conn);

                int anz = command.ExecuteNonQuery();
                if (anz <= 0)
                {
                }
                else
                {
                }
            }
            catch (Exception)
            {

            }

        }

        // PUT: api/Message/5
        public void Put(int id, [FromBody] string value)
        {
            string ergebnis = "false;";
            Dozent value1 = (Dozent)JsonConvert.DeserializeObject(value, typeof(Dozent));
            string connectionstring = "Server=localhost;Port=3307;Database=klausurNr2; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = " UPDATE `Dozent` SET `Name`='" + value1.Name + "',`Fach`='" + value1.Fach + "' WHERE id=" + id;
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlstring, conn);

                int anz = command.ExecuteNonQuery();
                if (anz <= 0)
                {
                    ergebnis = "false";
                }
                else
                {
                    ergebnis = "ok";
                }
            }
            catch (Exception)
            {
            }
        }

        // DELETE: api/Message/5
        public void Delete(int id)
        {
            string connectionstring = "Server=localhost;Port=3307;Database=klausurNr2; Uid =user;Password=user";
            MySqlConnection conn = new MySqlConnection(connectionstring);
            try
            {
                string sqlstring = "DELETE FROM `Dozent` WHERE `ID` = '" + id.ToString() + "';";
                conn.Open();
                MySqlCommand command = new MySqlCommand(sqlstring, conn);

                int anz = command.ExecuteNonQuery();
                if (anz <= 0)
                {
                }
                else
                {
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion
    }
}
