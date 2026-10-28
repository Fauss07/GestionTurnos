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
        public int DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public long Telefono { get; set; }
        public string TipoCobertura { get; set; }
        public string mail { get; set; }
        public Persona(string nom,string ape, int dni, DateTime fechaNacimiento, long telefono, string tipoCobertura, string mail)
        {
            this.Nombre = nom;
            this.Apellido = ape;
            this.DNI = dni;
            this.FechaNacimiento = fechaNacimiento;
            this.Telefono = telefono;
            this.TipoCobertura = tipoCobertura;
            this.mail = mail;
        }
       
    }
}
