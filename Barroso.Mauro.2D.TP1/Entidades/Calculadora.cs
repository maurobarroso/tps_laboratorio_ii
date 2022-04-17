namespace Entidades
{
    public class Calculadora
    {

        /// <summary>
        /// Recibe dos operandos y un operador para operar entre ellos
        /// </summary>
        /// <param name="num1">Primer operando para operación</param>
        /// <param name="num2">Segundo operando para operación</param>
        /// <param name="operador">Parámetro que definirá el tipo de operador</param>
        /// <returns>Retorna el resultado de la operación</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {

            double resultado = 0;

            switch (ValidarOperador(operador))
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Comprueba que el char pasado sea un caracter válido
        /// </summary>
        /// <param name="operador">Parámetro operador a ser evaluado</param>
        /// <returns>Retorna el operador o '+' si no se ingresó char válido</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                return operador;
            }

            return '+';
        }


    }
}
