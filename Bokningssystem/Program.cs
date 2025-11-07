using System.Runtime.CompilerServices;

namespace Bokningssystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool programIsRunning = true;
            while (programIsRunning)
            {

                
                //switch sats meny
                Console.WriteLine($"[1] Boka Sal"); //Kalla till en klass metod som ska spara "namn, lokal, starttid och sluttid"

                Console.WriteLine($"[2] Bokningar"); //Ska kallar på alla objekt i en klass för bokningar

                Console.WriteLine($"[3] Lokaler"); //Lista alla lokaler som finns

                Console.WriteLine($"[4] Ändra bokning");

                Console.WriteLine($"[5] lista alla bokningar");

                Console.WriteLine();

                //Console.ReadKey();
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    switch(input)
                    {
                        case "1":
                            //Metoden för att boka sal
                            Console.WriteLine("Test case 1");
                            break;

                        case "2":
                            //Metoden för att se alla bokningar
                            Console.WriteLine("Test case 2");
                            break;

                        case "3":
                            //Metoden för att lista salar och deras egenskaper
                            Console.WriteLine("Test case 3");
                            break;

                        case "4":
                            //Metod för att ändra / ta bort
                            Console.WriteLine("Test case 4");
                            break;

                        case "5":
                            //Metod för att lista alla bokningar inom ett specifikt år.
                            Console.WriteLine("Test case 5");
                            break;

                        case "0":
                            programIsRunning = false;
                            break;

                        default:
                            Console.WriteLine("Vänligen ange siffran för den funktion du vill göra (1-5) eller tryck 0 för att avsluta");
                            
                            break;
                        

                    }

                }
                else Console.WriteLine("Vänligen välj ett en siffra (1-5) eller 0 för att avsluta");
            
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
    public DateTime Öppentider;
}

class Grupprum : Lokal //Fylla i egenskaper, namn och kapacitet (kanske något mer)
{

}
class NyBokning : IBookable //Klass metod för att göra ny bokning
{
    public string Name;
    public string Lokal;
    public DateTime Starttid;
    public DateTime Sluttid;

    public void StartTid()
    {
        throw new NotImplementedException();
    }
    public void SlutTid()
    {
        throw new NotImplementedException();
    }

}

class Bokningar // Här kommer vi lagra bokningar som objekt för att kunna lista.
{

}