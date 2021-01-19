using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Klausur_Nr._2
{
    public class Controller
    {
        #region Eigenschaften
        private List<Dozent> _list;
        private static int _EditID;

        #endregion

        #region Accessoren/Modifier
        public static int EditID { get => _EditID; set => _EditID = value; }
        public List<Dozent> List { get => _list; set => _list = value; }

        #endregion

        #region Konstruktoren
        public Controller()
        {
            List = new List<Dozent>();
            EditID = 0;
        }
        #endregion

        #region Worker
        public void LoadAlleDatenFromAPI()
        {
            List.Clear();
            HttpClient client = new HttpClient();

            string url = "http://localhost:44382/api/Message";


            Task<HttpResponseMessage> response = client.GetAsync(url);

            try
            {
                response.Wait();
            }
            catch (Exception)
            {
                return;
            }

            HttpResponseMessage result = response.Result;

            Task<string> content = result.Content.ReadAsStringAsync();

           
            content.Wait();
           
            
            

            string empfang = content.Result;

            List = (List<Dozent>)JsonConvert.DeserializeObject<List<Dozent>>(empfang).ToList();

        }

        public void addPerson(string value1, string value2)
        {
            Dozent D1 = new Dozent(-1, value1, value2);
            List.Add(D1);
            D1.PosttoAPI(); 
        }

        public void loeschen(string text)
        {
            //
            Dozent wert = new Dozent();
            wert.LoeschenAPI(text);

        }

        public void bearbeiten(int editID, string text1, string text2)
        {
            Dozent wert = new Dozent();
            for (int x=0;x<List.Count;x++)
            {
                if (List[x].ID == editID)
                {
                    wert.Name = text1;
                    wert.Fach = text2;
                }
            }
            wert.barabeitentoAPI(editID, text1, text2);
        }
    }
    #endregion
}