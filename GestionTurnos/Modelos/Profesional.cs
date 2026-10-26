using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTurnos.Modelos
{
    public class Profesional : Persona
    {
        public int Matricula {  get; set; }
        public decimal ValorConsulta { get; set; }

        public Profesional(int mat,string nom,string ape,decimal vc) : base(nom,ape)
        {
            this.Matricula = mat;
            this.ValorConsulta = vc;
        }

    }
}
