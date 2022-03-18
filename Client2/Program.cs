using Client2.ServiceReference;
using Client2.ServiceReference1;
using Client2.ServiceReference2;
using Client2.ServiceReference3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client2
{
    internal class Program
    {
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
            ChannelFactory<IService> factory = null;
            try
            {
                factory = new ChannelFactory<IService>(new BasicHttpBinding(), new EndpointAddress("http://localhost:62355/Service.svc"));
                var channel = factory.CreateChannel();
                var s = channel.GetData("Call Server Synchronize Method.");
                Console.WriteLine(s);
                Console.WriteLine("Waiting for Synchronize operation...");
                factory.Close();
                throw new Exception();
            }
            catch (Exception e)
            {
                if (factory != null)
                {
                    factory.Abort();
                }
            }
        }

        private static void CallEventBasedAsync()
        {
            Console.WriteLine("Not support to create channel by ourselves");
        }

        private static void CallIAsyncResultClientSide()
        {
            CreateChannel();
            channel1.BeginGetData("IAsyncResult asynchronous pattern (Client-Side)", new AsyncCallback(GetDataCallBackClient), null);
            Console.WriteLine("Waiting for async operation...");

            
        }

        static ChannelFactory<IService1> factory1 = null;
        static IService1 channel1 = null;
        private static void CreateChannel()
        {
            try
            {
                factory1 = new ChannelFactory<IService1>(new BasicHttpBinding(), new EndpointAddress("http://localhost:62355/Service1.svc"));
                channel1 = factory1.CreateChannel();
            }
            catch (Exception e)
            {
                if (factory1 != null)
                {
                    factory1.Abort();
                }
            }
        }

        static void GetDataCallBackClient(IAsyncResult result)
        {
            
            try
            {
                Console.WriteLine(channel1.EndGetData(result).ToString());
                factory1.Close();
                throw new Exception();
            }
            catch (Exception e)
            {
                if (factory1 != null)
                {
                    factory1.Abort();
                }
            }
        }

        private static void CallIAsyncResultServerSide()
        {
            CreateChannel2();
            channel2.BeginGetData("IAsyncResult asynchronous pattern (Server-Side)", new AsyncCallback(GetDataCallBackServer), null);
            Console.WriteLine("Waiting for async operation...");
        }

        static ChannelFactory<IService2> factory2 = null;
        static IService2 channel2 = null;
        private static void CreateChannel2()
        {
            try
            {
                factory2 = new ChannelFactory<IService2>(new BasicHttpBinding(), new EndpointAddress("http://localhost:62355/Service2.svc"));
                channel2 = factory2.CreateChannel();
            }
            catch (Exception e)
            {
                if (factory2 != null)
                {
                    factory2.Abort();
                }
            }
        }

        static void GetDataCallBackServer(IAsyncResult result)
        {
            try
            {
                Console.WriteLine(channel2.EndGetData(result).ToString());
                factory2.Close();
                throw new Exception();
            }
            catch (Exception e)
            {
                if (factory2 != null)
                {
                    factory2.Abort();
                }
            }
        }

        private static void CallTaskBasedAsync()
        {
            InvokeAsyncMethod("task-based asynchronous pattern");
            Console.WriteLine("Waiting for async operation...");
        }
        static async void InvokeAsyncMethod(string message)
        {
            Console.WriteLine(await CallMethod(message));
        }

        static async Task<string> CallMethod(string message)
        {
            string s = null;
            ChannelFactory<IService3> factory = null;
            try
            {
                factory = new ChannelFactory<IService3>(new BasicHttpBinding(), new EndpointAddress("http://localhost:62355/Service3.svc"));
                var channel = factory.CreateChannel();
                s = await channel.GetDataAsync("task-based asynchronous pattern");
               
                factory.Close();
                throw new Exception();
            }
            catch (Exception e)
            {
                if (factory != null)
                {
                    factory.Abort();
                }
            }
            return s;
        }
    }
}
