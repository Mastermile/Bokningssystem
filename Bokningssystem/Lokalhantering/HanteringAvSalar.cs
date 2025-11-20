using System.Text.Json;

namespace Bokningssystem.Lokalhantering
{
    public class HanteringAvSalar
    {
        private readonly string _filväg = @"C:\Users\maxen\Source\Repos\Bokningssystem\Bokningssystem\Salar.json";
        private List<Sal> _salar;

        public HanteringAvSalar() //Laddar in alla rum från filerna när programmet startar.
        {
            LaddaAllaGrupprumFrånFil();
        }
        private void LaddaAllaGrupprumFrånFil() //Laddar in grupprum
        {
            if (!File.Exists(_filväg))
            {
                _salar = new List<Sal>();
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
        
        public void LäggTillNySal(Sal sal)
        {
            _salar.Add(sal);

            SparaTillFilSalar();
        }

        private void SparaTillFilSalar()
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonLokal = JsonSerializer.Serialize(_salar, jsonOptions);
            File.WriteAllText(_filväg, jsonLokal);
        }

        public List<Sal> VisaSalar()
        {
            return _salar;
        }
    }
}
