namespace k.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("client")]
    public partial class client : EventPropertyChanged
    {
        private Individual individual;
        private ICollection<contract> contract1;
        private legalEntity legalEntity1;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client()
        {
            contract = new HashSet<contract>();
        }

        public client(client client)
        {
            contract = new HashSet<contract>();
            id = client.id;
            if (client.Individual != null)
            {
                Individual = new Individual();
                Individual.birthday = client.Individual.birthday;
                Individual.FIO = client.Individual.FIO;
                Individual.id = client.Individual.id;
                Individual.INN = client.Individual.INN;
                Individual.passport = client.Individual.passport;
                Individual.client = this;
            }
            if (client.legalEntity != null)
            {
                legalEntity = new legalEntity();
                legalEntity.adress = client.legalEntity.adress;
                legalEntity.director = client.legalEntity.director;
                legalEntity.id = client.legalEntity.id;
                legalEntity.INN = client.legalEntity.INN;
                legalEntity.KPP = client.legalEntity.KPP;
                legalEntity.name = client.legalEntity.name;
                legalEntity.client = this;
            }

        }

        public int id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contract> contract
        {
            get => contract1; set
            {
                contract1 = value;
                OnPropertyChanged(nameof(contract));
            }
        }

        public virtual Individual Individual
        {
            get => individual; set
            {
                individual = value;
                OnPropertyChanged(nameof(Individual));
            }
        }

        public virtual legalEntity legalEntity
        {
            get => legalEntity1; set
            {
                legalEntity1 = value;
                OnPropertyChanged(nameof(legalEntity));
            }
        }

        public string TipLica
        {
            get
            {
                if (legalEntity != null)
                    return "ёридическое лицо";
                else
                    return "‘изическое лицо";
            }
        }
    }
}
