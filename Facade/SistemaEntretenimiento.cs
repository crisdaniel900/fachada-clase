using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    // Implementación de la fachada
    class SistemaEntretenimiento : IEntretenimiento
    {
        // Componentes del sistema de entretenimiento
        private TV tv;
        private ConsolaVideojuegos consola;
        private Luces luces;
        private Altavoces altavoces;
        private Laptop laptop;

        // Variables a utilizar
        private int opcionCanal = 0, opcionJuego = 0, opcionConsola = 0;

        public SistemaEntretenimiento()
        {
            tv = new TV();
            consola = new ConsolaVideojuegos();
            luces = new Luces();
            altavoces = new Altavoces();
            laptop = new Laptop();
        }

        public void ModoCine()
        {
            altavoces.Encender();
            luces.Atenuar();
            tv.Encender();

            do
            {
                Console.Clear();
                Console.WriteLine("====================================================");
                Console.WriteLine("|             CONFIGURE SU MODO CINE               |");
                Console.WriteLine("====================================================");
                tv.MostrarCanales();
                Console.WriteLine("6) Apagar TV");
                Console.WriteLine("====================================================");
                Console.Write("\nSeleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcionCanal))
                {
                    Console.WriteLine("Entrada inválida. Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                if (opcionCanal < 1 || opcionCanal > 6)
                {
                    Console.WriteLine("Opción no válida. \nSeleccione un canal entre 1 y 6...");
                    Console.ReadKey();
                    continue;
                }
                else if (opcionCanal == 6)
                {
                    tv.Apagar();
                    altavoces.Apagar();
                    luces.Encender();
                }
                else
                {
                    tv.SeleccionarCanal(opcionCanal);
                }

            } while (opcionCanal != 6);
        }

        public void ModoJuego()
        {
            altavoces.Encender();
            luces.Atenuar();

            do
            {
                Console.Clear();
                Console.WriteLine("====================================================");
                Console.WriteLine("|          SELECCIONE DONDE JUGAR                  |");
                Console.WriteLine("====================================================");
                Console.WriteLine("1) Consola de Videojuegos");
                Console.WriteLine("2) Laptop");
                Console.WriteLine("3) No jugar");
                Console.WriteLine("====================================================");
                Console.Write("\nSeleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcionConsola))
                {
                    Console.WriteLine("Entrada inválida. Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                Console.Clear();

                switch (opcionConsola)
                {
                    case 1:
                        tv.Encender();
                        consola.Encender();

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("====================================================");
                            Console.WriteLine("|            SELECCIONE UN JUEGO                   |");
                            Console.WriteLine("====================================================");
                            consola.MostrarJuegos();
                            Console.WriteLine("5) Apagar Consola");
                            Console.WriteLine("====================================================");
                            Console.Write("\nSeleccione una opción: ");

                            if (!int.TryParse(Console.ReadLine(), out opcionJuego))
                            {
                                Console.WriteLine("Entrada inválida. Presione una tecla para continuar...");
                                Console.ReadKey();
                                continue;
                            }

                            if (opcionJuego < 1 || opcionJuego > 5)
                            {
                                Console.WriteLine("Opción no válida. \nSeleccione un juego entre 1 y 5...");
                                Console.ReadKey();
                            }
                            else if (opcionJuego == 5)
                            {
                                consola.Apagar();
                                altavoces.Apagar();
                                luces.Encender();
                            }
                            else
                            {
                                consola.IniciarJuego(opcionJuego);
                            }

                        } while (opcionJuego != 5);
                        break;

                    case 2:
                        laptop.Encender();

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("====================================================");
                            Console.WriteLine("|          MOSTRANDO APLICACIONES DISPONIBLES      |");
                            Console.WriteLine("====================================================");
                            laptop.MostrarAplicaciones();
                            Console.WriteLine("5) Apagar Laptop");
                            Console.WriteLine("====================================================");
                            Console.Write("\nSeleccione una opción: ");

                            if (!int.TryParse(Console.ReadLine(), out opcionJuego))
                            {
                                Console.WriteLine("Entrada inválida. Presione una tecla para continuar...");
                                Console.ReadKey();
                                continue;
                            }

                            if (opcionJuego < 1 || opcionJuego > 5)
                            {
                                Console.WriteLine("Opción no válida. \nSeleccione una opción entre 1 y 5...");
                                Console.ReadKey();
                            }
                            else if (opcionJuego == 5)
                            {
                                altavoces.Apagar();
                                luces.Encender();
                                laptop.Apagar();
                            }
                            else
                            {
                                laptop.AbrirAplicacion(opcionJuego);
                            }

                        } while (opcionJuego != 5);
                        break;

                    case 3:
                        Console.WriteLine("No jugar");
                        Console.WriteLine("Presione ENTER para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Opción no válida. \nSeleccione una opción entre 1 y 3...");
                        Console.ReadKey();
                        break;
                }

            } while (opcionConsola != 3);
        }

        public void ApagarTodo()
        {
            Console.WriteLine("\nApagando todo el sistema...");
            tv.Apagar();
            consola.Apagar();
            luces.Encender(); // Podrías usar luces.Apagar() si prefieres oscuridad total
            altavoces.Apagar();
            laptop.Apagar();
            Console.WriteLine("Sistema apagado completamente...");
        }
    }
}
