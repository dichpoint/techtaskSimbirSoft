using System;
using System.Data.Entity; // технология, позволяющая работать с СУБД

namespace techtaskSimbirSoft
{
    // связь с БД
    class AppContext : DbContext
    {
        public DbSet<UniqueWord> UniqueWords { get; set; }

        public AppContext() : base("DefaultConnection") { }
    }
}