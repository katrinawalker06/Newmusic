using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newmusic.Models;

namespace Newmusic.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Newmusic.Models.Band> Band { get; set; }
        public DbSet<Newmusic.Models.BandMember> BandMember { get; set; }
        public DbSet<Newmusic.Models.BandMemberBand> BandMemberBand { get; set; }
    }
}
