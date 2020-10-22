using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Destino
    {
        private int cantidadDias;
        private int costoDia;
        private string paisDestino;
        private string ciudadDestino;

        #region Properties

        public int CantidadDias
        {
            get { return cantidadDias; }
            set { cantidadDias = value; }
        }
        public int CostoDia
        {
            get { return costoDia; }
            set { costoDia = value; }
        }
        public string PaisDestino
        {
            get { return paisDestino; }
            set { paisDestino = value; }
        }
        public string CiudadDestino
        {
            get { return ciudadDestino; }
            set { ciudadDestino = value; }
        }
        #endregion

        public Destino(int cantidadDias, int costoDia, string paisDestino, string ciudadDestino)
        {
            this.cantidadDias = cantidadDias;
            this.costoDia = costoDia;
            this.paisDestino = paisDestino;
            this.ciudadDestino = ciudadDestino;
        }

        //Se declara el metodo ToString con un nuevo constructor
        public string ToString(int cotizacionDolar)
        {
            //El parametro cotizacionDolar se usa para convertir el costo de dolares a pesos
            return $"Cuidad destino: {ciudadDestino}\nPais destino: {paisDestino}\nCantidad de dias: {cantidadDias}\nCosto por dia: {costoDia}\nCosto total: U$S{costoDia * cantidadDias} o UY${(costoDia * cantidadDias) * cotizacionDolar}\n------";
        }
    }
}
