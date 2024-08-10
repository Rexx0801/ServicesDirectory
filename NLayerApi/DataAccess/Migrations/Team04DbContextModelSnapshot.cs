﻿// <auto-generated />
using System;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(Team04DbContext))]
    partial class Team04DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Entities.Accreditation", b =>
                {
                    b.Property<Guid>("AccreditationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccreditationName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("PremiseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AccreditationId");

                    b.HasIndex("PremiseId");

                    b.ToTable("Accreditation");
                });

            modelBuilder.Entity("DataAccess.Entities.Address", b =>
                {
                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AddressLine3")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("TownId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AddressId");

                    b.HasIndex("TownId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DataAccess.Entities.Contact", b =>
                {
                    b.Property<Guid>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ContactType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MobilePhone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ContactId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("DataAccess.Entities.Country", b =>
                {
                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CountryId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("DataAccess.Entities.County", b =>
                {
                    b.Property<Guid>("CountyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountyName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CountyId");

                    b.HasIndex("CountryId");

                    b.ToTable("County");
                });

            modelBuilder.Entity("DataAccess.Entities.Facility", b =>
                {
                    b.Property<Guid>("FacilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConnectivityType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FacilityDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FacilityType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LeadContact")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PremiseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoomAndEquipmentNotes")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("RoomCapacity")
                        .HasColumnType("int");

                    b.Property<string>("RoomHost")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("RoomSize")
                        .HasColumnType("int");

                    b.Property<string>("WirelessAccessInformation")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("FacilityId");

                    b.HasIndex("PremiseId");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("DataAccess.Entities.JcpOffice", b =>
                {
                    b.Property<Guid>("JcpOfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JcpOfficeName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PremiseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("JcpOfficeId");

                    b.HasIndex("PremiseId");

                    b.ToTable("JcpOffice");
                });

            modelBuilder.Entity("DataAccess.Entities.LocalDemographicIssue", b =>
                {
                    b.Property<Guid>("LocalDemographicIssuesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocalDemographicIssuesName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PremiseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LocalDemographicIssuesId");

                    b.HasIndex("PremiseId");

                    b.ToTable("LocalDemographicIssues");
                });

            modelBuilder.Entity("DataAccess.Entities.LocalHotel", b =>
                {
                    b.Property<Guid>("LocalHotelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocalHotelName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PremiseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LocalHotelId");

                    b.HasIndex("PremiseId");

                    b.ToTable("LocalHotels");
                });

            modelBuilder.Entity("DataAccess.Entities.LocationOpenDay", b =>
                {
                    b.Property<Guid>("LocationOpenDayId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("PremiseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.Property<string>("WeekendDay")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LocationOpenDayId");

                    b.HasIndex("PremiseId");

                    b.ToTable("LocationOpenDay");
                });

            modelBuilder.Entity("DataAccess.Entities.LocationType", b =>
                {
                    b.Property<Guid>("LocationTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PremiseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LocationTypeId");

                    b.HasIndex("PremiseId");

                    b.ToTable("LocationType");
                });

            modelBuilder.Entity("DataAccess.Entities.MinorWork", b =>
                {
                    b.Property<Guid>("MinorWorkId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly?>("ActualCompletionDate")
                        .HasColumnType("date");

                    b.Property<double?>("ActualCost")
                        .HasColumnType("float");

                    b.Property<DateOnly?>("ActualStartDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("AnticipatedCompletion")
                        .HasColumnType("date");

                    b.Property<string>("AuthorisedByName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateOnly?>("AuthorisedDate")
                        .HasColumnType("date");

                    b.Property<string>("Contact")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Directorate")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateOnly?>("EnqReceivedDate")
                        .HasColumnType("date");

                    b.Property<double?>("EstimatedCost")
                        .HasColumnType("float");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsMinorWorks")
                        .HasColumnType("bit");

                    b.Property<string>("NotesActions")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("PremiseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("MinorWorkId");

                    b.HasIndex("PremiseId");

                    b.ToTable("MinorWorks");
                });

            modelBuilder.Entity("DataAccess.Entities.Organisation", b =>
                {
                    b.Property<Guid>("OrganisationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HeadOfficeAddress")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("OrganisationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Postcode")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("OrganisationId")
                        .HasName("PK_Organisation_1");

                    b.HasIndex("ContactId");

                    b.ToTable("Organisation");
                });

            modelBuilder.Entity("DataAccess.Entities.OutreachLocation", b =>
                {
                    b.Property<Guid>("OutreachLocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OuttreachLocationName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PremiseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OutreachLocationId");

                    b.HasIndex("PremiseId");

                    b.ToTable("OutreachLocation");
                });

            modelBuilder.Entity("DataAccess.Entities.Premise", b =>
                {
                    b.Property<Guid>("PremiseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CateringContact")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CateringType")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ClientITFacilitiesDetails")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GeneralFaxNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HostingContact")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsNewShop")
                        .HasColumnType("bit");

                    b.Property<string>("KnownAs")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LocalDemographicNotes")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LocationDescription")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("LocationManaged")
                        .HasColumnType("bit");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LocationStatus")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly?>("LocationStatusDate")
                        .HasColumnType("date");

                    b.Property<string>("MediaContactName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("MiniCommNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Network")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PremiseName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("PrimaryLocation")
                        .HasColumnType("bit");

                    b.Property<bool?>("RoomAvailability")
                        .HasColumnType("bit");

                    b.Property<bool?>("STNetworkConnectivity")
                        .HasColumnType("bit");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly?>("ShopFlagDate")
                        .HasColumnType("date");

                    b.Property<bool>("SpecialistShop")
                        .HasColumnType("bit");

                    b.Property<string>("TravelDetails")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TravelNearestAirport")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TravelNearestBus")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TravelNearestRail")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("VisitorParkingAlternative")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("VisitorParkingSpaces")
                        .HasColumnType("int");

                    b.HasKey("PremiseId");

                    b.HasIndex("AddressId");

                    b.HasIndex("ContactId");

                    b.ToTable("Premise");
                });

            modelBuilder.Entity("DataAccess.Entities.PremiseRate", b =>
                {
                    b.Property<Guid>("PrimiseRateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("BBNegotiatedRate")
                        .HasColumnType("float");

                    b.Property<double?>("BBRate")
                        .HasColumnType("float");

                    b.Property<string>("Codings")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Comments")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<double?>("DBBNegotiatedRate")
                        .HasColumnType("float");

                    b.Property<double?>("DBBRate")
                        .HasColumnType("float");

                    b.Property<double?>("DDRate")
                        .HasColumnType("float");

                    b.Property<DateOnly?>("LastNegotiatedDate")
                        .HasColumnType("date");

                    b.Property<bool?>("Lunch")
                        .HasColumnType("bit");

                    b.Property<double?>("MeetingRoomRatePerDay")
                        .HasColumnType("float");

                    b.Property<double?>("NegotiatedRoomOnlyRate")
                        .HasColumnType("float");

                    b.Property<int?>("NoOfMeetingRooms")
                        .HasColumnType("int");

                    b.Property<string>("PreferredStatus")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PremiseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Rate24hr")
                        .HasColumnType("float");

                    b.Property<double?>("RateNegoteated24hr")
                        .HasColumnType("float");

                    b.Property<DateOnly?>("ReNegotiateOn")
                        .HasColumnType("date");

                    b.Property<double?>("RoomOnlyRate")
                        .HasColumnType("float");

                    b.Property<double?>("TeaAndCoofee")
                        .HasColumnType("float");

                    b.HasKey("PrimiseRateId")
                        .HasName("PK_PrimiseRate");

                    b.HasIndex("PremiseId");

                    b.ToTable("PremiseRate");
                });

            modelBuilder.Entity("DataAccess.Entities.Town", b =>
                {
                    b.Property<Guid>("TownId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TownName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TownId");

                    b.HasIndex("CountyId");

                    b.ToTable("Town");
                });

            modelBuilder.Entity("DataAccess.Entities.Volunteering", b =>
                {
                    b.Property<Guid>("VolunteeringId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("PremiseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("date");

                    b.Property<int?>("VolunteerNos")
                        .HasColumnType("int");

                    b.Property<string>("VolunteeringContact")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("VolunteeringOpportunityDetails")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("VolunteeringPurpose")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("VolunteeringId");

                    b.HasIndex("PremiseId");

                    b.ToTable("Volunteering");
                });

            modelBuilder.Entity("DataAccess.Entities.Accreditation", b =>
                {
                    b.HasOne("DataAccess.Entities.Premise", "Premise")
                        .WithMany("Accreditations")
                        .HasForeignKey("PremiseId")
                        .HasConstraintName("FK_Accreditation_Premise");

                    b.Navigation("Premise");
                });

            modelBuilder.Entity("DataAccess.Entities.Address", b =>
                {
                    b.HasOne("DataAccess.Entities.Town", "Town")
                        .WithMany("Addresses")
                        .HasForeignKey("TownId")
                        .IsRequired()
                        .HasConstraintName("FK_Address_Town");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("DataAccess.Entities.County", b =>
                {
                    b.HasOne("DataAccess.Entities.Country", "Country")
                        .WithMany("Counties")
                        .HasForeignKey("CountryId")
                        .IsRequired()
                        .HasConstraintName("FK_County_Country");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("DataAccess.Entities.Facility", b =>
                {
                    b.HasOne("DataAccess.Entities.Premise", "Premise")
                        .WithMany("Facilities")
                        .HasForeignKey("PremiseId")
                        .IsRequired()
                        .HasConstraintName("FK_Facilities_Premise");

                    b.Navigation("Premise");
                });

            modelBuilder.Entity("DataAccess.Entities.JcpOffice", b =>
                {
                    b.HasOne("DataAccess.Entities.Premise", "Premise")
                        .WithMany("JCPOffices")
                        .HasForeignKey("PremiseId")
                        .IsRequired()
                        .HasConstraintName("FK_JCPOffice_Premise");

                    b.Navigation("Premise");
                });

            modelBuilder.Entity("DataAccess.Entities.LocalDemographicIssue", b =>
                {
                    b.HasOne("DataAccess.Entities.Premise", "Premise")
                        .WithMany("LocalDemographicIssues")
                        .HasForeignKey("PremiseId")
                        .IsRequired()
                        .HasConstraintName("FK_LocalDemographicIssues_Premise");

                    b.Navigation("Premise");
                });

            modelBuilder.Entity("DataAccess.Entities.LocalHotel", b =>
                {
                    b.HasOne("DataAccess.Entities.Premise", "Premise")
                        .WithMany("LocalHotels")
                        .HasForeignKey("PremiseId")
                        .IsRequired()
                        .HasConstraintName("FK_LocalHotels_Premise");

                    b.Navigation("Premise");
                });

            modelBuilder.Entity("DataAccess.Entities.LocationOpenDay", b =>
                {
                    b.HasOne("DataAccess.Entities.Premise", "Premise")
                        .WithMany("LocationOpenDays")
                        .HasForeignKey("PremiseId")
                        .IsRequired()
                        .HasConstraintName("FK_LocationOpenDay_Premise");

                    b.Navigation("Premise");
                });

            modelBuilder.Entity("DataAccess.Entities.LocationType", b =>
                {
                    b.HasOne("DataAccess.Entities.Premise", "Premise")
                        .WithMany("LocationTypes")
                        .HasForeignKey("PremiseId")
                        .IsRequired()
                        .HasConstraintName("FK_LocationType_Premise");

                    b.Navigation("Premise");
                });

            modelBuilder.Entity("DataAccess.Entities.MinorWork", b =>
                {
                    b.HasOne("DataAccess.Entities.Premise", "Premise")
                        .WithMany("MinorWorks")
                        .HasForeignKey("PremiseId")
                        .IsRequired()
                        .HasConstraintName("FK_MinorWorks_Premise");

                    b.Navigation("Premise");
                });

            modelBuilder.Entity("DataAccess.Entities.Organisation", b =>
                {
                    b.HasOne("DataAccess.Entities.Contact", "Contact")
                        .WithMany("Organisations")
                        .HasForeignKey("ContactId")
                        .IsRequired()
                        .HasConstraintName("FK_Organisation_Contact");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("DataAccess.Entities.OutreachLocation", b =>
                {
                    b.HasOne("DataAccess.Entities.Premise", "Premise")
                        .WithMany("OutreachLocations")
                        .HasForeignKey("PremiseId")
                        .IsRequired()
                        .HasConstraintName("FK_OutreachLocation_Premise");

                    b.Navigation("Premise");
                });

            modelBuilder.Entity("DataAccess.Entities.Premise", b =>
                {
                    b.HasOne("DataAccess.Entities.Address", "Address")
                        .WithMany("Premises")
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("FK_Premise_Address");

                    b.HasOne("DataAccess.Entities.Contact", "Contact")
                        .WithMany("Premises")
                        .HasForeignKey("ContactId")
                        .HasConstraintName("FK_Premise_Contact");

                    b.Navigation("Address");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("DataAccess.Entities.PremiseRate", b =>
                {
                    b.HasOne("DataAccess.Entities.Premise", "Premise")
                        .WithMany("PremiseRates")
                        .HasForeignKey("PremiseId")
                        .IsRequired()
                        .HasConstraintName("FK_PrimiseRate_Premise");

                    b.Navigation("Premise");
                });

            modelBuilder.Entity("DataAccess.Entities.Town", b =>
                {
                    b.HasOne("DataAccess.Entities.County", "County")
                        .WithMany("Towns")
                        .HasForeignKey("CountyId")
                        .IsRequired()
                        .HasConstraintName("FK_Town_County");

                    b.Navigation("County");
                });

            modelBuilder.Entity("DataAccess.Entities.Volunteering", b =>
                {
                    b.HasOne("DataAccess.Entities.Premise", "Premise")
                        .WithMany("Volunteerings")
                        .HasForeignKey("PremiseId")
                        .IsRequired()
                        .HasConstraintName("FK_Volunteering_Premise");

                    b.Navigation("Premise");
                });

            modelBuilder.Entity("DataAccess.Entities.Address", b =>
                {
                    b.Navigation("Premises");
                });

            modelBuilder.Entity("DataAccess.Entities.Contact", b =>
                {
                    b.Navigation("Organisations");

                    b.Navigation("Premises");
                });

            modelBuilder.Entity("DataAccess.Entities.Country", b =>
                {
                    b.Navigation("Counties");
                });

            modelBuilder.Entity("DataAccess.Entities.County", b =>
                {
                    b.Navigation("Towns");
                });

            modelBuilder.Entity("DataAccess.Entities.Premise", b =>
                {
                    b.Navigation("Accreditations");

                    b.Navigation("Facilities");

                    b.Navigation("JCPOffices");

                    b.Navigation("LocalDemographicIssues");

                    b.Navigation("LocalHotels");

                    b.Navigation("LocationOpenDays");

                    b.Navigation("LocationTypes");

                    b.Navigation("MinorWorks");

                    b.Navigation("OutreachLocations");

                    b.Navigation("PremiseRates");

                    b.Navigation("Volunteerings");
                });

            modelBuilder.Entity("DataAccess.Entities.Town", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}