using System;
using System.Threading; // Se agrega para la simulación de apagado

namespace Facade
{
    // ----------------------------------------------------------------
    // 1. INTERFACE (CONTRATO DE LA FACHADA)
    // ----------------------------------------------------------------
    public interface SistemaEntretenimiento : IEntretenimiento
    {
        void ModoCine();
        void ModoJuegos();
        void ApagarTodo();
    }

    // ----------------------------------------------------------------
    // 2. COMPONENTES DEL SUBSISTEMA (Device Classes)
    // ----------------------------------------------------------------

    // Clase de Dispositivo base para simular operaciones
    public abstract class Dispositivo
    {
        protected string Nombre;
        protected Dispositivo(string nombre) { Nombre = nombre; }
        public void Encender() => Console.WriteLine($"\t[{Nombre}] Encendido.");
        public void Apagar() => Console.WriteLine($"\t[{Nombre}] Apagado.");
    }

    public class TV : Dispositivo
    {
        private string[] canales = { "Noticias", "Deportes", "Películas", "Documentales", "Música" };
        public TV() : base("TV") { }
        public void MostrarCanales()
        {
            Console.WriteLine("\n--- CANALES DISPONIBLES ---");
            for (int i = 0; i < canales.Length; i++)
            {
                Console.WriteLine($"\t{i + 1}) {canales[i]}");
            }
        }
        public void seleccionarCanal(int numCanal)
        {
            if (numCanal >= 1 && numCanal <= canales.Length)
            {
                Console.WriteLine($"\t[TV] Canal seleccionado: {canales[numCanal - 1]}.");
            }
        }
    }

    public class Luces : Dispositivo
    {
        public Luces() : base("Luces") { }
        public void Atenuar() => Console.WriteLine("\t[Luces] Atenuadas para ambiente de cine/juegos.");
    }

    public class Altavoces : Dispositivo
    {
        public Altavoces() : base("Altavoces") { }
    }

    public class ConsolaVideojuegos : Dispositivo
    {
        private string[] juegos = { "Juego de Carreras", "Juego de Aventura", "Juego de Lógica", "Juego de Lucha" };
        public ConsolaVideojuegos() : base("Consola") { }
        public void MostrarJuegos()
        {
            Console.WriteLine("\n--- JUEGOS DISPONIBLES ---");
            for (int i = 0; i < juegos.Length; i++)
            {
                Console.WriteLine($"\t{i + 1}) {juegos[i]}");
            }
        }
        public void IniciarJuego(int numJuego)
        {
            if (numJuego >= 1 && numJuego <= juegos.Length)
            {
                Console.WriteLine($"\t[Consola] Iniciando {juegos[numJuego - 1]}...");
            }
        }
    }

    public class Laptop : Dispositivo
    {
        private string[] aplicaciones = { "Navegador Web", "Editor de Código", "Juego de Estrategia", "Software de Diseño" };
        public Laptop() : base("Laptop") { }
        public void MostrarAplicaciones()
        {
            Console.WriteLine("\n--- APLICACIONES DISPONIBLES ---");
            for (int i = 0; i < aplicaciones.Length; i++)
            {
                Console.WriteLine($"\t{i + 1}) {aplicaciones[i]}");
            }
        }
        public void AbrirAplicacion(int numApp)
        {
            if (numApp >= 1 && numApp <= aplicaciones.Length)
            {
                Console.WriteLine($"\t[Laptop] Abriendo {aplicaciones[numApp - 1]}...");
            }
        }
    }


    // ----------------------------------------------------------------
    // 3. FACHADA (EL CÓDIGO CORREGIDO)
    // ----------------------------------------------------------------

    // Implementación de la fachada
    class SistemaEntretenimiento : IEntretenimiento
    {
        // Componentes del sistema de entretenimiento
        private TV tv;
        private ConsolaVideojuegos consola;
        private Luces luces;
        private Altavoces altavoces;
        private Laptop laptop;

        //Variables a utilizar
        public int opcionCanal = 0, opcionJuego = 0, opcionConsola = 0;

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
            // Operación simplificada (Encender/Configurar dispositivos)
            altavoces.Encender();
            luces.Atenuar();
            tv.Encender();

