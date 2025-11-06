using System.Runtime.CompilerServices;

namespace Bokningssystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //switch sats meny
                Console.WriteLine($"[1] Boka Sal"); //Kalla till en klass metod som ska spara "namn, lokal, starttid och sluttid"

                Console.WriteLine($"[2] Bokningar"); //Ska kallar på alla objekt i en klass för bokningar

                Console.WriteLine($"[3] Lokaler"); //Lista alla lokaler som finns

                Console.WriteLine($"[4] Ändra bokning");

                Console.WriteLine($"[5] lista alla bokningar");

                Console.WriteLine();

                Console.ReadKey();

            }
        }
    }
}
interface IBookable //interface för klasser som ska kunna bokas
{
    //Egenskaper som ska ärvas av klasser. Namn för bokaren, typ av lokal, storlek, starttid, sluttid
    void StartTid();
    void SlutTid();
}

class Lokal : IBookable//Base class
{
    
    public void StartTid()
    {
        throw new NotImplementedException();
    }
    public void SlutTid()
    {
        throw new NotImplementedException();
    }
}

class Sal : Lokal //Fylla i egenskaper, namn och kapacitet (kanske något mer)
{
    public string LokalNamn;
}

class Grupprum : Lokal //Fylla i egenskaper, namn och kapacitet (kanske något mer)
{

}
class NyBokning : IBookable//Klass metod för att göra ny bokning
{
    public string Name;
    public string Lokal;
    public void StartTid()
    {

    }

    public void SlutTid()
    {

    }
}