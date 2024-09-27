using System;
using System.Collections.Generic;

namespace Esercitazione_27_09_2024.Models;

public partial class Prestito
{
    public int PrestitoId { get; set; }

    public int UtenteRif { get; set; }

    public int LibroRif { get; set; }

    public DateOnly Dataprestito { get; set; }

    public DateOnly Dataritorno { get; set; }

    public virtual Libri LibroRifNavigation { get; set; } = null!;

    public virtual Utente UtenteRifNavigation { get; set; } = null!;


    public override string ToString() //_ to string permette di stampare 
    {
        return $"[Prestito]{PrestitoId}{UtenteRif}{LibroRif} {Dataprestito}{Dataritorno}{UtenteRifNavigation.ToString()}{LibroRifNavigation.ToString()}";
    }
}
