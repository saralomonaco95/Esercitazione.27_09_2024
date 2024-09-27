using System;
using System.Collections.Generic;

namespace Esercitazione_27_09_2024.Models;

public partial class Libri
{
    public int LibroId { get; set; }

    public string Titolo { get; set; } = null!;

    public int AnnoPubb { get; set; }

    public bool StatoDisp { get; set; }

    public virtual ICollection<Prestito> Prestitos { get; set; } = new List<Prestito>();


    public override string ToString() //_ to string permette di stampare 
    {
        return $"[Libro]{LibroId}{Titolo}{AnnoPubb}";
    }
}
