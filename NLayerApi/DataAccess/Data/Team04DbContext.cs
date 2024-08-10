using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data;

public class Team04DbContext : DbContext
{
    public Team04DbContext()
    {
    }

    public Team04DbContext(DbContextOptions<Team04DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accreditation> Accreditations { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<County> Counties { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<JcpOffice> JcpOffices { get; set; }

    public virtual DbSet<LocalDemographicIssue> LocalDemographicIssues { get; set; }

    public virtual DbSet<LocalHotel> LocalHotels { get; set; }

    public virtual DbSet<LocationOpenDay> LocationOpenDays { get; set; }

    public virtual DbSet<LocationType> LocationTypes { get; set; }

    public virtual DbSet<MinorWork> MinorWorks { get; set; }

    public virtual DbSet<Organisation> Organisations { get; set; }

    public virtual DbSet<OutreachLocation> OutreachLocations { get; set; }

    public virtual DbSet<Premise> Premises { get; set; }

    public virtual DbSet<PremiseRate> PremiseRates { get; set; }

    public virtual DbSet<Town> Towns { get; set; }

    public virtual DbSet<Volunteering> Volunteerings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlServer("Server=DESKTOP-6J6L1FC;Database=Team04Db;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accreditation>(entity =>
        {
            entity.Property(e => e.AccreditationId).ValueGeneratedNever();

            entity.HasOne(d => d.Premise).WithMany(p => p.Accreditations).HasConstraintName("FK_Accreditation_Premise");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.AddressId).ValueGeneratedNever();

            entity.HasOne(d => d.Town).WithMany(p => p.Addresses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_Town");
        });

        modelBuilder.Entity<Contact>(entity => { entity.Property(e => e.ContactId).ValueGeneratedNever(); });

        modelBuilder.Entity<Country>(entity => { entity.Property(e => e.CountryId).ValueGeneratedNever(); });

        modelBuilder.Entity<County>(entity =>
        {
            entity.Property(e => e.CountyId).ValueGeneratedNever();

            entity.HasOne(d => d.Country).WithMany(p => p.Counties)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_County_Country");
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.Property(e => e.FacilityId).ValueGeneratedNever();

            entity.HasOne(d => d.Premise).WithMany(p => p.Facilities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Facilities_Premise");
        });

        modelBuilder.Entity<JcpOffice>(entity =>
        {
            entity.Property(e => e.JcpOfficeId).ValueGeneratedNever();

            entity.HasOne(d => d.Premise).WithMany(p => p.JCPOffices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JCPOffice_Premise");
        });

        modelBuilder.Entity<LocalDemographicIssue>(entity =>
        {
            entity.Property(e => e.LocalDemographicIssuesId).ValueGeneratedNever();

            entity.HasOne(d => d.Premise).WithMany(p => p.LocalDemographicIssues)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LocalDemographicIssues_Premise");
        });

        modelBuilder.Entity<LocalHotel>(entity =>
        {
            entity.Property(e => e.LocalHotelId).ValueGeneratedNever();

            entity.HasOne(d => d.Premise).WithMany(p => p.LocalHotels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LocalHotels_Premise");
        });

        modelBuilder.Entity<LocationOpenDay>(entity =>
        {
            entity.Property(e => e.LocationOpenDayId).ValueGeneratedNever();

            entity.HasOne(d => d.Premise).WithMany(p => p.LocationOpenDays)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LocationOpenDay_Premise");
        });

        modelBuilder.Entity<LocationType>(entity =>
        {
            entity.Property(e => e.LocationTypeId).ValueGeneratedNever();

            entity.HasOne(d => d.Premise).WithMany(p => p.LocationTypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LocationType_Premise");
        });

        modelBuilder.Entity<MinorWork>(entity =>
        {
            entity.Property(e => e.MinorWorkId).ValueGeneratedNever();

            entity.HasOne(d => d.Premise).WithMany(p => p.MinorWorks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MinorWorks_Premise");
        });

        modelBuilder.Entity<Organisation>(entity =>
        {
            entity.HasKey(e => e.OrganisationId).HasName("PK_Organisation_1");

            entity.Property(e => e.OrganisationId).ValueGeneratedNever();

            entity.HasOne(d => d.Contact).WithMany(p => p.Organisations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Organisation_Contact");
        });

        modelBuilder.Entity<OutreachLocation>(entity =>
        {
            entity.Property(e => e.OutreachLocationId).ValueGeneratedNever();

            entity.HasOne(d => d.Premise).WithMany(p => p.OutreachLocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OutreachLocation_Premise");
        });

        modelBuilder.Entity<Premise>(entity =>
        {
            entity.Property(e => e.PremiseId).ValueGeneratedNever();

            entity.HasOne(d => d.Address).WithMany(p => p.Premises)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Premise_Address");

            entity.HasOne(d => d.Contact).WithMany(p => p.Premises).HasConstraintName("FK_Premise_Contact");
        });

        modelBuilder.Entity<PremiseRate>(entity =>
        {
            entity.HasKey(e => e.PrimiseRateId).HasName("PK_PrimiseRate");

            entity.Property(e => e.PrimiseRateId).ValueGeneratedNever();

            entity.HasOne(d => d.Premise).WithMany(p => p.PremiseRates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrimiseRate_Premise");
        });

        modelBuilder.Entity<Town>(entity =>
        {
            entity.Property(e => e.TownId).ValueGeneratedNever();

            entity.HasOne(d => d.County).WithMany(p => p.Towns)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Town_County");
        });

        modelBuilder.Entity<Volunteering>(entity =>
        {
            entity.Property(e => e.VolunteeringId).ValueGeneratedNever();

            entity.HasOne(d => d.Premise).WithMany(p => p.Volunteerings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Volunteering_Premise");
        });
    }
}