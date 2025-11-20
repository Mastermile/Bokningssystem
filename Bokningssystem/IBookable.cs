namespace Bokningssystem
{
    interface IBookable //interface för klasser som ska kunna bokas
    {
        //Egenskaper som ska ärvas av klasser. Namn för bokaren, typ av lokal, storlek, starttid, sluttid
        void BokaTid();

    }
}
