using Microsoft.EntityFrameworkCore.ChangeTracking;
using Intuit.Ipp.DataService;
using RestClient.PN;
using Model.PN.Model;
using PutniNalogDataContext.PN.Database;

namespace Console.PN
{
   class Program
    {
        static void Main(string[] args)
        {
             PNDbContext pnDbContext = new PNDbContext();

            /*Dodavanje mjesta*/
            EntityEntry<MjestoPutovanja> novoMjestoPutovanja = pnDbContext.MjestoPutovanja.Add(new MjestoPutovanja 
            {
                Id = 4,
                NazivMjesta = "Varazdin"
            });
            pnDbContext.SaveChanges();

            /*Update naziva mjesta*/

            MjestoPutovanja izmjenaNaziva = pnDbContext.MjestoPutovanja.Find(novoMjestoPutovanja.Entity.NazivMjesta);
            izmjenaNaziva.NazivMjesta = "Virovitica";

            novoMjestoPutovanja = pnDbContext.MjestoPutovanja.Update(izmjenaNaziva);
            pnDbContext.SaveChanges();

            /*brisanje mjesta*/

            pnDbContext.MjestoPutovanja.Remove(novoMjestoPutovanja.Entity);
            pnDbContext.SaveChanges();

            /*Dodavanje Putnog troska*/
            EntityEntry<PutniTroskovi> noviPutniTroskovi = pnDbContext.PutniTroskovi.Add(new PutniTroskovi
            {
                Id = 4,
                IznosTroska = 276.25,
                VrstaTroska = 1
                
            }); 
            pnDbContext.SaveChanges();

            /*Dodavanje Radnog mjesta*/
            EntityEntry<RadnoMjesto> novoRadnoMjesto = pnDbContext.RadnoMjesto.Add(new RadnoMjesto
            {
                Id = 4,
                Naziv = "Tehnicar"

            });
            pnDbContext.SaveChanges();

            /*Dodavanje vozila*/
            EntityEntry<Vozilo> novoVozilo = pnDbContext.Vozilo.Add(new Vozilo
            {
                Id = 4,
                Marka = "Audi",
                Registracija ="ZG4658FF"

            });
            pnDbContext.SaveChanges();

            /*Dodavanje vrste troska*/
            EntityEntry<VrstaTroska> novaVrstaTroska = pnDbContext.VrstaTroska.Add(new VrstaTroska
            {
                Id = 4,
                Naziv ="Ostali troskovi"

            });
            pnDbContext.SaveChanges();

            /*Dodavanje zaposlenika*/
            EntityEntry<Zaposlenik> noviZaposlenik = pnDbContext.Zaposlenik.Add(new Zaposlenik
            {
                Id = 4,
                Ime ="Marko",
                Prezime = "Markic",
                UkupniIznosTroska = 12365.57,
                RadnoMjesto = 1,
                PutniTroskovi =1

            });
            pnDbContext.SaveChanges();


            /*

            if (args.Length == 3)
            {
                DataService.baseUrl = $"https://{args[1]}:{args[2]}";
            }
            else
            {
                DataService.baseUrl = @"https://localhost:7109";
            }

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
                    Environment.Exit(-1);
                }

                command = System.Console.ReadLine().ToLower();

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
                    Environment.Exit(0);
                }

                tryCount++;
            }

            RestClient<Zaposlenik> zaposlenikRestClient = new RestClient<Zaposlenik>("Zaposlenik");

            System.Console.WriteLine("Calling REST service ...");

            zaposlenikRestClient.loadAll();

            zaposlenikRestClient.getDataSource().ForEach(item =>
            {

                System.Console.WriteLine($"{item.FirstName} {item.LastName}");

            });*/

        }
    }
}
