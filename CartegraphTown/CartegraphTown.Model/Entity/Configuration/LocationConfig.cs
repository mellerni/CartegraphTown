namespace CartegraphTown.Model.Entity.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    internal class LocationConfig : EntityTypeConfiguration<Location>
    {
        internal LocationConfig()
        {
            this.HasKey(e => e.Id); ;

            this.ToTable("Locations");

            this.Property(e => e.Address1)
                .HasColumnName("Address1")
                .HasMaxLength(250)
                .IsUnicode(false);

            this.Property(e => e.Address2)
                .HasColumnName("Address2")
                .HasMaxLength(250)
                .IsUnicode(false);

            this.Property(e => e.City)
                .HasColumnName("City")
                .HasMaxLength(250)
                .IsUnicode(false);

            this.Property(e => e.ZipCode)
                .HasColumnName("ZipCode")
                .HasMaxLength(50)
                .IsUnicode(false);

            this.Property(e => e.Latitude)
                .HasColumnName("Latitude");

            this.Property(e => e.Longitude)
                .HasColumnName("Longitude");

            this.Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")
                .IsRequired();

            this.Property(e => e.CreatedBy)
                .HasColumnName("CreatedBy")
                .IsRequired();

            this.Property(e => e.UpdatedDate)
                .HasColumnName("UpdatedDate");

            this.Property(e => e.UpdatedBy)
                .HasColumnName("UpdatedBy");

            this.HasOptional(e => e.State)
                .WithMany(x => x.Locations)
                .HasForeignKey(e => e.StateId);
        }
    }
}
