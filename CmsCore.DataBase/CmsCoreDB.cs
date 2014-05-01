using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.DataBase
{
    public class CmsCoreDB : DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<Site> Site { get; set; }

        public DbSet<ReleasePoint> ReleasePoint { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<ContentModel> ContentModel { get; set; }

        public DbSet<ContentModelField> ContentModelField { get; set; }

        public DbSet<SinglePage> SinglePage { get; set; }
    }
}