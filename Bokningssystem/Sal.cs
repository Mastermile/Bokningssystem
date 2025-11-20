namespace Bokningssystem
{
    public class Sal : Lokal //Fylla i egenskaper, namn och kapacitet (kanske något mer)
    {
        private static int ID = 1; //Namnet för lokalen som automatiskt tilldelas när man skapar ett nytt rum
        public int _lokalId { get; set; }
        public int Kapacitet { get; set; }
        public string SalNamn { get; set; }
        public string Typ { get; set; }

        public Sal() { }
        public Sal(string typ, int kapacitet, string salNamn)
        {
            _lokalId = ID;
            ID++;
            Typ = typ;
            Kapacitet = kapacitet;
            SalNamn = salNamn;
        }
    }
}
