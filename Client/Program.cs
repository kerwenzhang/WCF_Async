using Client.ServiceReference;
using Client.ServiceReference1;
using Client.ServiceReference2;
using Client.ServiceReference3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static ServiceClient client = new ServiceClient();
        static Service1Client client1 = new Service1Client();
        static Service2Client client2 = new Service2Client();
        static Service3Client client3 = new Service3Client();
        static void Main(string[] args)
        {
            CallSynMethod();
            CallEventBasedAsync();
            CallIAsyncResultClientSide();
            CallIAsyncResultServerSide();
            CallTaskBasedAsync();
            Console.Read();
        }

        private static void CallSynMethod()
        {
            Console.WriteLine(client.GetData("Call Server Synchronize Method."));
            Console.WriteLine("Waiting for Synchronize operation...");
        }
        private static void CallEventBasedAsync()
        {
            client1.GetDataCompleted += client_GetDataCompleted;
            client1.GetDataAsync("event-based asynchronous pattern");
            Console.WriteLine("Waiting for async operation...");
        }

        static void client_GetDataCompleted(object sender, ServiceReference1.GetDataCompletedEventArgs e)
        {
            Console.WriteLine(e.Result.ToString());
        }

        private static void CallIAsyncResultClientSide()
        {
            client1.BeginGetData("IAsyncResult asynchronous pattern (Client-Side)", new AsyncCallback(GetDataCallBackClient), null);
            Console.WriteLine("Waiting for async operation...");
        }

        static void GetDataCallBackClient(IAsyncResult result)
        {
            Console.WriteLine(client1.EndGetData(result).ToString());
        }

        private static void CallIAsyncResultServerSide()
        {
            client2.BeginGetData("IAsyncResult asynchronous pattern (Server-Side)", new AsyncCallback(GetDataCallBackServer), null);
            Console.WriteLine("Waiting for async operation...");
        }
        static void GetDataCallBackServer(IAsyncResult result)
        {
            Console.WriteLine(client2.EndGetData(result).ToString());
        }

        private static void CallTaskBasedAsync()
        {
            InvokeAsyncMethod("task-based asynchronous pattern");
            Console.WriteLine("Waiting for async operation...");
        }
        static async void InvokeAsyncMethod(string message)
        {
            Console.WriteLine(await client3.GetDataAsync(message));
        }
    }
}
