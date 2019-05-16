using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC_QL_T15
{
    class msg_0x05:MsgFrame
    {
        private UInt16 speed = 0;    //车速
        private UInt16 instantaneous_power = 0;  //瞬时功率
        private UInt16 instantaneous_energy_consumption = 0;//瞬时能耗
        private UInt16 hundred_kilometers_of_energy_consumption = 0;//百公里能耗
        private enum_GEAR gear = (enum_GEAR)0;
        private enum_PAGE page = (enum_PAGE)0;
        private enum_RUNNING_PAGE_DISP running_page_disp = (enum_RUNNING_PAGE_DISP)0;
        private enum_POPUP_PAGE_DISP popup_page_disp = (enum_POPUP_PAGE_DISP)0;


    }
}
