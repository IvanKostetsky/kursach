namespace kursovoi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("obje")]
    public partial class obje : EventPropertyChanged
    {
        private string name1;
        private int area1;
        private string adress1;
        private decimal priceRent1;
        private decimal priceBuy1;
        private flat flat1;
        private houses houses1;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public obje()
        {
            contract = new HashSet<contract>();            
        }

        public obje(obje obje)
        {
            contract = new HashSet<contract>();
            id = obje.id;
            name = obje.name;
            area = obje.area;
            adress = obje.adress;
            priceBuy = obje.priceBuy;
            priceRent = obje.priceRent;
            if(obje.houses != null)
            {
                houses = new houses();
                houses.id = obje.houses.id;
                houses.garage = obje.houses.garage;
                houses.floors = obje.houses.floors;
                houses.territorySquare = obje.houses.territorySquare;

            }
            if (obje.flat != null)
            {
                flat = new flat();
                flat.id = obje.flat.id;
                flat.floor = obje.flat.floor;
                flat.parkingLot = obje.flat.parkingLot;
            }
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get => name1; set
            {
                name1 = value;
                OnPropertyChanged(nameof(name));
            }
        }


        public int area { get => area1; set
            {
                area1 = value;
                OnPropertyChanged(nameof(area));
            }
        }
              

        [Required]
        public string adress { get => adress1; set
            {
                adress1 = value;
                OnPropertyChanged(nameof(adress));
            }
        }
                

        [Column(TypeName = "money")]
        public decimal priceRent { get => priceRent1; set
            {
                if ((value.ToString().IndexOf('.') > -1 && value.ToString().Split('.')[1].Length <= 2) || (value.ToString().IndexOf('.') < 0))
                    priceRent1 = value;
                OnPropertyChanged(nameof(priceRent));
            }
        }

        [Column(TypeName = "money")]
        public decimal priceBuy { get => priceBuy1; set
            {
                if ((value.ToString().IndexOf('.') > -1 && value.ToString().Split('.')[1].Length <= 2) || (value.ToString().IndexOf('.') < 0))
                    priceBuy1 = value;
                OnPropertyChanged(nameof(priceBuy));
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contract> contract { get; set; }

        public virtual flat flat { get => flat1; set
            {
                flat1 = value;
                OnPropertyChanged(nameof(flat));
            }
        }

        public virtual houses houses { get => houses1; set
            {
                houses1 = value;
                OnPropertyChanged(nameof(houses));
            }
        }

        public bool isSold
        {
            get
            {
                if ((contract.Count > 0) && (contract.Where(i => i.contract_type == 2).Count() > 0))
                    return true;
                return false;
            }
        }

        public bool isRent
        {
            get
            {
                if(!isSold)
                    if ((contract.Count > 0) && (contract.Where(i => i.beginRent <= DateTime.Today && i.endRent >= DateTime.Today).Count() > 0))
                        return true;
                return false;
            }
        }

        public bool isEditable
        {
            get
            {
                if (contract.Count == 0)
                    return true;
                return false;
            }
        }

        public string Status
        {
            get
            {
                if (isSold)
                    return "Продано";
                if (isRent)
                    return "Арендовано";
                return "Свободно";
            }
        }

        public string Tipe
        {
            get
            {
                if (flat != null)
                    return "Квартира";
                else
                    return "Частный дом";
            }
        }
    }
}
