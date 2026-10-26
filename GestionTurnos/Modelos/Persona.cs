using GestionTurnos.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTurnos.Modelos
{
    public abstract class Persona 
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; } 
        public Persona(string nom,string ape)
        {
            this.Nombre = nom;
            this.Apellido = ape;
        }
    }
}
