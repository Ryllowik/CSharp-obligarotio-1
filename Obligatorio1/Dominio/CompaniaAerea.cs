using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CompaniaAerea
    {
        private int codigo;
        private string paisPertenencia;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string PaisPertenencia
        {
            get { return paisPertenencia; }
            set { paisPertenencia = value; }
        }

        public CompaniaAerea(int codigo, string paisPertenencia)
        {
            this.codigo = codigo;
            this.paisPertenencia = paisPertenencia;
        }

        public override string ToString()
        {
            return $"\n\t-Codigo: {codigo}\n\t-Pais de pertenecia: {paisPertenencia}";
        }
    }
}
