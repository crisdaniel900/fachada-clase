using System;
using System.Threading;
namespace Facade
{
    public class ConsolaVideojuegos
    {
        //Arreglo de juegos
        private string[] juegos = { "FORTNITE", "CALL OF DUTY", "GTA V", "RUST" };

        bool estado = false;

        public void Encender()
        {
            Console.Write("Encendiendo Consola");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
            Console.Write("Consola de videojuegos encendida");

            estado = true;

            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public void MostrarJuegos()
        {
            for (int i = 0; i < juegos.Length; i++)
            {
                Console.WriteLine($"{i + 1} Canal {i + 1}: {juegos[i]}");
            }
        }

        public void Apagar()
        {
            if (estado)
            {
                Console.Write("Apagando Consola de videojuegos");
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(500);
                    Console.Write(".");
                }
                Console.WriteLine("Consola apagada");
                estado = false;
            }
            else
            {
                Console.WriteLine("La consola ya está apagada");
            }

        }
        public void IniciarJuego(int juego)
        {
            Console.WriteLine($"Iniciando el juego {juegos[juego - 1]}");
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
