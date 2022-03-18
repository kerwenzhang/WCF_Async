using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
public class Service2 : IService2
{
    public IAsyncResult BeginGetData(string message, AsyncCallback callback, object asyncState)
    {
        var task = Task<string>.Factory.StartNew((res) => GetData(asyncState, message), asyncState);
        return task.ContinueWith(res => callback(task));
    }

    public string EndGetData(IAsyncResult result)
    {
        return ((Task<string>)result).Result;
    }

    private string GetData(object asyncState, string message)
    {
        Thread.Sleep(5000);
        return string.Format("Server return: {0}", message);
    }
}
