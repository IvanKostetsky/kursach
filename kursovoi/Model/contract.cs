namespace kursovoi.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("contract")]
    public partial class contract : EventPropertyChanged
    {
        private int contract_type1;
        private decimal price1;
        private DateTime date1;
        private DateTime? beginRent1;
        private DateTime? endRent1;
        private client client1;
        private obje obje1;
        private tipecontract tipecontract1;
        private worker worker1;

        public int contractID { get; set; }

        

        public int contract_type
        {
            get => contract_type1; set
            {
                contract_type1 = value;
                OnPropertyChanged(nameof(contract_type));
            }
        }

        [Column(TypeName = "money")]
        public decimal price
        {
            get => price1; set
            {
                price1 = value;
                OnPropertyChanged(nameof(price));
            }
        }

        [Column(TypeName = "date")]
        public DateTime date
        {
            get => date1; set
            {
                date1 = value;
                OnPropertyChanged(nameof(date));
            }
        }

        public int clientFK { get; set; }

        public int workerFK { get; set; }

        public int objeFK { get; set; }

        [Column(TypeName = "date")]
        public DateTime? beginRent
        {
            get => beginRent1; set
            {
                beginRent1 = value;
                price_upd();
                OnPropertyChanged(nameof(beginRent));
            }
        }

        [Column(TypeName = "date")]
        public DateTime? endRent
        {
            get => endRent1; set
            {
                endRent1 = value;
                price_upd();
                OnPropertyChanged(nameof(endRent));
            }
        }

        public virtual client client { get => client1; set
            {
                client1 = value;
                OnPropertyChanged(nameof(client));
            }
        }

        public virtual obje obje { get => obje1; set
            {
                obje1 = value;
                price_upd();
                OnPropertyChanged(nameof(obje));
            }
        }

        public virtual tipecontract tipecontract { get => tipecontract1; set
            {
                tipecontract1 = value;
                price_upd();
                OnPropertyChanged(nameof(tipecontract));
            }
        }

        public virtual worker worker { get => worker1; set
            {
                worker1 = value;
                OnPropertyChanged(nameof(worker));
            }
        }

        void  price_upd()
        {
            if (tipecontract != null && tipecontract.id == 1)
            {
                if(beginRent != null && endRent != null && endRent >= beginRent && obje != null)
                {
                    price = ((endRent - beginRent).Value.Days + 1) * obje.priceRent;
                }
            }
            else
            {
                if (obje != null)
                {
                    price = obje.priceBuy;
                }
            }
        }

        public string tipe
        {
            get
            {
                string str = tipecontract.Name + ".";
                if (contract_type == 1)
                    str += " C " + beginRent.Value.ToString("d/M/yyyy") + ", по " + endRent.Value.ToString("d/M/yyyy");
                return str;
            }
        }
    }
}
