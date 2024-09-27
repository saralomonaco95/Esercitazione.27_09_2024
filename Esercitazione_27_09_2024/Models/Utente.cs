using System;
using System.Collections.Generic;

namespace Esercitazione_27_09_2024.Models;

public partial class Utente
{
    public int UtenteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Prestito> Prestitos { get; set; } = new List<Prestito>();

    public override string ToString() //_ to string permette di stampare 
    {
        return $"[Utente]{UtenteId}{Nome}{Cognome}{Email}";
    }

}
