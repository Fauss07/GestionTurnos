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
        public List <Profesional> Profesionales { get; set; } = new List<Profesional>();
        

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
        public void MostrarPacientes()
        {
            if (Pacientes.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados.");
                return;
            }

            Console.WriteLine("-----LISTA DE PACIENTES-----");
            foreach (var paciente in Pacientes)
            {
                Console.WriteLine($"Nombre: {paciente.Nombre} {paciente.Apellido}, Fecha de Nacimiento: {paciente.FechaNacimiento.ToShortDateString()}, Teléfono: {paciente.Telefono}, Tipo de Cobertura: {paciente.TipoCobertura}");
            }
        }
        
        public void BuscarPaciente(string nombre, string apellido)
        {
            var paciente = Pacientes.FirstOrDefault(p =>
            p.Nombre.ToUpper() == nombre.ToUpper() &&
            p.Apellido.ToUpper() == apellido.ToUpper());
          
            if (paciente != null)
            {
                Console.WriteLine($"Nombre: {paciente.Nombre} {paciente.Apellido}, Fecha de Nacimiento: {paciente.FechaNacimiento.ToShortDateString()}, Teléfono: {paciente.Telefono}, Tipo de Cobertura: {paciente.TipoCobertura}");
                Console.WriteLine("Historial de turnos:");
                foreach (var turno in paciente.Turnos)
                {
                    Console.WriteLine($"Fecha: {turno.Fecha.ToShortDateString()}, Profesional: {turno.Profesional.Nombre} {turno.Profesional.Apellido}, Especialidad: {turno.Profesional.Especialidad}, Estado: {turno.Estado}");
                }
            }
            else
            {
                Console.WriteLine("Paciente no encontrado.");
            }
        }
        public void RegistrarProfesional(Profesional profesional)
        {
            if (profesional == null)
            {
                Console.WriteLine("Error: el profesional no puede ser nulo.");
                return;
            }
            Console.WriteLine("-----REGISTRO DE PROFESIONAL-----");

            Console.WriteLine($"Ingrese la matrícula del profesional");
            profesional.Matricula = Console.ReadLine();
            while (profesional.Matricula == "")
            {
                Console.WriteLine("La matrícula no puede estar vacía. Intente nuevamente:");
                profesional.Matricula = Console.ReadLine();
            }

            Console.WriteLine($"Ingrese el nombre del profesional");
            profesional.Nombre = Console.ReadLine();
            while (profesional.Nombre == "")
            {
                Console.WriteLine("El nombre no puede estar vacío. Intente nuevamente:");
                profesional.Nombre = Console.ReadLine();
            }

            Console.WriteLine($"Ingrese el apellido del profesional");
            profesional.Apellido = Console.ReadLine();
            while (profesional.Apellido == "")
            {
                Console.WriteLine("El apellido no puede estar vacío. Intente nuevamente:");
                profesional.Apellido = Console.ReadLine();
            }
            Profesionales.Add(profesional);
            Console.WriteLine("\nProfesional cargado correctamente.");
    }
     public void MostrarProfesionales(string especialidad = null)
        {
            var profesionalesFiltrados = Profesionales;

            if (!string.IsNullOrEmpty(especialidad))
            {
                profesionalesFiltrados = Profesionales.Where(p => p.Especialidad.ToString().Equals(especialidad, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (profesionalesFiltrados.Count == 0)
            {
                Console.WriteLine("No hay profesionales registrados con la especialidad especificada.");
                return;
            }

            Console.WriteLine("-----LISTA DE PROFESIONALES-----");
            foreach (var profesional in profesionalesFiltrados)
            {
                Console.WriteLine($"Matrícula: {profesional.Matricula}, Nombre: {profesional.Nombre} {profesional.Apellido}, Especialidad: {profesional.Especialidad}, Valor de Consulta: {profesional.ValorConsulta}, Días de Atención: {string.Join(", ", profesional.DiasAtencion)}");
            }
        }
  
  
   public void VerAgendaProfesional(string matricula, DateTime fecha)
        {
            var profesional = Profesionales.FirstOrDefault(p => p.Matricula == matricula);
            if (profesional == null)
            {
                Console.WriteLine("Profesional no encontrado.");
                return;
            }

            Console.WriteLine($"-----AGENDA DEL PROFESIONAL {profesional.Nombre} {profesional.Apellido} PARA EL DÍA {fecha.ToShortDateString()}-----");
            var turnosDelDia = profesional.Turnos.Where(t => t.Fecha.Date == fecha.Date).ToList();

            if (turnosDelDia.Count == 0)
            {
                Console.WriteLine("No hay turnos programados para este día.");
                return;
            }

            foreach (var turno in turnosDelDia)
            {
                string estadoTurno = turno.Estado.ToString();
                string nombrePaciente = turno.Paciente != null ? $"{turno.Paciente.Nombre} {turno.Paciente.Apellido}" : "Libre";
                Console.WriteLine($"Hora: {turno.Fecha.ToShortTimeString()}, Estado: {estadoTurno}, Paciente: {nombrePaciente}");
            }
        }
        /*7. Sacar turno
Qué hace: Asigna un turno a un paciente con un profesional en una fecha y horario. Datos que pide: DNI del paciente, matrícula del profesional (o especialidad, para que el sistema muestre quiénes atienden esa especialidad), fecha y horario. Validaciones:

El paciente y el profesional deben existir.
La fecha no puede ser anterior a la fecha actual.
El día no puede ser feriado ni día no laborable (se verifica consultando una API de feriados de Argentina).
El profesional debe atender ese día de la semana.
El horario debe estar libre (no puede haber dos turnos del mismo profesional a la misma hora). Qué muestra: Comprobante del turno con número, paciente, profesional, especialidad, fecha, horario y costo estimado de la consulta según la cobertura del paciente. Persistencia: Se guarda en el archivo JSON de turnos.*/
       public void SacarTurno(string dniPaciente, string matriculaProfesional, DateTime fechaHora)
        {
            var paciente = Pacientes.FirstOrDefault(p => p.Dni == dniPaciente);
            if (paciente == null)
            {
                Console.WriteLine("Paciente no encontrado.");
                return;
            }

            var profesional = Profesionales.FirstOrDefault(p => p.Matricula == matriculaProfesional);
            if (profesional == null)
            {
                Console.WriteLine("Profesional no encontrado.");
                return;
            }

            if (fechaHora < DateTime.Now)
            {
                Console.WriteLine("La fecha y hora del turno no puede ser anterior a la fecha actual.");
                return;
            }

            // Aquí se debería agregar la validación de feriados y días no laborables consultando la API correspondiente.

            HttpClient cliente = new HttpClient();
            // Se realiza la solicitud a la API de feriados de Argentina para el año 2026
            string respuesta = await cliente.GetStringAsync("https://api.argentinadatos.com/v1/feriados/2026");
            List<Feriado> feriados = JsonSerializer.Deserialize<List<Feriado>>(respuesta);
            string fechaCita = fechaHora.ToString("yyyy-MM-dd");
            Feriado feriado = feriados.FirstOrDefault(f => f.fecha == fechaCita);

            if (feriado != null)
           {
               Console.WriteLine("No se puede sacar turno porque es feriado: " + feriado.nombre);
               return;
           }

            var turnoExistente = profesional.Turnos.FirstOrDefault(t => t.Fecha == fechaHora);
            if (turnoExistente != null)
            {
                Console.WriteLine("El horario seleccionado ya está ocupado por otro turno.");
                return;
            }

            var nuevoTurno = new Turno
            {
                Paciente = paciente,
                Profesional = profesional,
                Fecha = fechaHora,
                Estado = EstadoTurno.Pendiente
            };

            profesional.Turnos.Add(nuevoTurno);
            paciente.Turnos.Add(nuevoTurno);

            decimal costoConsulta = paciente.Cobertura.CalcularCosto(profesional.ValorConsulta);
            
            Console.WriteLine("-----COMPROBANTE DE TURNO-----");
            Console.WriteLine($"Número de Turno: {nuevoTurno.Id}");
            Console.WriteLine($"Paciente: {paciente.Nombre} {paciente.Apellido}");
            Console.WriteLine($"Profesional: {profesional.Nombre} {profesional.Apellido}");
            Console.WriteLine($"Especialidad: {profesional.Especialidad}");
            Console.WriteLine($"Fecha y Hora: {fechaHora}");
            Console.WriteLine($"Costo Estimado de la Consulta: ${costoConsulta}");
        }

}
}



