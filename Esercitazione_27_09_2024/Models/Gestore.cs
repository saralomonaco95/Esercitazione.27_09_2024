using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_27_09_2024.Models
{
    internal class Gestore
    { 
        public static void Stampatutto() {
            // stampo tutto utenti prenotazione e  libro
            using (var ctx = new Esercizio27092024Context())
            { 
                var elenco = ctx.Prestitos.ToList();

               foreach (var pre in elenco)
                {
                   pre.UtenteRifNavigation = ctx.Utentes.Single(u => u.UtenteId == pre.UtenteRif);

                    pre.LibroRifNavigation = ctx.Libris.Single(u => u.LibroId == pre.LibroRif); 


                   Console.WriteLine(pre);
                }
           }


        }

        public static  void Stampalibri()
        {
            using (var ctx = new Esercizio27092024Context())
            {
                var elenco = ctx.Libris.ToList();
               
                foreach(var lib in elenco)
                {
                    Console.WriteLine(lib);
                }


            }


            }



        public static void StampaUtente()
        {
            using (var ctx = new Esercizio27092024Context())
            {
                var elenco = ctx.Utentes.ToList();

                foreach (var ut in elenco)
                {
                    Console.WriteLine(ut);
                }


            }


        }



        public static bool Insertlibro(string Vartitolo , int Varannopub , bool varstato )
        { // inserisco libri 
             bool risultato = false;


            Libri lib = new Libri()
            {
                
             Titolo = Vartitolo ,
             AnnoPubb=Varannopub ,
             StatoDisp=varstato 


            };

            
            
            using (var ctx = new Esercizio27092024Context())

            {
                try
                {
                    ctx.Libris.Add(lib);
                    ctx.SaveChanges();
                    Console.WriteLine("inserimento ok ");
                       risultato =true; 
                    



                } catch (Exception ex) {
                
                       Console.WriteLine (ex.Message);
                }

            }



                return (risultato);



        }



    }
}
