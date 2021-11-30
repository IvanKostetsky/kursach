namespace k.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("flat")]
    public partial class flat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int floor { get; set; }

        public bool parkingLot { get; set; }

        public virtual obje obje { get; set; }
    }
}
