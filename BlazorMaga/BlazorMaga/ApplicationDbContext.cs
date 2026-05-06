using BlazorMaga.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorMaga
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticlesTags> ArticlesTags { get; set; }
        public DbSet<Ephemeri> Ephemeris { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Nakshatra> Nakshatras { get; set; }
        public DbSet<NakshatraName> NakshatraNames { get; set; }
        public DbSet<NakshatrasTotem> NakshatrasTotems { get; set; }
        public DbSet<Sign> Signs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TotemName> TotemNames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Article ↔ Topic
            modelBuilder.Entity<Article>()
                .HasOne(a => a.Topic)
                .WithMany(t => t.Articles)
                .HasForeignKey(a => a.TopicId);

            // Article ↔ Tag (через ArticlesTags)
            modelBuilder.Entity<ArticlesTags>()
                .HasKey(x => new { x.ArticleId, x.TagId });

            modelBuilder.Entity<ArticlesTags>()
                .HasOne(x => x.Article)
                .WithMany(a => a.ArticlesTags)
                .HasForeignKey(x => x.ArticleId);

            modelBuilder.Entity<ArticlesTags>()
                .HasOne(x => x.Tag)
                .WithMany(t => t.ArticlesTags)
                .HasForeignKey(x => x.TagId);

            // Menu ↔ Topic
            modelBuilder.Entity<Topic>()
                .HasOne(t => t.Menu)
                .WithMany(m => m.Topics)
                .HasForeignKey(t => t.MenuId);

            // Sign ↔ Ephemeri
            modelBuilder.Entity<Ephemeri>()
                .HasOne(e => e.Sign)
                .WithMany(s => s.Ephemeris)
                .HasForeignKey(e => e.SignId);

            // Sign ↔ Nakshatra
            modelBuilder.Entity<Nakshatra>()
                .HasOne(n => n.Sign)
                .WithMany(s => s.Nakshatras)
                .HasForeignKey(n => n.SignId);

            // Nakshatra ↔ NakshatraName
            modelBuilder.Entity<Nakshatra>()
                .HasOne(n => n.NakshatraNavigation)
                .WithMany(x => x.Nakshatras)
                .HasForeignKey(n => n.NakshatraId);

            // NakshatraName ↔ NakshatrasTotem
            modelBuilder.Entity<NakshatrasTotem>()
                .HasKey(q => new { q.NakshatraId, q.TotemId });

            modelBuilder.Entity<NakshatrasTotem>()
                .HasOne(x => x.Nakshatra)
                .WithOne(q => q.NakshatrasTotem)
                .HasForeignKey<NakshatrasTotem>(x => x.NakshatraId);

            modelBuilder.Entity<NakshatrasTotem>()
                .HasOne(x => x.Totem)
                .WithMany(x => x.NakshatrasTotems)
                .HasForeignKey(x => x.TotemId);
        }
    }
}
