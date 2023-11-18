using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MarienProject.Api.Models;

public partial class MarienPharmacyContext : DbContext
{
    public MarienPharmacyContext()
    {
    }

    public MarienPharmacyContext(DbContextOptions<MarienPharmacyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomModels.AllCustomerData> AllCustomerDatas { get; set; }
    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Conversion> Conversions { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<DeliveryType> DeliveryTypes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }

    public virtual DbSet<GenericMedicationName> GenericMedicationNames { get; set; }

    public virtual DbSet<InternalMovement> InternalMovements { get; set; }

    public virtual DbSet<InvoiceStatus> InvoiceStatuses { get; set; }

    public virtual DbSet<Medication> Medications { get; set; }

    public virtual DbSet<MedicationCategory> MedicationCategories { get; set; }

    public virtual DbSet<MedicationDetail> MedicationDetails { get; set; }

    public virtual DbSet<MedicationInStock> MedicationInStocks { get; set; }

    public virtual DbSet<MedicationLaboratory> MedicationLaboratories { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Municipality> Municipalities { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    public virtual DbSet<RefreshTokenHistory> RefreshTokenHistories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleDetail> SaleDetails { get; set; }

    public virtual DbSet<ShelfCategory> ShelfCategories { get; set; }

    public virtual DbSet<ShelfLocationCategory> ShelfLocationCategories { get; set; }

    public virtual DbSet<StorageCategory> StorageCategories { get; set; }

    public virtual DbSet<StorageLocationCategory> StorageLocationCategories { get; set; }

    public virtual DbSet<StoredMedication> StoredMedications { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__City__3214EC07644C79C2");

            entity.ToTable("City");

            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Conversion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Conversi__3214EC07A4BC55D1");

            entity.ToTable("Conversion");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeleteAt)
                .HasColumnType("date")
                .HasColumnName("Delete_at");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UnitOfMeasurementId).HasColumnName("UnitOfMeasurement_Id");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("date")
                .HasColumnName("Update_at");

            entity.HasOne(d => d.UnitOfMeasurement).WithMany(p => p.Conversions)
                .HasForeignKey(d => d.UnitOfMeasurementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Conversio__UnitO__4CA06362");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Currency__3214EC07288719B6");

            entity.ToTable("Currency");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07EA706471");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.UserId, "UQ__Customer__1788CC4DABD3D834").IsUnique();

            entity.HasIndex(e => e.EmailAddress, "UQ__Customer__49A147405E2B5BA4").IsUnique();

            entity.HasIndex(e => e.Phone, "UQ__Customer__5C7E359EE5C9062D").IsUnique();

            entity.Property(e => e.EmailAddress).HasMaxLength(120);
            entity.Property(e => e.FirstNames).HasMaxLength(50);
            entity.Property(e => e.LastNames).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.State).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Role).WithMany(p => p.Customers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Customer_Role");

            entity.HasOne(d => d.User).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.UserId)
                .HasConstraintName("FK_Customer_User");
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC078B6CBCF7");

            entity.ToTable("CustomerAddress");

