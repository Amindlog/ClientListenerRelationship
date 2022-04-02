﻿namespace ClientListenerRelationship.Client
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                System.Console.WriteLine("/Ping, Ping, ping  - проверяет есть ли конект к серверу\n");
                System.Console.WriteLine("/PostInputData , PostInputData, postinputdata -  выбор конвертации.\n");
                System.Console.WriteLine("/GetAnswer, GetAnswer, getanswer - возращение обработаного запроса с сериализации.\n");
                System.Console.WriteLine("/Stop, Stop, stop - останавливает работу сервера\n");
                System.Console.Write("В ведите команду: ");
                switch (System.Console.ReadLine().ToLower())
                {
                    case "/ping":
                    case "ping":
                        try
                        {
                            using (HttpClient client = new HttpClient())
                            {
                                var response = client.GetAsync("http://localhost:23234/ping").Result;
                                response.EnsureSuccessStatusCode();
                                var responseBody = response.Content.ReadAsStringAsync().Result;
                                if (responseBody == "200")
                                {
                                    System.Console.ForegroundColor = System.ConsoleColor.Green;
                                    System.Console.WriteLine("Сервере активен \n");
                                    System.Console.ResetColor();
                                }
                                else
                                {
                                    System.Console.ForegroundColor = System.ConsoleColor.Blue;
                                    System.Console.WriteLine("Сервере не запущен, запустите сервер \n");
                                    System.Console.ResetColor();
                                }
                            }
                        }
                        catch (HttpRequestException e)
                        {
                            Console.WriteLine("\nException Caught!");
                            Console.WriteLine("Message :{0} ", e.Message);
                        }
                        catch (AggregateException)
                        {
                            System.Console.ForegroundColor = System.ConsoleColor.Blue;
                            System.Console.WriteLine("Сервере не запущен, запустите сервер \n");
                            System.Console.ResetColor();
                        }
                        break;
                    case "/postinputdata":
                    case "postinputdata":
                        try
                        {
                            HttpClient client = new HttpClient();
                            var response = client.GetAsync("http://localhost:23234/postinputdata").Result;
                            var responseBody = response.Content.ReadAsStringAsync().Result;
                            System.Console.WriteLine(responseBody);

                        }
                        catch (HttpRequestException e)
                        {
                            Console.WriteLine("\nException Caught!");
                            Console.WriteLine("Message :{0} ", e.Message);
                        }
                        catch (AggregateException)
                        {
                            System.Console.WriteLine("Сервере не запущен, запустите сервер");
                        }
                        break;
                    case "/getanswer":
                    case "getanswer":
                        try
                        {
                            using (HttpClient client = new HttpClient())
                            {
                                var response = client.GetAsync("http://localhost:23234/getanswer").Result;
                                response.EnsureSuccessStatusCode();
                                var responseBody = response.Content.ReadAsStringAsync().Result;
                                System.Console.WriteLine(responseBody);
                            }
                        }
                        catch (HttpRequestException e)
                        {
                            Console.WriteLine("\nException Caught!");
                            Console.WriteLine("Message :{0} ", e.Message);
                        }
                        break;
                    case "/stop":
                    case "stop":
                        try
                        {
                            using (HttpClient client = new HttpClient())
                            {
                                var response = client.GetAsync("http://localhost:23234/stop").Result;
                                response.EnsureSuccessStatusCode();
                                var responseBody = response.Content.ReadAsStringAsync().Result;
                            }
                        }
                        catch (HttpRequestException e)
                        {
                            Console.WriteLine("\nException Caught!");
                            Console.WriteLine("Message :{0} ", e.Message);
                        }
                        catch (AggregateException e)
                        {
                            System.Console.WriteLine("Message :{0} ", e.Message);
                        }
                        break;

                    default:
                        System.Console.ForegroundColor = System.ConsoleColor.Red;
                        System.Console.WriteLine("Такой команды на сервере не предусмотренно. \n");
                        System.Console.ResetColor();
                        break;
                }
            }
        }
    }

}