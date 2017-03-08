using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFSNet
{
    internal class XFSMessageHandler
    {

        public Action<string, int, string> ErrorHandler { get; protected set; }
        public Action<object> EventHandler { get; protected set; }
        public Type TargetType { get; set; }
        public XFSMessageHandler(Action<string, int, string> errorEventHandler, Action<object> completeHandler,Type paramType)
        {
            ErrorHandler = errorEventHandler;
            EventHandler = completeHandler;
            TargetType = paramType;
        }
    }
}
