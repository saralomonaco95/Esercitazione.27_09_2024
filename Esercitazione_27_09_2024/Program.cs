using Esercitazione_27_09_2024.Models;

namespace Esercitazione_27_09_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Gestore.Stampatutto();
            // Gestore.Stampalibri();
            //Gestore.StampaUtente(); 

            Console.WriteLine("dammi il titolo");

              string? insTitolo = Console.ReadLine();


            Console.WriteLine("dammi la data di pubblicazione");


            int Insannopub = Convert.ToInt32( Console.ReadLine());

            Console.WriteLine("dimmi true o false per capire se è disponibile ");
            bool Insdisp = Convert.ToBoolean( Console.ReadLine());

            Gestore.Insertlibro(insTitolo,Insannopub,Insdisp);

        }

        }
    }

