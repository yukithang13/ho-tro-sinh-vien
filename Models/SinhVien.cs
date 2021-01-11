namespace HoTroSinhVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [Key]
        [StringLength(11)]
        public string MSSV { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int MaHN { get; set; }

        public int MaTN { get; set; }

        public int MaTL { get; set; }

        public int MaDD { get; set; }

        public int MaHT { get; set; }

        public virtual DaoDuc DaoDuc { get; set; }

        public virtual HocTap HocTap { get; set; }

        public virtual HoiNhap HoiNhap { get; set; }

        public virtual TheLuc TheLuc { get; set; }

        public virtual TinhNguyen TinhNguyen { get; set; }
    }
}
