using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Klausur_Nr._2
{
    public class Dozent
    {
        #region Eigenschaften
        private int _ID;
        private string _Name;
        private string _Fach;

        #endregion

        #region Accessoren/Modifier
        public int ID { get => _ID; set => _ID = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Fach { get => _Fach; set => _Fach = value; }


        #endregion
        //
        #region Konstruktoren
        public Dozent()
        {
            ID = 0;
            Name = "";
            Fach = "";
        }
        public Dozent(int id, string name, string fach)
        {
            ID = id;
            Name = name;
            Fach = fach;

        }
        public Dozent(Dozent value)
        {
            ID = value.ID;
            Name = value.Name;
            Fach = value.Fach;
        }


        #endregion

        #region Worker
        public void PosttoAPI()
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44382/api/Message";

            string json = JsonConvert.SerializeObject(this);

            Task<HttpResponseMessage> response = client.PostAsJsonAsync(url, json);

            try
            {
                response.Wait();
            }
            catch (Exception)
            {

            }


        }

        public void LoeschenAPI(string text)
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44382/api/Message";

            //senden
            Task<HttpResponseMessage> response = client.DeleteAsync(url + "/" + text);
            try
            {
                response.Wait();
            }
            catch (Exception)
            {
            }
        }



        public void barabeitentoAPI(int editID, string text1, string text2)
        {
            HttpClient client = new HttpClient();

            string url = "http://localhost:44382/api/Message";
            string json = JsonConvert.SerializeObject(this);

            //senden
            Task<HttpResponseMessage> response = client.PutAsJsonAsync(url + "/" + editID.ToString(), json);
            try
            {
                response.Wait();
            }
            catch (Exception)
            {

            }
        }

        #endregion
    }
}