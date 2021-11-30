namespace k.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("worker")]
    public partial class worker : EventPropertyChanged
    {
        private string fIO;
        private string post1;
        private DateTime birthdate;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public worker()
        {
            contract = new HashSet<contract>();
        }

        public worker(worker worker)
        {
            contract = new HashSet<contract>();
            workerID = worker.workerID;
            FIO = worker.FIO;
            Birthdate = worker.Birthdate;
            post = worker.post;
        }

        public int workerID { get; set; }

        [Required]
        [StringLength(50)]
        public string FIO
        {
            get => fIO; set
            {
                fIO = value;
                OnPropertyChanged(nameof(FIO));
            }
        }

        [Required]
        [StringLength(50)]
        public string post
        {
            get => post1; set
            {
                post1 = value;
                OnPropertyChanged(nameof(post));
            }
        }

        public DateTime Birthdate
        {
            get => birthdate.Date; set
            {
                birthdate = value.Date;
                OnPropertyChanged(nameof(Birthdate));
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contract> contract { get; set; }
    }
}
