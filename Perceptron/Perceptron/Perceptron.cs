using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    public class Perceptron
    {
        private static int input;

        public static int ativador(double saida)
        {
            if (saida >= 0)
                return 1;
            else
                return -1;
        }

        public static double perceptron(int entrada, double[] pesos)
        {
            double saida = 0.0;

            foreach (var item in pesos)
            {
                saida += entrada * item;
            }

            return ativador(saida);
        }

        public static double[] calcularPeso(int entrada, double[] pesos, double taxa, double erro)
        {
            for (int i = 0; i < pesos.Length; i++)
            {
                pesos[i] = pesos[i] + taxa * erro * entrada;
            }

            return pesos;
        }

        public static void treinar(int[,,] entradas, double taxa, double[] pesos, int bias = 1)
        {
           
            foreach (var item in entradas)
            {
                //o erro possivelmente tá aqui
                input = input + bias;

                while (true)
                {
                    var p = perceptron(input, pesos);
                    double erro = item - p;

                    if (erro == 0)
                    {
                        Console.WriteLine("Correto.");
                        break;
                    } else
                    {
                        pesos = calcularPeso(input, pesos, taxa, erro);
                        Console.WriteLine("Incorreto.");
                    }
                }
            }
        }
    }
}
