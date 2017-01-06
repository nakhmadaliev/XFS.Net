using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFSNet
{
    public interface IXFSDevice
    {
        void Open(string logicName, bool paramAutoRegister = true, string appID = "XFS.NET", string lowVersion = "3.0", string highVersion = "3.0");
        void Close();
        void Reset();
        event Action OpenComplete;
        event Action RegisterComplete;
    }
}
