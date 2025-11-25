using Bokningssystem.Lokalhantering;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Bokningssystem
{
    internal class Program
    {
        private readonly HanteringAvGrupprum _gruppHantering; //En instans av hanterings klassen för att använda dens funktioner.
        private readonly HanteringAvSalar _salHantering;
        public Program() //Konstruktor för att initiera hanterings klasserna
        {
            _gruppHantering = new HanteringAvGrupprum();
            _salHantering = new HanteringAvSalar();
        }

        static void Main(string[] args)
        {
            Program test = new(); //Instans av program för att slippa använda åtkomstmodifierare
            bool programIsRunning = true;
            while (programIsRunning)
            {

                Console.Clear();
                Console.WriteLine($"=====Välkommen till bokningssystemet!=====");
                //switch sats meny
                Console.WriteLine($"[1] Boka Sal"); //Kalla till en klass metod som ska spara "namn, lokal, starttid och sluttid"
                Console.WriteLine($"[2] Bokningar"); //Ska kallar på alla objekt i en klass för bokningar
                Console.WriteLine($"[3] Lokaler"); //Lista alla lokaler som finns
                Console.WriteLine($"[4] Ändra bokning");
                Console.WriteLine($"[5] lista alla bokningar");
                Console.WriteLine($"[6] Skapa ny lokal");
                Console.WriteLine($"[0] Avsluta programmet");
                Console.WriteLine();
                Console.Write($"Ditt val 1-6 eller 0 för att avsluta: ");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    switch (input)
                    {
                        case "1":
                            //Metoden för att boka sal

                            //tillfälliga tester
                            Sal sal = new Sal("sal", 14, "");
                            sal.BokaTid();
                            break;

                        case "2": //Inkomplett
                            //Metoden för att se alla bokningar
                            Console.WriteLine("Test case 2");
                            break;

                        case "3": //M.O
                            //Metoden för att lista salar och deras egenskaper
                            test.ListaAllaLokaler();
                            break;

                        case "4": //Inkomplett
                            //Metod för att ändra / ta bort
                            Console.WriteLine("Test case 4");
                            break;

                        case "5": //Inkomplett
                            //Metod för att lista alla bokningar inom ett specifikt år.
                            Console.WriteLine("Test case 5");
                            break;

                        case "6": //M.O
                            test.SkapaNyLokal();
                            break;

                        case "0":
                            programIsRunning = false;
                            break;

                        default:
                            Console.WriteLine("Vänligen ange siffran för den funktion du vill göra (1-5) eller tryck 0 för att avsluta");
                            break;
                    }    
                }
                else Console.WriteLine("Vänligen välj ett en siffra (1-6) eller 0 för att avsluta");

            }
        }

        //Metod för att skapa en ny lokal
        public void SkapaNyLokal() //M.O 
        {
            Console.Clear();
            Console.WriteLine("Vilken typ av lokal vill du lägga till? (1-2).");
            Console.WriteLine("[1]. Sal");
            Console.WriteLine("[2]. Grupprum");
            while (true)
            {
                Console.Write("Ditt val: ");
                string input = Console.ReadLine(); //Tar in användarens val
                if (int.TryParse(input, out int userChoice)) //Validering
                {
                    if (userChoice == 1)
                    {
                        SkapaNySal(); //Skickar användaren till metoden för att skapa en ny sal
                        break;
                    }
                    else if (userChoice == 2)
                    {
                        SkapaNyGrupprum(); //Skickar användaren till metoden för att skapa ett nytt grupprum
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Vänliga välj en siffra mellan (1-2)");
                    }
                }
                else
                    Console.WriteLine("Något gick fel försök igen.");
            }
        }
        //Metod för att skapa ett nytt grupprum
        public void SkapaNyGrupprum() //M.O
        {
            while (true)
            {
                Console.Write("Välj ett namn på grupprummet: ");
                string inputNamn = Console.ReadLine();

                Console.Write("Ange hur många platser grupprummet har: ");
                bool success = int.TryParse(Console.ReadLine(), out int kapacitet);

                if (!string.IsNullOrEmpty(inputNamn) && success != false) //validering för att undvika tomma strängar och ogiltiga inputs
                {
                    Grupprum grupprum = new Grupprum("Grupprum", kapacitet, inputNamn);
                    Console.WriteLine($"Ditt nya grupprum har skapats! \nNamn: {inputNamn}\nAntal platser: {kapacitet}");
                    _gruppHantering.LäggTillNyttGrupprum(grupprum);
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
                    Console.ReadKey();
                    break;
                }
                else
                    Console.Clear();
                    Console.WriteLine("Något gick fel försök igen.");
            }
        }
        //Metod för att skapa en ny sal
        public void SkapaNySal() //M.O
        {
            while (true)
            {
                Console.Write("Välj ett namn på salen: ");
                string inputNamn = Console.ReadLine();

                Console.Write("Ange hur många platser salen har: ");
                bool success = int.TryParse(Console.ReadLine(), out int kapacitet);

                if (!string.IsNullOrEmpty(inputNamn) && success != false)
                {
                    Sal sal = new Sal("Sal", kapacitet, inputNamn); //Skapar ett nytt sal objekt, skapar en hårdkodad typ "Sal"
                    Console.WriteLine($"Din nya sal har skapats! \nNamn: {inputNamn}\nAntal platser: {kapacitet}");
                    _salHantering.LäggTillNySal(sal); //Lägger till den nya salen i listan över salar
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
                    Console.ReadKey();
                    break;
                }
                else
                    Console.Clear();
                    Console.WriteLine("Något gick fel försök igen.");
            }
        }
        //Metod för att lista alla lokaler
        public void ListaAllaLokaler() //M.O
        {
            var grupprum = _gruppHantering.VisaGrupprum();
            var salar = _salHantering.VisaSalar();

            if (!grupprum.Any()) //Kollar om det finns några grupprum i listan
            {
                Console.WriteLine("Det finns inga grupprum");
            }
            foreach (var g in grupprum) //Listar alla grupprum med deras egenskaper
            {
                Console.WriteLine($"[Typ: {g.Typ}] [Namn: {g.GrupprumNamn}] [Antal platser = {g.Kapacitet}]");
            }
            if (!salar.Any())  //Kollar om det finns några salar i listan
            {
                Console.WriteLine("Det finns inga salar att visa");
            }
            foreach (var s in salar)
            {
                Console.WriteLine($"[Typ: {s.Typ}] [Namn: {s.SalNamn}] [Antal platser = {s.Kapacitet}]"); //Listar alla salar med deras egenskaper
            }
            Console.WriteLine("Tryck på valfri knapp för att fortsätta...");
            Console.ReadKey();
        }
    }
}
