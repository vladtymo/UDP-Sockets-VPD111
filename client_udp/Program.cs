using System.Net;
using System.Net.Sockets;
using System.Text;

namespace client_udp
{
    internal class Program
    {
        const short serverPort = 5566;
        static void Main(string[] args)
        {
            // create server endpoint
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Parse("10.7.173.218"), serverPort); // recommended > 1024

            // create client socket instance
            UdpClient client = new(); // bind to a random free port

            Console.WriteLine("Time to Live: " + client.Ttl);

            string message = string.Empty;
            do
            {
                // write a message from keyboard
                Console.Write("Enter a message: ");
                message = Console.ReadLine();

                // send data to the server
                byte[] data = Encoding.UTF8.GetBytes(message);

                client.Send(data, data.Length, serverEndpoint);

                // wait for the response
                byte[] responseData = client.Receive(ref serverEndpoint);
                string response = Encoding.UTF8.GetString(responseData);
                Console.WriteLine($"Server response: {response} at {DateTime.Now.ToShortTimeString()}");

            } while (message != "END");
        }
    }
}