using GestionTurnos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTurnos.Modelos
{
    public class Profesional : Persona
    {
        public List<HorarioAtencion> Horarios { get; set; } = new List<HorarioAtencion>();
        public string  Matricula {  get; set; }
        public decimal ValorConsulta { get; set; }
        public Especialidades  especialidad { get; set; }

        public Profesional(string mat,string nom,string ape,decimal vc) : base(nom,ape)
        {
            this.Matricula = mat;
            this.ValorConsulta = vc;
        }

    }
}
