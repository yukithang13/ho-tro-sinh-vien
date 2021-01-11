namespace HoTroSinhVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

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

        [StringLength(150)]
        public string CuocThiKiNang { get; set; }

        [DataType(DataType.Upload)]
       
        [Required(ErrorMessage = "Please choose file to upload.")]
        [StringLength(150)]
        
        public string ChungChiAV { get; set; }

       
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
