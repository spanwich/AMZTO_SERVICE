using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
//using System.Web.Security;
using System.Linq;

namespace AMZTO_LOCAL
{
    public class UploadContext : DbContext
    {
        public UploadContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<LinkDataSet> LinkDataSet { get; set; }
    }

    [Table("LinkLists")]
    public class LinkDataSet
    {
        [Key]
        public int LinkID { get; set; }
        public String ShopName { get; set; }
        public String LinkShops { get; set; }
        public String sourceLink { get; set; }
        public String sourceType { get; set; }
        public int status { get; set; }
    }
}