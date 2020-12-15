namespace TOUR.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LienHe")]
    public partial class LienHe
    {
        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string tenCty { get; set; }

        [Required]
        [StringLength(200)]
        public string diaChiCty { get; set; }

        [Required]
        [StringLength(10)]
        public string sdtCty { get; set; }

        [Required]
        [StringLength(200)]
        public string emailCty { get; set; }

        [StringLength(300)]
        public string facebookCty { get; set; }
    }
}
