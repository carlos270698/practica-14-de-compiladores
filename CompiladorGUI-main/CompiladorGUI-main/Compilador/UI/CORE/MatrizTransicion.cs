using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.UI.CORE
{
    public class MatrizTransicion
    {
        //Columnas:
        // 0 = Letra o '_'
        // 1 = Digito
        // 2 = Espacio en blanco
        // 3 = Otro simbolo (por ejemplo: operadores, delimitadores, etc.)

        // Estados o renglones:
        // 100 = Aceptar ID/palabra reservada
        // 200 = Aceptar numero entero
        // 300 = Error lexico

        private readonly int[,] _matriz =
        {
            //         L     D   ESP   ;    =    /    +    -    *    >    <    :    (    )    {    }    ,    '    .   OTRO
            /*0*/ {    1,    2,    0, 300, 301, 302, 303, 304, 305, 306, 307, 308, 309, 310, 311, 312, 313, 314, 501, 501 }, // Inicio

            /*1*/ {    1,    1,  100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 501 }, // ID

            /*2*/ {  501,    2,  200, 200, 200, 200, 200, 200, 200, 200, 200, 200, 200, 200, 200, 200, 200, 200,   3, 501 }, // Entero

            /*3*/ {  501,    3,  201, 201, 201, 201, 201, 201, 201, 201, 201, 201, 201, 201, 201, 201, 201, 201, 501, 501 }  // Decimal
        };



        public int ObtenerColumna(char c)
        {
            if (char.IsLetter(c) || c == '_')
                return 0; //Columna de letras/underscore

            if (char.IsDigit(c))
                return 1; //Digito

            if (char.IsWhiteSpace(c))
                return 2; //Espacios

            if (c == ';')
                return 3;

            if (c == '=')
                return 4;

            if (c == '/')
                return 5;

            if (c == '+')
                return 6;

            if (c == '-')
                return 7;

            if (c == '*')
                return 8;

            if (c == '>')
                return 9;

            if (c == '<')
                return 10;

            if (c == ':')
                return 11;

            if (c == '(')
                return 12;

            if (c == ')')
                return 13;

            if (c == '{')
                return 14;

            if (c == '}')
                return 15;

            if (c == ',')
                return 16;

            if (c == '\'')
                return 17;

            if (c == '.')
                return 18;

            return 19; //Otros caracteres
        }

        public int SiguienteEstado(int estado, int columna)
        {
            //Segun la cantidad de estados
            if (estado < 0 || estado > 3)
                throw new ArgumentOutOfRangeException(nameof(estado));

            return _matriz[estado, columna];
        }
    }
}
