﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;


namespace MultipleWCFContracts
{
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
         string DoProcess(string message);
    }
}
