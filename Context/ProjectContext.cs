
using Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Project.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }

        public ProjectContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().HasIndex(b => b.PhoneNumber).IsUnique();

            modelBuilder.Entity<StudentInfo>().HasMany(s => s.StudentNguyenVongs)
           .WithOne(c => c.StudentInfo).OnDelete(DeleteBehavior.NoAction);

            // modelBuilder.Entity<Asset>().Property(x => x.AssetId).ValueGeneratedOnAdd();

            // modelBuilder.Entity<Assignment>().HasOne(a => a.RequestReturn).WithOne(r => r.Assignment).OnDelete(DeleteBehavior.NoAction);
            // modelBuilder.Entity<TinhInfo>().HasOne<Tinh>(x => x.Tinh10).WithOne(b => b.Tinh10Info).OnDelete(DeleteBehavior.NoAction);
            // modelBuilder.Entity<TinhInfo>().HasOne<Tinh>(x => x.Tinh11).WithOne(b => b.Tinh11Info).OnDelete(DeleteBehavior.NoAction);
            // modelBuilder.Entity<TinhInfo>().HasOne<Tinh>(x => x.Tinh12).WithOne(b => b.Tinh12Info).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StudentInfo>().HasOne<Truong>(x => x.Truong10).WithOne(b => b.Truong10Info).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<StudentInfo>().HasOne<Truong>(x => x.Truong11).WithOne(b => b.Truong11Info).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<StudentInfo>().HasOne<Truong>(x => x.Truong12).WithOne(b => b.Truong12Info).OnDelete(DeleteBehavior.NoAction);

            // modelBuilder.Entity<StudentInfo>().Property(p => p.DiemTb10).HasComputedColumnSql("AVG(DiemToan10 + DiemHoa10 + DiemLy10) /3");
            // modelBuilder.Entity<StudentInfo>().Property(p => p.DiemTb11).HasComputedColumnSql("AVG(DiemToan11 + DiemHoa11 + DiemLy11) /3");

            // modelBuilder.Entity<StudentInfo>().Property(p => p.DiemTb12).HasComputedColumnSql("AVG(DiemToan12 + DiemHoa12 + DiemLy12) /3");
            //             modelBuilder.Entity<StudentInfo>().Property(p => p.DiemTb_UuTien).HasComputedColumnSql(@"select AVG(DiemTb10 + DiemTb11 + DiemTb12) /3 + 
            // ((CASE WHEN DoiTuongId IN ('01', '02', '03', '04') THEN 2
            // 	WHEN DoiTuongId IN ('05', '06', '07') THEN 1
            // 	ELSE 0 END)) +
            // 	((CASE WHEN KhuVucId IN ('1') THEN 0.75
            // 		WHEN KhuVucId IN ('2') THEN 0.25
            // 			WHEN KhuVucId IN ('2NT') THEN 0.5
            // 		ELSE 0 END))
            // from StudentInfos
            // GROUP BY DoiTuongId, KhuVucId;");
            // modelBuilder.Entity<UserRole>().HasKey(o => new { o.UserId, o.RoleId });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<DoiTuong> DoiTuongs { get; set; }
        // public DbSet<HocBaUrl> HocBaUrls { get; set; }
        public DbSet<KhuVuc> KhuVucs { get; set; }
        // public DbSet<LienHe> LienHes { get; set; }

        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<Nganh> Nganhs { get; set; }
        public DbSet<StudentInfo> StudentInfos { get; set; }
        public DbSet<StudentNguyenVong> StudentNguyenVongs { get; set; }
        public DbSet<Tinh> Tinhs { get; set; }
        public DbSet<ToHop> ToHops { get; set; }
        public DbSet<Truong> Truongs { get; set; }

        // public DbSet<TinhInfo> TinhInfos { get; set; }
        // public DbSet<TruongInfo> TruongInfos { get; set; }
        // public DbSet<StudentDiemTb> StudentDiemTbs { get; set; }

        public DbSet<Role> Roles { get; set; }
        // public DbSet<UserRole> UserRoles { get; set; }

    }
}