using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //ToSturct();
            //ToEnum();
            ToConstants();
            Console.ReadKey();
        }

        public static void ToConstants()
        {
            string str = @"#define WFS_ERR_IDC_MEDIAJAM                    (-(IDC_SERVICE_OFFSET + 0))
#define WFS_ERR_IDC_NOMEDIA                     (-(IDC_SERVICE_OFFSET + 1))
#define WFS_ERR_IDC_MEDIARETAINED               (-(IDC_SERVICE_OFFSET + 2))
#define WFS_ERR_IDC_RETAINBINFULL               (-(IDC_SERVICE_OFFSET + 3))
#define WFS_ERR_IDC_INVALIDDATA                 (-(IDC_SERVICE_OFFSET + 4))
#define WFS_ERR_IDC_INVALIDMEDIA                (-(IDC_SERVICE_OFFSET + 5))
#define WFS_ERR_IDC_FORMNOTFOUND                (-(IDC_SERVICE_OFFSET + 6))
#define WFS_ERR_IDC_FORMINVALID                 (-(IDC_SERVICE_OFFSET + 7))
#define WFS_ERR_IDC_DATASYNTAX                  (-(IDC_SERVICE_OFFSET + 8))
#define WFS_ERR_IDC_SHUTTERFAIL                 (-(IDC_SERVICE_OFFSET + 9))
#define WFS_ERR_IDC_SECURITYFAIL                (-(IDC_SERVICE_OFFSET + 10))
#define WFS_ERR_IDC_PROTOCOLNOTSUPP             (-(IDC_SERVICE_OFFSET + 11))
#define WFS_ERR_IDC_ATRNOTOBTAINED              (-(IDC_SERVICE_OFFSET + 12))
#define WFS_ERR_IDC_INVALIDKEY                  (-(IDC_SERVICE_OFFSET + 13))
#define WFS_ERR_IDC_WRITE_METHOD                (-(IDC_SERVICE_OFFSET + 14))
#define WFS_ERR_IDC_CHIPPOWERNOTSUPP            (-(IDC_SERVICE_OFFSET + 15))
#define WFS_ERR_IDC_CARDTOOSHORT                (-(IDC_SERVICE_OFFSET + 16))
#define WFS_ERR_IDC_CARDTOOLONG                 (-(IDC_SERVICE_OFFSET + 17))
#define WFS_ERR_IDC_INVALID_PORT                (-(IDC_SERVICE_OFFSET + 18))
#define WFS_ERR_IDC_POWERSAVETOOSHORT           (-(IDC_SERVICE_OFFSET + 19))
#define WFS_ERR_IDC_POWERSAVEMEDIAPRESENT       (-(IDC_SERVICE_OFFSET + 20))
#define WFS_ERR_IDC_CARDPRESENT                 (-(IDC_SERVICE_OFFSET + 21))
#define WFS_ERR_IDC_POSITIONINVALID             (-(IDC_SERVICE_OFFSET + 22))
            ";
            //Regex reg = new Regex(@"#define\s*?(\S+)\s*?\((WM_USER\s*\+\s*\d+)\)");
            Regex reg = new Regex(@"#define\s*?(\S+)\s*?(\(\-?\(?(\w*)\s*[\-\+]?\s*[\dxX]+\)\)?)");
            MatchCollection mc = reg.Matches(str);
            StringBuilder buf = new StringBuilder(128);
            foreach (Match item in mc)
            {
                buf.AppendLine(string.Format("public const int {0}={1};", item.Groups[1].Value, item.Groups[2].Value));
            }
            string s = buf.ToString();
            Clipboard.SetText(s);
            Console.WriteLine(s);
        }

        public static void ToEnum()
        {
            string str = @"#define     WFS_IDC_EXITPOSITION                (0x0001)
#define     WFS_IDC_TRANSPORTPOSITION           (0x0002)";
            Regex reg = new Regex(@"#define\s*?(\S+)\s*?\(?(\s*\-?\s*[\dxX]+)\)?");
            MatchCollection mc = reg.Matches(str);
            StringBuilder buf = new StringBuilder(128);
            foreach (Match item in mc)
            {
                buf.AppendLine(string.Format("{0}={1},", item.Groups[1].Value, item.Groups[2].Value));
            }
            buf.Length -= 3;
            string s = buf.ToString();
            Clipboard.SetText(s);
            Console.WriteLine(s);
        }

        public static void ToSturct()
        {
            string str = @"typedef struct _wfs_siu_status
{
    WORD            fwDevice;
    WORD            fwSensors [WFS_SIU_SENSORS_SIZE];
    WORD            fwDoors [WFS_SIU_DOORS_SIZE];
    WORD            fwIndicators [WFS_SIU_INDICATORS_SIZE];
    WORD            fwAuxiliaries [WFS_SIU_AUXILIARIES_SIZE];
    WORD            fwGuidLights [WFS_SIU_GUIDLIGHTS_SIZE];
    LPSTR           lpszExtra;
    USHORT          usPowerSaveRecoveryTime;
    WORD            wAntiFraudModule;
} WFSSIUSTATUS, *LPWFSSIUSTATUS;

typedef struct _wfs_siu_caps
{
    WORD            wClass;
    WORD            fwType;
    WORD            fwSensors [WFS_SIU_SENSORS_SIZE];
    WORD            fwDoors [WFS_SIU_DOORS_SIZE];
    WORD            fwIndicators [WFS_SIU_INDICATORS_SIZE];
    WORD            fwAuxiliaries [WFS_SIU_AUXILIARIES_SIZE];
    WORD            fwGuidLights [WFS_SIU_GUIDLIGHTS_SIZE];
    LPSTR           lpszExtra;
    BOOL            bPowerSaveControl;
    WORD            fwAutoStartupMode;
    BOOL            bAntiFraudModule;
} WFSSIUCAPS, *LPWFSSIUCAPS;

typedef struct wfs_siu_get_startup_time
{
    WORD            wMode;
    LPSYSTEMTIME    lpStartTime;
} WFSSIUGETSTARTUPTIME, *LPWFSSIUGETSTARTUPTIME;


/*=================================================================*/
/* SIU Execute Command Structures */
/*=================================================================*/

typedef struct _wfs_siu_enable
{
    WORD            fwSensors [WFS_SIU_SENSORS_SIZE];
    WORD            fwDoors [WFS_SIU_DOORS_SIZE];
    WORD            fwIndicators [WFS_SIU_INDICATORS_SIZE];
    WORD            fwAuxiliaries [WFS_SIU_AUXILIARIES_SIZE];
    WORD            fwGuidLights [WFS_SIU_GUIDLIGHTS_SIZE];
    LPSTR           lpszExtra;
} WFSSIUENABLE, *LPWFSSIUENABLE;


typedef struct _wfs_siu_set_ports
{
    WORD            fwDoors [WFS_SIU_DOORS_SIZE];
    WORD            fwIndicators [WFS_SIU_INDICATORS_SIZE];
    WORD            fwAuxiliaries [WFS_SIU_AUXILIARIES_SIZE];
    WORD            fwGuidLights [WFS_SIU_GUIDLIGHTS_SIZE];
    LPSTR           lpszExtra;
} WFSSIUSETPORTS, *LPWFSSIUSETPORTS;


typedef struct _wfs_siu_set_door
{
    WORD            wDoor;
    WORD            fwCommand;
} WFSSIUSETDOOR, *LPWFSSIUSETDOOR;


typedef struct _wfs_siu_set_indicator
{
    WORD            wIndicator;
    WORD            fwCommand;
} WFSSIUSETINDICATOR, *LPWFSSIUSETINDICATOR;


typedef struct _wfs_siu_set_auxiliary
{
    WORD            wAuxiliary;
    WORD            fwCommand;
} WFSSIUSETAUXILIARY, *LPWFSSIUSETAUXILIARY;


typedef struct _wfs_siu_set_guidlight
{
    WORD            wGuidLight;
    WORD            fwCommand;
} WFSSIUSETGUIDLIGHT, *LPWFSSIUSETGUIDLIGHT;


typedef struct _wfs_siu_power_save_control
{
    USHORT          usMaxPowerSaveRecoveryTime;
} WFSSIUPOWERSAVECONTROL, *LPWFSSIUPOWERSAVECONTROL;

typedef struct wfs_siu_set_startup_time
{
    WORD            wMode;
    LPSYSTEMTIME    lpStartTime;
} WFSSIUSETSTARTUPTIME, *LPWFSSIUSETSTARTUPTIME;


/*=================================================================*/
/* SIU Message Structures */
/*=================================================================*/

typedef struct _wfs_siu_port_event
{
    WORD            wPortType;
    WORD            wPortIndex;
    WORD            wPortStatus;
    LPSTR           lpszExtra;
} WFSSIUPORTEVENT, *LPWFSSIUPORTEVENT;


typedef struct _wfs_siu_port_error
{
    WORD            wPortType;
    WORD            wPortIndex;
    HRESULT         PortError;
    WORD            wPortStatus;
    LPSTR           lpszExtra;
} WFSSIUPORTERROR, *LPWFSSIUPORTERROR;

typedef struct _wfs_siu_power_save_change
{
    USHORT          usPowerSaveRecoveryTime;
} WFSSIUPOWERSAVECHANGE, *LPWFSSIUPOWERSAVECHANGE;
";
            Regex reg = new Regex(@"typedef struct \w+\s+\{([^\}]+)\}\s+(\w+)");
            Regex regInner = new Regex(@"\s+(\w+)\s+(\w+);");
            MatchCollection mc = reg.Matches(str);
            StringBuilder buf = new StringBuilder(512);
            foreach (Match item in mc)
            {
                buf.AppendLine("[StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]");
                buf.AppendLine("public struct " + item.Groups[2].Value + "{");
                MatchCollection mcFields = regInner.Matches(item.Groups[1].Value);
                foreach (Match itemField in mcFields)
                {
                    string strType = itemField.Groups[1].Value.ToLower();
                    switch (strType)
                    {
                        case "lpstr":
                            strType = "string";
                            break;
                        case "word":
                            strType = "ushort";
                            break;
                        case "lpword":
                            strType = "ushort*";
                            break;
                        case "dword":
                            strType = "int";
                            break;
                        case "lpbyte":
                            strType = "IntPtr";
                            break;
                        case "long":
                            strType = "int";
                            break;
                        case "ulong":
                            strType = "uint";
                            break;
                    }
                    buf.Append("public ");
                    buf.Append(strType);
                    buf.Append(' ');
                    buf.AppendLine(itemField.Groups[2].Value + "{get;set;}");
                }
                buf.AppendLine("}");
            }
            string s = buf.ToString();
            Clipboard.SetText(s);
            Console.WriteLine(s);
        }
    }


}
