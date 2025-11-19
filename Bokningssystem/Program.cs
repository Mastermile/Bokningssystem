using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

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

    interface IBookable //interface för klasser som ska kunna bokas
    {
        //Egenskaper som ska ärvas av klasser. Namn för bokaren, typ av lokal, storlek, starttid, sluttid
        void BokaTid();

    }

    public class Lokal : IBookable//Base class
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
                Console.WriteLine($"Vilken tid vill du boka ({openTime}-{closingTime - 1})");
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
                                    bokadTid = endTime - startTime; //Displays HH

                                    pickEndTime = false;


                                    ///////////////////////////////////// För tester ////////////////////////////////////////////
                                    Console.WriteLine($"Start tid: {startTime}");
                                    Console.WriteLine($"Slut tid: {endTime}");
                                    Console.WriteLine($"Timmar bokat: {bokadTid.Hours}");
                                    /////////////////////////////////////////////////////////////////////////////////////////////                                   
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
                        //////////////////////////////////////////////////////////////////////////////////////////
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

    public class HanteringAvSalar
    {
        private readonly string _filväg = @"C:\Users\maxen\Source\Repos\Bokningssystem\Bokningssystem\Salar.json";
        private List<Sal> _salar;

        public HanteringAvSalar() //Laddar in alla rum från filerna när programmet startar.
        {
            LaddaAllaGrupprumFrånFil();
            //LaddaAllaSalarFrånFil();
        }
        private void LaddaAllaGrupprumFrånFil() //Laddar in grupprum
        {
            if (!File.Exists(_filväg))
            {
                _salar = new List<Sal>();
                return;
            }
            try
            {
                string jsonLokaler = File.ReadAllText(_filväg);
                _salar = JsonSerializer.Deserialize<List<Sal>>(jsonLokaler);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Det fanns ingen lista så en ny är nu skapad. {ex.Message}");
                _salar = new List<Sal>();
            }
        }
        
        public void LäggTillNySal(Sal sal)
        {
            _salar.Add(sal);

            SparaTillFilSalar();
        }

        private void SparaTillFilSalar()
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonLokal = JsonSerializer.Serialize(_salar, jsonOptions);
            File.WriteAllText(_filväg, jsonLokal);
        }

        public List<Sal> VisaSalar()
        {
            return _salar;
        }
    }
    public class HanteringAvGrupprum
    {
        //private readonly string _filvägGrupprum = "Grupprum.json";
        //private readonly string _filvägSalar = "Salar.json";
        //private List<Grupprum> _grupprum;
        private readonly string _filväg = @"C:\Users\maxen\Source\Repos\Bokningssystem\Bokningssystem\Grupprum.json";
        private List<Grupprum> _grupprum;
        private List<Sal> _salar;

        public HanteringAvGrupprum() //Laddar in alla rum från filerna när programmet startar.
        {
            LaddaAllaGrupprumFrånFil();
            //LaddaAllaSalarFrånFil();
        }
        private void LaddaAllaGrupprumFrånFil() //Laddar in grupprum
        {
            if (!File.Exists(_filväg))
            {
                _grupprum = new List<Grupprum>();
                return;
            }
            try
            {
                string jsonLokaler = File.ReadAllText(_filväg);
                _grupprum = JsonSerializer.Deserialize<List<Grupprum>>(jsonLokaler);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Det fanns ingen lista så en ny är nu skapad. {ex.Message}");
                _grupprum = new List<Grupprum>();
            }
        }
       
        public void LäggTillNyttGrupprum(Grupprum grupprum)
        {
            _grupprum.Add(grupprum);

            SparaTillFilGrupprum();
        }

        private void SparaTillFilGrupprum()
        {
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonLokal = JsonSerializer.Serialize(_grupprum, jsonOptions);
            File.WriteAllText(_filväg, jsonLokal);
        }

        public List<Grupprum> VisaGrupprum()
        {
            return _grupprum;
        }
    }
    class Bokningar // Här kommer vi lagra bokningar som objekt för att kunna lista.
    {

    }
}
