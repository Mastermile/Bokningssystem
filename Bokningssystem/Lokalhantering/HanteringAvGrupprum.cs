using System.Text.Json;

namespace Bokningssystem.Lokalhantering
{
    /// <summary>
    /// 
    /// </summary>
    public class HanteringAvGrupprum
    {
        private readonly string _filväg = @"C:\Users\maxen\Source\Repos\Bokningssystem\Bokningssystem\Grupprum.json";
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
       
        public void LäggTillNyttGrupprum(Grupprum grupprum)
        {
            _grupprum.Add(grupprum);

            SparaTillFilGrupprum();
        }

        private void SparaTillFilGrupprum()
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
