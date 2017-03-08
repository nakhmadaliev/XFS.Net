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

namespace XFSNet.IDC
{
    public unsafe class IDC : XFSDeviceBase<WFSIDCSTATUS, WFSIDCCAPS>
    {
        #region consturctor
        public IDC()
        {
            executeCompleteHandlers = new Dictionary<int, XFSNet.XFSMessageHandler>();
            executeCompleteHandlers.Add(IDCDefinition.WFS_CMD_IDC_READ_RAW_DATA, new XFSMessageHandler(ReadRawDataError, OnReadRawDataComplete,null));
            executeCompleteHandlers.Add(IDCDefinition.WFS_CMD_IDC_EJECT_CARD, new XFSMessageHandler(EjectError, OnEjectComplete, null));
        }
        #endregion
        public event Action<string, int, string> ReadRawDataError;
        public event Action<IDCCardData[]> ReadRawDataComplete;
        public event Action EjectComplete;
        public event Action<int> RetainComplete;
        public event Action<string, int, string> EjectError;
        public event Action<string, int, string> RetainError;
        public event Action MediaInserted;
        public event Action MediareMoved;
        public event Action InvalidMedia;
        protected override void OnExecuteEvent(ref WFSRESULT result)
        {
            switch (result.dwCommandCodeOrEventID)
            {
                case IDCDefinition.WFS_EXEE_IDC_MEDIAINSERTED:
                    OnMediaInserted();
                    break;
                case IDCDefinition.WFS_EXEE_IDC_INVALIDMEDIA:
                    break;
            }
        }
        protected override void OnServiceEvent(ref WFSRESULT result)
        {
            switch (result.dwCommandCodeOrEventID)
            {
                case IDCDefinition.WFS_SRVE_IDC_MEDIAREMOVED:
                    OnMediareMoved();
                    break;
            }
        }
        protected override void OnUserEvent(ref WFSRESULT result)
        {
            switch(result.dwCommandCodeOrEventID)
            {
                 
            }
        }
        public void ReadRawData(IDCDataSource sources)
        {
            int hResult = XfsApi.WFSAsyncExecute(hService, IDCDefinition.WFS_CMD_IDC_READ_RAW_DATA, new IntPtr(&sources), 0,
                Handle, ref requestID);
            HandleAysncExcutionResult(hResult, ReadRawDataError);
        }
        public void EjectCard()
        {
            ExecuteCommand(IDCDefinition.WFS_CMD_IDC_EJECT_CARD, IntPtr.Zero, EjectError);
        }
        public void RetainCard()
        {
            ExecuteCommand(IDCDefinition.WFS_CMD_IDC_RETAIN_CARD, IntPtr.Zero);
        }
        #region Event handler
        protected void OnReadRawDataComplete(object  objPtr)
        {
            IntPtr ptr = (IntPtr)objPtr;
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
        protected virtual void OnEjectComplete(object obj)
        {
            if (EjectComplete != null)
                EjectComplete();
        }
        protected virtual void OnMediaInserted()
        {
            if (MediaInserted != null)
                MediaInserted();
        }
        protected virtual void OnMediareMoved()
        {
            if (MediareMoved != null)
                MediareMoved();
        }
        protected virtual void OnRetainComplete(int count)
        {
            if (RetainComplete != null)
                RetainComplete(count);
        }
        #endregion

        #region Virtual
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
