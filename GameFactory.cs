using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace GameLib
{
    public class GameFactory
    {
        StreamWriter sw;
        StreamReader sr;
        XmlSerializer serial;
        List<Game> gameList;

        public string FilePath { get; set; }

        public GameFactory (string filepath)
        {
            this.FilePath = filepath;
        }
        public void CreateGameList()
        {
            gameList = new List<Game>();
            Game g = new Game("Hornets","Bulldogs",50,75);
            gameList.Add(g);
            g = new Game("Wasps", "Panthers", 52, 65);
            gameList.Add(g);
            g = new Game("Bulls", "Bears", 55, 75);
            gameList.Add(g);
            g = new Game("Cobras", "Trojans", 30, 50);
            gameList.Add(g);
            g = new Game("Tigers", "WildCats", 40, 30);
            gameList.Add(g);
            g = new Game("Lions", "Pumas", 20, 5);
            gameList.Add(g);
        }

        public Boolean SerializeGameList()
        {
            try
            {
                serial = new XmlSerializer(gameList.GetType());
                sw = new StreamWriter(FilePath);
                serial.Serialize(sw, gameList);
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
            
        } // end Serialize

        public List<Game> DeserializeGameList(out string resultMessage)
        {
            try
            {
                gameList = new List<Game>();
                sr = new StreamReader(FilePath);
                serial = new XmlSerializer(gameList.GetType());
                gameList = (List<Game>)serial.Deserialize(sr);
                sr.Close();
                resultMessage = "Congratulations";
                return gameList;
            }
            catch (Exception ex)
            {
                resultMessage = "Exception Thrown " + ex.Message;
                return null;
            }

        }

    } // Class GameFactory
}
