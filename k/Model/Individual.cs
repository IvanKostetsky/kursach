namespace k.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Individual")]
    public partial class Individual
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string FIO { get; set; }

        [Required]
        [StringLength(50)]
        public string INN { get; set; }

        [Required]
        [StringLength(50)]
        public string passport { get; set; }

        [Column(TypeName = "date")]
        public DateTime birthday { get; set; }

        public virtual client client { get; set; }
    }
}
