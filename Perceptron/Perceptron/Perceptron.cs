using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    public class Perceptron
    {
        private static double[] inputs;
        private static double classe;


        public static int ativador(double saida)
        {
            if (saida >= 0)
                return 1;
            else
                return -1;
        }

        public static double perceptron(double[] entradas, double[] pesos)
        {
            double saida = 0.0;
            int i = 0;

            foreach (var p in pesos)
            {
                for (i = i; i < entradas.Length; i++)
                {
                    saida += p * entradas[i];
                    i += 1;
                    break;
                }

            }

            return ativador(saida);
        }

        public static double[] calcularPeso(double[] inputs, double[] pesos, double aprendizagem, double erro)
        {
            int j = 0;

            for (int i = 0; i < pesos.Length; i++)
            {
                for (j = j; j < inputs.Length; j++)
                {
                    pesos[i] = pesos[i] + aprendizagem * erro * inputs[j];
                    j = j + 1;
                    break;
                }
            }

            return pesos;
        }

        public static void treinar(List<double[]> entradas, double aprendizagem, double[] pesos, int bias = 1)
        {
            bool verificar = false;
            foreach (var item in entradas)
            {
                separarDados(item, bias);
                int controle = 1;
                double erro = 0.0d;

                while (true)
                {
                    var p = perceptron(inputs, pesos);
                    erro = classe - p;

                    if (erro == 0)
                    {
                        Console.WriteLine($"({item[0] + "," + item[1] + ", " + item[2]}) correto na interação número {controle}.");
                        controle += 1;
                        break;
                    }
                    else
                    {
                        verificar = true;
                        pesos = calcularPeso(inputs, pesos, aprendizagem, erro);
                        Console.WriteLine($"({item[0] + "," + item[1] + ", " + item[2]}) incorreto na interação número {controle}.");
                        controle += 1;
                    }
                }
            }

            if (verificar)
            {
                treinar(entradas, aprendizagem, pesos);
                Console.WriteLine("Pesos finais: (" + pesos[0] + "," + pesos[1] + ", " + pesos[2] + ")");

            }

        }

        private static void separarDados(double[] item, int bias)
        {

            inputs = new double[] { item[0], item[1], bias };

            classe = Convert.ToInt32(item[2]);
        }
    }
}
