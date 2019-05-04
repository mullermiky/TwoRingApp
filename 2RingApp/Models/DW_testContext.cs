using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _2RingApp.Models
{
    public partial class DW_testContext : DbContext
    {
        public DW_testContext()
        {
        }

        public DW_testContext(DbContextOptions<DW_testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactCallDetail> ContactCallDetail { get; set; }
        public virtual DbSet<ContactQueueDetail> ContactQueueDetail { get; set; }
        public virtual DbSet<ContactServiceQueue> ContactServiceQueue { get; set; }
        public virtual DbSet<RtCsqsSummary> RtCsqsSummary { get; set; }
        public virtual DbSet<UccxTimeZone> UccxTimeZone { get; set; }

        public virtual DbSet<SpGetData> SpGetData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-N00T9TF;Database=DW_test;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<ContactCallDetail>(entity =>
            {
                entity.HasKey(e => new { e.SessionId, e.SessionSeqNum, e.NodeId });

                entity.ToTable("ContactCallDetail", "journal");

                entity.Property(e => e.SessionId)
                    .HasColumnName("sessionID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SessionSeqNum).HasColumnName("sessionSeqNum");

                entity.Property(e => e.NodeId).HasColumnName("nodeID");

                entity.Property(e => e.ApplicationId).HasColumnName("applicationID");

                entity.Property(e => e.ApplicationName)
                    .HasColumnName("applicationName")
                    .HasMaxLength(30);

                entity.Property(e => e.Conference).HasColumnName("conference");

                entity.Property(e => e.ConnectTime).HasColumnName("connectTime");

                entity.Property(e => e.ContactDisposition).HasColumnName("contactDisposition");

                entity.Property(e => e.ContactType).HasColumnName("contactType");

                entity.Property(e => e.CustomVariable1)
                    .HasColumnName("customVariable1")
                    .HasMaxLength(40);

                entity.Property(e => e.CustomVariable10)
                    .HasColumnName("customVariable10")
                    .HasMaxLength(40);

                entity.Property(e => e.CustomVariable2)
                    .HasColumnName("customVariable2")
                    .HasMaxLength(40);

                entity.Property(e => e.CustomVariable3)
                    .HasColumnName("customVariable3")
                    .HasMaxLength(40);

                entity.Property(e => e.CustomVariable4)
                    .HasColumnName("customVariable4")
                    .HasMaxLength(40);

                entity.Property(e => e.CustomVariable5)
                    .HasColumnName("customVariable5")
                    .HasMaxLength(40);

                entity.Property(e => e.CustomVariable6)
                    .HasColumnName("customVariable6")
                    .HasMaxLength(40);

                entity.Property(e => e.CustomVariable7)
                    .HasColumnName("customVariable7")
                    .HasMaxLength(40);

                entity.Property(e => e.CustomVariable8)
                    .HasColumnName("customVariable8")
                    .HasMaxLength(40);

                entity.Property(e => e.CustomVariable9)
                    .HasColumnName("customVariable9")
                    .HasMaxLength(40);

                entity.Property(e => e.DestinationDn)
                    .HasColumnName("destinationDN")
                    .HasMaxLength(30);

                entity.Property(e => e.DestinationId).HasColumnName("destinationID");

                entity.Property(e => e.DestinationType).HasColumnName("destinationType");

                entity.Property(e => e.EndDateTime)
                    .HasColumnName("endDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.InsertDateTime)
                    .HasColumnName("insertDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OriginatorDn)
                    .HasColumnName("originatorDN")
                    .HasMaxLength(30);

                entity.Property(e => e.OriginatorId).HasColumnName("originatorID");

                entity.Property(e => e.OriginatorType).HasColumnName("originatorType");

                entity.Property(e => e.Redirect).HasColumnName("redirect");

                entity.Property(e => e.StartDateTime)
                    .HasColumnName("startDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Transfer).HasColumnName("transfer");

                entity.Property(e => e.UccxGmtOffset)
                    .HasColumnName("uccxGmtOffset")
                    .HasDefaultValueSql("([dbo].[GetUccxGmtOffsetInMinutes]())");

                entity.Property(e => e.UccxLocalEndDateTime)
                    .HasColumnName("uccxLocalEndDateTime")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(dateadd(minute,[uccxGmtOffset],[endDateTime]))");

                entity.Property(e => e.UccxLocalStartDateTime)
                    .HasColumnName("uccxLocalStartDateTime")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(dateadd(minute,[uccxGmtOffset],[startDateTime]))");
            });

            modelBuilder.Entity<ContactQueueDetail>(entity =>
            {
                entity.HasKey(e => new { e.SessionId, e.SessionSeqNum, e.NodeId, e.TargetId, e.TargetType, e.QIndex });

                entity.ToTable("ContactQueueDetail", "journal");

                entity.Property(e => e.SessionId)
                    .HasColumnName("sessionID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SessionSeqNum).HasColumnName("sessionSeqNum");

                entity.Property(e => e.NodeId).HasColumnName("nodeID");

                entity.Property(e => e.TargetId).HasColumnName("targetID");

                entity.Property(e => e.TargetType).HasColumnName("targetType");

                entity.Property(e => e.QIndex).HasColumnName("qIndex");

                entity.Property(e => e.Disposition).HasColumnName("disposition");

                entity.Property(e => e.InsertDateTime)
                    .HasColumnName("insertDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MetServiceLevel).HasColumnName("metServiceLevel");

                entity.Property(e => e.Queuetime).HasColumnName("queuetime");

                entity.Property(e => e.StartDateTime)
                    .HasColumnName("startDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UccxGmtOffset)
                    .HasColumnName("uccxGmtOffset")
                    .HasDefaultValueSql("([dbo].[GetUccxGmtOffsetInMinutes]())");

                entity.Property(e => e.UccxLocalStartDateTime)
                    .HasColumnName("uccxLocalStartDateTime")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(dateadd(minute,isnull([uccxGmtOffset],(0)),[startDateTime]))");
            });

            modelBuilder.Entity<ContactServiceQueue>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.ToTable("ContactServiceQueue", "enumeration");

                entity.Property(e => e.RecordId)
                    .HasColumnName("recordID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.ContactServiceQueueId).HasColumnName("contactServiceQueueID");

                entity.Property(e => e.CsqName)
                    .IsRequired()
                    .HasColumnName("csqName")
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDateTime)
                    .HasColumnName("insertDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("([dbo].[GetDateForUpdate]())");

                entity.Property(e => e.QueueType).HasColumnName("queueType");

                entity.Property(e => e.ResourceGroupId).HasColumnName("resourceGroupID");

                entity.Property(e => e.ResourcePoolType).HasColumnName("resourcePoolType");

                entity.Property(e => e.SkillGroupId).HasColumnName("skillGroupID");
            });

            modelBuilder.Entity<RtCsqsSummary>(entity =>
            {
                entity.HasKey(e => e.Csqname);

                entity.ToTable("RtCSQsSummary", "enumeration");

                entity.Property(e => e.Csqname)
                    .HasColumnName("csqname")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Availableagents).HasColumnName("availableagents");

                entity.Property(e => e.Callswaiting).HasColumnName("callswaiting");

                entity.Property(e => e.Enddatetime)
                    .HasColumnName("enddatetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Loggedinagents).HasColumnName("loggedinagents");

                entity.Property(e => e.Oldestcontact).HasColumnName("oldestcontact");

                entity.Property(e => e.Reservedagents).HasColumnName("reservedagents");

                entity.Property(e => e.Talkingagents).HasColumnName("talkingagents");

                entity.Property(e => e.Unavailableagents).HasColumnName("unavailableagents");

                entity.Property(e => e.UpdateDateTime)
                    .HasColumnName("updateDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("([dbo].[GetDateForUpdate]())");

                entity.Property(e => e.Workingagents).HasColumnName("workingagents");
            });

            modelBuilder.Entity<UccxTimeZone>(entity =>
            {
                entity.ToTable("UccxTimeZone", "dataCollection");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UccxLocalDateTime).HasColumnType("datetime");
            });
        }
    }
}
