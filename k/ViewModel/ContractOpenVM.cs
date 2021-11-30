using k.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k.ViewModel
{
    class ContractOpenVM : EventPropertyChanged
    {
        public ContractOpenVM(contract contract)
        {
            Contract = contract;            
            if(contract.tipecontract.id == 1)
            {
                Rent = true;
            }
        }

        bool rent;
        public bool Rent
        {
            get => rent;
            set
            {
                rent = value;
                OnPropertyChanged(nameof(Rent));
            }
        }

        contract contract;
        public contract Contract
        {
            get => contract;
            set
            {
                contract = value;
                OnPropertyChanged(nameof(Contract));
            }
        }
    }
}
