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
        public List<Paciente> Pacientes { get; set; } 


        public Paciente(int dni,string nom,string ape,DateTime fecnac, int tel,string tipcob) : base (nom,ape)
        {
            this.DNI = dni;
            this.FechaNacimiento = fecnac;
            this.Telefono = tel;
            this.TipoCobertura = tipcob;
            Pacientes = new List<Paciente>();
        }   

        public void RegistrarPaciente(Paciente p)
        {
            do
            {
                Console.WriteLine("Ingrese DNI del paciente");
                valido = int.TryParse(Console.ReadLine(), out int d);
                DNI = d;
                if(!valido)
                {
                    Console.WriteLine("Ingrese un DNI válido.");
                }
                else if (Pacientes.Any(a => a.DNI == DNI))
                {
                    Console.WriteLine("No se puede registrar dos pacientes con el mismo DNI.");
                    valido = false;
                }

            }while (!valido);

           Pacientes.Add(p); 
        }

        public void Listarpaciente()
        {
            Console.WriteLine("DNI\t\tNombre\t\tEdad");
            Console.WriteLine("------------------------------------------");

            foreach (Paciente paciente in Pacientes)
            {
                Console.WriteLine($"{paciente.DNI}\t\t{paciente.Nombre}\t\t{paciente.Telefono}\t\t{paciente.TipoCobertura}\t\t{paciente.CalcularEdad()}");
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
