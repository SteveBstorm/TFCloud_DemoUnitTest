using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUnitTest
{
    public class Calcul
    {
        public int Addition(int nb1, int nb2)
        {
            checked
            {
                try
                {
                    int result = nb1 + nb2;
                    return result;
                }
                catch {
                    throw new OverflowException("Limite d'entier dépassée");
                }
            }
            
        }
        /// <summary>
        /// Produit le résultat d'une division de deux entiers
        /// </summary>
        /// <param name="numerateur"></param>
        /// <param name="diviseur"></param>
        /// <returns>double</returns>
        /// <exception cref="DivideByZeroException"></exception>
        public double Division(int numerateur, int diviseur)
        {
            if (diviseur == 0) throw new DivideByZeroException();
            try
            {
                double result = (double)numerateur / diviseur;
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
