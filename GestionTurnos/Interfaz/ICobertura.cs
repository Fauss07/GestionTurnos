using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTurnos.Interfaz
{
    internal interface ICobertura
    {
        decimal CalcularCostoConsulta(decimal ValorConsulta);
        decimal CalcularMontoObraSocial(decimal  ValorConsulta);
    }
}
