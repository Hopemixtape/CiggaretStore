﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Entities;
using System.Data.Entity;



namespace Store.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Ware> Wares { get; set; }

    }

}

