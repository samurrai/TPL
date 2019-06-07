using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace TPLPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(() => {
                WebRequest request = WebRequest.Create("https://omgvamp-hearthstone-v1.p.rapidapi.com/cards/Ysera");
                request.Headers.Add("X-RapidAPI-Host", "omgvamp-hearthstone-v1.p.rapidapi.com");
                request.Headers.Add("X-RapidAPI-Key", "7be6bad869msh4a1275c8b247fb1p1e2dfdjsna3d2728f7718");
                WebResponse response = request.GetResponse();
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    List<Card> card = JsonConvert.DeserializeObject<List<Card>>(json);
                    Console.WriteLine($"{card[0].Attack} - атака");
                    Console.WriteLine($"{card[0].Health} - здоровье");
                    Console.WriteLine($"{card[0].Cost} - цена");
                    Console.WriteLine($"{card[0].Name} - имя");
                    Console.WriteLine($"{card[0].Rarity} - редкость");
                    Console.WriteLine($"{card[0].Type} - тип");
                    Console.WriteLine($"{card[0].Race} - раса");
                }
            });
            task.Start();
            Console.ReadLine();
        }
    }
}
