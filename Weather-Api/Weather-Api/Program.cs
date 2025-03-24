using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Api
{
    class Program
    {

        static void Main(string[] args)
        {
            //User to enter city name for which to retrieve the current weather.
            Console.Write("Enter city name to retrieve weather info : ");
            string location = Console.ReadLine(); //Read the entered city.

            //API uri address.
            string apiUri = $"https://api.openweathermap.org/data/2.5/weather?q={location}&units=metric&appid=79de72e93db093f63c3f96a58720da3c";

            //Request from uri.
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(apiUri);
            webRequest.Method = "GET"; //Specify web request method.

            try
            {
                //Retrieve response from server.
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

                //If the request has been successful (200).
                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Read the response stream.
                    using (Stream stream = webResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                        //Read the stream to end which holds the json string.
                        string json = reader.ReadToEnd();

                        //Use dynamic object to deserialize the json into. Could also create a class with properties holding the json attributes.
                        dynamic result = JsonConvert.DeserializeObject<dynamic>(json);

                        Console.WriteLine();

                        //Display current weather fot the entered city
                        Console.WriteLine($"Current weather for {location} :");
                        Console.WriteLine($"Weather : {result.weather[0].main}");
                        Console.WriteLine($"Description : {result.weather[0].description}");
                        Console.WriteLine($"Temprature : {result.main.temp}");
                        Console.WriteLine($"Feels like : {result.main.feels_like}");
                        Console.WriteLine($"Minimum temprature : {result.main.temp_min}");
                        Console.WriteLine($"Maximum temprature : {result.main.temp_max}");
                        Console.WriteLine($"Humidity : {result.main.humidity}%");
                        Console.WriteLine($"Visibility : {result.visibility / 1000}Km");
                        Console.WriteLine($"Wind speed : {result.wind.speed ?? 0}m/s");
                        Console.WriteLine($"Wind degrees : {result.wind.deg} degrees");
                        Console.WriteLine($"Wind gust : {result.wind.gust ?? 0}m/s");
                        Console.WriteLine($"Cloudiness : {result.clouds.all ?? 0}%");

                        //User to press any key to exit application after displaying weather.
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine(String.Format("Request unsuccessful with description : {0}", webResponse.StatusDescription));
                }
            }
            catch (Exception ex) //Catch any exeptions
            {
                Console.WriteLine("");
                Console.WriteLine(String.Format("An error has occured: {0}", ex.Message));
            }
        }
    }
}
