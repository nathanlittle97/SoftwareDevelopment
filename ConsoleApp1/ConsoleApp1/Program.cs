using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SessionController Controller = new SessionController();
            Controller.Initialise();

            Console.ReadKey();
        }
    }

    class SessionController //singleton method
    {
        public SessionController()
        {

        }

        public void Initialise()
        {
            string UserTitle = "";
            Menu(UserTitle);
            DBInterface Interface = new DBInterface();
            JObject FilmData = Interface.GetDataRecords(UserTitle);
            DisplayFilmInfo(FilmData);

        }

        public void Menu(string UserTitle)
        {
            Console.WriteLine("Enter movie title");
            UserTitle = Console.ReadLine();

        }

        public void DisplayFilmInfo(JObject FilmData)
        {
            foreach (JProperty property in FilmData.Properties())
            {
                Console.WriteLine(property.Name + " - " + property.Value);
            }
            FilmData.Properties();
        }
    }

    class DBInterface
    {
        public DBInterface()
        {

        }

        public JObject GetDataRecords(string Title)
        {
            return JObject.Parse(GET("http://www.omdbapi.com/?t=" + Title + "&apikey=c5f5153e"));
        }

        string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }
    }

    class Wishlist
    {
        Wishlist()
        {
        }

        void Save()
        {

        }

        void Load()
        {

        }
        void Add()
        {


        }

    }


}


