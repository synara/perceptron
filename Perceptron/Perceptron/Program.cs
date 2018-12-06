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
            int[, ,] entradas = new int[, ,] { { { 0, 0, -1 }, { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 1 } } };
            Random r = new Random();

            //double[] pesos = { r.NextDouble(), r.NextDouble(), r.NextDouble() };
            double[] pesos = { 1, 1, 1 };

            double taxaAprendizagem = 0.2d;

            Perceptron.treinar(entradas, taxaAprendizagem, pesos);

        }
    }
}
