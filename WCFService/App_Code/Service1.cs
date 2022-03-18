using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
public class Service1 : IService1
{
    public string GetData(string message)
    {
        Thread.Sleep(5000);
        return string.Format("Server return: {0}", message);
    }
}
