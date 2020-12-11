using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        private double _numero;
        #endregion

        #region Properties
        private string SetNumero
        {
            set
            {
                _numero = ValidarNumero(value);
            }
        }
        #endregion


        #region Metodos
        public static string BinarioDecimal(string binario)
        {
            int[] cadenaInt = new int[binario.Length];
            string retorno = "";
            double numero = 0;
            bool flag = true;
            int i;
            for (i = 0; i < binario.Length; i++)
            {
                cadenaInt[i] = (int)char.GetNumericValue(binario[i]);
                if (cadenaInt[i] != 0 && cadenaInt[i] != 1)
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
            {
                for (i = 0; i < binario.Length; i++)
                {
                    numero += (cadenaInt[i] * Math.Pow(2, binario.Length - i - 1));
                }
                retorno = numero.ToString();
            }
            else
            {
                retorno = "Valor invalido";
            }

            return retorno;
        }

        public static string DecimalBinario(string numero)
        {
            string retorno;
            double numeroDouble;
            if (double.TryParse(numero, out numeroDouble))
            {
                retorno = DecimalBinario(numeroDouble);
            }
            else
            {
                retorno = "Valor invalido";
            }
            return retorno;
        }

        public static string DecimalBinario(double entero)
        {
            int numero = (int)entero;
            string binario = "";
            while (numero > 0)
            {
                binario += (numero % 2).ToString();
                numero = numero / 2;
            }
            char[] charArray = binario.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private double ValidarNumero(string strNumero)
        {
            double retNum;
            double.TryParse(strNumero, out retNum);
            return retNum;
        }
        #endregion

        #region Constructor
        public Numero() : this(0)
        {

        }

        public Numero(double _numero) : this(_numero.ToString())
        {

        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        #endregion

        #region Sobrecargas
        public static double operator +(Numero n1, Numero n2)
        {
            return n1._numero + n2._numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1._numero - n2._numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1._numero * n2._numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            return n1._numero / n2._numero;
        }
        #endregion


    }
}
