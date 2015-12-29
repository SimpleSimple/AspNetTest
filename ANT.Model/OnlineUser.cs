using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANT.Model
{
    public class OnlineUser
    {
        public int id { get; set; }

        public int user_id { get; set; }

        public DateTime signin_time { get; set; }

        public DateTime signout_time { get; set; }

        public DateTime create_time { get; set; }
    }
}
