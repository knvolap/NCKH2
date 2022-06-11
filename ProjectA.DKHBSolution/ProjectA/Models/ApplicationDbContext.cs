using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Models
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       
        public virtual DbSet<CapDoHoatDong> CapDoHoatDongs { get; set; }
        public virtual DbSet<DangKyHocBong> DangKyHocBongs { get; set; }
        public virtual DbSet<DanhSachThamGiaHoatDong> DanhSachThamGiaHoatDongs { get; set; }
        public virtual DbSet<Diem> Diems { get; set; }
        public virtual DbSet<HoatDong> HoatDongs { get; set; }
        public virtual DbSet<HocBong> HocBongs { get; set; }
        public virtual DbSet<HocKy> HocKies { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<LoaiGiai> LoaiGiais { get; set; }
        public virtual DbSet<LoaiHocBong> LoaiHocBongs { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<Nganh> Nganhs { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

           

            modelBuilder.Entity<CapDoHoatDong>(entity =>
            {
                entity.HasKey(e => e.IdCapDo)
                    .HasName("PK__CapDoHoa__3D8740E1C436AA40");

                entity.ToTable("CapDoHoatDong");

                entity.Property(e => e.IdCapDo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idCapDo");

                entity.Property(e => e.HeSo).HasColumnName("heSo");

                entity.Property(e => e.TenCapDo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tenCapDo");
            });

            modelBuilder.Entity<DangKyHocBong>(entity =>
            {
                entity.HasKey(e => e.IdDangKy)
                    .HasName("PK__DangKyHo__AE481C765A65DCD0");

                entity.ToTable("DangKyHocBong");

                entity.Property(e => e.IdDangKy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idDangKy");

                entity.Property(e => e.IdHocBong)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idHocBong");

                entity.Property(e => e.IdSinhVien)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idSinhVien");

                entity.Property(e => e.TgDangKy)
                    .HasColumnType("datetime")
                    .HasColumnName("tgDangKy");

                entity.Property(e => e.TinhTrang)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("tinhTrang");

                entity.HasOne(d => d.IdHocBongNavigation)
                    .WithMany(p => p.DangKyHocBongs)
                    .HasForeignKey(d => d.IdHocBong)
                    .HasConstraintName("FK_IDHOCBONG_DKHB");

                entity.HasOne(d => d.IdSinhVienNavigation)
                    .WithMany(p => p.DangKyHocBongs)
                    .HasForeignKey(d => d.IdSinhVien)
                    .HasConstraintName("FK_IDSINHVIEN_DKHB");
            });

            modelBuilder.Entity<DanhSachThamGiaHoatDong>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DanhSachThamGiaHoatDong");

                entity.Property(e => e.DiemHoatDong).HasColumnName("diemHoatDong");

                entity.Property(e => e.IdCapDo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idCapDo");

                entity.Property(e => e.IdDangKy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idDangKy");

                entity.Property(e => e.IdHoatDong)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idHoatDong");

                entity.Property(e => e.IdLoaiGiai)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idLoaiGiai");

                entity.Property(e => e.MinhChung)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("minhChung");

                entity.HasOne(d => d.IdCapDoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCapDo)
                    .HasConstraintName("FK_IDCAPDO_DSTGHD");

                entity.HasOne(d => d.IdDangKyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdDangKy)
                    .HasConstraintName("FK_IDDANGKY_DSTGHD");

                entity.HasOne(d => d.IdHoatDongNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdHoatDong)
                    .HasConstraintName("FK_IDHOATDONG_DSTGHD");

                entity.HasOne(d => d.IdLoaiGiaiNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdLoaiGiai)
                    .HasConstraintName("FK_IDLOAIGIAI_DSTGHD");
            });

            modelBuilder.Entity<Diem>(entity =>
            {
                modelBuilder.Entity<Diem>().HasKey(sc => new { sc.IdHocKy, sc.IdSinhVien });

                entity.ToTable("Diem");

                entity.Property(e => e.DiemRenLuyen).HasColumnName("diemRenLuyen");

                entity.Property(e => e.DiemThang10).HasColumnName("diemThang10");

                entity.Property(e => e.DiemThang4).HasColumnName("diemThang4");

                entity.Property(e => e.IdHocKy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idHocKy");

                entity.Property(e => e.IdSinhVien)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idSinhVien");

                entity.Property(e => e.SoTinChi).HasColumnName("soTinChi");

                entity.Property(e => e.XepLoai)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("xepLoai");

                modelBuilder.Entity<Diem>()
                    .HasOne<SinhVien>(sc => sc.IdSinhVienNavigation)
                    .WithMany(s => s.Diems)
                    .HasForeignKey(sc => sc.IdSinhVien).OnDelete(DeleteBehavior.Cascade);


                modelBuilder.Entity<Diem>()
                    .HasOne<HocKy>(sc => sc.IdHocKyNavigation)
                    .WithMany(s => s.Diems)
                    .HasForeignKey(sc => sc.IdHocKy).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<HoatDong>(entity =>
            {
                entity.HasKey(e => e.IdHoatDong)
                    .HasName("PK__HoatDong__E60F4DBB4671BB68");

                entity.ToTable("HoatDong");

                entity.Property(e => e.IdHoatDong)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idHoatDong");

                entity.Property(e => e.GhiChu)
                    .HasMaxLength(300)
                    .HasColumnName("ghiChu");

                entity.Property(e => e.NgayBatDau)
                    .HasColumnType("datetime")
                    .HasColumnName("ngayBatDau");

                entity.Property(e => e.NgayKetThuc)
                    .HasColumnType("datetime")
                    .HasColumnName("ngayKetThuc");

                entity.Property(e => e.TenHoatDong)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("tenHoatDong");
            });

            modelBuilder.Entity<HocBong>(entity =>
            {
                entity.HasKey(e => e.IdHocBong)
                    .HasName("PK__HocBong__BB9E17CFA7F05835");

                entity.ToTable("HocBong");

                entity.Property(e => e.IdHocBong)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idHocBong");

                entity.Property(e => e.DoiTuongApDung)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("doiTuongApDung");

                entity.Property(e => e.IdLhb)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idLHB");

                entity.Property(e => e.KinhPhi)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("kinhPhi");

                entity.Property(e => e.NgayBatDau)
                    .HasColumnType("datetime")
                    .HasColumnName("ngayBatDau");

                entity.Property(e => e.NgayDuKienPhatHb)
                    .HasColumnType("datetime")
                    .HasColumnName("ngayDuKienPhatHB");

                entity.Property(e => e.NgayKetThuc)
                    .HasColumnType("datetime")
                    .HasColumnName("ngayKetThuc");

                entity.Property(e => e.NoiDungHb)
                    .IsRequired()
                    .HasColumnName("noiDungHB");

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");

                entity.Property(e => e.TenHb)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("tenHB");

                entity.HasOne(d => d.IdLhbNavigation)
                    .WithMany(p => p.HocBongs)
                    .HasForeignKey(d => d.IdLhb)
                    .HasConstraintName("FK_IDLHB_HOCBONG");
            });

            modelBuilder.Entity<HocKy>(entity =>
            {
                entity.HasKey(e => e.IdHocKy)
                    .HasName("PK__HocKy__4C048364CD804C95");

                entity.ToTable("HocKy");

                entity.Property(e => e.IdHocKy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idHocKy");

                entity.Property(e => e.NamHoc).HasColumnType("datetime");

                entity.Property(e => e.TenHocKy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tenHocKy");

                entity.Property(e => e.TgBatDau)
                    .HasColumnType("date")
                    .HasColumnName("tgBatDau");

                entity.Property(e => e.TgKetThuc)
                    .HasColumnType("date")
                    .HasColumnName("tgKetThuc");
            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.IdKhoa)
                    .HasName("PK__Khoa__C30A683D317AAE21");

                entity.ToTable("Khoa");

                entity.Property(e => e.IdKhoa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idKhoa");

                entity.Property(e => e.TenKhoa)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("tenKhoa");
            });

            modelBuilder.Entity<LoaiGiai>(entity =>
            {
                entity.HasKey(e => e.IdLoaiGiai)
                    .HasName("PK__LoaiGiai__9E68083E26BB65CC");

                entity.ToTable("LoaiGiai");

                entity.Property(e => e.IdLoaiGiai)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idLoaiGiai");

                entity.Property(e => e.DiemThanhTich).HasColumnName("diemThanhTich");

                entity.Property(e => e.TenGiai)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tenGiai");
            });

            modelBuilder.Entity<LoaiHocBong>(entity =>
            {
                entity.HasKey(e => e.IdLhb)
                    .HasName("PK__LoaiHocB__3C7D8C4296DA8832");

                entity.ToTable("LoaiHocBong");

                entity.Property(e => e.IdLhb)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idLHB");

                entity.Property(e => e.TenLhb)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tenLHB");
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.IdLop)
                    .HasName("PK__Lop__3C7153C34757DF17");

                entity.ToTable("Lop");

                entity.Property(e => e.IdLop)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idLop");

                entity.Property(e => e.IdNganh)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idNganh");

                entity.Property(e => e.NienKhoa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nienKhoa");

                entity.Property(e => e.TenLop)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tenLop");

                entity.HasOne(d => d.IdNganhNavigation)
                    .WithMany(p => p.Lops)
                    .HasForeignKey(d => d.IdNganh)
                    .HasConstraintName("FK_IDNGANH_LOP");
            });

            modelBuilder.Entity<Nganh>(entity =>
            {
                entity.HasKey(e => e.IdNganh)
                    .HasName("PK__Nganh__B663CFDF04ED3E68");

                entity.ToTable("Nganh");

                entity.Property(e => e.IdNganh)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idNganh");

                entity.Property(e => e.IdKhoa)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idKhoa");

                entity.Property(e => e.TenNganh)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("tenNganh");

                entity.HasOne(d => d.IdKhoaNavigation)
                    .WithMany(p => p.Nganhs)
                    .HasForeignKey(d => d.IdKhoa)
                    .HasConstraintName("FK_IDKHOA_NGANH");
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.IdSinhVien)
                    .HasName("PK__SinhVien__AD2D734328312735");

                entity.ToTable("SinhVien");

                entity.HasIndex(e => e.Email, "UQ__SinhVien__AB6E6164BDCCBC1C")
                    .IsUnique();

                entity.Property(e => e.IdSinhVien)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idSinhVien");

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(100)
                    .HasColumnName("diaChi");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gioiTinh")
                    .HasDefaultValueSql("('M')")
                    .IsFixedLength(true);

                entity.Property(e => e.IdLop)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("idLop");

                entity.Property(e => e.NgaySinh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaySinh");

                entity.Property(e => e.PasswordSv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("passwordSV");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("soDienThoai")
                    .IsFixedLength(true);

                entity.Property(e => e.TenSinhVien)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("tenSinhVien");

                entity.HasOne(d => d.IdLopNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.IdLop)
                    .HasConstraintName("FK_IDLOP_SINHVIEN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
