namespace TOUR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanHoiLienHe")]
    public partial class PhanHoiLienHe
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string tenKhachHang { get; set; }

        [Required]
        [StringLength(10)]
        public string sdtKhachHang { get; set; }

        [Required]
        [StringLength(100)]
        public string emailKhachHang { get; set; }

        [Required]
        public string loiNhanKhachHang { get; set; }

        public int? idBaiViet { get; set; }

        public virtual BaiViet BaiViet { get; set; }
    }
}
