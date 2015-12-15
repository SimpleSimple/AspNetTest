using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T4TemplateGenerator
{
    public class OnlineStatusLog
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTime ExitTime { get; set; }

        public DateTime CreateTime { get; set; }

        public int RoomID { get; set; }

        public string SystemType { get; set; }

        public string UserIP { get; set; }

        public int ProvinceID { get; set; }

        public int CityID { get; set; }

        public int SourceID { get; set; }

        public int OnlineType { get; set; }
    }
}
