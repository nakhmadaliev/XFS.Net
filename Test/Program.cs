using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //ToSturct();
            ToEnum();
            //ToConstants();
            Console.ReadKey();
        }

        public static void ToConstants()
        {
            string str = @"#define     WFS_SERVICE_CLASS_SIU               (8)

#define WFS_SERVICE_CLASS_VERSION_SIU       (0x1403) /* Version 3.20 */

#define SIU_SERVICE_OFFSET                  (WFS_SERVICE_CLASS_SIU * 100)


            /* SIU Info Commands */

#define WFS_INF_SIU_STATUS                  (SIU_SERVICE_OFFSET + 1)
#define WFS_INF_SIU_CAPABILITIES            (SIU_SERVICE_OFFSET + 2)
#define WFS_INF_SIU_GET_AUTOSTARTUP_TIME    (SIU_SERVICE_OFFSET + 3)


            /* SIU Command Verbs */

#define WFS_CMD_SIU_ENABLE_EVENTS           (SIU_SERVICE_OFFSET + 1)
#define WFS_CMD_SIU_SET_PORTS               (SIU_SERVICE_OFFSET + 2)
#define WFS_CMD_SIU_SET_DOOR                (SIU_SERVICE_OFFSET + 3)
#define WFS_CMD_SIU_SET_INDICATOR           (SIU_SERVICE_OFFSET + 4)
#define WFS_CMD_SIU_SET_AUXILIARY           (SIU_SERVICE_OFFSET + 5)
#define WFS_CMD_SIU_SET_GUIDLIGHT           (SIU_SERVICE_OFFSET + 6)
#define WFS_CMD_SIU_RESET                   (SIU_SERVICE_OFFSET + 7)
#define WFS_CMD_SIU_POWER_SAVE_CONTROL      (SIU_SERVICE_OFFSET + 8)
#define WFS_CMD_SIU_SET_AUTOSTARTUP_TIME    (SIU_SERVICE_OFFSET + 9)


            /* SIU Messages */

#define WFS_SRVE_SIU_PORT_STATUS            (SIU_SERVICE_OFFSET + 1)
#define WFS_EXEE_SIU_PORT_ERROR             (SIU_SERVICE_OFFSET + 2)
#define WFS_SRVE_SIU_POWER_SAVE_CHANGE      (SIU_SERVICE_OFFSET + 3)
            ";
            //Regex reg = new Regex(@"#define\s*?(\S+)\s*?\((WM_USER\s*\+\s*\d+)\)");
            Regex reg = new Regex(@"#define\s*?(\S+)\s*?\(((\w*)\s*[\-\+]?\s*[\dxX]+)\)");
            MatchCollection mc = reg.Matches(str);
            StringBuilder buf = new StringBuilder(128);
            foreach (Match item in mc)
            {
                buf.AppendLine(string.Format("public const int {0}={1};",item.Groups[1].Value,item.Groups[2].Value));
            }
            string s = buf.ToString();
            Console.WriteLine(s);
        }

        public static void ToEnum()
        {
            string str = @"#define     WFS_SIU_OFF                         (0x0001)
#define     WFS_SIU_ON                          (0x0002)
#define     WFS_SIU_SLOW_FLASH                  (0x0004)
#define     WFS_SIU_MEDIUM_FLASH                (0x0008)
#define     WFS_SIU_QUICK_FLASH                 (0x0010)
#define     WFS_SIU_CONTINUOUS                  (0x0080)";
            Regex reg = new Regex(@"#define\s*?(\S+)\s*?\(?(\s*\-?\s*[\dxX]+)\)?");
            MatchCollection mc = reg.Matches(str);
            StringBuilder buf = new StringBuilder(128);
            foreach (Match item in mc)
            {
                buf.AppendLine(string.Format("{0}={1},", item.Groups[1].Value, item.Groups[2].Value));
            }
            buf.Length -= 3;
            string s = buf.ToString();
            Console.WriteLine(s);
        }

        public static void ToSturct()
        {
            string str = @"typedef struct _wfs_idc_status
{
    WORD                     fwDevice;
    WORD                     fwMedia;
    WORD                     fwRetainBin;
    WORD                     fwSecurity;
    USHORT                   usCards;
    WORD                     fwChipPower;
    LPSTR                    lpszExtra;
    DWORD                    dwGuidLights[WFS_IDC_GUIDLIGHTS_SIZE];
    WORD                     fwChipModule;
    WORD                     fwMagReadModule;
    WORD                     fwMagWriteModule;
    WORD                     fwFrontImageModule;
    WORD                     fwBackImageModule;
    WORD                     wDevicePosition;
    USHORT                   usPowerSaveRecoveryTime;
    LPWORD                   lpwParkingStationMedia; 
    WORD                     wAntiFraudModule;
} WFSIDCSTATUS, *LPWFSIDCSTATUS;

typedef struct _wfs_idc_caps
{
    WORD                     wClass;
    WORD                     fwType;
    BOOL                     bCompound;
    WORD                     fwReadTracks;
    WORD                     fwWriteTracks;
    WORD                     fwChipProtocols;
    USHORT                   usCards;
    WORD                     fwSecType;
    WORD                     fwPowerOnOption;
    WORD                     fwPowerOffOption;
    BOOL                     bFluxSensorProgrammable;
    BOOL                     bReadWriteAccessFollowingEject;
    WORD                     fwWriteMode;
    WORD                     fwChipPower;
    LPSTR                    lpszExtra;
    WORD                     fwDIPMode;
    LPWORD                   lpwMemoryChipProtocols;
    DWORD                    dwGuidLights[WFS_IDC_GUIDLIGHTS_SIZE];
    WORD                     fwEjectPosition;
    BOOL                     bPowerSaveControl;
    USHORT                   usParkingStations; 
    BOOL                     bAntiFraudModule;
} WFSIDCCAPS, *LPWFSIDCCAPS;

typedef struct _wfs_idc_form
{
    LPSTR                    lpszFormName;
    CHAR                     cFieldSeparatorTrack1;
    CHAR                     cFieldSeparatorTrack2;
    CHAR                     cFieldSeparatorTrack3;
    WORD                     fwAction;
    LPSTR                    lpszTracks;
    BOOL                     bSecure;
    LPSTR                    lpszTrack1Fields;
    LPSTR                    lpszTrack2Fields;
    LPSTR                    lpszTrack3Fields;
    LPSTR                    lpszFrontTrack1Fields;
    CHAR                     cFieldSeparatorFrontTrack1;
    LPSTR                    lpszJIS1Track1Fields;
    LPSTR                    lpszJIS1Track3Fields;
    CHAR                     cFieldSeparatorJIS1Track1;
    CHAR                     cFieldSeparatorJIS1Track3;
} WFSIDCFORM, *LPWFSIDCFORM;

typedef struct _wfs_idc_ifm_identifier
{
    WORD                     wIFMAuthority;
    LPSTR                    lpszIFMIdentifier;
} WFSIDCIFMIDENTIFIER, *LPWFSIDCIFMIDENTIFIER;

/*=================================================================*/
/* IDC Execute Command Structures */
/*=================================================================*/

typedef struct _wfs_idc_write_track
{
    LPSTR                    lpstrFormName;
    LPSTR                    lpstrTrackData;
    WORD                     fwWriteMethod;
} WFSIDCWRITETRACK, *LPWFSIDCWRITETRACK;

typedef struct _wfs_idc_retain_card
{
    USHORT                   usCount;
    WORD                     fwPosition;
} WFSIDCRETAINCARD, *LPWFSIDCRETAINCARD;

typedef struct _wfs_idc_setkey
{
    USHORT                   usKeyLen;
    LPBYTE                   lpbKeyValue;
} WFSIDCSETKEY, *LPWFSIDCSETKEY;

typedef struct _wfs_idc_card_data
{
    WORD                     wDataSource;
    WORD                     wStatus;
    ULONG                    ulDataLength;
    LPBYTE                   lpbData;
    WORD                     fwWriteMethod;
} WFSIDCCARDDATA, *LPWFSIDCCARDDATA;

typedef struct _wfs_idc_chip_io
{
    WORD                     wChipProtocol;
    ULONG                    ulChipDataLength;
    LPBYTE                   lpbChipData;
} WFSIDCCHIPIO, *LPWFSIDCCHIPIO;

typedef struct _wfs_idc_chip_power_out
{
    ULONG                    ulChipDataLength;
    LPBYTE                   lpbChipData;
} WFSIDCCHIPPOWEROUT, *LPWFSIDCCHIPPOWEROUT;

typedef struct _wfs_idc_parse_data
{
    LPSTR                    lpstrFormName;
    LPWFSIDCCARDDATA         *lppCardData;
} WFSIDCPARSEDATA, *LPWFSIDCPARSEDATA;

typedef struct _wfs_idc_set_guidlight
{
    WORD                     wGuidLight;
    DWORD                    dwCommand;
} WFSIDCSETGUIDLIGHT, *LPWFSIDCSETGUIDLIGHT;

typedef struct _wfs_idc_eject_card
{
    WORD                     wEjectPosition;
} WFSIDCEJECTCARD, *LPWFSIDCEJECTCARD;

typedef struct _wfs_idc_power_save_control
{
    USHORT                   usMaxPowerSaveRecoveryTime;
} WFSIDCPOWERSAVECONTROL, *LPWFSIDCPOWERSAVECONTROL;

typedef struct _wfs_idc_park_card
{
    WORD                     wDirection;
    USHORT                   usParkingStation;
} WFSIDCPARKCARD, *LPWFSIDCPARKCARD;

/*=================================================================*/
/* IDC Message Structures */
/*=================================================================*/

typedef struct _wfs_idc_track_event
{
    WORD                     fwStatus;
    LPSTR                    lpstrTrack;
    LPSTR                    lpstrData;
} WFSIDCTRACKEVENT, *LPWFSIDCTRACKEVENT;

typedef struct _wfs_idc_card_act
{
    WORD                     wAction;
    WORD                     wPosition;
} WFSIDCCARDACT, *LPWFSIDCCARDACT;

typedef struct _wfs_idc_device_position
{
    WORD                     wPosition;
} WFSIDCDEVICEPOSITION, *LPWFSIDCDEVICEPOSITION;

typedef struct _wfs_idc_power_save_change
{
    USHORT                   usPowerSaveRecoveryTime;
} WFSIDCPOWERSAVECHANGE, *LPWFSIDCPOWERSAVECHANGE;

typedef struct _wfs_idc_track_detected
{
    WORD                     fwTracks;
} WFSIDCTRACKDETECTED, *LPWFSIDCTRACKDETECTED;";
            Regex reg = new Regex(@"typedef struct \w+\s+\{([^\}]+)\}\s+(\w+)");
            Regex regInner = new Regex(@"\s+(\w+)\s+(\w+);");
            MatchCollection mc = reg.Matches(str);
            StringBuilder buf = new StringBuilder(512);
            foreach (Match item in mc)
            {
                buf.AppendLine("[StructLayout(LayoutKind.Sequential, Pack = XFSConstants.STRUCTPACKSIZE, CharSet = XFSConstants.CHARSET)]");
                buf.AppendLine("public struct "+item.Groups[2].Value+"{");
                MatchCollection mcFields = regInner.Matches(item.Groups[1].Value);
                foreach (Match itemField in mcFields)
                {
                    string strType = itemField.Groups[1].Value.ToLower();
                    switch(strType)
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
                    buf.AppendLine(itemField.Groups[2].Value+";");
                }
                buf.AppendLine("}");
            }
            string s = buf.ToString();
            Console.WriteLine(s);
        }
    }


}
