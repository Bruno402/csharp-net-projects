double resultado = 0;
string regresar = "SI";

while (regresar == "SI")
{
    Console.WriteLine("=== Calculadora en C# ===");
    Console.WriteLine("Selecciona una operación:");
    Console.WriteLine("1. Suma");
    Console.WriteLine("2. Resta");
    Console.WriteLine("3. Multiplicación");
    Console.WriteLine("4. División");

    Console.Write("Opción: ");
    int opcion = int.Parse(Console.ReadLine());

    if( opcion >= 1 && opcion < 5)
    {
        Console.Write("Ingresa el primer número: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("Ingresa el segundo número: ");
        double num2 = double.Parse(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                resultado = num1 + num2;
                break;
            case 2:
                resultado = num1 - num2;
                break;
            case 3:
                resultado = num1 * num2;
                break;
            case 4:
                if (num2 != 0)
                    resultado = num1 / num2;
                else
                    Console.WriteLine("Error: División entre cero no permitida.");
                break;
        }
        Console.WriteLine($"Resultado: {resultado}");
    }
    else
    {
        Console.WriteLine("La opcion ingresada no esta en la calculadora :( ");
    }
    
    Console.WriteLine("Si quieres realizar otra operacion introduce SI, de lo contrario introduce NO...");
    regresar = Console.ReadLine();
    Console.Clear();
}

Console.WriteLine("¡Gracias por ocupar esta calculadora amigo vuelve pronto!");
Console.ReadKey();