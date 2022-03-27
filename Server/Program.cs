using System.Net;
var httpListener = new HttpListener();

httpListener.Prefixes.Add("http://localhost:23234/");
httpListener.Start();
var IsStarted = true;
var count = 0;
while (IsStarted)
{
    var context = httpListener.GetContext();
    var request = context.Request;


    var response = context.Response;
    string responseStr = $"<html><head><meta charset='utf8'></head><body>Привет мир! {count}</body></html>";
    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseStr);

    response.ContentLength64 = buffer.Length;
    var output = response.OutputStream;
    output.Write(buffer, 0, buffer.Length);

    output.Close();
    count++;
}
httpListener.Stop();
Console.WriteLine("Обработка подключений завершена");
Console.ReadKey();