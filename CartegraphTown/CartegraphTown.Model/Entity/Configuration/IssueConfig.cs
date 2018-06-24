namespace CartegraphTown.Model.Entity.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    internal class IssueConfig : EntityTypeConfiguration<Issue>
    {
        internal IssueConfig()
        {
            this.HasKey(e => e.Id); ;

            this.ToTable("Issues");

            this.Property(e => e.IssueType)
                .HasColumnName("IssueType")
                .IsRequired();

            this.Property(e => e.LocationId)
                .HasColumnName("LocationId")
                .IsRequired();

            this.Property(e => e.CitizenId)
                .HasColumnName("CitizenId")
                .IsRequired();

            this.Property(e => e.Details)
                .HasColumnName("Details")
                .HasMaxLength(4000)
                .IsUnicode(false);

            this.Property(e => e.CorrectiveAction)
                .HasColumnName("CorrectiveAction")
                .HasMaxLength(4000)
                .IsUnicode(false);

            this.Property(e => e.CorrectionDate)
                .HasColumnName("CorrectionDate");

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

            this.HasRequired(e => e.Location)
                .WithMany(x => x.Issues)
                .HasForeignKey(e => e.LocationId);

            this.HasRequired(e => e.Citizen)
                .WithMany(x => x.Issues)
                .HasForeignKey(e => e.CitizenId);
        }
    }
}
