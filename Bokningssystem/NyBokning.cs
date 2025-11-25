namespace Bokningssystem //Inkomplett
{
    class NyBokning : IBookable//Klass metod för att göra ny bokning
    {

        public TimeOnly Starttid;
        public TimeOnly Sluttid;
        public TimeSpan BokadTid;


        public void BokaTid()
        {
            throw new NotImplementedException();
        }
    }
}
