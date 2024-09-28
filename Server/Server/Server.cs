// Receiver

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace Server;

public class Server
{
  static void Main(string[] args)
  {
    int port = int.Parse(args[0]); // Define the port number

    TcpListener server = new TcpListener(IPAddress.Any, port);
    server.Start();
    Console.WriteLine("Server started. Waiting for connection...");

    using (TcpClient client = server.AcceptTcpClient())
    {
      Console.WriteLine("Client connected!");

      using (NetworkStream stream = client.GetStream())
      {
        using (FileStream fileStream = new FileStream("received.dll", FileMode.Create, FileAccess.Write))
        {
          byte[] buffer = new byte[1024];
          int bytesRead;
          while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
          {
            fileStream.Write(buffer, 0, bytesRead);
          }
        }
      }
    }

    server.Stop();
    Console.WriteLine("File received and saved as 'received.dll'");
  }
}

