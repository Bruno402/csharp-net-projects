using System;

namespace ConversorUnidades
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Conversor de Unidades ===");
                Console.WriteLine("1. Temperatura (Celsius ↔ Fahrenheit)");
                Console.WriteLine("2. Longitud (Metros ↔ Pies)");
                Console.WriteLine("3. Peso (Kilogramos ↔ Libras)");
                Console.WriteLine("4. Salir");
                Console.Write("Selecciona una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = 0;

                switch (opcion)
                {
                    case 1:
                        ConvertirTemperatura();
                        break;
                    case 2:
                        ConvertirLongitud();
                        break;
                    case 3:
                        ConvertirPeso();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (opcion != 4)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 4);
        }

        static void ConvertirTemperatura()
        {
            Console.Write("Ingresa la temperatura en Celsius: ");
            double celsius = double.Parse(Console.ReadLine());
            double fahrenheit = (celsius * 9 / 5) + 32;
            Console.WriteLine($"{celsius} °C = {fahrenheit} °F");

            Console.Write("Ingresa la temperatura en Fahrenheit: ");
            fahrenheit = double.Parse(Console.ReadLine());
            celsius = (fahrenheit - 32) * 5 / 9;
            Console.WriteLine($"{fahrenheit} °F = {celsius} °C");
        }

        static void ConvertirLongitud()
        {
            Console.Write("Ingresa la longitud en metros: ");
            double metros = double.Parse(Console.ReadLine());
            double pies = metros * 3.28084;
            Console.WriteLine($"{metros} m = {pies} ft");

            Console.Write("Ingresa la longitud en pies: ");
            pies = double.Parse(Console.ReadLine());
            metros = pies / 3.28084;
            Console.WriteLine($"{pies} ft = {metros} m");
        }

        static void ConvertirPeso()
        {
            Console.Write("Ingresa el peso en kilogramos: ");
            double kg = double.Parse(Console.ReadLine());
            double libras = kg * 2.20462;
            Console.WriteLine($"{kg} kg = {libras} lb");

            Console.Write("Ingresa el peso en libras: ");
            libras = double.Parse(Console.ReadLine());
            kg = libras / 2.20462;
            Console.WriteLine($"{libras} lb = {kg} kg");
        }
    }
}