            entity.Property(e => e.Address).HasMaxLength(150);
            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.MunicipalityId).HasColumnName("Municipality_Id");
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Residence).HasMaxLength(150);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerA__Custo__208CD6FA");

            entity.HasOne(d => d.Municipality).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.MunicipalityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerA__Munic__2180FB33");
        });

        modelBuilder.Entity<DeliveryType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Delivery__3214EC07C2EFE678");

            entity.ToTable("DeliveryType");

            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Type).HasMaxLength(150);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07B677DEB3");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.UserId, "UQ__Employee__1788CC4DF854DEDD").IsUnique();

            entity.HasIndex(e => e.EmailAddress, "UQ__Employee__49A14740B19CA027").IsUnique();

            entity.HasIndex(e => e.Phone, "UQ__Employee__5C7E359ED08BBE13").IsUnique();

            entity.Property(e => e.Dni)
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EmailAddress).HasMaxLength(120);
            entity.Property(e => e.FirstNames).HasMaxLength(50);
            entity.Property(e => e.LastNames).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.State).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Client_Role");

            entity.HasOne(d => d.User).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.UserId)
                .HasConstraintName("FK_Client_User");
        });

        modelBuilder.Entity<ExchangeRate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ExchangeRate");

            entity.Property(e => e.CurrencyId).HasColumnName("Currency_Id");
            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.Currency).WithMany()
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExchangeR__Curre__123EB7A3");
        });

        modelBuilder.Entity<GenericMedicationName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GenericM__3214EC071796027E");

            entity.ToTable("GenericMedicationName");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeleteAt)
                .HasColumnType("date")
                .HasColumnName("Delete_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdateAt)
                .HasColumnType("date")
                .HasColumnName("Update_at");
        });

        modelBuilder.Entity<InternalMovement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Internal__3214EC07FC5579D1");

            entity.ToTable("InternalMovement");

            entity.Property(e => e.Batch)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("Created_at");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.DeleteAt)
                .HasColumnType("date")
                .HasColumnName("Delete_at");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.StoredMedicationId).HasColumnName("StoredMedication_Id");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("date")
                .HasColumnName("Update_at");

            entity.HasOne(d => d.StoredMedication).WithMany(p => p.InternalMovements)
                .HasForeignKey(d => d.StoredMedicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InternalM__Store__6383C8BA");
        });

        modelBuilder.Entity<InvoiceStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__InvoiceS__3214EC07288DBF76");

            entity.ToTable("InvoiceStatus");

            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.Status).HasMaxLength(150);
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Medicati__3214EC07E14DC109");

            entity.ToTable("Medication");

            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Category).WithMany(p => p.Medications)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medicatio__Categ__398D8EEE");
        });

        modelBuilder.Entity<MedicationCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Medicati__3214EC07BA95BD98");

            entity.ToTable("MedicationCategory");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<MedicationDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Medicati__3214EC0735F9C02B");

            entity.ToTable("MedicationDetail");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeleteAt)
                .HasColumnType("date")
                .HasColumnName("Delete_at");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.GenericMedicationNameId).HasColumnName("GenericMedicationName_Id");
            entity.Property(e => e.MedicationId).HasColumnName("Medication_Id");
            entity.Property(e => e.MedicationLaboratoryId).HasColumnName("MedicationLaboratory_Id");
            entity.Property(e => e.Prescription).HasColumnType("date");
            entity.Property(e => e.State).HasDefaultValueSql("((1))");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("date")
                .HasColumnName("Update_at");

            entity.HasOne(d => d.GenericMedicationName).WithMany(p => p.MedicationDetails)
                .HasForeignKey(d => d.GenericMedicationNameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medicatio__Gener__440B1D61");

            entity.HasOne(d => d.Medication).WithMany(p => p.MedicationDetails)
                .HasForeignKey(d => d.MedicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medicatio__Medic__4222D4EF");

            entity.HasOne(d => d.MedicationLaboratory).WithMany(p => p.MedicationDetails)
                .HasForeignKey(d => d.MedicationLaboratoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medicatio__Medic__4316F928");
        });

        modelBuilder.Entity<MedicationInStock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Medicati__3214EC07490CCB48");

            entity.ToTable("MedicationInStock");

            entity.Property(e => e.InternalMovementId).HasColumnName("InternalMovement_Id");
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.StoredMedicationId).HasColumnName("StoredMedication_Id");

            entity.HasOne(d => d.InternalMovement).WithMany(p => p.MedicationInStocks)
                .HasForeignKey(d => d.InternalMovementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medicatio__Inter__6754599E");

            entity.HasOne(d => d.Location).WithMany(p => p.MedicationInStocks)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__Medicatio__Locat__68487DD7");

            entity.HasOne(d => d.StoredMedication).WithMany(p => p.MedicationInStocks)
                .HasForeignKey(d => d.StoredMedicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medicatio__Store__66603565");
        });

        modelBuilder.Entity<MedicationLaboratory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Medicati__3214EC075E850D78");

            entity.ToTable("MedicationLaboratory");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeleteAt)
                .HasColumnType("date")
                .HasColumnName("Delete_at");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State).HasDefaultValueSql("((1))");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("date")
                .HasColumnName("Update_at");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__F6BCBF2ED44B4DEC");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu).HasColumnName("Id_Menu");
            entity.Property(e => e.IdMenuFather).HasColumnName("Id_MenuFather");
            entity.Property(e => e.IdRole).HasColumnName("Id_Role");
            entity.Property(e => e.MenuName).HasColumnName("Menu_Name");

            entity.HasOne(d => d.IdMenuFatherNavigation).WithMany(p => p.InverseIdMenuFatherNavigation)
                .HasForeignKey(d => d.IdMenuFather)
                .HasConstraintName("FK_Id_MenuFather");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Menus)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Id_Role");
        });

        modelBuilder.Entity<Municipality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Municipa__3214EC07AEFEA113");

            entity.ToTable("Municipality");

            entity.Property(e => e.CityId).HasColumnName("City_Id");
            entity.Property(e => e.Name).HasMaxLength(150);

            entity.HasOne(d => d.City).WithMany(p => p.Municipalities)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Municipal__City___0E6E26BF");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Purchase__3214EC077ADDD220");

            entity.ToTable("Purchase");

            entity.Property(e => e.DeliveryDate).HasColumnType("date");
            entity.Property(e => e.InvoiceStatusId).HasColumnName("InvoiceStatus_Id");
            entity.Property(e => e.SupplierId).HasColumnName("Supplier_Id");

            entity.HasOne(d => d.InvoiceStatus).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.InvoiceStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Purchase__Invoic__7B5B524B");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Purchase__Suppli__7A672E12");
        });

        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Purchase__3214EC073AE27588");

            entity.ToTable("PurchaseDetail");

            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");
            entity.Property(e => e.PurchaseId).HasColumnName("Purchase_Id");
            entity.Property(e => e.StoredMedicationId).HasColumnName("StoredMedication_Id");

            entity.HasOne(d => d.Employee).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseD__Emplo__00200768");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseD__Purch__7E37BEF6");

            entity.HasOne(d => d.StoredMedication).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.StoredMedicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseD__Store__7F2BE32F");
        });

        modelBuilder.Entity<RefreshTokenHistory>(entity =>
        {
            entity.HasKey(e => e.HistorialTokenId).HasName("PK__RefreshT__1CD201C1E94BCA1D");

            entity.ToTable("RefreshTokenHistory");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasComputedColumnSql("(case when [ExpirationDate]<getdate() then CONVERT([bit],(0)) else CONVERT([bit],(1)) end)", false);
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Token)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokenHistories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__RefreshTo__UserI__245D67DE");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC07C3EA1872");

            entity.ToTable("Role");

            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sale__3214EC0741BC0CAE");

            entity.ToTable("Sale");

            entity.Property(e => e.Address).HasMaxLength(150);
            entity.Property(e => e.CreditCardNumber).HasMaxLength(16);
            entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");
            entity.Property(e => e.DeliveryDate).HasColumnType("date");
            entity.Property(e => e.DeliveryEmployeeId).HasColumnName("DeliveryEmployee_Id");
            entity.Property(e => e.DeliveryTypeId).HasColumnName("DeliveryType_Id");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");
            entity.Property(e => e.InvoiceStatusId).HasColumnName("InvoiceStatus_Id");
            entity.Property(e => e.MunicipalityId).HasColumnName("Municipality_Id");
            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.PostalCode).HasMaxLength(15);
            entity.Property(e => e.Residence).HasMaxLength(30);
            entity.Property(e => e.ShippingDate).HasColumnType("date");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sale__Customer_I__151B244E");

            entity.HasOne(d => d.DeliveryEmployee).WithMany(p => p.SaleDeliveryEmployees)
                .HasForeignKey(d => d.DeliveryEmployeeId)
                .HasConstraintName("FK__Sale__DeliveryEm__18EBB532");

            entity.HasOne(d => d.DeliveryType).WithMany(p => p.Sales)
                .HasForeignKey(d => d.DeliveryTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sale__DeliveryTy__17036CC0");

            entity.HasOne(d => d.Employee).WithMany(p => p.SaleEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Sale__Employee_I__17F790F9");

            entity.HasOne(d => d.InvoiceStatus).WithMany(p => p.Sales)
                .HasForeignKey(d => d.InvoiceStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sale__InvoiceSta__160F4887");

            entity.HasOne(d => d.Municipality).WithMany(p => p.Sales)
                .HasForeignKey(d => d.MunicipalityId)
                .HasConstraintName("FK__Sale__Municipali__19DFD96B");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SaleDeta__3214EC0716B63ADA");

            entity.ToTable("SaleDetail");

            entity.Property(e => e.MedicationInStockId).HasColumnName("MedicationInStock_Id");
            entity.Property(e => e.SaleId).HasColumnName("Sale_Id");

            entity.HasOne(d => d.MedicationInStock).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.MedicationInStockId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SaleDetai__Medic__1DB06A4F");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SaleDetai__Sale___1CBC4616");
        });

        modelBuilder.Entity<ShelfCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ShelfCat__3214EC07148CD69C");

            entity.ToTable("ShelfCategory");

            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.State).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<ShelfLocationCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ShelfLoc__3214EC07B33278F0");

            entity.ToTable("ShelfLocationCategory");

            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ShelfId).HasColumnName("Shelf_Id");
            entity.Property(e => e.State).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Shelf).WithMany(p => p.ShelfLocationCategories)
                .HasForeignKey(d => d.ShelfId)
                .HasConstraintName("FK__ShelfLoca__Shelf__59063A47");
        });

        modelBuilder.Entity<StorageCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StorageC__3214EC07B5813A1F");

            entity.ToTable("StorageCategory");

            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.State).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<StorageLocationCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StorageL__3214EC07C3FAFC34");

            entity.ToTable("StorageLocationCategory");

            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.State).HasDefaultValueSql("((1))");
            entity.Property(e => e.StorageId).HasColumnName("Storage_Id");

            entity.HasOne(d => d.Storage).WithMany(p => p.StorageLocationCategories)
                .HasForeignKey(d => d.StorageId)
                .HasConstraintName("FK__StorageLo__Stora__52593CB8");
        });

        modelBuilder.Entity<StoredMedication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StoredMe__3214EC07E726FF48");

            entity.ToTable("StoredMedication");

            entity.Property(e => e.Batch)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ExpeditionDate).HasColumnType("date");
            entity.Property(e => e.ExpiryDate).HasColumnType("date");
            entity.Property(e => e.ExpiryWarning)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.MedicationDetailId).HasColumnName("MedicationDetail_Id");
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.State).HasDefaultValueSql("((1))");
            entity.Property(e => e.SupplierId).HasColumnName("Supplier_Id");
            entity.Property(e => e.UnitMeasurementId).HasColumnName("UnitMeasurement_Id");

            entity.HasOne(d => d.Location).WithMany(p => p.StoredMedications)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__StoredMed__Locat__5FB337D6");

            entity.HasOne(d => d.MedicationDetail).WithMany(p => p.StoredMedications)
                .HasForeignKey(d => d.MedicationDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StoredMed__Medic__5CD6CB2B");

            entity.HasOne(d => d.Supplier).WithMany(p => p.StoredMedications)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StoredMed__Suppl__5DCAEF64");

            entity.HasOne(d => d.UnitMeasurement).WithMany(p => p.StoredMedications)
                .HasForeignKey(d => d.UnitMeasurementId)
                .HasConstraintName("FK__StoredMed__UnitM__5EBF139D");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC078B5CBD75");

            entity.ToTable("Supplier");

            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.State).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<UnitOfMeasurement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UnitOfMe__3214EC074AF015E1");

            entity.ToTable("UnitOfMeasurement");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserProf__3214EC075C2C3127");

            entity.ToTable("UserProfile");

            entity.HasIndex(e => e.UserName, "UC_UserProfile_Username").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__UserProf__C9F28456AA866E55").IsUnique();

            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.UserPassaword)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
