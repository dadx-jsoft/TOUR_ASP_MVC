namespace TOUR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinTheoTourKhach")]
    public partial class ThongTinTheoTourKhach
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string tenKhachHang { get; set; }

        [Required]
        [StringLength(10)]
        public string sdtKhachHang { get; set; }

        [Required]
        public string loiNhanKhachHang { get; set; }

        public int idTour { get; set; }

        public virtual Tour Tour { get; set; }
    }
}
