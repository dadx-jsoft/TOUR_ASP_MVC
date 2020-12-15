namespace TOUR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            DonHangPheDuyets = new HashSet<DonHangPheDuyet>();
        }

        public int hoaDonId { get; set; }

        [StringLength(100)]
        public string tenKhachHang { get; set; }

        [StringLength(10)]
        public string sdtKhachHang { get; set; }

        public int? idTour { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHangPheDuyet> DonHangPheDuyets { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