            do
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("|       CONFIGURE SU MODO CINE        |");
                Console.WriteLine("=======================================");
                tv.MostrarCanales();
                Console.WriteLine("     6) Apagar TV (Salir del Modo Cine)");
                Console.WriteLine("=======================================");
                Console.Write("\nSeleccione una opción: ");

                // Manejo de errores de parsing
                if (!int.TryParse(Console.ReadLine(), out opcionCanal))
                {
                    Console.WriteLine("\nEntrada inválida. Presione cualquier tecla para reintentar...");
                    Console.ReadKey();
                    continue;
                }

                //Validar que la opción seleccionada sea válida
                if (opcionCanal < 1 || opcionCanal > 6)
                {
                    Console.WriteLine("\nOpción no válida. \nSeleccione un canal entre 1 y 6...");
                    Console.ReadKey();
                    continue;
                }
                else if (opcionCanal == 6)
                {
                    // Apagar el modo
                    tv.Apagar();
                    altavoces.Apagar();
                    luces.Encender(); // Se encienden las luces a normal
                    Console.WriteLine("\nSaliendo del Modo Cine...");
                    Console.ReadKey();
                }
                else if (opcionCanal >= 1 && opcionCanal <= 5)
                {
                    tv.seleccionarCanal(opcionCanal);
                    Console.WriteLine("\nPresione ENTER para seleccionar otro canal...");
                    Console.ReadKey();
                }
            } while (opcionCanal != 6);
        } // Fin del método ModoCine (CORREGIDO)

        public void ModoJuegos()
        {
            // Operación simplificada (Encender/Configurar dispositivos)
            altavoces.Encender();
            luces.Atenuar();
            Console.WriteLine("\nConfigurando ambiente para juegos...");
            Console.ReadKey();

            do
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("|      SELECCIONE DONDE JUGAR       |");
                Console.WriteLine("======================================");
                Console.WriteLine("     1) Consola de Videojuegos");
                Console.WriteLine("     2) Laptop");
                Console.WriteLine("     3) No jugar (Salir del Modo Juegos)");
                Console.WriteLine("======================================");
                Console.Write("\nSeleccione una opción: ");

                // Manejo de errores de parsing
                if (!int.TryParse(Console.ReadLine(), out opcionConsola))
                {
                    Console.WriteLine("\nEntrada inválida. Presione cualquier tecla para reintentar...");
                    Console.ReadKey();
                    continue;
                }

                Console.Clear();
                //Validar que la opción seleccionada sea válida
                switch (opcionConsola)
                {
                    case 1:
                        tv.Encender();
                        consola.Encender();
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("======================================");
                            Console.WriteLine("|        SELECCIONE UN JUEGO         |");
                            Console.WriteLine("======================================");
                            consola.MostrarJuegos();
                            Console.WriteLine("     5) Apagar Consola (Salir de Opción 1)");
                            Console.WriteLine("=====================================");
                            Console.Write("\nSeleccione una opción: ");

                            // Manejo de errores de parsing
                            if (!int.TryParse(Console.ReadLine(), out opcionJuego))
                            {
                                Console.WriteLine("\nEntrada inválida. Presione cualquier tecla para reintentar...");
                                Console.ReadKey();
                                continue;
                            }

                            //Validar que la opción seleccionada sea válida
                            if (opcionJuego < 1 || opcionJuego > 5)
                            {
                                Console.WriteLine("\nOpción no válida. \nSeleccione un juego entre 1 y 5...");
                                Console.ReadKey();
                                continue;
                            }
                            else if (opcionJuego == 5)
                            {
                                // Apagar solo la consola y la TV
                                consola.Apagar();
                                tv.Apagar();
                                Console.WriteLine("\nSaliendo de la Consola...");
                                Console.ReadKey();
                                // Los altavoces y luces se mantienen hasta salir del ModoJuegos
                            }
                            else if (opcionJuego >= 1 && opcionJuego <= 4)
                            {
                                consola.IniciarJuego(opcionJuego);
                                Console.WriteLine("\nPresione ENTER para seleccionar otro juego...");
                                Console.ReadKey();
                            }
                        } while (opcionJuego != 5);
                        break;

                    case 2:
                        Laptop.Encender();
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("=====================================");
                            Console.WriteLine("       MOSTRANDO APLICACIONES DISPONIBLES     ");
                            // Llamar al método para mostrar las aplicaciones
                            Laptop.MostrarAplicaciones();
                            Console.WriteLine("\n5) Apagar Laptop (Salir de Opción 2)");

                            Console.WriteLine("=====================================");
                            Console.Write("\nSeleccione una opción: ");

                            // Manejo de errores de parsing
                            if (!int.TryParse(Console.ReadLine(), out opcionJuego))
                            {
                                Console.WriteLine("\nEntrada inválida. Presione cualquier tecla para reintentar...");
                                Console.ReadKey();
                                continue;
                            }

                            //Validar que la opción seleccionada sea válida
                            if (opcionJuego < 1 || opcionJuego > 5)
                            {
                                Console.WriteLine("\nOpción no válida. \nSeleccione un juego o aplicación entre 1 y 5...");
                                Console.ReadKey();
                                continue;
                            }
                            else if (opcionJuego == 5)
                            {
                                // Apagar solo la laptop
                                Laptop.Apagar();
                                Console.WriteLine("\nSaliendo de la Laptop...");
                                Console.ReadKey();
                            }
                            else if (opcionJuego >= 1 && opcionJuego <= 4)
                            {
                                Laptop.AbrirAplicacion(opcionJuego);
                                Console.WriteLine("\nPresione ENTER para seleccionar otra aplicación...");
                                Console.ReadKey();
                            }
                        } while (opcionJuego != 5);
                        break;

                    case 3:
                        Console.WriteLine("Saliendo del Modo Juegos...");
                        // Se apaga el modo
                        altavoces.Apagar();
                        luces.Encender();
                        Console.WriteLine("Presione ENTER para continuar...");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Opción no válida. \nSeleccione una opción entre 1 y 3...");
                        Console.ReadKey();
                        break;
                }
            } while (opcionConsola != 3);
        } // Fin del método ModoJuegos (CORREGIDO)

        public void ApagarTodo()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("\nApagando todo el sistema...");
            // Espera simulada
            Thread.Sleep(500);
            tv.Apagar();
            Thread.Sleep(200);
            consola.Apagar();
            Thread.Sleep(200);
            Laptop.Apagar();
            Thread.Sleep(200);
            altavoces.Apagar();
            Thread.Sleep(200);
            luces.Apagar(); // Se apagan las luces
            Thread.Sleep(500);
            Console.WriteLine("\nSistema apagado COMPLETAMENTE.");
            Console.WriteLine("======================================");
        }
    }

    // ----------------------------------------------------------------
    // 4. PROGRAMA PRINCIPAL (DEMOSTRACIÓN DE USO)
    // ----------------------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            // El cliente interactúa SOLAMENTE con la Fachada
            IEntretenimiento facade = new SistemaEntretenimiento();

            int opcionMenu = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("======================================");
                Console.WriteLine("|       SISTEMA DE ENTRETENIMIENTO     |");
                Console.WriteLine("|           (PATRÓN FACADE)          |");
                Console.WriteLine("======================================");
                Console.WriteLine(" 1) Activar Modo Cine");
                Console.WriteLine(" 2) Activar Modo Juegos");
                Console.WriteLine(" 3) Apagar Todo");
                Console.WriteLine(" 4) Salir del Programa");
                Console.WriteLine("======================================");
                Console.Write("\nSeleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcionMenu))
                {
                    Console.WriteLine("\nEntrada inválida. Presione cualquier tecla para reintentar...");
                    Console.ReadKey();
                    continue;
                }

                switch (opcionMenu)
                {
                    case 1:
                        facade.ModoCine();
                        break;
                    case 2:
                        facade.ModoJuegos();
                        break;
                    case 3:
                        facade.ApagarTodo();
                        break;
                    case 4:
                        Console.WriteLine("\nSaliendo del programa. ¡Adiós!");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Presione ENTER para reintentar...");
                        Console.ReadKey();
                        break;
                }
            } while (opcionMenu != 4);
        }
    }
}
