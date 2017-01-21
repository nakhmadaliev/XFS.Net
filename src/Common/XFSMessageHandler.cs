using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFSNet
{
    internal class XFSMessageHandler
    {

        public bool IsMarshaled { get; protected set; }
        public Action<string, int, string> ErrorHandler { get; protected set; }
        public Action<object> EventHandler { get; protected set; }
        public Type MyProperty { get; set; }
        public XFSMessageHandler(Action<string, int, string> errorEventHandler, Action<object> completeHandler, bool isMarshaled = false)
        {
            ErrorHandler = errorEventHandler;
            EventHandler = completeHandler;
            IsMarshaled = isMarshaled;
        }
    }
}
