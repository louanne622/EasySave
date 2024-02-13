using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveConsol_2.Model
{
    class DailyLog
    {
        private Save _save;
        public string name { get; set; }
        public string fileSource { get; set; }
        public string fileTarget { get; set; }
        public string size { get; set; }
        public string fileTransferTime { get; set; }
        public string time { get; set; }
    }
}
