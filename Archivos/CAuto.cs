using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    internal class CAuto
    {
        public double costo;
        public string modelo;

        public double Costo { get {return costo ;} set { costo = value;} }
        public String Modelo { get { return modelo; } set { modelo = value; } }

        public CAuto(string pModelo, double pCosto)
        {
            costo = pCosto;
            modelo = pModelo;
        }

        public void MuestraInformacion()
        {
            Console.WriteLine("El costo de tu auto es: " + Costo);
            Console.WriteLine("El modelod e tu auto es: " + Modelo);
            Console.WriteLine("_____________________________________");
        }
    }
}
