using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Weather.Cli
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //HTTP Object to get data from the API.
            HttpClient client = new HttpClient();

            //Creating local variables.
            string[] rows;
            string[] columns;


            //Getting Location of the fiel.
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(location);
            var fileName = "\\in.csv";
            var path = directory + fileName;

            //Setting Index..
            int index = 1;

            //Reading whole content from the file.
            rows = File.ReadAllLines(path);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("++++++++++++++++++++++++++++++ Welcome to CLI Weather App ++++++++++++++++++++++++++++++++");

            Console.WriteLine("Lets Begin.....");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter City : ");

            //Input from user side - City
            string inputCity = Console.ReadLine();

            //Setting Base Address.
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.open-meteo.com/v1/")
            };
             
            //Looping over the data from the filem till we get the match which user entered as City.
            while (index < rows.Length) {
                columns = rows[index].Split(',');
                var one = columns[0];

                //Condition once we get the match.
                if (one.Equals(inputCity))
                {
                    //Getting latitude & longitude fo given City provided.
                    float lat = float.Parse(columns[1]);
                    float lon = float.Parse(columns[2]);

                    //Fetching the data aacording to the latitude and longitude info we get from City Input fro the user.
                    var responseTask = await httpClient.GetAsync($"forecast?latitude={lat}&longitude={lon}&current_weather=true");

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Fetching " + inputCity + " city data please wait.....");

                    //Checking whether responseTask is returning success.
                    if (responseTask.IsSuccessStatusCode) {

                        var rawData = await responseTask.Content.ReadAsStringAsync();

                        //Verifying rawData having some data.
                        if (rawData != null) {
                            //var rawData = httpResult.Content.ReadAsStringAsync();
                            //rawData.Wait();

                            //Splitting the data into normalized form...
                            var resultData = rawData.Split(',');

                            //Showing data to the user...
                            Console.WriteLine();
                            Console.WriteLine("******** Weather Info for " + inputCity + " ********");
                            Console.WriteLine();
                            Console.WriteLine(resultData[0]);
                            Console.WriteLine(resultData[1]);
                            Console.WriteLine(resultData[2]);

                            Console.WriteLine(resultData[3]);
                            Console.WriteLine(resultData[4]);
                            Console.WriteLine(resultData[5]);
                            Console.WriteLine(resultData[6]);

                            Console.WriteLine("Current Weather Infomation : ");
                            Console.WriteLine(resultData[7]);
                            Console.WriteLine(resultData[8]);
                            Console.WriteLine(resultData[9]);
                            Console.WriteLine(resultData[10]);
                            Console.WriteLine(resultData[11]);
                        }
                    }

                    //Breaking once we get the desired data.
                    break;
                }
                //Incrementing.....
                index++;
            }

            if(index == rows.Length) {
                Console.WriteLine("Input City does not exist");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Press any key to exit from the application....");
            Console.ReadKey();
        }
    }
}
