using Bokningssystem.Lokalhantering;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Bokningssystem
{
    internal class Program
    {
        private readonly HanteringAvGrupprum _gruppHantering; //En instans av hanterings klassen för att använda denns funktioner.
        private readonly HanteringAvSalar _salHantering;
        public Program()
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


                //switch sats meny
                Console.WriteLine($"[1] Boka Sal"); //Kalla till en klass metod som ska spara "namn, lokal, starttid och sluttid"

                Console.WriteLine($"[2] Bokningar"); //Ska kallar på alla objekt i en klass för bokningar

                Console.WriteLine($"[3] Lokaler"); //Lista alla lokaler som finns

                Console.WriteLine($"[4] Ändra bokning");

                Console.WriteLine($"[5] lista alla bokningar");

                Console.WriteLine($"[6] Skapa ny lokal");

                Console.WriteLine();

                //Console.ReadKey();
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

                        case "2":
                            //Metoden för att se alla bokningar

                            Console.WriteLine("Test case 2");
                            break;

                        case "3":
                            //Metoden för att lista salar och deras egenskaper
                            Console.WriteLine("Test case 3");
                            test.ListaAllaLokaler();
                            break;

                        case "4":
                            //Metod för att ändra / ta bort
                            Console.WriteLine("Test case 4");
                            break;

                        case "5":
                            //Metod för att lista alla bokningar inom ett specifikt år.
                            Console.WriteLine("Test case 5");
                            break;

                        case "6":
                            Lokal lokal = new Lokal();
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

        public void SkapaNyLokal()
        {
            Console.WriteLine("Vilken typ av lokal vill du lägga till? (1-2).");

            Console.WriteLine("[1]. Sal");
            Console.WriteLine("[2]. Grupprum");
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int userChoice))
                {
                    if (userChoice == 1)
                    {
                        SkapaNySal();
                        break;
                    }
                    else if (userChoice == 2)
                    {

                        SkapaNyGrupprum();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Vänliga välj en siffra mellan (1-2)");
                    }
                }
            }
        }
        public void SkapaNyGrupprum()
        {
            Console.Write("Välj ett namn på grupprummet:");
            string inputNamn = Console.ReadLine();

            Console.WriteLine("Ange hur många platser salen har: ");
            int.TryParse(Console.ReadLine(), out int kapacitet);

            if (!string.IsNullOrEmpty(inputNamn))
            {
                Grupprum grupprum = new Grupprum("Grupprum", kapacitet, inputNamn);
                Console.WriteLine($"Ditt nya grupprum har skapats! \nNamn: {inputNamn}\nAntal platser: {kapacitet}");
                _gruppHantering.LäggTillNyttGrupprum(grupprum);
            }
        }
        public void SkapaNySal()
        {
            Console.Write("Välj ett namn på salen:");
            string inputNamn = Console.ReadLine();

            Console.WriteLine("Ange hur många platser salen har: ");
            int.TryParse(Console.ReadLine(), out int kapacitet);

            if (!string.IsNullOrEmpty(inputNamn))
            {
                Sal sal = new Sal("Sal", kapacitet, inputNamn);
                Console.WriteLine($"Din nya sal har skapats! \nNamn: {inputNamn}\nAntal platser: {kapacitet}");
                _salHantering.LäggTillNySal(sal);
            }
            else
                Console.WriteLine("Något gick fel försök igen.");
        }
        public void ListaAllaLokaler()
        {
            var grupprum = _gruppHantering.VisaGrupprum();
            var salar = _salHantering.VisaSalar();

            if (!grupprum.Any())
            {
                Console.WriteLine("Det finns inga grupprum");
            }
            foreach (var g in grupprum)
            {
                Console.WriteLine($"[Typ: {g.Typ}] [Namn: {g.GrupprumNamn}] [Antal platser = {g.Kapacitet}]");
            }
            if (!salar.Any())
            {
                Console.WriteLine("Det finns inga salar att visa");
            }
            foreach (var s in salar)
            {
                Console.WriteLine($"[Typ: {s.Typ}] [Namn: {s.SalNamn}] [Antal platser = {s.Kapacitet}]");
            }
        }
    }
}
