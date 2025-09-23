using Microsoft.EntityFrameworkCore;

namespace DingoBox.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Word> Words { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Progress> Progresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ví dụ cấu hình bảng
            modelBuilder.Entity<Word>().ToTable("Words");
            modelBuilder.Entity<Card>().ToTable("Cards");
            modelBuilder.Entity<User>().ToTable("Users");

            // Cấu hình quan hệ
            modelBuilder.Entity<Card>()
                .HasOne(c => c.Word)
                .WithMany(w => w.Cards)
                .HasForeignKey(c => c.WordId);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Test)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TestId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Progress)
                .WithOne()
                .HasForeignKey<User>(u => u.ProgressId);

        }
    }
}