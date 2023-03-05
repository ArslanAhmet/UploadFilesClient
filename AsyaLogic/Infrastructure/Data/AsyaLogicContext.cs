using AsyaLogic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AsyaLogic.Infrastructure.Data
{
    public class AsyaLogicContext : DbContext
    {
        public DbSet<EventRecord> EventRecords { get; set; }
        public DbSet<RecordChange> RecordColumnChanges { get; set; }
        public AsyaLogicContext(DbContextOptions<AsyaLogicContext> options)
            : base(options)
        {
        }
    }
}
