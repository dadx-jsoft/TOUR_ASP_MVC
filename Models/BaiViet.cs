namespace TOUR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiViet")]
    public partial class BaiViet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaiViet()
        {
            PhanHoiLienHes = new HashSet<PhanHoiLienHe>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string tieuDe { get; set; }

        [StringLength(200)]
        public string anhBaiViet { get; set; }

        public string noiDung { get; set; }

        public DateTime? ngayTao { get; set; }

        public int ChuDeBaiVietId { get; set; }

        public virtual ChuDeBaiViet ChuDeBaiViet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanHoiLienHe> PhanHoiLienHes { get; set; }
    }
}
