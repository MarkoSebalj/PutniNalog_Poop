using Model.PN.Model;
using RestClient.PN.RestClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.PN.Service
{
    public sealed class DataService
    {
        public static string baseUrl { get; set; } = "https://localhost:7118";

        private static readonly DataService instance = new DataService();
        public static RestClient<Zaposlenik> zaposlenikRestClient { get; set; }
        //public static BankAccountRestClient<BankAccount> bankAccountRestClient { get; set; }
        //public static RestClient<BankAccountType> bankAccountTypeRestClient { get; set; }

        private DataService()
        {
            Initialize();
        }


        public static DataService Instance
        {

            get { return instance; }
        }

        public static void Initialize()
        {
            zaposlenikRestClient = new RestClient<Zaposlenik>("Zaposlenik");
            //bankAccountRestClient = new BankAccountRestClient<BankAccount>("BankAccount");
            //bankAccountTypeRestClient = new RestClient<BankAccountType>("BankAccountType");
        }

    }
}
