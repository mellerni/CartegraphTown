namespace CartegraphTown.Model.Entity.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    internal class CitizenConfig : EntityTypeConfiguration<Citizen>
    {
        internal CitizenConfig()
        {
            this.HasKey(e => e.Id); ;

            this.ToTable("Citizens");

            this.Ignore(x => x.FullName);

            this.Property(e => e.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(250)
                .IsUnicode(false);

            this.Property(e => e.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(250)
                .IsUnicode(false);

            this.Property(e => e.Email)
                .HasColumnName("Email")
                .HasMaxLength(250)
                .IsUnicode(false);

            this.Property(e => e.Phone)
                .HasColumnName("Phone")
                .HasMaxLength(50)
                .IsUnicode(false);

            this.Property(e => e.LocationId)
                .HasColumnName("LocationId");

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

            this.HasOptional(e => e.Location)
                .WithMany(x => x.Citizens)
                .HasForeignKey(e => e.LocationId);
        }
    }
}
