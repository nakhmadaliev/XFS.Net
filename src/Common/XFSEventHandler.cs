using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFSNet
{
    public class XFSEventHandler
    {
        public Action EventHandler { get; protected set; }
        public Action<IntPtr> SubRoutine { get; protected set; }
        public Type TargetType { get; protected set; }
        public XFSEventHandler(Action eventHandler, Action<IntPtr> subRoutine = null, Type targetType = null)
        {
            EventHandler = eventHandler;
            SubRoutine = subRoutine;
            TargetType = targetType;
        }
    }
}
