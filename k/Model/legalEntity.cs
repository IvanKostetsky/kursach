namespace k.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("legalEntity")]
    public partial class legalEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string adress { get; set; }

        [Required]
        [StringLength(50)]
        public string INN { get; set; }

        [Required]
        [StringLength(50)]
        public string KPP { get; set; }

        [Required]
        [StringLength(50)]
        public string director { get; set; }

        public virtual client client { get; set; }
    }
}
