using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compilador.UI.CORE
{
    public class AnalizadorLexico
    {
        private readonly MatrizTransicion _matriz;
        private readonly PalabrasReservadas _palabrasReservadas;

        public AnalizadorLexico()
        {
            _matriz = new MatrizTransicion();
            _palabrasReservadas = new PalabrasReservadas();
        }

        public ResultadoLexico Analizar(CodigoFuente fuente)
        {
            var resultado = new ResultadoLexico();
            resultado.AgregarAviso("Lexico iniciado");

            try
            {
                for (int numLinea = 1; numLinea <= fuente.NumeroLineas; numLinea++)
                {
                    ProcesarLinea(fuente.ObtenerLinea(numLinea), numLinea, resultado);
                }

                resultado.AgregarAviso("Lexico finalizado exitosamente");
            }
            catch (Exception ex)
            {
                resultado.AgregarAviso("Error grave en lexico: " + ex.Message);
            }

            return resultado;
        }

        private void ProcesarLinea(string lineaOriginal, int numLinea, ResultadoLexico resultado)
        {
            int estado = 0;
            var lexema = new StringBuilder();
            int token = 0;

            if (string.IsNullOrWhiteSpace(lineaOriginal))
                return;

            string linea = (lineaOriginal ?? string.Empty) + " ";

            for (int i = 0; i < linea.Length; i++)
            {
                char c = linea[i];

                if ((c == '+' || c == '-') && i + 1 < linea.Length && char.IsDigit(linea[i + 1]))
                {
                    lexema.Append(c);
                    continue;
                }

                if (i + 1 < linea.Length)
                {
                    string doble = $"{c}{linea[i + 1]}";

                    if (doble == "==")
                    {
                        resultado.Tokens.Add(new Token(320, "==", numLinea));
                        estado = 0;
                        lexema.Clear();
                        token = 0;
                        i++;
                        continue;
                    }
                    else if (doble == ">=")
                    {
                        resultado.Tokens.Add(new Token(321, ">=", numLinea));
                        estado = 0;
                        lexema.Clear();
                        token = 0;
                        i++;
                        continue;
                    }
                    else if (doble == "<=")
                    {
                        resultado.Tokens.Add(new Token(322, "<=", numLinea));
                        estado = 0;
                        lexema.Clear();
                        token = 0;
                        i++;
                        continue;
                    }
                }

                if (c == '/' && i + 1 < linea.Length && linea[i + 1] == '/')
                {
                    if (lexema.Length > 0)
                    {
                        string lex = lexema.ToString();

                        if (estado == 1)
                        {
                            token = _palabrasReservadas.ObtenerToken(lex);
                            resultado.Tokens.Add(new Token(token, lex, numLinea));
                        }
                        else if (estado == 2)
                        {
                            token = 200;
                            resultado.Tokens.Add(new Token(token, lex, numLinea));
                        }
                        else if (estado == 3)
                        {
                            token = 201;
                            resultado.Tokens.Add(new Token(token, lex, numLinea));
                        }

                        lexema.Clear();
                        estado = 0;
                    }

                    string comentario = lineaOriginal.Substring(i);
                    resultado.AgregarAviso($"Comentario detectado en linea {numLinea}: {comentario}");
                    break;
                }

                int columna = _matriz.ObtenerColumna(c);
                int valorMatriz = _matriz.SiguienteEstado(estado, columna);

                if (valorMatriz == 0)
                {
                    estado = 0;
                    lexema.Clear();
                    token = 0;
                }
                else if (valorMatriz < 100)
                {
                    estado = valorMatriz;
                    lexema.Append(c);
                    token = 0;
                }
                else if (valorMatriz == 100)
                {
                    string lex = lexema.ToString();
                    token = _palabrasReservadas.ObtenerToken(lex);
                    resultado.Tokens.Add(new Token(token, lex, numLinea));
                    lexema.Clear();
                    estado = 0;
                    i--;
                }
                else if (valorMatriz == 200)
                {
                    string lex = lexema.ToString();
                    token = 200;
                    resultado.Tokens.Add(new Token(token, lex, numLinea));
                    lexema.Clear();
                    estado = 0;
                    i--;
                }
                else if (valorMatriz == 201)
                {
                    string lex = lexema.ToString();
                    token = 201;
                    resultado.Tokens.Add(new Token(token, lex, numLinea));
                    lexema.Clear();
                    estado = 0;
                    i--;
                }
                else if (valorMatriz >= 300 && valorMatriz < 500)
                {
                    token = valorMatriz;
                    resultado.Tokens.Add(new Token(token, c.ToString(), numLinea));
                    lexema.Clear();
                    estado = 0;
                }
                else if (valorMatriz > 500)
                {
                    string mensaje = $"ERROR: En linea [{numLinea}] simbolo no reconocido: '{c}'";
                    resultado.AgregarAviso(mensaje);
                    estado = 0;
                    lexema.Clear();
                    token = valorMatriz;
                }
            }
        }
    }
}
