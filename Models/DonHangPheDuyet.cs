namespace TOUR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHangPheDuyet")]
    public partial class DonHangPheDuyet
    {
        public int id { get; set; }

        public int? hoaDonId { get; set; }

        public int? trangThaiDuyet { get; set; }

        public DateTime? ngayPheDuyet { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
