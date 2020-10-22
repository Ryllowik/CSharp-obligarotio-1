using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ExcursionNacional : Excursion
    {
        private bool interesNacional;

        public bool InteresNacional
        {
            get { return interesNacional; }
            set { interesNacional = value; }
        }

        public ExcursionNacional(string descripcion, DateTime fechaComienzo, List<Destino> destinos, int diasTraslados, bool interesNacional) : base (descripcion, fechaComienzo, destinos, diasTraslados)
        {
            this.interesNacional = interesNacional;
        }

        public override string ToString()
        {
            string interesNac;
            string destinosString = "";
            //Verifica si la excursion es de interes nacional
            if (interesNacional)
            {
                interesNac = "Si";
            } else
            {
                interesNac = "No";
            }
            //Recorre los destinos en la excursion para mostrarlos
            foreach (Destino des in Destinos)
            {
                destinosString = destinosString + $"\n\t-{des.CiudadDestino}, {des.PaisDestino}";
            }
            return $"Descripcion: {Descripcion}\nFecha de inicio: {FechaComienzo.ToString("dd/MM/yyyy")}\nDestinos:{destinosString}\nDias de traslado: {DiasTraslados}\nInteres Nacional: {interesNac}\n-----------\n";
        }
    }
}
