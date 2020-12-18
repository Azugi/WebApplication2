using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NewsSite.Models
{
    public class NewsContext: DbContext
    {
        public DbSet<News> News { get; set; }
    }
}