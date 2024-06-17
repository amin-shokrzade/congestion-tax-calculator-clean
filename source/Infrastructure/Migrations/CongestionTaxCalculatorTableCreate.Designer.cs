using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("CongestionTaxCalculatorTableCreate")]
    partial class CongestionTaxCalculatorTableCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Persian_100_CS_AS_KS_WS_SC_UTF8")
                .HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);


            modelBuilder.Entity("congestion-tax-calculator-clean.Domain.Entities.VehicleType", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Title")
                    .HasColumnType("nvarchar(32)")
                    .IsRequired()
                    .HasMaxLength(32);

                b.Property<int>("SortOrder")
                    .HasColumnType("int")
                    .IsRequired();

                b.Property<DateTimeOffset>("CreatedOn")
                    .HasColumnType("datetimeoffset")
                    .IsRequired(required: true);

                b.Property<Guid>("Creator")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTimeOffset>("ModifiedOn")
                    .HasColumnType("datetimeoffset")
                    .IsRequired(required: true);

                b.Property<Guid>("Modifier")
                    .HasColumnType("uniqueidentifier");

                b.Property<bool>("Deleted")
                    .HasColumnType("bit");

                b.HasKey("Id");

                b.ToTable("VehicleTypes");
            });


            modelBuilder.Entity("congestion-tax-calculator-clean.Domain.Entities.Vehicle", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(64)")
                    .HasMaxLength(64);

                b.Property<string>("PlateNumber")
                    .HasColumnType("nvarchar(16)")
                    .HasMaxLength(16);

                b.Property<Guid>("VehicleTypeId")
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                b.Property<DateTimeOffset>("CreatedOn")
                    .HasColumnType("datetimeoffset")
                    .IsRequired(required: true);

                b.Property<Guid>("Creator")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTimeOffset>("ModifiedOn")
                    .HasColumnType("datetimeoffset")
                    .IsRequired(required: true);

                b.Property<Guid>("Modifier")
                    .HasColumnType("uniqueidentifier");

                b.Property<bool>("Deleted")
                    .HasColumnType("bit");

                b.HasKey("Id");

                b.HasIndex("VehicleTypeId");

                b.ToTable("Vehicles");
            });

            modelBuilder.Entity("congestion-tax-calculator-clean.Domain.Entities.City", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(32)")
                    .IsRequired()
                    .HasMaxLength(32);

                b.Property<int>("MaxDailyTax")
                    .IsRequired()
                    .HasColumnType("int");

                b.Property<int>("SingleChargeRuleTimeInMinute")
                   .IsRequired()
                   .HasColumnType("int");

                b.Property<string>("TaxFreeWeekDays")
                    .HasColumnType("nvarchar(64)")
                    .HasMaxLength(64);

                b.Property<string>("TaxFreeMonths")
                    .HasColumnType("nvarchar(32)")
                    .HasMaxLength(32);

                b.Property<DateTimeOffset>("CreatedOn")
                    .HasColumnType("datetimeoffset")
                    .IsRequired(required: true);

                b.Property<Guid>("Creator")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTimeOffset>("ModifiedOn")
                    .HasColumnType("datetimeoffset")
                    .IsRequired(required: true);

                b.Property<Guid>("Modifier")
                    .HasColumnType("uniqueidentifier");

                b.Property<bool>("Deleted")
                    .HasColumnType("bit");

                b.HasKey("Id");

                b.ToTable("Cities");
            });

            modelBuilder.Entity("congestion-tax-calculator-clean.Domain.Entities.TaxFreeDate", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("FreeDate")
                    .HasColumnType("datetime2")
                    .IsRequired();

                b.Property<Guid>("CityId")
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                b.Property<DateTimeOffset>("CreatedOn")
                    .HasColumnType("datetimeoffset")
                    .IsRequired(required: true);

                b.Property<Guid>("Creator")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTimeOffset>("ModifiedOn")
                    .HasColumnType("datetimeoffset")
                    .IsRequired(required: true);

                b.Property<Guid>("Modifier")
                    .HasColumnType("uniqueidentifier");

                b.Property<bool>("Deleted")
                    .HasColumnType("bit");

                b.HasKey("Id");

                b.HasIndex("CityId");

                b.ToTable("TaxFreeDates");
            });

            modelBuilder.Entity("congestion-tax-calculator-clean.Domain.Entities.TaxFreeVehicle", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                b.Property<Guid>("CityId")
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                b.Property<Guid>("VehicleTypeId")
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                b.Property<DateTimeOffset>("CreatedOn")
                    .HasColumnType("datetimeoffset")
                    .IsRequired(required: true);

                b.Property<Guid>("Creator")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTimeOffset>("ModifiedOn")
                    .HasColumnType("datetimeoffset")
                    .IsRequired(required: true);

                b.Property<Guid>("Modifier")
                    .HasColumnType("uniqueidentifier");

                b.Property<bool>("Deleted")
                    .HasColumnType("bit");

                b.HasKey("Id");

                b.HasIndex("CityId");

                b.HasIndex("VehicleTypeId");

                b.ToTable("TaxFreeVehicles");
            });

            modelBuilder.Entity("congestion-tax-calculator-clean.Domain.Entities.TimeAndTaxAmount", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("uniqueidentifier")
                    .ValueGeneratedOnAdd();

                b.Property<TimeSpan>("From")
                    .HasColumnType("time")
                    .IsRequired();

                b.Property<TimeSpan>("To")
                    .HasColumnType("time")
                    .IsRequired();

                b.Property<int>("Amount")
                    .HasColumnType("int")
                    .IsRequired();

                b.Property<Guid>("CityId")
                    .HasColumnType("uniqueidentifier")
                    .IsRequired();

                b.Property<DateTimeOffset>("CreatedOn")
                    .HasColumnType("datetimeoffset")
                    .IsRequired(required: true);

                b.Property<Guid>("Creator")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTimeOffset>("ModifiedOn")
                    .HasColumnType("datetimeoffset")
                    .IsRequired(required: true);

                b.Property<Guid>("Modifier")
                    .HasColumnType("uniqueidentifier");

                b.Property<bool>("Deleted")
                    .HasColumnType("bit");

                b.HasKey("Id");

                b.HasIndex("CityId");

                b.ToTable("TimeAndTaxAmounts");
            });

#pragma warning restore 612, 618
        }
    }
}
