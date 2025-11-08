using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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
                            
                            //tillfälliga tester
                            Sal sal = new Sal();
                            sal.BokaTid();
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
    void BokaTid();

}

class Lokal : IBookable//Base class
{
    //Open times
    static int openTime = 8; 
    static int closingTime = 17;

    public void BokaTid()
    {
        bool pickStartTime = true;
        bool pickEndTime = false;
        int IntStartTime;
        TimeOnly startTime;
        TimeOnly endTime;
        TimeSpan bokadTid;

        

        while (pickStartTime = true)
        {
            Console.Clear();
            Console.WriteLine("[0] Tillbaka");
            Console.WriteLine($"Vilken tid vill du boka ({openTime}-{closingTime-1})");
            string inputStartTime = Console.ReadLine();

            //Go back to main menu
            if (inputStartTime == "0")
            {
                pickStartTime = false;
                break;
            }

            bool isInt = int.TryParse(inputStartTime, out int value); //Returns true is input is an integer
            //Checks if the input is a valid input
            if (string.IsNullOrEmpty(inputStartTime) || isInt == false)
            {
                Console.WriteLine("Vänligen välj en siffra");
            }
            else
            {
                int startTimeInt = int.Parse(inputStartTime); //Makes input string into an int
                //Checks if the chosen time is within open times
                if (startTimeInt >= openTime && startTimeInt < closingTime)
                {
                    startTime = new TimeOnly(startTimeInt, 0); //Displays HH:00

                    pickStartTime = false;
                    pickEndTime = true;


                    //Pick when your booked time ends
                    while (pickEndTime = true)
                    {
                        Console.WriteLine($"Välj när du vill avsulta bokningen");
                        string inputEndTime = Console.ReadLine();

                        isInt = int.TryParse(inputEndTime, out value); //Returns true is input is an integer
                        //Checks if the input is a valid input
                        if (string.IsNullOrEmpty(inputEndTime) || isInt == false)
                        {
                            Console.WriteLine("Vänligen välj en siffra");
                        }
                        else
                        {
                            int endTimeInt = int.Parse(inputEndTime); //Makes input string into an int
                            if (endTimeInt > startTimeInt && endTimeInt <= closingTime)
                            {

                                endTime = new TimeOnly(endTimeInt, 0); //Displays HH:00
                                bokadTid = endTime-startTime; //Displays HH
                                
                                pickEndTime = false;
                                

///////////////////////////////////// För tester ////////////////////////////////////////////
                                Console.WriteLine($"Start tid: {startTime}");
                                Console.WriteLine($"Slut tid: {endTime}");
                                Console.WriteLine($"Timmar bokat: {bokadTid.Hours}");
                                
                                break;
                            }
                            else //endTime is before startTime or after closingTime
                            {
                                Console.WriteLine("Du kan inte välja den tiden");
                            }
                        }
                    }

////////////////////////////////// För tester ////////////////////////////////////////////
                    Console.WriteLine();
                    Console.WriteLine("Tryck på valfri knapp för att gå vidare");
                    Console.ReadKey();
                    break;
                }
                else //startTime is before openTime or at closingTime
                {
                    Console.WriteLine("Välj en giltig tid");
                }
            }
        }
        
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
class NyBokning : IBookable//Klass metod för att göra ny bokning
{
    public string Name;
    public string Lokal;
    public DateTime Starttid;
    public DateTime Sluttid;

    public void BokaTid()
    {
        throw new NotImplementedException();
    }
}

class Bokningar // Här kommer vi lagra bokningar som objekt för att kunna lista.
{

}