using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XFSNet;
using System.Runtime.InteropServices;
using System.Threading;

namespace XFSNet.IDC
{
    public unsafe class IDC : XFSDeviceBase<WFSIDCSTATUS, WFSIDCCAPS>
    {
        #region consturctor
        public IDC()
        {
            commandHandlers = new Dictionary<int, XFSCommandHandler>();
            eventHandlers = new Dictionary<int, XFSEventHandler>();
            commandHandlers.Add(IDCDefinition.WFS_CMD_IDC_READ_RAW_DATA, new XFSCommandHandler(OnReadRawDataError, null, OnReadRawDataComplete));
            commandHandlers.Add(IDCDefinition.WFS_CMD_IDC_EJECT_CARD, new XFSCommandHandler(OnEjectError, OnEjectComplete));
            commandHandlers.Add(IDCDefinition.WFS_CMD_IDC_RETAIN_CARD, new XFSCommandHandler(OnRetainError, OnRetainComplete));
            eventHandlers.Add(IDCDefinition.WFS_EXEE_IDC_MEDIAINSERTED, new XFSEventHandler(OnMediaInserted));
            eventHandlers.Add(IDCDefinition.WFS_SRVE_IDC_MEDIAREMOVED, new XFSEventHandler(OnMediaRemoved));
            eventHandlers.Add(IDCDefinition.WFS_EXEE_IDC_INVALIDMEDIA, new XFSEventHandler(OnInvalidMedia));
        }
        #endregion
        #region Events
        public event Action<string, int, string> ReadRawDataError;
        public event Action<IDCCardData[]> ReadRawDataComplete;
        public event Action EjectComplete;
        public event Action RetainComplete;
        public event Action<string, int, string> EjectError;
        public event Action<string, int, string> RetainError;
        public event Action MediaInserted;
        public event Action MediaRemoved;
        public event Action InvalidMedia;
        #endregion
        #region API
        public void ReadRawData(IDCDataSource sources)
        {
            ExecuteCommand(IDCDefinition.WFS_CMD_IDC_READ_RAW_DATA, new IntPtr(&sources), OnReadRawDataError);
        }
        public void EjectCard()
        {
            ExecuteCommand(IDCDefinition.WFS_CMD_IDC_EJECT_CARD, IntPtr.Zero, OnEjectError);
        }
        public void RetainCard()
        {
            ExecuteCommand(IDCDefinition.WFS_CMD_IDC_RETAIN_CARD, IntPtr.Zero,OnRetainError);
        }
        #endregion

        #region Event handler
        protected void OnReadRawDataComplete(IntPtr ptr)
        {
            WFSIDCCardData[] data = XFSUtil.XFSPtrToArray<WFSIDCCardData>(ptr);
            IDCCardData[] outerData = new IDCCardData[data.Length];
            for (int i = 0; i < data.Length; ++i)
            {
                outerData[i] = new IDCCardData();
                outerData[i].DataSource = data[i].wDataSource;
                outerData[i].WriteMethod = data[i].fwWriteMethod;
                outerData[i].Status = data[i].wStatus;
                if (data[i].ulDataLength > 0)
                {
                    outerData[i].Data = new byte[data[i].ulDataLength];
                    for (int j = 0; j < data[i].ulDataLength; ++j)
                        outerData[i].Data[j] = Marshal.ReadByte(data[i].lpbData, j);
                }
            }
            if (ReadRawDataComplete != null)
                ReadRawDataComplete(outerData);
        }
        protected virtual void OnReadRawDataError(string service, int code, string message)
        {
            if (ReadRawDataError != null)
                ReadRawDataError(service, code, message);
        }
        protected virtual void OnEjectError(string service, int code, string message)
        {
            if (EjectError != null)
                EjectError(service, code, message);
        }
        protected virtual void OnEjectComplete()
        {
            if (EjectComplete != null)
                EjectComplete();
        }
        protected virtual void OnRetainError(string service, int code, string message)
        {
            if (RetainError != null)
                RetainError(service, code, message);
        }
        protected virtual void OnRetainComplete()
        {
            if (RetainComplete != null)
                RetainComplete();
        }
        protected virtual void OnMediaInserted()
        {
            if (MediaInserted != null)
                MediaInserted();
        }
        protected virtual void OnMediaRemoved()
        {
            if (MediaRemoved != null)
                MediaRemoved();
        }
        protected virtual void OnInvalidMedia()
        {
            if (InvalidMedia != null)
                InvalidMedia();
        }
        #endregion

        #region Override Property
        protected override int StatusCommandCode
        {
            get
            {
                return IDCDefinition.WFS_INF_IDC_STATUS;
            }
        }
        protected override int CapabilityCommandCode
        {
            get
            {
                return IDCDefinition.WFS_INF_IDC_CAPABILITIES;
            }
        }
        #endregion
    }
}
