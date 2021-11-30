namespace k.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class houses
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int floors { get; set; }

        public int territorySquare { get; set; }

        public bool garage { get; set; }

        public virtual obje obje { get; set; }
    }
}
