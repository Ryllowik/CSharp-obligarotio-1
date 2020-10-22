using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Agencia
    {
        private static Agencia instancia;

        private List<Destino> destinos;
        private List<Excursion> excursiones;
        private List<CompaniaAerea> companiasAereas;
        
        #region Properties
        public List<Destino> Destinos
        {
            get { return destinos; }
            set { destinos = value; }
        }

        public List<Excursion> Excursiones
        {
            get { return excursiones; }
            set { excursiones = value; }
        }
        
        public List<CompaniaAerea> CompaniasAereas
        {
            get { return companiasAereas; }
            set { companiasAereas = value; }
        }

        public static Agencia Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new Agencia();
                return instancia;
            }
        }
        #endregion

        private Agencia()
        {
            this.destinos = new List<Destino>();
            this.excursiones = new List<Excursion>();
            this.companiasAereas = new List<CompaniaAerea>();
        }

        public void AgregarDestino(int cantidadDias, int costoDia, string paisDestino, string ciudadDestino)
        {
            //Comprueba que los datos sean ingresados correctamente, los numeros sean mayores a 0 y los textos tengan al menos 3 caracteres
            if(cantidadDias < 0 || costoDia < 0 || paisDestino.Length < 3 || ciudadDestino.Length < 3)
            {
                Console.WriteLine("Profavor ingrese los datos correctamente, los numeros deben ser positivos y los textos deven tener al menos 3 caracteres");
                Console.ReadKey();
            } else
            {
                //Comprueba si el destino ingresado ya existe en la aplicacion
                bool existe = CompobarExistencia(paisDestino, ciudadDestino);
                if(existe)
                {
                    //En caso de que exista se imprime un mesaje diciendo que ya existe
                    Console.WriteLine("El destino ingresado ya existe en el sistema");
                    Console.ReadKey();
                } else
                {
                    //En caso de que no exista se agrega a la lista de destinos
                    Destino nuevoDestino = new Destino(cantidadDias, costoDia, paisDestino, ciudadDestino);
                    destinos.Add(nuevoDestino);
                    Console.WriteLine("El destino de ha agregado correctamente");
                    
                }
            }
        }

        public void AgregarExcursionNacional(string descripcion, DateTime fechaComienzo, List<Destino> destinos, int diasTraslados, bool interesNacional)
        {
            //Agrega una excursion nacional a la lista de excursiones
            Excursion nuevaExcursion = new ExcursionNacional(descripcion, fechaComienzo, destinos, diasTraslados, interesNacional);
            excursiones.Add(nuevaExcursion);
        }

        public void AgregarExcursionInternacional(string descripcion, DateTime fechaComienzo, List<Destino> destinos, int diasTraslados, CompaniaAerea companiaAerea)
        {
            //Agrega una excursion internacional a la lista de excursiones
            Excursion nuevaExcursion = new ExcursionInternacional(descripcion, fechaComienzo, destinos, diasTraslados, companiaAerea);
            excursiones.Add(nuevaExcursion);
        }

        public void AgregarCompaniaAerea(int codigo, string paisPertenencia)
        {
            //agrega una nueva compania aerea
            CompaniaAerea nuevaCompaniaAerea = new CompaniaAerea(codigo, paisPertenencia);
            companiasAereas.Add(nuevaCompaniaAerea);
        }

        public void DestinoEnFecha(string ciudadDestino, DateTime fechaInicio, DateTime fechaFin)
        {
            //Comprueba que la ciudad ingresada exista en algun destino
            Destino destino = ObtenerDestino(ciudadDestino);
            if (destino == null)
            {
                Console.WriteLine("El destino ingresado no existe");
            } else
            {
                //Se recorren todas las excursiones
                foreach (Excursion exc in excursiones)
                {
                    //Se recorren todos los destinos dentro de cada excursion
                    foreach (Destino des in exc.Destinos)
                    {
                        //Si el destino esta en alguna excursion, se compruba de que se encuetre dentro de el rango dado
                        if (des == destino)
                        {
                            if (fechaInicio >= exc.FechaComienzo)
                            {
                                if (fechaInicio <= exc.FechaFinal)
                                {
                                    Console.WriteLine(exc.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("No existe excursion con ese destino en ese rango de fechas");
                                }
                            }
                            else if (fechaFin <= exc.FechaFinal)
                            {
                                Console.WriteLine(exc.ToString());
                            }
                            else
                            {
                                Console.WriteLine("No existe excursion con ese destino en ese rango de fechas");
                            }
                        }
                    }
                }
            }  
        }

        private bool CompobarExistencia(string paisDestino, string ciudadDestino)
        {
            //Dado un pais y una cuidad, comprueba si esa combinacion de pais y ciudad existe en la aplicacion
            bool existe = false;
            //Recorre todos los destinos
            foreach (Destino des in destinos)
            {
                //Comprueba si la combinacion cuidad-pais coincide con alguno de los destinos existentes
                if (des.PaisDestino == paisDestino && des.CiudadDestino == ciudadDestino)
                {
                    existe = true;
                    return existe;
                }
            }
            return existe;
        }

        public Destino ObtenerDestino(string ciudadDestino)
        {
            //Dada una ciudad, devulve el destino en el cual se encuentra
            foreach (Destino des in destinos)
            {
                if (des.CiudadDestino == ciudadDestino)
                {
                    return des;
                }
            }
            return null;
        }
    }
}
