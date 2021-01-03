namespace HoTroSinhVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoiNhap")]
    public partial class HoiNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoiNhap()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        [Key]
        public int MaHN { get; set; }

        [MaxLength(100)]
        public byte[] CuocThiKiNang { get; set; }

        [MaxLength(100)]
        public byte[] ChungChiAV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
