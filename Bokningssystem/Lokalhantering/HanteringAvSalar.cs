using System.Text.Json;

namespace Bokningssystem.Lokalhantering //M.O
{
    public class HanteringAvSalar
    {
        private readonly string _filväg = @"C:\Users\maxen\Desktop\Bokningssystem\Bokningssystem\Bokningssystem\Salar.json";
        private List<Sal> _salar;

        public HanteringAvSalar() //Laddar in alla rum från filerna när programmet startar.
        {
            LaddaAllaGrupprumFrånFil();
        }
        private void LaddaAllaGrupprumFrånFil() //Laddar in grupprum
        {
            if (!File.Exists(_filväg)) //Kollar om filen finns
            {
                _salar = new List<Sal>(); //Om den inte finns skapas en ny lista
                return;
            }
            try
            {
                string jsonLokaler = File.ReadAllText(_filväg);
                _salar = JsonSerializer.Deserialize<List<Sal>>(jsonLokaler);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Det fanns ingen lista så en ny är nu skapad. {ex.Message}");
                _salar = new List<Sal>();
            }
        }
        
        public void LäggTillNySal(Sal sal) //Lägger till ett nytt sal objekt till listan och sparar till fil
        {
            _salar.Add(sal);

            SparaTillFilSalar();
        }

        private void SparaTillFilSalar() //Sparar alla salar till fil
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonLokal = JsonSerializer.Serialize(_salar, jsonOptions);
            File.WriteAllText(_filväg, jsonLokal);
        }

        public List<Sal> VisaSalar() //Returnerar listan med salar
        {
            return _salar;
        }
    }
}
