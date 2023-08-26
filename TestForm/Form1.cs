using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XFSNet;
using XFSNet.IDC;
using XFSNet.PIN;
using XFSNet.CDM;
using XFSNet.SIU;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using NLog;

namespace TestForm
{
    public partial class Form1 : Form
    {
        private Logger LOGGER = LogManager.GetCurrentClassLogger();
        //private IDC device = new IDC();
        //private PIN pin = new PIN();
        //private CDM cdm = new CDM();
        //private SIU siu = new SIU();
        public Form1()
        {
            InitializeComponent();
            //Controls.Add(device);
            //device.RegisterComplete += Device_RegisterComplete;
            //device.RegisterError += Device_RegisterError;
            //device.OpenError += Device_OpenError;
            //device.Open("IDCARDUNIT1", lowVersion: "3.10", highVersion: "3.10");
            //cdm.Open("BRMDispenser1");
            //pin.PINKey += Pin_PINKey;
            // pin.Open("PINPAD1");
            //cdm.DispenComplete += Cdm_DispenComplete;
            //cdm.Open("CURRENCYDISPENSER1");
            //siu.Open("SIU");
            //LogInfo();
        }

        private void LogInfo(CDM cdm)
        {
            LOGGER.Info("Start WFSCDMSTATUS...");
            WFSCDMSTATUS status;
            bool isSuccess = cdm.GetStatus(out status);
            string statusJson = JsonConvert.SerializeObject(status);
            LOGGER.Info($"WFSCDMSTATUS ({isSuccess}) -> \r\n" + statusJson);
            LOGGER.Info("End WFSCDMSTATUS...");

            LOGGER.Info("Start WFSCDMCAPS...");
            WFSCDMCAPS caps;
            isSuccess = cdm.GetCapability(out caps);
            string capsJson = JsonConvert.SerializeObject(caps);
            LOGGER.Info($"WFSCDMCAPS ({isSuccess}) -> \r\n" + capsJson);
            LOGGER.Info("End WFSCDMCAPS...");

            LOGGER.Info("Start WFSCDMCUINFO...");
            ISTATUS cashInfo;
            isSuccess = cdm.Get_WFSCDMCUINFO(out cashInfo);
            string cashInfoJson = JsonConvert.SerializeObject((CashInfoObject)cashInfo);
            LOGGER.Info($"WFSCDMCUINFO ({isSuccess}) -> \r\n" + cashInfoJson);
            LOGGER.Info("End WFSCDMCUINFO...");
        }

        private void Cdm_DispenComplete()
        {
            //cdm.Present();
        }

        private void Pin_PINKey(string obj)
        {
            Console.WriteLine(obj);
        }

        private void Device_OpenError(int obj)
        {
            MessageBox.Show("OpenError:" + obj);
        }

        private void Device_RegisterError(int obj)
        {
            MessageBox.Show("RegisterError:"+obj);
        }

        private void Device_RegisterComplete()
        {
            MessageBox.Show("RegisterComplete");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //device.ReadRawData(IDCDataSource.WFS_IDC_TRACK2 | IDCDataSource.WFS_IDC_TRACK3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //device.EjectCard();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //pin.GetData(0, false, PINDefinition.NumerKeys|XFSPINKey.WFS_PIN_FK_ENTER|XFSPINKey.WFS_PIN_FK_CANCEL, XFSPINKey.WFS_PIN_FK_UNUSED);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //pin.Cancel();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //device.Cancel();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //cdm.Dispense(200);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //siu.SetGuidLight(GuidLights.WFS_SIU_NOTESDISPENSER, LightControl.WFS_SIU_MEDIUM_FLASH);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //WFSIDCSTATUS stu = new WFSIDCSTATUS();
            //device.GetStatus(out stu);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //WFSIDCCAPS cap = new WFSIDCCAPS();
            //device.GetCapability(out cap);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //int size = Marshal.SizeOf(typeof(WFSIDCCAPS));
            //Console.WriteLine(size);
        }

        private void btnWebase1_Click(object sender, EventArgs e)
        {
            using (CDM cdm = new CDM())
            {
                cdm.Open(cmbWebaseServices.Text);
                LogInfo(cdm);
            }
            
        }
    }
}
