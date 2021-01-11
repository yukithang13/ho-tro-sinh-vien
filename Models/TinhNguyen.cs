namespace HoTroSinhVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinhNguyen")]
    public partial class TinhNguyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TinhNguyen()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        [Key]
        public int MaTN { get; set; }

        [StringLength(150)]
        public string HoatDongTInhNguyen { get; set; }

        [StringLength(150)]
        public string MuaHeXanh { get; set; }

        [StringLength(150)]
        public string XuanTinhNguyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
