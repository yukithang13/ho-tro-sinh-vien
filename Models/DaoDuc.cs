namespace HoTroSinhVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DaoDuc")]
    public partial class DaoDuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DaoDuc()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        [Key]
        public int MaDD { get; set; }

        public int? DiemRenLuyen { get; set; }

        [MaxLength(100)]
        public byte[] CuocThiDaoDuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
