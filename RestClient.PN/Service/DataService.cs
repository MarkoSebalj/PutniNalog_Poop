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
        public static RestClient<VrstaTroska> vrstaTroskaRestClient { get; set; }
        public static RestClient<Vozilo> voziloRestClient { get; set; }
        public static RestClient<RadnoMjesto> radnoMjestoRestClient { get; set; }
        public static RestClient<PutniTroskovi> putniTroskoviRestClient  { get; set; }
        public static RestClient<PutniNalog> putniNalogRestClient { get; set; }
        public static RestClient<MjestoPutovanja> mjestoPutovanjaRestClient { get; set; }


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
            vrstaTroskaRestClient = new RestClient<VrstaTroska>("Vrsta Troška");
            voziloRestClient = new RestClient<Vozilo>("Vozilo");
            radnoMjestoRestClient = new RestClient<RadnoMjesto>("Radno Mjesto");
            putniTroskoviRestClient = new RestClient<PutniTroskovi>("Putni Troškovi");
            putniNalogRestClient = new RestClient<PutniNalog>("Putni Nalog");
            mjestoPutovanjaRestClient = new RestClient<MjestoPutovanja>("Mjesto Putovanja");
           
        }

    }
}
