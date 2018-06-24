namespace CartegraphTown.Model.Entity.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    internal class StateConfig : EntityTypeConfiguration<State>
    {
        internal StateConfig()
        {
            this.HasKey(e => e.Id); ;

            this.ToTable("States");

            this.Property(e => e.Abbreviation)
                .HasColumnName("Abbreviation")
                .HasMaxLength(2)
                .IsRequired()
                .IsUnicode(false);

            this.Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode(false);
        }
    }
}
