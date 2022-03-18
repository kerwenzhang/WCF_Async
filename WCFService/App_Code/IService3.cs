﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService3" in both code and config file together.
[ServiceContract]
public interface IService3
{
    //task-based asynchronous pattern
    [OperationContract]
    Task<string> GetDataAsync(string message);
}
