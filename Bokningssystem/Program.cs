using System.Runtime.CompilerServices;

namespace Bokningssystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine($"[1] Boka Sal");
                Console.WriteLine($"[2] Bokningar");
                Console.WriteLine($"[3] Lokaler");
                Console.WriteLine($"[4] Ändra bokningar");
                Console.ReadKey();
            }
        }
    }
}


interface IBookable //interface för klasser som ska kunna bokas
{
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

class Sal : Lokal
{

}

class Grupprum : Lokal
{

}