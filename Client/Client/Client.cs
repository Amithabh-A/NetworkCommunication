// sender

using System;
using System.IO;
using System.Net.Sockets;
namespace Client;

public class Client
{
  static void Main(string[] args)
  {
    string serverIP = args[0]; // Replace with the server's IP address
    int port = int.Parse(args[1]); // Same port as the server

    TcpClient client = new TcpClient(serverIP, port);
    Console.WriteLine("Connected to the server.");

    using (NetworkStream stream = client.GetStream())
    {
      using (FileStream fileStream = new FileStream(args[2], FileMode.Open, FileAccess.Read))
      {
        byte[] buffer = new byte[1024];
        int bytesRead;
        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
        {
          stream.Write(buffer, 0, bytesRead);
        }
      }
    }

    client.Close();
    Console.WriteLine("File sent to the server.");
  }
}

