﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC_QL_T712
{
    public class CmdLinesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsSelect { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RegType { get; set; }
        /// <summary>
        /// 页面
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RegID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WSValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RFormat { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public int NumOfLine { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<CmdLinesItem> CmdLines { get; set; }
    }

}
