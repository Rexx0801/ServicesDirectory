using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Organisation",
                columns: table => new
                {
                    OrganisationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganisationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HeadOfficeAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisation_1", x => x.OrganisationId);
                    table.ForeignKey(
                        name: "FK_Organisation_Contact",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "ContactId");
                });

            migrationBuilder.CreateTable(
                name: "County",
                columns: table => new
                {
                    CountyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_County", x => x.CountyId);
                    table.ForeignKey(
                        name: "FK_County_Country",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "Town",
                columns: table => new
                {
                    TownId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TownName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CountyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town", x => x.TownId);
                    table.ForeignKey(
                        name: "FK_Town_County",
                        column: x => x.CountyId,
                        principalTable: "County",
                        principalColumn: "CountyId");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressLine3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TownId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Town",
                        column: x => x.TownId,
                        principalTable: "Town",
                        principalColumn: "TownId");
                });

            migrationBuilder.CreateTable(
                name: "Premise",
                columns: table => new
                {
                    PremiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PremiseName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    KnownAs = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LocationStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocationStatusDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PrimaryLocation = table.Column<bool>(type: "bit", nullable: true),
                    LocationManaged = table.Column<bool>(type: "bit", nullable: true),
                    STNetworkConnectivity = table.Column<bool>(type: "bit", nullable: true),
                    LocationDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    GeneralFaxNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MiniCommNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsNewShop = table.Column<bool>(type: "bit", nullable: true),
                    ShopFlagDate = table.Column<DateOnly>(type: "date", nullable: true),
                    SpecialistShop = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    MediaContactName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LocalDemographicNotes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CateringContact = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CateringType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Network = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ClientITFacilitiesDetails = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RoomAvailability = table.Column<bool>(type: "bit", nullable: true),
                    TravelDetails = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TravelNearestBus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TravelNearestRail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TravelNearestAirport = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HostingContact = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VisitorParkingSpaces = table.Column<int>(type: "int", nullable: true),
                    VisitorParkingAlternative = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premise", x => x.PremiseId);
                    table.ForeignKey(
                        name: "FK_Premise_Address",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_Premise_Contact",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "ContactId");
                });

            migrationBuilder.CreateTable(
                name: "Accreditation",
                columns: table => new
                {
                    AccreditationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccreditationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PremiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accreditation", x => x.AccreditationId);
                    table.ForeignKey(
                        name: "FK_Accreditation_Premise",
                        column: x => x.PremiseId,
                        principalTable: "Premise",
                        principalColumn: "PremiseId");
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    FacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacilityType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FacilityDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RoomCapacity = table.Column<int>(type: "int", nullable: true),
                    RoomSize = table.Column<int>(type: "int", nullable: true),
                    ConnectivityType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WirelessAccessInformation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LeadContact = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RoomHost = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RoomAndEquipmentNotes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PremiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.FacilityId);
                    table.ForeignKey(
                        name: "FK_Facilities_Premise",
                        column: x => x.PremiseId,
                        principalTable: "Premise",
                        principalColumn: "PremiseId");
                });

            migrationBuilder.CreateTable(
                name: "JcpOffice",
                columns: table => new
                {
                    JcpOfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JcpOfficeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PremiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JcpOffice", x => x.JcpOfficeId);
                    table.ForeignKey(
                        name: "FK_JCPOffice_Premise",
                        column: x => x.PremiseId,
                        principalTable: "Premise",
                        principalColumn: "PremiseId");
                });

            migrationBuilder.CreateTable(
                name: "LocalDemographicIssues",
                columns: table => new
                {
                    LocalDemographicIssuesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocalDemographicIssuesName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PremiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalDemographicIssues", x => x.LocalDemographicIssuesId);
                    table.ForeignKey(
                        name: "FK_LocalDemographicIssues_Premise",
                        column: x => x.PremiseId,
                        principalTable: "Premise",
                        principalColumn: "PremiseId");
                });

            migrationBuilder.CreateTable(
                name: "LocalHotels",
                columns: table => new
                {
                    LocalHotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocalHotelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PremiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalHotels", x => x.LocalHotelId);
                    table.ForeignKey(
                        name: "FK_LocalHotels_Premise",
                        column: x => x.PremiseId,
                        principalTable: "Premise",
                        principalColumn: "PremiseId");
                });

            migrationBuilder.CreateTable(
                name: "LocationOpenDay",
                columns: table => new
                {
                    LocationOpenDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeekendDay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    PremiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationOpenDay", x => x.LocationOpenDayId);
                    table.ForeignKey(
                        name: "FK_LocationOpenDay_Premise",
                        column: x => x.PremiseId,
                        principalTable: "Premise",
                        principalColumn: "PremiseId");
                });

            migrationBuilder.CreateTable(
                name: "LocationType",
                columns: table => new
                {
                    LocationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PremiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationType", x => x.LocationTypeId);
                    table.ForeignKey(
                        name: "FK_LocationType_Premise",
                        column: x => x.PremiseId,
                        principalTable: "Premise",
                        principalColumn: "PremiseId");
                });

            migrationBuilder.CreateTable(
                name: "MinorWorks",
                columns: table => new
                {
                    MinorWorkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsMinorWorks = table.Column<bool>(type: "bit", nullable: true),
                    NotesActions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EstimatedCost = table.Column<double>(type: "float", nullable: true),
                    ActualCost = table.Column<double>(type: "float", nullable: true),
                    Directorate = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AuthorisedByName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    EnqReceivedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    AuthorisedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ActualStartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    AnticipatedCompletion = table.Column<DateOnly>(type: "date", nullable: true),
                    ActualCompletionDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    PremiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinorWorks", x => x.MinorWorkId);
                    table.ForeignKey(
                        name: "FK_MinorWorks_Premise",
                        column: x => x.PremiseId,
                        principalTable: "Premise",
                        principalColumn: "PremiseId");
                });

            migrationBuilder.CreateTable(
                name: "OutreachLocation",
                columns: table => new
                {
                    OutreachLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OuttreachLocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PremiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutreachLocation", x => x.OutreachLocationId);
                    table.ForeignKey(
                        name: "FK_OutreachLocation_Premise",
                        column: x => x.PremiseId,
                        principalTable: "Premise",
                        principalColumn: "PremiseId");
                });

            migrationBuilder.CreateTable(
                name: "PremiseRate",
                columns: table => new
                {
                    PrimiseRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomOnlyRate = table.Column<double>(type: "float", nullable: true),
                    BBRate = table.Column<double>(type: "float", nullable: true),
                    DBBRate = table.Column<double>(type: "float", nullable: true),
                    DDRate = table.Column<double>(type: "float", nullable: true),
                    Rate24hr = table.Column<double>(type: "float", nullable: true),
                    TeaAndCoofee = table.Column<double>(type: "float", nullable: true),
                    Lunch = table.Column<bool>(type: "bit", nullable: true),
                    NoOfMeetingRooms = table.Column<int>(type: "int", nullable: true),
                    MeetingRoomRatePerDay = table.Column<double>(type: "float", nullable: true),
                    Codings = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NegotiatedRoomOnlyRate = table.Column<double>(type: "float", nullable: true),
                    BBNegotiatedRate = table.Column<double>(type: "float", nullable: true),
                    DBBNegotiatedRate = table.Column<double>(type: "float", nullable: true),
                    RateNegoteated24hr = table.Column<double>(type: "float", nullable: true),
                    LastNegotiatedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ReNegotiateOn = table.Column<DateOnly>(type: "date", nullable: true),
                    PreferredStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PremiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimiseRate", x => x.PrimiseRateId);
                    table.ForeignKey(
                        name: "FK_PrimiseRate_Premise",
                        column: x => x.PremiseId,
                        principalTable: "Premise",
                        principalColumn: "PremiseId");
                });

            migrationBuilder.CreateTable(
                name: "Volunteering",
                columns: table => new
                {
                    VolunteeringId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VolunteeringContact = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    VolunteeringPurpose = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    VolunteeringOpportunityDetails = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    VolunteerNos = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    PremiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteering", x => x.VolunteeringId);
                    table.ForeignKey(
                        name: "FK_Volunteering_Premise",
                        column: x => x.PremiseId,
                        principalTable: "Premise",
                        principalColumn: "PremiseId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accreditation_PremiseId",
                table: "Accreditation",
                column: "PremiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_TownId",
                table: "Address",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_County_CountryId",
                table: "County",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_PremiseId",
                table: "Facilities",
                column: "PremiseId");

            migrationBuilder.CreateIndex(
                name: "IX_JcpOffice_PremiseId",
                table: "JcpOffice",
                column: "PremiseId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalDemographicIssues_PremiseId",
                table: "LocalDemographicIssues",
                column: "PremiseId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalHotels_PremiseId",
                table: "LocalHotels",
                column: "PremiseId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationOpenDay_PremiseId",
                table: "LocationOpenDay",
                column: "PremiseId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationType_PremiseId",
                table: "LocationType",
                column: "PremiseId");

            migrationBuilder.CreateIndex(
                name: "IX_MinorWorks_PremiseId",
                table: "MinorWorks",
                column: "PremiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisation_ContactId",
                table: "Organisation",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_OutreachLocation_PremiseId",
                table: "OutreachLocation",
                column: "PremiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Premise_AddressId",
                table: "Premise",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Premise_ContactId",
                table: "Premise",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PremiseRate_PremiseId",
                table: "PremiseRate",
                column: "PremiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Town_CountyId",
                table: "Town",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteering_PremiseId",
                table: "Volunteering",
                column: "PremiseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accreditation");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "JcpOffice");

            migrationBuilder.DropTable(
                name: "LocalDemographicIssues");

            migrationBuilder.DropTable(
                name: "LocalHotels");

            migrationBuilder.DropTable(
                name: "LocationOpenDay");

            migrationBuilder.DropTable(
                name: "LocationType");

            migrationBuilder.DropTable(
                name: "MinorWorks");

            migrationBuilder.DropTable(
                name: "Organisation");

            migrationBuilder.DropTable(
                name: "OutreachLocation");

            migrationBuilder.DropTable(
                name: "PremiseRate");

            migrationBuilder.DropTable(
                name: "Volunteering");

            migrationBuilder.DropTable(
                name: "Premise");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Town");

            migrationBuilder.DropTable(
                name: "County");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
