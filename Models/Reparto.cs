//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EjercicioMVC3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reparto
    {
        public int Id { get; set; }
        public string Personaje { get; set; }
        public int PeliculaId { get; set; }
        public int ActorId { get; set; }
    
        public virtual Pelicula Pelicula { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
