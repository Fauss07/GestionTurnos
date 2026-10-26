using GestionTurnos.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTurnos.Modelos
{
    internal class ObraSocial : ICobertura
    {
        public string Nombre { get; set; }
        public string NumAfiliado { get; set; }
        public decimal PorcentajeSeguro { get; set; }

        public decimal CalcularCostoConsulta(decimal ValorConsulta)
        {
            return ValorConsulta * PorcentajeSeguro / 100;
        }

        public decimal CalcularMontoObraSocial(decimal ValorConsulta)
        {
            return ValorConsulta - CalcularCostoConsulta(ValorConsulta);
        }
    }
}
