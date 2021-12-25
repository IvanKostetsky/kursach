namespace kursovoi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class houses : EventPropertyChanged
    {
        private int floors1;
        private int territorySquare1;
        private bool garage1;



        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int floors { get => floors1; set
            {
                floors1 = value;
                OnPropertyChanged(nameof(floors));
            }
        }

        public int territorySquare { get => territorySquare1; set
            {
                territorySquare1 = value;
                OnPropertyChanged(nameof(territorySquare));
            }
        }

        public bool garage { get => garage1; set
            {
                garage1 = value;
                OnPropertyChanged(nameof(garage));
            }
        }
        public virtual obje obje { get; set; }
    }
}
