using GestionTurnos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTurnos.Modelos
{
    internal class Turno
    {
        public int Numero { get; set; }
        public Paciente Paciente { get; set; }
        public Profesional Profesional { get; set; }
        public DateTime Fecha { get; set; }
        public string MotivoPaciente { get; set; }
        public string Diagnostico { get; set; }
        public string MotivoCancelacion { get; set; }
        public decimal MontoPaciente { get; set; }
        public decimal MontoObraSocial { get; set; }
        public EstadoTurno Estado { get; set; }
    }
}
