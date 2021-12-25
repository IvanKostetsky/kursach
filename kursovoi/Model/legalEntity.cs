namespace kursovoi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("legalEntity")]
    public partial class legalEntity : EventPropertyChanged
    {
        private string name1;
        private string adress1;
        private string iNN;
        private string kPP;
        private string director1;
        private client client1;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get => name1; set
            {
                name1 = value;
                OnPropertyChanged(nameof(name));
            }
        }

        [Required]
        [StringLength(50)]
        public string adress { get => adress1; set
            {
                adress1 = value;
                OnPropertyChanged(nameof(adress));
            }
        }

        [Required]
        [StringLength(50)]
        public string INN { get => iNN; set
            {
                if (value.Length <= 12)
                {
                    bool p = true;
                    int t = 0;
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
        public string KPP { get => kPP; set
            {
                if (value.Length <= 9)
                {
                    bool p = true;
                    int t = 0;
                    for (int i = 0; i < value.Length; i++)
                        if (!int.TryParse(value[i].ToString(), out t))
                            p = false;
                    if (p)
                        kPP = value;
                }
                OnPropertyChanged(nameof(KPP));
            }
        }

        [Required]
        [StringLength(50)]
        public string director { get => director1; set
            {
                director1 = value;
                OnPropertyChanged(nameof(director));
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
