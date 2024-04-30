using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            String valor = "";

            Console.WriteLine("1) Guardar Archivo,  2) Leer Archivo");
            valor = Console.ReadLine();
            opcion = Convert.ToInt32(valor);

            if(opcion == 1 ) 
            {
                //Creamos el objeto CAuto
                string modelo = "";
                double costo = 0;

                Console.WriteLine("Dame el modelo");
                modelo = Console.ReadLine();

                Console.WriteLine("Dame el costo");
                valor = Console.ReadLine();
                costo = Convert.ToDouble(valor);

                CAuto miAuto = new CAuto(modelo, costo);

                //Variables extra
                int numero = 5;
                bool acceso = false;
                byte conteo = 120;

                //Creamos el Stream
                FileStream fs = new FileStream("MiArchivo.arc", FileMode.Create, FileAccess.Write, FileShare.None);

                //Creamos el escritor
                BinaryWriter writer = new BinaryWriter(fs);

                //Ecribimos los atributos del objeto
                //NO ESTAMOS SERIALIZANDO
                writer.Write(miAuto.Modelo);
                writer.Write(miAuto.Costo);

                //Escribimos las variables
                writer.Write(numero);
                writer.Write(acceso);   
                writer.Write(conteo);

                fs.Close();
            }

            if (opcion == 2 )
            {
                //Leemos el objeto
                Console.WriteLine(" - - - Leemos el objeto - - - ");

                //Creamos el Stream
                FileStream fs = new FileStream("MiArchivo.arc", FileMode.Open, FileAccess.Read, FileShare.None);

                //Creamos el lector
                BinaryReader lector = new BinaryReader(fs);

                //Leemos en el mismo orden en que se escribio

                string modelo = "";
                double costo = 0;
                int numero = 0;
                bool acceso = true;
                byte conteo = 0;

                modelo = lector.ReadString();
                costo = lector.ReadDouble();
                CAuto miAuto = new CAuto(modelo, costo);

                numero = lector.ReadInt32();
                acceso = lector.ReadBoolean();
                conteo = lector.ReadByte();

                //Cerramos el stream
                fs.Close();

                //Imprimimos
                Console.WriteLine("numero {0}" + numero);
                Console.WriteLine("acceso {0}" + acceso);
                Console.WriteLine("conteo {0}" + conteo);
            }
        }
    }
}
