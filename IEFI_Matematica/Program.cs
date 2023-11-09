using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Función para generar un conjunto aleatorio de 5 elementos
    static HashSet<int> ConjuntoAleatorio(Random random)
    {
        HashSet<int> conj = new HashSet<int>();
        while (conj.Count < 5)
        {
            conj.Add(random.Next(1, 10)); // Números aleatorios del 1 al 10
        }
        return conj;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("¡Bienvenido al juego de adivinanza de conjuntos!");
        Console.WriteLine("Se mostrarán dos conjuntos de cinco elementos, tendrás que");
        Console.WriteLine("ingresar la unión y la intersección de dichos conjuntos.");
        Console.WriteLine("Ganarás un punto por respuesta correcta.");
        Console.WriteLine("\nIMPORTANTE: ingresar los elementos separados por una coma y un espacio.");
        Console.WriteLine("No es necesario ordenar los elementos. Solo ingresa los elementos correctos.");
        Console.WriteLine("\nPresiona Enter para comenzar...");
        Console.ReadLine();

        int puntajeFinal = 0;
        Random random = new Random();

        HashSet<int> conjA = ConjuntoAleatorio(random);
        HashSet<int> conjB = ConjuntoAleatorio(random);

        for (int ronda = 1; ronda <= 2; ronda++)
        {
            Console.WriteLine($"Ronda {ronda}:");

            // Mostrar conjuntos A y B al jugador
            Console.WriteLine($"\nConjunto A: {string.Join(", ", conjA)}");
            Console.WriteLine($"Conjunto B: {string.Join(", ", conjB)}");

            // Solicitar al jugador que adivine la intersección y la unión
            Console.Write("\nAdivina la intersección (elementos comunes) separados por coma y espacio: ");
            string respuestaInterseccion = Console.ReadLine();
            Console.Write("Adivina la unión (todos los elementos) separados por coma y espacio: ");
            string respuestaUnion = Console.ReadLine();

            // Calcular la intersección y la unión real
            HashSet<int> intersection = new HashSet<int>(conjA.Intersect(conjB));
            HashSet<int> union = new HashSet<int>(conjA.Union(conjB));

            // Verificar las respuestas del jugador
            HashSet<int> conjRespuestaInterseccion = new HashSet<int>(respuestaInterseccion.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            HashSet<int> conjRespuestaUnion = new HashSet<int>(respuestaUnion.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            if (intersection.SetEquals(conjRespuestaInterseccion))
            {
                Console.WriteLine("\n¡Adivinaste la intersección correctamente!");
                puntajeFinal++;
            }
            else
            {
                Console.WriteLine("\nLa intersección era: " + string.Join(", ", intersection));
            }

            if (union.SetEquals(conjRespuestaUnion))
            {
                Console.WriteLine("\n¡Adivinaste la unión correctamente!\n");
                puntajeFinal++;
            }
            else
            {
                Console.WriteLine("\nLa unión era: " + string.Join(", ", union) + "\n");
            }

            // Generar nuevos conjuntos para la próxima ronda
            conjA = ConjuntoAleatorio(random);
            conjB = ConjuntoAleatorio(random);
        }

        Console.WriteLine($"Puntuación total: {puntajeFinal}");
        Console.WriteLine("Presiona Enter para salir...");
        Console.ReadLine(); // Esperar hasta que el usuario presione Enter
    }
}