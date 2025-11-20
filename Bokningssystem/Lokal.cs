namespace Bokningssystem
{
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
}
