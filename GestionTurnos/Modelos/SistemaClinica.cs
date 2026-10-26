using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTurnos.Modelos
{
    internal class SistemaClinica
    {
        public List <Paciente> Pacientes { get; set; } = new List<Paciente>();

        public void RegistrarPaciente(Paciente paciente)
        {
            if (paciente == null)
            {
                Console.WriteLine("Error: el paciente no puede ser nulo.");
                return;
            }
            Console.WriteLine("-----REGISTRO DE PACIENTE-----");

            Console.WriteLine($"Ingrese el nombre del paciente");
            paciente.Nombre = Console.ReadLine();
            while (paciente.Nombre == "")
            {
                Console.WriteLine("El nombre no puede estar vacío. Intente nuevamente:");
                paciente.Nombre = Console.ReadLine();
            }

            Console.WriteLine($"Ingrese el apellido del paciente");
            paciente.Apellido = Console.ReadLine();
            while (paciente.Apellido == "")
            {
                Console.WriteLine("El apellido no puede estar vacío. Intente nuevamente:");
                paciente.Apellido = Console.ReadLine();
            }

            while (true)
            {
                Console.WriteLine("Ingrese la fecha de nacimiento (dd/MM/yyyy):");


                if (DateTime.TryParse(Console.ReadLine(), out DateTime FechaNacimiento)
                    && FechaNacimiento <= DateTime.Today)
                {
                    paciente.FechaNacimiento = FechaNacimiento;
                    break;
                }
                else
                {
                    Console.WriteLine("Fecha inválida. Intente nuevamente.");
                }
            }
            while (true) 
            { 
                Console.WriteLine($"Ingrese el telefono del paciente");
                if (int.TryParse(Console.ReadLine(), out int telefono) && telefono > 0)
                {
                paciente.Telefono = telefono;
                break;
                }
                else
                {
                Console.WriteLine("Teléfono inválido. Ingrese un número positivo.");
                }
            }

            Console.WriteLine($"Ingrese el tipo del cobertura del paciente");
            Console.WriteLine("1 - Particular");
            Console.WriteLine("2 - Obra social");
            string opcion = Console.ReadLine();
            if (opcion == "1")
            {
                paciente.TipoCobertura = "Particular";
                paciente.Cobertura = new Particular();
                
            }
            else if (opcion == "2")
            {
                paciente.TipoCobertura = "Obra social";
                paciente.Cobertura = new ObraSocial();
            }
            else
            {
                Console.WriteLine("Opción inválida ingrese 1 o 2");
                
            }
            Console.WriteLine("\nPaciente cargado correctamente.");
            Pacientes.Add(paciente);


        }

    }
}
