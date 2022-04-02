using System.Runtime.InteropServices;
using System.Net;
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
            OutStreamPrint.Print($"{PostInputData.str}", context);
            break;

        case "/getanswer":
            OutStreamPrint.Print($"{GetAnswer.str}", context);
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

internal static class GetAnswer
{
    internal static string str = "GetAnswer";
}

internal static class PostInputData
{
    internal static string str = "PostInputData";
}

public static class OutStreamPrint
{
    public static void Print(string str, HttpListenerContext context)
    {
        var request = context.Request;
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