using GestionTurnos.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTurnos.Modelos
{
    internal class Particular : ICobertura
    {



        public decimal CalcularCostoConsulta(decimal ValorConsulta)
        {
            return ValorConsulta;
        }

        public decimal CalcularMontoObraSocial(decimal ValorConsulta)
        {
            return 0;
        }
    }
}
