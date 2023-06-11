using System.Net;
using System.Net.Sockets;
using System.Text;

namespace server_udp
{
    internal class Program
    {
        const short serverPort = 5566;
        static void Main(string[] args)
        {
            // create server socket
            UdpClient server = new(serverPort);

            while (true)
            {
                // wait client request
                Console.WriteLine("Waiting for the client request...");

                IPEndPoint clientEndpoint = null; // stores sender endpoint value
                byte[] requestData = server.Receive(ref clientEndpoint);

                // convert bytes to string
                string requestMsg = Encoding.UTF8.GetString(requestData);

                Console.WriteLine($"Request message: {requestMsg} from: {clientEndpoint}");

                // send response to the client
                string responseMsg = "Thank you for the request!";
                byte[] responseData = Encoding.UTF8.GetBytes(responseMsg);
                server.Send(responseData, clientEndpoint);
            }
        }
    }
}