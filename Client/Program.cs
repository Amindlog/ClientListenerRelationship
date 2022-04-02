namespace ClientListenerRelationship.Client
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                System.Console.WriteLine("В ведите ");
                string a = System.Console.ReadLine();
                switch (a.ToString())
                {
                    case "/ping":
                        var httpClient = new HttpClient();
                        try
                        {
                            var response = httpClient.GetAsync("http://localhost:23234/ping").Result;
                            response.EnsureSuccessStatusCode();
                            var responseBody = response.Content.ReadAsStringAsync().Result;
                            if (responseBody == "200")
                            {
                                System.Console.WriteLine("Server is On");
                            }
                            else
                            {
                                System.Console.WriteLine("Server is Down");
                            }
                        }
                        catch (HttpRequestException e)
                        {
                            Console.WriteLine("\nException Caught!");
                            Console.WriteLine("Message :{0} ", e.Message);
                        }
                        break;
                    default:
                        
                    break;
                }
            }
        }
    }

}