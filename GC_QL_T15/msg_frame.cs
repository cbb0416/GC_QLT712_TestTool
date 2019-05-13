using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC_QL_T15
{
    class MsgFrame
    {      
        /// <summary>
        /// 数据编码
        /// </summary>
        /// <param name="dat"></param>
        /// <returns></returns>
        public byte[] Encode( byte func_code, byte[] dat )
        {
            byte[] ret = new byte[12];
            byte[] crc = new byte[2];
            byte i = 0;

            ret[0] = 0xA5;
            ret[1] = func_code;
            for (i = 0; i < 8; i++)
            {
                ret[2+i] = dat[i];
            }
            crc = ToModbus(ret, 10);
            ret[10] = crc[0];
            ret[11] = crc[1];

            return ret;
        }

        /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
        /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
        /// <returns> Returns an array of bytes. </returns>
        public byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
            {
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            }
 
            return buffer;
        }
 
        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        public string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
            {
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            }
 
            return sb.ToString().ToUpper();
        }
        /// <summary>
        /// CRC16_Modbus效验
        /// </summary>
        /// <param name="byteData">要进行计算的字节数组</param>
        /// <returns>计算后的数组</returns>
        public static byte[] ToModbus(byte[] byteData)
        {
            byte[] CRC = new byte[2];

            UInt16 wCrc = 0xFFFF;
            for (int i = 0; i < byteData.Length; i++)
            {
                wCrc ^= Convert.ToUInt16(byteData[i]);
                for (int j = 0; j < 8; j++)
                {
                    if ((wCrc & 0x0001) == 1)
                    {
                        wCrc >>= 1;
                        wCrc ^= 0xA001;//异或多项式
                    }
                    else
                    {
                        wCrc >>= 1;
                    }
                }
            }

            CRC[1] = (byte)((wCrc & 0xFF00) >> 8);//高位在后
            CRC[0] = (byte)(wCrc & 0x00FF);       //低位在前
            return CRC;

        }
 

        /// <summary>
        /// CRC16_Modbus效验
        /// </summary>
        /// <param name="byteData">要进行计算的字节数组</param>
        /// <param name="byteLength">长度</param>
        /// <returns>计算后的数组</returns>
        public static byte[] ToModbus(byte[] byteData, int byteLength)
        {
            byte[] CRC = new byte[2];

            UInt16 wCrc = 0xFFFF;
            for (int i = 0; i < byteLength; i++)
            {
                wCrc ^= Convert.ToUInt16(byteData[i]);
                for (int j = 0; j < 8; j++)
                {
                    if ((wCrc & 0x0001) == 1)
                    {
                        wCrc >>= 1;
                        wCrc ^= 0xA001;//异或多项式
                    }
                    else
                    {
                        wCrc >>= 1;
                    }
                }
            }

            CRC[1] = (byte)((wCrc & 0xFF00) >> 8);//高位在后
            CRC[0] = (byte)(wCrc & 0x00FF);       //低位在前
            return CRC;
        }

    }

    public enum enum_MSG05_ITEM
    { 
        MSG05_ITEM_SPEED = 0,
        MSG05_ITEM_INSTANTANEOUS_POWER,
        MSG05_ITEM_INSTANTANEOUS_ENERGY_CONSUMPTION,
        MSG05_ITEM_HUNDRED_KILOMETER_OF_ENERGY_CONSUMPTION,
        MSG05_ITEM_GEAR,
        MSG05_ITEM_PAGE,
        MSG05_ITEM_RUNNING_PAGE_DISP,
        MSG05_ITEM_POPUP_PAGE_DISP,

        MSG05_ITEM_ERR
    };

    public enum enum_GEAR
    {
        GEAR_DISAPPEAR = 0,  //消失
        GEAR_R,
        GEAR_D,
        GEAR_N,
        GEAR_P,

        GEAR_ERR,
    };

    public enum enum_PAGE
    { 
        PAGE_BLACK = 0,//黑屏
        PAGE_SELFTEST, //自检
        PAGE_RUNNING,  //行车
        PAGE_POPUP,    //弹窗
        PAGE_CHARGING, //充电

        PAGE_ERR,
    };

    public enum enum_RUNNING_PAGE_DISP
    { 
        RUNNING_PAGE_DISP_SPEED = 0,    //车速
        RUNNING_PAGE_DISP_DRIVE_TIME,   //行驶时间
        RUNNING_PAGE_DISP_TOTAL_VOLTAGE,//总电压
        RUNNING_PAGE_DISP_SINGAL_VOLTAGE,//单体电压
        RUNNING_PAGE_DISP_TIRE_PRESSURE, //胎压

        RUNNING_PAGE_DISP_ERR
    };

    public enum enum_POPUP_PAGE_DISP
    { 
        POPUP_PAGE_DISP_NONE = 0, //无弹窗
        POPUP_PAGE_DISP_READY,    //READY
        POPUP_PAGE_DISP_BREAK_POWER_RECOVERY, //制动能量回收
        POPUP_PAGE_DISP_STOP,     //STOP
        POPUP_PAGE_DISP_LOW_SPEED_WARING,     //低速警语

        POPUP_PAGE_DISP_ERR
    };

    class MsgFrame05 : MsgFrame
    {
        public UInt16 Speed = 0;    //车速
        public UInt16 InstantaneousPower = 0;  //瞬时功率
        public UInt16 InstantaneousEnergyConsumption = 0;//瞬时能耗
        public UInt16 HundredKilometersOfEnergyConsumption = 0;//百公里能耗
        public enum_GEAR Gear = (enum_GEAR)0;
        public enum_PAGE Page = (enum_PAGE)0;
        public enum_RUNNING_PAGE_DISP RunningPageDisp = (enum_RUNNING_PAGE_DISP)0;
        public enum_POPUP_PAGE_DISP PopupPageDisp = (enum_POPUP_PAGE_DISP)0;

        public delegate void ItemValueChangeHandler(enum_MSG05_ITEM item, Int32 val);
        public event ItemValueChangeHandler ItemValueChangeEvent;

        public delegate void SpeedChangedHandler(UInt16 value);
        public event SpeedChangedHandler SpeedChanged;

        public void SetSpeed(enum_MSG05_ITEM item, UInt16 speed)
        {
            /*switch (item)
            {
                case (enum_MSG05_ITEM)MSG05_ITEM_SPEED:
                    break;
                case MSG05_ITEM_INSTANTANEOUS_POWER:
                    break;
                case MSG05_ITEM_INSTANTANEOUS_ENERGY_CONSUMPTION:
                    break;
                case MSG05_ITEM_HUNDRED_KILOMETER_OF_ENERGY_CONSUMPTION:
                    break;
                case MSG05_ITEM_GEAR:
                    break;
                case MSG05_ITEM_PAGE:
                    break;
                case MSG05_ITEM_RUNNING_PAGE_DISP:
                    break;
                case MSG05_ITEM_POPUP_PAGE_DISP:
                    break;
            }*/
            if (SpeedChanged != null)
            {
                SpeedChanged(speed);
            }
        }
    }
}
