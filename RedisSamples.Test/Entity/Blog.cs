﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console.Tests.Entity
{
    public class Blog
    {
        public Blog()
        {
            Tags = new List<string>();
            this.BlogPostIds = new List<long>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public List<string> Tags { get; set; }
        public List<long> BlogPostIds { get; set; }
    }
}
