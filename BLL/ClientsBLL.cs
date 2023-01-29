using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
   public class ClientsBLL
    {
        DBConnection dbCon;
        List<Clients> listOfClients;
        public ClientsBLL()
        {
            dbCon = new DBConnection();
            listOfClients = dbCon.GetDbSet<Clients>().ToList();
        }
        public List<Clients> GetAllClients()
        {
            return listOfClients;
        }
        public string InsertClient(Clients client)
        {
            if (listOfClients.Find(c => c.codeClient == client.codeClient) == null)
            {
                try
                {
                    dbCon.Execute<Clients>(client, DBConnection.ExecuteActions.Insert);
                    return client.codeClient.ToString();
                }
                catch (Exception ex)
                {
                    return "error";
                }
            }
            else
            {
                return "client is exist";
            }
        }
        public int UpdateClients(Clients client)
        {
            try
            {
                dbCon.Execute<Clients>(client, DBConnection.ExecuteActions.Update);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        
        public int DeleteClients(Clients client)
        {
            try
            {
                dbCon.Execute<Clients>(client, DBConnection.ExecuteActions.Delete);
                return 1;
            }
            catch
            {
                return 0;

            }
        }‏



        public int login(string name,string password)
        {
            List<Clients> newList = new List<Clients>();
            newList=GetAllClients();
            foreach (var item in newList)
            {
                if (item.PasswordClient.Equals(password)) 
                {
                    if (item.nameClient.Equals(name))
                        return 1;
                    else
                        return 0;
                }
            }
            return -1;
        }

        public Clients getClientById(int id)
        {
            return dbCon.GetDbSet<Clients>().Where(x => x.codeClient == id).FirstOrDefault();
        }
    }
}
