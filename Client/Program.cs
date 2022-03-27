using System.Runtime.Serialization;
var isExecute = true;


while (isExecute)
{
    System.Console.WriteLine("Выберите действия: ");
    System.Console.WriteLine("Метод Ping");
    System.Console.WriteLine("Метод GetInputData");
    System.Console.WriteLine("Метод WriteAnswer");
    System.Console.WriteLine("Метод Exit");
    System.Console.WriteLine();
    System.Console.Write("Введите метод:");

    try
    {
        var inInputUsers = Console.ReadLine();

        switch (inInputUsers.ToLower())
        {
            case "ping":
                RunMethod.Ping();
                System.Console.WriteLine("Ping");
                break;
            case "getinputdata":
                // RunMethod.GetInputData();
                System.Console.WriteLine("GetInputData");
                System.Console.WriteLine();
                break;
            case "writeanswer":
                // RunMethod.WriteAnswer();
                System.Console.WriteLine("WriteAnswer");
                System.Console.WriteLine();
                break;
            case "exit":
                System.Console.WriteLine("Exit");
                System.Console.WriteLine();
                break;
            default:
                System.Console.Write("Что то пошло не так, введи правельный метод, \n");
                break;
        }
    }
    catch (ArgumentNullException ex)
    {
        System.Console.WriteLine(ex.Message);
    }
}

public class RunMethod
{
    public static void Ping()
    {
        using (HttpClient client = new HttpClient())
        {
            var response = client.GetAsync("https://github.com/").Result;
            response.StatusCode.GetHashCode();
            var body = response.Content.ReadAsStringAsync().Result;
            System.Console.WriteLine(body);
        }
    }

    public static void GetInputData()
    {
        throw new NotImplementedException();
    }

    internal static void WriteAnswer()
    {
        throw new NotImplementedException();
    }
}