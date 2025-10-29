using System;
using System.Threading;
namespace Facade
{
    public class TV
    {
        //Arreglo con canales de TV
        private string[] canales = { "PRIME", "DISNEY+", "NETFLIX", "HBO MAX", "TV Abierta" };

        bool estado = false;

        public void Encender()
        {
            Console.Write("Encendiendo TV");
           
            Console.Write(" TV encendida");

            estado = true;

            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public void MostrarCanales()
        {
            for (int i = 0; i < canales.Length; i++)
            {
                Console.WriteLine($"{i + 1} Canal {i + 1}: {canales[i]}");
            }
        }

        public void Apagar()
        {
            if (estado)
            {
                Console.Write("Apagando TV");
                Console.WriteLine("TV apagada");
                estado = false;
            }
            else
            {
                Console.WriteLine("La TV ya está apagada");
            }
        }
        public void SeleccionarCanal(int opcionCanal)
        {
            Console.WriteLine($"TV sintonizada en el canal No. {opcionCanal} - {canales[opcionCanal - 1]}");
            Console.ReadKey();
            Console.Clear();
        }
    } 
}
