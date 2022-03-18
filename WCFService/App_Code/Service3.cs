using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service3" in code, svc and config file together.
public class Service3 : IService3
{
    public async Task<string> GetDataAsync(string message)
    {
        return await Task.Factory.StartNew(() => GetData(message));
    }

    private string GetData(string message)
    {
        Thread.Sleep(5000);
        return string.Format("Server return: {0}", message);
    }
}
