﻿#region using

// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable UnusedMethodReturnValue.Local
// ReSharper disable FunctionNeverReturns

#endregion

using System;
using System.Net;

namespace Universal_Share.Net {
    public class SharedComponents : NetworkFileSend{

    }

    public interface ISharedAble {
       void Start(IPAddress ipAddress);
       void Abort();
    }
}