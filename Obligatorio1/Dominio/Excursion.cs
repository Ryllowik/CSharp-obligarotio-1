using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Excursion
    {
        private static int ultId = 1000;
        private int diasTotales;
        private string descripcion;
        private DateTime fechaComienzo;
        private List<Destino> destinos;
        private int diasTraslados;
        private int id;
        private DateTime fechaFinal;

        public DateTime FechaFinal
        {
            get { return fechaFinal; }
        }

        #region Properties
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public DateTime FechaComienzo
        {
            get { return fechaComienzo; }
            set { fechaComienzo = value; }
        }

        public List<Destino> Destinos
        {
            get { return destinos; }
            set { destinos = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int DiasTraslados
        {
            get { return diasTraslados; }
            set { diasTraslados = value; }
        }
        #endregion

        public Excursion(string descripcion, DateTime fechaComienzo, List<Destino> destinos, int diasTraslados)
        {
            this.descripcion = descripcion;
            this.fechaComienzo = fechaComienzo;
            this.destinos = destinos;
            this.id = ultId;
            this.diasTraslados = diasTraslados;
            //Se recorren los destinos de la excursion
            foreach (var des in destinos)
            {
                //se calculan los dias totales que se estara entre todos los destinos
                diasTotales = diasTotales + des.CantidadDias;
            }
            //se le suma los dias de traslados
            diasTotales = diasTotales + diasTraslados;
            //se le sumas los dias totales a la fecha de inicio para calcular cuando termina la excursion
            this.fechaFinal = fechaComienzo.AddDays(Convert.ToDouble(diasTotales));
            diasTotales = 0;
            ultId = ultId + 100;
        }
        public abstract override string ToString();
    }
}
