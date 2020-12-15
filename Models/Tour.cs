namespace TOUR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tour")]
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            HoaDons = new HashSet<HoaDon>();
            ThongTinTheoTourKhaches = new HashSet<ThongTinTheoTourKhach>();
        }

        [Key]
        public int idTour { get; set; }

        public int dongTourId { get; set; }

        [Required]
        [StringLength(200)]
        public string diaDiem { get; set; }

        [StringLength(200)]
        public string anhTour { get; set; }

        [StringLength(200)]
        public string anhChiTietTour { get; set; }

        public double giaGoc { get; set; }

        public double? giaKhuyenMai { get; set; }

        public int khuyenMaiUuDai { get; set; }

        [Required]
        [StringLength(200)]
        public string tenTour { get; set; }

        [StringLength(200)]
        public string tenTieuDeTour { get; set; }

        public string moTaTour { get; set; }

        public int soNgay { get; set; }

        public DateTime? ngayTao { get; set; }

        public virtual DongTour DongTour { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinTheoTourKhach> ThongTinTheoTourKhaches { get; set; }
    }
}
