using Microsoft.EntityFrameworkCore.ChangeTracking;
using RestClient.PN;
using Model.PN.Model;
using PutniNalogDataContext.PN.Database;
using RestClient.PN.Service;
using RestClient.PN.RestClient;
using System;

namespace Console.PN
{
    class Program
    {
        static void Main(string[] args)
        {

            //if (args.Length == 3)
            //{
            //    DataService.baseUrl = $"https://{args[1]}:{args[2]}";
            //}
            //else
            //{
            //    DataService.baseUrl = @"https://localhost:7118";
            //}

            System.Console.WriteLine($"Adresa REST servera je {DataService.baseUrl}  - preuzeti podatke(Da/Ne):");

            var executeRequest = false;
            var tryCount = 0;

            string command;

            const int MAX_RETRIES = 3;
            const string CMD_YES = "da";
            const string CMD_NO = "ne";

            while (!executeRequest)
            {
                if (tryCount == MAX_RETRIES)
                {
                    System.Console.WriteLine("Previše pokušaja - izlaz");
                    //Environment.Exit(-1);
                }

                command = System.Console.ReadLine();

                if (command == CMD_YES)
                {
                    executeRequest = true;
                }
                else if (command != CMD_NO)
                {
                    System.Console.WriteLine($"[{tryCount + 1}]Unesite Da ili Ne!");
                }
                else
                {
                    System.Console.WriteLine("Izlaz");
                    //Environment.Exit(0);
                }

                tryCount++;
            }

            RestClient<Zaposlenik> zaposlenikRestClient = new RestClient<Zaposlenik>("Zaposlenik");

            System.Console.WriteLine("Calling REST service ...");

            zaposlenikRestClient.loadAll();

            zaposlenikRestClient.getDataSource().ForEach(item =>
            {

                System.Console.WriteLine($"{item.Ime} {item.Prezime}");

            });
            System.Console.ReadLine();
            
        }
    }
}
