using System.Net;
using Server.Serialize;
using Newtonsoft.Json;
var httpListener = new HttpListener();

httpListener.Prefixes.Add("http://localhost:23234/");
httpListener.Start();

var IsStarted = true;
while (IsStarted)
{
    var context = httpListener.GetContext();
    var request = context.Request;
    var path = request.RawUrl;
    var response = context.Response;
    switch (path.ToLower())
    {
        case "/ping":
            Ping.StatusServer(context);
            break;

        case "/postinputdata":
            var body = request.InputStream;
            var encoding = request.ContentEncoding;
            var reader = new System.IO.StreamReader(body, encoding);
            string s = reader.ReadLine();
            Calcus.AddInput(s);
            OutStreamPrint.Print("Данные приняли, обрабатываем. ответ от сервера /GetAnswer ",context);
            reader.Close();
            break;

        case "/getanswer":
            OutStreamPrint.Print($"{Calcus.JsonResponse()}", context);
            break;

        case "/stop":
            httpListener.Stop();
            IsStarted = false;
            break;

        default:
            OutStreamPrint.Print($"{Home.str}", context);
            break;

    }
}
public class Input
    {
        // {"K":10,"Sums":[1.01,2.02],"Muls":[1,4]}
        public int K { get; set; }
        public decimal[] Sums { get; set; }
        public int[] Muls { get; set; }
    }

internal static class GetAnswer
{
    internal static string str = "GetAnswer";
}

internal static class PostInputData
{

    internal static string str = "\t PostInputData \n";
}

public static class OutStreamPrint
{
    public static void Print(string str, HttpListenerContext context)
    {
        var response = context.Response;
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);

        response.ContentLength64 = buffer.Length;
        var output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);

        output.Close();
    }
}
internal static class Ping
{
    internal static void StatusServer(HttpListenerContext context)
    {
        var code = context.Response.StatusCode;
        OutStreamPrint.Print(code.ToString(), context);
    }
}
public class Home
{
    public static string str = "Home";
}