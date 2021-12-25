namespace kursovoi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Individual")]
    public partial class Individual : EventPropertyChanged
    {
        public Individual()
        {
        }

        private string fIO;
        private string iNN;
        private string passport1;
        private DateTime birthday1;
        private client client1;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string FIO { get => fIO; set
            {
                fIO = value;
                OnPropertyChanged(nameof(FIO));
            }
        }

        [Required]
        [StringLength(50)]
        public string INN { get => iNN; set
            {
                bool p = true;
                int t = 0;
                if(value.Length <= 12)
                {
                    for (int i = 0; i < value.Length; i++)
                        if (!int.TryParse(value[i].ToString(), out t))
                            p = false;
                    if (p)
                        iNN = value;
                }
               
                OnPropertyChanged(nameof(INN));
            }
        }

        [Required]
        [StringLength(50)]
        public string passport { get => passport1; set
            {
                passport1 = value;
                OnPropertyChanged(nameof(passport));
            }
        }

        [Column(TypeName = "date")]
        public DateTime birthday { get => birthday1; set
            {
                birthday1 = value;
                OnPropertyChanged(nameof(birthday));
            }
        }

        public virtual client client { get => client1; set
            {
                client1 = value;
                OnPropertyChanged(nameof(client));
            }
        }
    }
}
