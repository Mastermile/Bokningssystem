using System.Text.Json;

namespace Bokningssystem.Lokalhantering
{
    
    public class HanteringAvGrupprum //M.O
    {
        private readonly string _filväg = @"C:\Users\maxen\Desktop\Bokningssystem\Bokningssystem\Bokningssystem\Grupprum.json";
        private List<Grupprum> _grupprum;

        public HanteringAvGrupprum() //Laddar in alla rum från filerna när programmet startar.
        {
            LaddaAllaGrupprumFrånFil();
        }
        private void LaddaAllaGrupprumFrånFil() //Laddar in grupprum
        {
            if (!File.Exists(_filväg))
            {
                _grupprum = new List<Grupprum>();
                return;
            }
            try
            {
                string jsonLokaler = File.ReadAllText(_filväg);
                _grupprum = JsonSerializer.Deserialize<List<Grupprum>>(jsonLokaler);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Det fanns ingen lista så en ny är nu skapad. {ex.Message}");
                _grupprum = new List<Grupprum>();
            }
        }
       
        public void LäggTillNyttGrupprum(Grupprum grupprum) //Lägger till ett nytt grupprum objekt till listan och sparar till fil
        {
            _grupprum.Add(grupprum);

            SparaTillFilGrupprum();
        }

        private void SparaTillFilGrupprum() //Sparar alla grupprum till fil
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonLokal = JsonSerializer.Serialize(_grupprum, jsonOptions);
            File.WriteAllText(_filväg, jsonLokal);
        }

        public List<Grupprum> VisaGrupprum()
        {
            return _grupprum;
        }
    }
}
