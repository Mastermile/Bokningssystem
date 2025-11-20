namespace Bokningssystem
{
    class NyBokning : IBookable//Klass metod för att göra ny bokning
    {
        public string Name;
        public string Lokal;
        public TimeOnly Starttid;
        public TimeOnly Sluttid;

        public void BokaTid()
        {
            throw new NotImplementedException();
        }
    }
}
