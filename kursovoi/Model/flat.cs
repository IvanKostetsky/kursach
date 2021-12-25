namespace kursovoi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("flat")]
    public partial class flat : EventPropertyChanged
    {
        private int floor1;
        private bool parkingLot1;


        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int floor { get => floor1; set
            {
                floor1 = value;
                OnPropertyChanged(nameof(floor));
            }
        }

        public bool parkingLot { get => parkingLot1; set
            {
                parkingLot1 = value;
                OnPropertyChanged(nameof(parkingLot));
            }
        }

        public virtual obje obje { get; set; }
    }
}
