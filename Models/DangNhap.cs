namespace HoTroSinhVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DangNhap")]
    public partial class DangNhap
    {
        [Key]
        [StringLength(11)]
        public string TaiKhoan { get; set; }

        [StringLength(30)]
        public string MatKhau { get; set; }
    }
}
