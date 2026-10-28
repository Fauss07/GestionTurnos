using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTurnos.Modelos
{
    public class HorarioAtencion
    {
        public DayOfWeek Dia { get; set; }
        //Estudiar TimeSpan para poder definir la hora de inicio y fin de la atención
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int DuracionTurnoMinutos { get; set; }
             
    }
}
