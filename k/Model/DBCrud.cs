using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k.Model
{
    public class DBCrud
    {
        CompanyDB db;
        public DBCrud()
        {
            db = new CompanyDB();
        }

        public List<client> getClients()
        {
            return db.client.ToList();
        }
        public List<obje> getObjes()
        {
            return db.obje.ToList();
        }
        public List<worker> getWorkers()
        {
            return db.worker.ToList();
        }
        public List<contract> getContracts()
        {
            return db.contract.ToList();
        }

        public List<tipecontract> getTipes()
        {
            return db.tipecontract.ToList();
        }


        public client getClient(int id)
        {
            return db.client.ToList().Where(i => i.id == id).FirstOrDefault();
        }
        public obje getObje(int id)
        {
            return db.obje.ToList().Where(i => i.id == id).FirstOrDefault();
        }
        public worker getWorker(int id)
        {
            return db.worker.ToList().Where(i => i.workerID == id).FirstOrDefault();
        }
        public contract getContract(int id)
        {
            return db.contract.ToList().Where(i => i.contractID == id).FirstOrDefault();
        }

        public int addClient(client item)
        {
            db.client.Add(item);
            return db.SaveChanges();
        }
        public int addObje(obje item)
        {
            db.obje.Add(item);
            return db.SaveChanges();

        }
        public int addWorker(worker item)
        {
            db.worker.Add(item);
            return db.SaveChanges();
        }
        public int addContract(contract item)
        {
            item.date = DateTime.Today;
            db.contract.Add(item);
            return db.SaveChanges();
        }

        public int editClient(client item)
        {
            client client = getClient(item.id);
            if (client != null)
            {
                if (client.Individual != null)
                {
                    if (item.Individual != null)
                    {
                        client.Individual.birthday = item.Individual.birthday;
                        client.Individual.FIO = item.Individual.FIO;
                        client.Individual.INN = item.Individual.INN;
                        client.Individual.passport = item.Individual.passport;
                    }
                    else
                    {
                        db.Individual.Remove(client.Individual);
                        legalEntity legalEntity = new legalEntity();
                        legalEntity.id = item.id;
                        legalEntity.name = item.legalEntity.name;
                        legalEntity.adress = item.legalEntity.adress;
                        legalEntity.INN = item.legalEntity.INN;
                        legalEntity.KPP = item.legalEntity.KPP;
                        legalEntity.director = item.legalEntity.director;
                        db.legalEntity.Add(legalEntity);
                    }
                }
                else
                {
                    if (item.legalEntity != null)
                    {
                        client.legalEntity.name = item.legalEntity.name;
                        client.legalEntity.adress = item.legalEntity.adress;
                        client.legalEntity.INN = item.legalEntity.INN;
                        client.legalEntity.KPP = item.legalEntity.KPP;
                        client.legalEntity.director = item.legalEntity.director;
                    }
                    else
                    {
                        db.legalEntity.Remove(client.legalEntity);
                        Individual Individual = new Individual();
                        Individual.id = item.id;
                        Individual.birthday = item.Individual.birthday;
                        Individual.FIO = item.Individual.FIO;
                        Individual.INN = item.Individual.INN;
                        Individual.passport = item.Individual.passport;
                        db.Individual.Add(Individual);
                    }
                }
            }
            return db.SaveChanges();
        }
        public int editObje(obje item)
        {
            obje obje = getObje(item.id);
            if (obje != null)
            {
                obje.name = item.name;
                obje.priceBuy = item.priceBuy;
                obje.priceRent = item.priceRent;
                obje.adress = item.adress;
                obje.area = item.area;
                if (obje.flat != null)
                {
                    if (item.flat != null)
                    {
                        obje.flat.floor = item.flat.floor;
                        obje.flat.parkingLot = item.flat.parkingLot;
                    }
                    else
                    {
                        db.flat.Remove(obje.flat);
                        obje.flat = null;
                        houses houses = new houses();
                        houses.id = item.id;
                        houses.floors = item.houses.floors;
                        houses.garage = item.houses.garage;
                        houses.territorySquare = item.houses.territorySquare;
                        obje.houses = houses;
                        db.houses.Add(houses);
                    }
                }
                else
                {
                    if (item.houses != null)
                    {
                        obje.houses.floors = item.houses.floors;
                        obje.houses.garage = item.houses.garage;
                        obje.houses.territorySquare = item.houses.territorySquare;
                    }
                    else
                    {
                        db.houses.Remove(obje.houses);
                        obje.houses = null;
                        flat flat = new flat();
                        flat.id = item.id;
                        flat.floor = item.flat.floor;
                        flat.parkingLot = item.flat.parkingLot;
                        obje.flat = flat;
                        db.flat.Add(flat);
                    }
                }
            }



            return db.SaveChanges();
        }
        public int editWorker(worker item)
        {
            worker worker = getWorker(item.workerID);
            worker.Birthdate = item.Birthdate;
            worker.FIO = item.FIO;
            worker.post = item.post;
            return db.SaveChanges();
        }
        //public int editContract(contract item)
        //{
        //    contract contract = getContract(item.contractID);
        //    contract.contract_type = item.contract_type;
        //    if(contract.contract_type != 1)
        //    contract.beginRent = item.beginRent;
        //    contract.
        //    return db.SaveChanges();
        //}
    }
}
