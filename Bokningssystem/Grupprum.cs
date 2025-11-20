namespace Bokningssystem
{
    public class Grupprum : Lokal //Fylla i egenskaper, namn och kapacitet (kanske något mer)
    {
        private static int LokalID = 1; //Namnet för lokalen som automatiskt tilldelas när man skapar ett nytt rum
        public int _lokalId { get; set; }
        public int Kapacitet { get; set; }
        public string GrupprumNamn { get; set; }
        public string Typ { get; set; }

        public Grupprum() { }
        public Grupprum(string typ, int kapacitet, string grupprumsNamn)
        {
            _lokalId = LokalID;
            LokalID++;
            Typ = typ;
            Kapacitet = kapacitet;
            GrupprumNamn = grupprumsNamn;
        }
    }
}
