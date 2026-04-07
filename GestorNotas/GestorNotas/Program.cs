using System;
using System.Collections.Generic;

namespace GestorNotas
{
    class Program
    {
        static List<string> notas = new List<string>();

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Gestor de Notas ===");
                Console.WriteLine("1. Crear nota");
                Console.WriteLine("2. Listar notas");
                Console.WriteLine("3. Editar nota");
                Console.WriteLine("4. Eliminar nota");
                Console.WriteLine("5. Salir");
                Console.Write("Selecciona una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = 0;

                switch (opcion)
                {
                    case 1:
                        CrearNota();
                        break;
                    case 2:
                        ListarNotas();
                        break;
                    case 3:
                        EditarNota();
                        break;
                    case 4:
                        EliminarNota();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 5);
        }

        static void CrearNota()
        {
            Console.Write("Escribe tu nota: ");
            string nota = Console.ReadLine();
            notas.Add(nota);
            Console.WriteLine("Nota agregada correctamente.");
        }

        static void ListarNotas()
        {
            Console.WriteLine("\n=== Lista de Notas ===");
            if (notas.Count == 0)
            {
                Console.WriteLine("No hay notas registradas.");
                return;
            }

            for (int i = 0; i < notas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {notas[i]}");
            }
        }

        static void EditarNota()
        {
            ListarNotas();
            Console.Write("\nSelecciona el número de la nota a editar: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= notas.Count)
            {
                Console.Write("Escribe la nueva nota: ");
                notas[index - 1] = Console.ReadLine();
                Console.WriteLine("Nota editada correctamente.");
            }
            else
            {
                Console.WriteLine("Número inválido.");
            }
        }

        static void EliminarNota()
        {
            ListarNotas();
            Console.Write("\nSelecciona el número de la nota a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= notas.Count)
            {
                notas.RemoveAt(index - 1);
                Console.WriteLine("Nota eliminada correctamente.");
            }
            else
            {
                Console.WriteLine("Número inválido.");
            }
        }
    }
}