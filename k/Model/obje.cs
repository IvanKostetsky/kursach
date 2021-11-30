namespace k.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obje")]
    public partial class obje
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public obje(obje objeSel)
        {
            contract = new HashSet<contract>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int area { get; set; }

        [Required]
        public string adress { get; set; }

        [Column(TypeName = "money")]
        public decimal priceRent { get; set; }

        [Column(TypeName = "money")]
        public decimal priceBuy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contract> contract { get; set; }

        public virtual flat flat { get; set; }

        public virtual houses houses { get; set; }
    }
}
