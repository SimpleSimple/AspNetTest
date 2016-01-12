using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console.Tests.Entity
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<long> BlogIds { get; set; }
    }
}
