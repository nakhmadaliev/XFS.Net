using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XFSNet
{
    public class XFSDeviceBase : UserControl
    {
        #region Events
        public event Action OpenComplete;
        public event Action<int> OpenError;
        public event Action CloseComplete;
        public event Action RegisterComplete;
        public event Action<int> RegisterError;
        protected ushort hService;
        protected bool autoRegister = false;
        protected int requestID = 0;
        protected bool isStartup = false;
        public int TimeOut { get; set; }
        /// <summary>
        /// dulication of handle for crossing thread
        /// </summary>
        protected IntPtr MessageHandle;
        #endregion
        public XFSDeviceBase()
        {
            this.Width = this.Height = 0;
            this.Visible = false;
            MessageHandle = Handle;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg >= XFSDefinition.WFS_OPEN_COMPLETE &&
                m.Msg <= XFSDefinition.WFS_TIMER_EVENT)
            {
                WFSRESULT result = new WFSRESULT();
                if (m.LParam != IntPtr.Zero)
                    XFSUtil.PtrToStructure(m.LParam, ref result);
                switch (m.Msg)
                {
                    case XFSDefinition.WFS_OPEN_COMPLETE:
                        OnOpenComplete();
                        break;
                    case XFSDefinition.WFS_CLOSE_COMPLETE:
                        OnCloseComplete();
                        break;
                    case XFSDefinition.WFS_REGISTER_COMPLETE:
                        OnRegisterComplete();
                        break;
                    case XFSDefinition.WFS_EXECUTE_COMPLETE:
                        OnExecuteComplete(ref result);
                        break;
                    case XFSDefinition.WFS_EXECUTE_EVENT:
                        OnExecuteEvent(ref result);
                        break;
                    case XFSDefinition.WFS_SERVICE_EVENT:
                        OnServiceEvent(ref result);
                        break;
                    case XFSDefinition.WFS_USER_EVENT:
                        OnUserEvent(ref result);
                        break;
                    case XFSDefinition.WFS_SYSTEM_EVENT:
                        OnSystemEvent(ref result);
                        break;
                }
                XfsApi.WFSFreeResult(ref result);
            }
            else
                base.WndProc(ref m);
        }

        protected virtual void OnOpenComplete()
        {
            if (OpenComplete != null)
                OpenComplete();
            if (autoRegister)
            {
                InnerRegister(GetEventClass());
            }
        }
        protected virtual int InnerGetInfo<T>(int category, T inParam)
        {
            
            //XfsApi.WFSGetInfo(hService, category,)
            return 0;
        }
        protected virtual int InnerGetInfo<T>(int category)
        {
            IntPtr pOutParam = IntPtr.Zero;
            //XfsApi.WFSGetInfo(hService, category, IntPtr.Zero, TimeOut, ref pOutParam);
            return 0;
        }
        protected void InnerRegister(int eventClasses)
        {
            int hResult = XfsApi.WFSAsyncRegister(hService, eventClasses, MessageHandle
                , MessageHandle, ref requestID);
            if (hResult != XFSDefinition.WFS_SUCCESS)
            {
                OnRegisterError(hResult);
            }
        }
        protected virtual int GetEventClass()
        {
            return XFSDefinition.EXECUTE_EVENTS | XFSDefinition.SERVICE_EVENTS
                | XFSDefinition.SYSTEM_EVENTS | XFSDefinition.USER_EVENTS;
        }
        protected virtual void OnOpenError(int code)
        {
            if (OpenError != null)
                OpenError(code);
        }
        protected virtual void OnCloseComplete()
        {
            if (CloseComplete != null)
                CloseComplete();
        }
        protected virtual void OnRegisterComplete()
        {
            if (RegisterComplete != null)
                RegisterComplete();
        }
        protected virtual void OnRegisterError(int code)
        {
            if (RegisterError != null)
                RegisterError(code);
        }
        protected virtual void OnExecuteComplete(ref WFSRESULT result)
        { }
        protected virtual void OnExecuteEvent(ref WFSRESULT result)
        { }
        protected virtual void OnServiceEvent(ref WFSRESULT result)
        { }
        protected virtual void OnUserEvent(ref WFSRESULT result)
        { }
        protected virtual void OnSystemEvent(ref WFSRESULT result)
        { }
        public void Open(string logicName, bool paramAutoRegister = true,
            string appID = "XFS.NET", string lowVersion = "3.0",
            string highVersion = "3.0")
        {
            autoRegister = paramAutoRegister;
            int requestVersion = XFSUtil.ParseVersionString(lowVersion,
                highVersion);
            WFSVERSION srvcVersion = new WFSVERSION();
            WFSVERSION spVersion = new WFSVERSION();
            int hResult = 0;
            if (!isStartup)
            {
                hResult = XfsApi.WFSStartUp(requestVersion, ref spVersion);
                if (hResult != XFSDefinition.WFS_SUCCESS &&
                    hResult != XFSDefinition.WFS_ERR_ALREADY_STARTED)
                {
                    OnOpenError(hResult);
                    return;
                }
            }
            hResult = XfsApi.WFSAsyncOpen(logicName, IntPtr.Zero, appID, 0,
                XFSConstants.WFS_INDEFINITE_WAIT, ref hService,
            MessageHandle, requestVersion, ref srvcVersion, ref spVersion,
            ref requestID);
            if (hResult != XFSDefinition.WFS_SUCCESS)
            {
                OnOpenError(hResult);
            }
        }
        public void Register(int eventClasses = XFSDefinition.EXECUTE_EVENTS |
            XFSDefinition.SERVICE_EVENTS | XFSDefinition.SYSTEM_EVENTS |
            XFSDefinition.USER_EVENTS)
        {
            InnerRegister(eventClasses);
        }

        public void Close()
        {
            //
        }

        public void Reset()
        {
            //
        }
        public void Cancel()
        {
            XfsApi.WFSCancelAsyncRequest(hService, requestID);
        }
    }
}
