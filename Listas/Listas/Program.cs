using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas
{
    using System;

    class Nodo
    {
        public int Coeficiente;
        public int Exponente;
        public Nodo Siguiente;

        public Nodo(int coeficiente, int exponente)
        {
            Coeficiente = coeficiente;
            Exponente = exponente;
            Siguiente = null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Definir el nodo cabeza
            Nodo cabeza = null;
            // Permitir al usuario agregar términos al polinomio
            Console.WriteLine("Introduce los términos del polinomio (coeficiente y exponente).");
            Console.WriteLine("Introduce 0 como coeficiente para terminar.");
            while (true)
            {
                int coeficiente = Solicitar("Introduce el coeficiente: ");
                if (coeficiente == 0) break;
                int exponente = Solicitar("Introduce el exponente: ");
                // Insertar el término en el polinomio
                InsertarAlInicio(ref cabeza, coeficiente, exponente);
            }
            // Mostrar el polinomio
            Console.WriteLine("El polinomio es:");
            Recorrer(cabeza);
            // Evaluar el polinomio para un valor de x
            double x = SolicitarDeci("Introduce un valor para x: ");
            double resultado = Evaluar(cabeza, x);
            Console.WriteLine($"El resultado del polinomio para x={x} es: {resultado}");
            // Calcular la derivada del polinomio
            Nodo derivada = Calcular(cabeza);
            Console.WriteLine("La derivada del polinomio es:");
            Recorrer(derivada);
            // Evitar que la consola se cierre inmediatamente
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
        // Función para insertar al inicio de la lista
        static void InsertarAlInicio(ref Nodo cabeza, int coeficiente, int exponente)
        {
            Nodo nuevoNodo = new Nodo(coeficiente, exponente);
            nuevoNodo.Siguiente = cabeza; // El nuevo nodo apunta al nodo cabeza actual
            cabeza = nuevoNodo; // El nuevo nodo se convierte en la nueva cabeza
        }

        // Función para evaluar el polinomio para un valor dado de x
        static double Evaluar(Nodo cabeza, double x)
        {
            double resultado = 0;
            Nodo temp = cabeza;
            while (temp != null)
            {
                resultado += temp.Coeficiente * Math.Pow(x, temp.Exponente);
                temp = temp.Siguiente;
            }
            return resultado;
        }

        // Función para calcular la derivada del polinomio
        static Nodo Calcular(Nodo cabeza)
        {
            Nodo derivada = null;
            Nodo temp = cabeza;
            while (temp != null)
            {
                if (temp.Exponente != 0) // La derivada de una constante es 0
                {
                    InsertarAlInicio(ref derivada, temp.Coeficiente * temp.Exponente, temp.Exponente - 1);
                }
                temp = temp.Siguiente;
            }
            return derivada;
        }
        // Función para recorrer la lista
        static void Recorrer(Nodo cabeza)
        {
            Nodo temp = cabeza;
            while (temp != null)
            {
                Console.Write($"{temp.Coeficiente}x^{temp.Exponente} ");
                temp = temp.Siguiente;
                if (temp != null)
                    Console.Write("+ ");
            }
            Console.WriteLine();
        }
        // Función para solicitar un número entero con validación
        static int Solicitar(string mensaje)
        {
            int numero;
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                if (int.TryParse(entrada, out numero))
                {
                    return numero;
                }
                else
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }
            }
        }

        // Función para solicitar un número decimal con validación
        static double SolicitarDeci(string mensaje)
        {
            double numero;
            while (true)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                if (double.TryParse(entrada, out numero))
                {
                    return numero;
                }
                else
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }
            }
        }
    }
}
