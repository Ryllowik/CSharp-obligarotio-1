using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ExcursionInternacional : Excursion
    {
        private CompaniaAerea companiaAerea;

        public CompaniaAerea CompaniaAerea
        {
            get { return companiaAerea; }
            set { companiaAerea = value; }
        }

        public ExcursionInternacional(string descripcion, DateTime fechaComienzo, List<Destino> destinos, int diasTraslados, CompaniaAerea companiaAerea) : base (descripcion, fechaComienzo, destinos, diasTraslados)
        {
            this.companiaAerea = companiaAerea;
        }

        public override string ToString()
        {
            string destinosString = "";
            //Recorre los destinos en la excursion para mostrarlos
            foreach (Destino des in Destinos)
            {
                destinosString = destinosString + $"\n\t-{des.CiudadDestino}, {des.PaisDestino}";
            }
            return $"Descripcion: {Descripcion}\nFecha de inicio: {FechaComienzo.ToString("dd/MM/yyyy")}\nDestinos:{destinosString}\nDias de traslado: {DiasTraslados}\nCompania Aerea: {companiaAerea.ToString()}\n-----------\n";
        }
    }
}
