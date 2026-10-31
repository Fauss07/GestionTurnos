using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Net.Http;
using System.Runtime.InteropServices;

namespace GestionTurnos.Modelos
{
    internal class SistemaClinica
    {
        public List<Paciente> Pacientes { get; set; } = new List<Paciente>();
        public List<Profesional> Profesionales { get; set; } = new List<Profesional>();
        public List<Turno> Turnos { get; set; } = new List<Turno>();


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
                //Estudiar
                foreach (Turno turno in Turnos.Where(t => t.Paciente == paciente))
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
                profesionalesFiltrados = Profesionales.Where(p => p.especialidad.ToString().Equals(especialidad, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (profesionalesFiltrados.Count == 0)
            {
                Console.WriteLine("No hay profesionales registrados con la especialidad especificada.");
                return;
            }

            Console.WriteLine("-----LISTA DE PROFESIONALES-----");
            foreach (var profesional in profesionalesFiltrados)
            {
                Console.WriteLine($"Matrícula: {profesional.Matricula}, Nombre: {profesional.Nombre} {profesional.Apellido}, Especialidad: {profesional.especialidad}, Valor de Consulta: {profesional.ValorConsulta}");
                Console.WriteLine("Horarios de atencion:");
                  foreach (var horario in profesional.Horarios)
                  {
                    Console.WriteLine($" {horario.Dia}: {horario.HoraInicio:hh\\:mm} a {horario.HoraFin:hh\\:mm}");

                  }
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
       public async Task SacarTurno(string dniPaciente, string matriculaProfesional, DateTime fechaHora)
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
            Feriado feriado = null;
            try
            {
              HttpClient cliente = new HttpClient();
            // Se realiza la solicitud a la API de feriados de Argentina para el año 2026
              string respuesta = await cliente.GetStringAsync("https://api.argentinadatos.com/v1/feriados/2026");
              List<Feriado> feriados = JsonSerializer.Deserialize<List<Feriado>>(respuesta);
              string fechaCita = fechaHora.ToString("yyyy-MM-dd");
              feriado  = feriados.FirstOrDefault(f => f.fecha == fechaCita);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar la API de feriados: " + ex.Message);
                return;
            }

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


// Qué hace: Lista los turnos del sistema. Datos que pide: Un criterio de filtro: por fecha, por profesional, por paciente o por estado (pendiente / atendido / cancelado / ausente). Qué muestra: Listado de turnos con número, fecha, horario, paciente, profesional y estado.
public async Task ListarTurnos(string criterioFiltro, string valorFiltro)
        {
            IEnumerable<Turno> turnosFiltrados = Turnos;

            switch (criterioFiltro.ToLower())
            {
                case "fecha":
                    if (DateTime.TryParse(valorFiltro, out DateTime fecha))
                    {
                        turnosFiltrados = Turnos.Where(t => t.Fecha.Date == fecha.Date);
                    }
                    else
                    {
                        Console.WriteLine("Fecha inválida.");
                        return;
                    }
                    break;
                case "profesional":
                    turnosFiltrados = Turnos.Where(t => t.Profesional.Matricula.Equals(valorFiltro, StringComparison.OrdinalIgnoreCase));
                    break;
                case "paciente":
                    turnosFiltrados = Turnos.Where(t => t.Paciente.Dni.Equals(valorFiltro, StringComparison.OrdinalIgnoreCase));
                    break;
                case "estado":
                    if (Enum.TryParse<EstadoTurno>(valorFiltro, true, out EstadoTurno estado))
                    {
                        turnosFiltrados = Turnos.Where(t => t.Estado == estado);
                    }
                    else
                    {
                        Console.WriteLine("Estado inválido.");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Criterio de filtro inválido.");
                    return;
            }

            if (!turnosFiltrados.Any())
            {
                Console.WriteLine("No se encontraron turnos con el criterio especificado.");
                return;
            }

            Console.WriteLine("-----LISTADO DE TURNOS-----");
            foreach (var turno in turnosFiltrados)
            {
                Console.WriteLine($"Número de Turno: {turno.Id}, Fecha y Hora: {turno.Fecha}, Paciente: {turno.Paciente.Nombre} {turno.Paciente.Apellido}, Profesional: {turno.Profesional.Nombre} {turno.Profesional.Apellido}, Estado: {turno.Estado}");
            }
        }
        

// 9. Reprogramar turno Qué hace: Cambia la fecha y/o el horario de un turno ya asignado, sin perder el registro del paciente y el profesional. Datos que pide: Número de turno, nueva fecha y nuevo horario. Validaciones: Las mismas que al sacar un turno. Solo se pueden reprogramar turnos en estado pendiente. Qué muestra: Comprobante actualizado.

public async Task ReprogramarTurno(int numeroTurno, DateTime nuevaFechaHora)
        {
            var turno = Turnos.FirstOrDefault(t => t.Id == numeroTurno);
            if (turno == null)
            {
                Console.WriteLine("Turno no encontrado.");
                return;
            }

            if (turno.Estado != EstadoTurno.Pendiente)
            {
                Console.WriteLine("Solo se pueden reprogramar turnos en estado pendiente.");
                return;
            }

            // Validaciones similares a SacarTurno
            if (nuevaFechaHora < DateTime.Now)
            {
                Console.WriteLine("La nueva fecha y hora del turno no puede ser anterior a la fecha actual.");
                return;
            }

            // Aquí se debería agregar la validación de feriados y días no laborables consultando la API correspondiente.
            Feriado feriado = null;
            try
            {
                HttpClient cliente = new HttpClient();
                string respuesta = await cliente.GetStringAsync("https://api.argentinadatos.com/v1/feriados/2026");
                List<Feriado> feriados = JsonSerializer.Deserialize<List<Feriado>>(respuesta);
                string fechaCita = nuevaFechaHora.ToString("yyyy-MM-dd");
                feriado = feriados.FirstOrDefault(f => f.fecha == fechaCita);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consultar la API de feriados: " + ex.Message);
                return;
            }

            if (feriado != null)
            {
                Console.WriteLine("No se puede reprogramar el turno porque es feriado: " + feriado.nombre);
                return;
            }

            var turnoExistente = turno.Profesional.Turnos.FirstOrDefault(t => t.Fecha == nuevaFechaHora);
            if (turnoExistente != null)
            {
                Console.WriteLine("El horario seleccionado ya está ocupado por otro turno.");
                return;
            }

            turno.Fecha = nuevaFechaHora;

            Console.WriteLine("-----COMPROBANTE DE TURNO REPROGRAMADO-----");
            Console.WriteLine($"Número de Turno: {turno.Id}");
            Console.WriteLine($"Paciente: {turno.Paciente.Nombre} {turno.Paciente.Apellido}");
            Console.WriteLine($"Profesional: {turno.Profesional.Nombre} {turno.Profesional.Apellido}");



        }

    //Qué hace: Cambia el estado del turno a cancelado y libera el horario en la agenda del profesional. Datos que pide: Número de turno y motivo de la cancelación. Validaciones: Solo se pueden cancelar turnos pendientes. Qué muestra: Confirmación de la cancelación.
    public async Task CancelarTurno(int numeroTurno, string motivoCancelacion)
        {
            var turno = Turnos.FirstOrDefault(t => t.Id == numeroTurno);
            if (turno == null)
            {
                Console.WriteLine("Turno no encontrado.");
                return;
            }

            if (turno.Estado != EstadoTurno.Pendiente)
            {
                Console.WriteLine("Solo se pueden cancelar turnos en estado pendiente.");
                return;
            }

            turno.Estado = EstadoTurno.Cancelado;
            turno.MotivoCancelacion = motivoCancelacion;

            Console.WriteLine("-----CONFIRMACIÓN DE CANCELACIÓN DE TURNO-----");
            Console.WriteLine($"Número de Turno: {turno.Id}");
            Console.WriteLine($"Paciente: {turno.Paciente.Nombre} {turno.Paciente.Apellido}");
            Console.WriteLine($"Profesional: {turno.Profesional.Nombre} {turno.Profesional.Apellido}");
            Console.WriteLine($"Fecha y Hora: {turno.Fecha}");
            Console.WriteLine($"Motivo de Cancelación: {motivoCancelacion}");

}

//Qué hace: Registra que el paciente concurrió y fue atendido, y cobra la consulta. Datos que pide: Número de turno y diagnóstico u observación de la atención. Cómo calcula el costo:

   // Paciente particular: paga el valor completo de la consulta del profesional.
   // Paciente con obra social: paga únicamente el coseguro; el resto queda registrado como monto a facturar a la obra social. Qué muestra: Detalle de la atención con el monto que abona el paciente y el monto que cubre la obra social. Otros estados: Desde esta misma opción se debe poder marcar el turno como ausente si el paciente no se presentó.

public async Task AtenderTurno(int numeroTurno, string diagnostico, bool ausente = false)
        {
            var turno = Turnos.FirstOrDefault(t => t.Id == numeroTurno);
            if (turno == null)
            {
                Console.WriteLine("Turno no encontrado.");
                return;
            }

            if (turno.Estado != EstadoTurno.Pendiente)
            {
                Console.WriteLine("Solo se pueden atender turnos en estado pendiente.");
                return;
            }

            if (ausente)
            {
                turno.Estado = EstadoTurno.Ausente;
                Console.WriteLine($"El paciente {turno.Paciente.Nombre} {turno.Paciente.Apellido} no se presentó al turno.");
                return;
            }

            turno.Estado = EstadoTurno.Atendido;
            turno.Diagnostico = diagnostico;

            decimal costoConsulta = turno.Paciente.Cobertura.CalcularCosto(turno.Profesional.ValorConsulta);

            Console.WriteLine("-----DETALLE DE ATENCIÓN-----");
            Console.WriteLine($"Número de Turno: {turno.Id}");
            Console.WriteLine($"Paciente: {turno.Paciente.Nombre} {turno.Paciente.Apellido}");
            Console.WriteLine($"Profesional: {turno.Profesional.Nombre} {turno.Profesional.Apellido}");
            Console.WriteLine($"Fecha y Hora: {turno.Fecha}");
            Console.WriteLine($"Diagnóstico/Observación: {diagnostico}");
            Console.WriteLine($"Monto abonado por el paciente: ${costoConsulta}");


}

//Qué hace: Muestra información de la clínica. Reportes que debe incluir como mínimo:

   // Turnos atendidos y recaudación total de una fecha o período.
   // Cantidad de turnos por profesional y por especialidad.
   // Porcentaje de ausentismo (turnos marcados como ausente sobre el total).
  //  Listado de montos pendientes de facturar a cada obra social.


    //Qué hace: Muestra información de la clínica. Reportes que debe incluir como mínimo:

   // Turnos atendidos y recaudación total de una fecha o período.
   // Cantidad de turnos por profesional y por especialidad.
   // Porcentaje de ausentismo (turnos marcados como ausente sobre el total).
  //  Listado de montos pendientes de facturar a cada obra social.
public async Task GenerarReporte(DateTime fechaInicio, DateTime fechaFin)
        {
            var turnosEnPeriodo = Turnos.Where(t => t.Fecha.Date >= fechaInicio.Date && t.Fecha.Date <= fechaFin.Date).ToList();

            int turnosAtendidos = turnosEnPeriodo.Count(t => t.Estado == EstadoTurno.Atendido);
            decimal recaudacionTotal = turnosEnPeriodo.Where(t => t.Estado == EstadoTurno.Atendido).Sum(t => t.Paciente.Cobertura.CalcularCosto(t.Profesional.ValorConsulta));

            var turnosPorProfesional = turnosEnPeriodo.GroupBy(t => t.Profesional.Matricula)
                .Select(g => new { Profesional = g.First().Profesional, CantidadTurnos = g.Count() })
                .ToList();

            var turnosPorEspecialidad = turnosEnPeriodo.GroupBy(t => t.Profesional.Especialidad)
                .Select(g => new { Especialidad = g.Key, CantidadTurnos = g.Count() })
                .ToList();

            int totalTurnos = turnosEnPeriodo.Count;
            int ausentes = turnosEnPeriodo.Count(t => t.Estado == EstadoTurno.Ausente);
            double porcentajeAusentismo = totalTurnos > 0 ? (double)ausentes / totalTurnos * 100 : 0;

            var montosPendientesObraSocial = turnosEnPeriodo
                .Where(t => t.Paciente.TipoCobertura == "Obra social" && t.Estado == EstadoTurno.Atendido)
                .GroupBy(t => t.Paciente.Cobertura.NombreObraSocial)
                .Select(g => new { ObraSocial = g.Key, MontoPendiente = g.Sum(t => t.Profesional.ValorConsulta - t.Paciente.Cobertura.CalcularCosto(t.Profesional.ValorConsulta)) })
                .ToList();

            Console.WriteLine("-----REPORTE DE LA CLÍNICA-----");
            Console.WriteLine($"Período: {fechaInicio.ToShortDateString()} - {fechaFin.ToShortDateString()}");
            Console.WriteLine($"Turnos atendidos: {turnosAtendidos}");
            Console.WriteLine($"Recaudación total: ${recaudacionTotal}");
            Console.WriteLine("Cantidad de turnos por profesional:");
            foreach (var item in turnosPorProfesional)
            {
                Console.WriteLine($"Profesional: {item.Profesional.Nombre} {item.Profesional.Apellido}, Cantidad de turnos: {item.CantidadTurnos}");
            }
            Console.WriteLine("Cantidad de turnos por especialidad:");
            foreach (var item in turnosPorEspecialidad)
            {
                Console.WriteLine($"Especialidad: {item.Especialidad}, Cantidad de turnos: {item.CantidadTurnos}");
            }
            Console.WriteLine($"Porcentaje de ausentismo: {porcentajeAusentismo:F2}%");
            Console.WriteLine("Montos pendientes de facturar a cada obra social:");
            foreach (var item in montosPendientesObraSocial)
            {
                Console.WriteLine($"Obra social: {item.ObraSocial}, Monto pendiente: ${item.MontoPendiente}");
            }

        }






    }

}



