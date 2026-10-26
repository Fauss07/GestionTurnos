using GestionTurnos.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTurnos.Modelos
{
    internal class Paciente : Persona
    {
        bool valido = false;
        public int DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Telefono { get; set; }
        public string TipoCobertura { get; set; }
        public string mail { get; set; }
        public ICobertura Cobertura { get; set; }


        public Paciente(int dni,string nom,string ape,DateTime fecnac, int tel,string tipcob) : base (nom,ape)
        {
            this.DNI = dni;
            this.FechaNacimiento = fecnac;
            this.Telefono = tel;
            this.TipoCobertura = tipcob;
            if (TipoCobertura == "Particular")
            {
                Cobertura = new Particular();
            }
            else if (TipoCobertura == "Obra social")
            {
                Cobertura = new ObraSocial();
            }
        }   
        public int CalcularEdad()
        {

            int edad = DateTime.Now.Year - FechaNacimiento.Year;

            if (DateTime.Now < FechaNacimiento.AddYears(edad))
            {
                edad--;
            }
            return edad;    
        }
    }
}
