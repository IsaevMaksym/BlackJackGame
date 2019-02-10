namespace BL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BJContext : DbContext
    {
        public BJContext()
            : base("name=BJContext")
        {
        }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<PLAYERS> PLAYERS { get; set; }
        public virtual DbSet<Cards> Cards { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cards>()
                .Property(e => e.CardName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cards>()
                .Property(e => e.CardSuit)
                .IsFixedLength()
                .IsUnicode(false);

           
            modelBuilder.Entity<Games>()
                .Property(e => e.GameLog)
                .IsUnicode(false);

            modelBuilder.Entity<PLAYERS>()
                .HasMany(e => e.Games)
                .WithOptional(e => e.PLAYERS)
                .HasForeignKey(e => e.Player_1_ID);
        }



        
    }
}
