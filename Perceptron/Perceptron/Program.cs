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
            List<double[]> entradas = new List<double[]>();
            //entradas.Add("0,0,-1");
            //entradas.Add("1,0,1");
            //entradas.Add("0,1,1");
            //entradas.Add("1,1,1");
            entradas.Add(new double[] { 1.0, 0.1, 1 });
            entradas.Add(new double[] { 9.4, 6.4, -1 });
            entradas.Add(new double[] { 2.5, 2.1, 1 });
            entradas.Add(new double[] { 8.0, 7.7, -1 });
            entradas.Add(new double[] { 0.5, 2.2, 1 });
            entradas.Add(new double[] { 7.9, 8.4, -1 });
            entradas.Add(new double[] { 7.0, 7.0, -1 });
            entradas.Add(new double[] { 2.8, 0.8, 1 });
            entradas.Add(new double[] { 1.2, 3.0, 1 });
            entradas.Add(new double[] { 7.8, 6.1, -1 });

            Random r = new Random();

            double[] pesos = { r.NextDouble(), r.NextDouble(), r.NextDouble() };
            var p = pesos;
            double aprendizagem = 0.2d;

            Perceptron.treinar(entradas, aprendizagem, pesos);
            Console.ReadKey();

        }
    }
}
