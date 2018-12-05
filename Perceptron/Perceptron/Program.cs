using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] entradas = new int[,] { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } };
            int[] saidas = { 0, 1, 1, 0 };

            Random r = new Random();

            double[] pesos = { r.NextDouble(), r.NextDouble(), r.NextDouble() };

            double taxaAprendizagem = 1;
            double totalErro = 1;

            while (totalErro > 0.2)
            {
                totalErro = 0;
                for (int i = 0; i < entradas.Length/2; i++)
                {
                    Console.WriteLine(totalErro);

                    var um = entradas[i, 0];
                    var dois = entradas[i, 1];
                    int ds = deltaSaida(entradas[i, 0], entradas[i, 1], pesos);

                    int erro = saidas[i] - ds;

                    pesos[0] += taxaAprendizagem * erro * entradas[i, 0];
                    pesos[1] += taxaAprendizagem * erro * entradas[i, 1];
                    pesos[2] += taxaAprendizagem * erro * 1;

                    totalErro += Math.Abs(erro);
                }

            }

            Console.WriteLine("Resultados:");
            for (int i = 0; i < entradas.Length/2; i++)
                Console.WriteLine(deltaSaida(entradas[i, 0], entradas[i, 1], pesos));

            Console.ReadLine();

        }

        private static int deltaSaida(double e1, double e2, double[] pesos)
        {
            double soma = e1 * pesos[0] + e2 * pesos[1] + 1 * pesos[2];
            return (soma >= 0) ? 1 : 0;
        }
    }
}
