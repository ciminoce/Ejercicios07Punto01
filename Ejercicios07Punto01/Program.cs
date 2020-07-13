using System;
using ConsoleTables;

namespace Ejercicios07Punto01
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] tempSemana = new[] { 14.5, 10.7, 8.7, 10, 12, 14, 18 };//se define e inicializa el vector
            do
            {
                #region Menu Principal

                int intOpcion;
                Console.Clear();//Limpia la pantalla
                Console.WriteLine("Menú Principal");
                Console.WriteLine("0 - Salir");
                Console.WriteLine("1 - Ingresar Datos");
                Console.WriteLine("2 - Modificar Datos x Indice");
                Console.WriteLine("3 - Modificar Datos x Contenido");
                Console.WriteLine("4 - Listar Datos");
                Console.WriteLine("5 - Estadísticas de Datos");
                Console.WriteLine("6 - Listado Estadístico");
                Console.WriteLine("7 - Ordenar Datos");
                Console.WriteLine("8 - Reiniciar");
                Console.WriteLine();
                do
                {
                    Console.Write("Ingrese una opción del menú:");
                    if (!int.TryParse(Console.ReadLine(), out intOpcion))
                    {
                        Console.WriteLine("Opción mal ingresada");
                    }
                    else
                    {
                        break;//me saca del ciclo
                    }

                } while (true);
                #endregion

                #region Opcion Elegida

                string opcionElegida;
                switch (intOpcion)
                {
                    case 0://Salir del Programa
                        Environment.Exit(0);
                        break;
                    case 1://Ingresar datos
                        opcionElegida = "Ingreso de datos";
                        IngresarDatos(opcionElegida, tempSemana);
                        break;
                    case 2://Modificar datos
                        opcionElegida = "Modificación de Datos";
                        ModificarDatos(opcionElegida, tempSemana);
                        break;
                    case 3://Modifcar datos por contenido
                        opcionElegida = "Modificar datos por Contenido";
                        ModificarDatosPorContenido(opcionElegida, tempSemana);
                        break;
                    case 4://Listar Datos
                        opcionElegida = "Listado de Datos";
                        ListarDatos(opcionElegida, tempSemana);
                        break;
                    case 5://Estadisticas
                        opcionElegida = "Estadísticas";
                        Estadisticas(opcionElegida, tempSemana);
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

                #endregion

            } while (true);

        }

        private static void Estadisticas(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            MostrarDatosEnTabla(tempSemana);
            var mayorTemperatura = HallarMayorTemperatura(tempSemana);
            var menorTemperatura = HallarMenorTemperatura(tempSemana);
            var promedioTemperaturas = CalcularPromedio(tempSemana);
            Console.WriteLine($"Mayor Temperatura:{mayorTemperatura}");
            Console.WriteLine($"Menor Temperatura:{menorTemperatura}");
            Console.WriteLine($"Promedio:{promedioTemperaturas:N2}");
            SalidaDelMetodo(opcionElegida);
        }

        private static double CalcularPromedio(double[] tempSemana)
        {
            double promedio = 0;
            foreach (var temperatura in tempSemana)
            {
                promedio += temperatura;
            }

            promedio /= tempSemana.Length;
            return promedio;
        }

        private static double HallarMenorTemperatura(double[] tempSemana)
        {
            double menorTemperatura = 25;
            foreach (var temperatura in tempSemana)
            {
                if (temperatura < menorTemperatura)
                {
                    menorTemperatura = temperatura;
                }
            }

            return menorTemperatura;
        }

        private static double HallarMayorTemperatura(double[] tempSemana)
        {
            double mayorTemperatura = -11;
            foreach (var temperatura in tempSemana)
            {
                if (temperatura > mayorTemperatura)
                {
                    mayorTemperatura = temperatura;
                }
            }

            return mayorTemperatura;
        }

        private static void ModificarDatosPorContenido(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            MostrarDatosEnTabla(tempSemana);
            Console.Write("Ingrese el valor a modificar:");
            var elementoModificar = double.Parse(Console.ReadLine());
            /*El metodo IndexOf me devuelve el indice del elemento a modificar
             de acuerdo con el vector que le pase en el primer argumento*/
            var intIndex = Array.IndexOf(tempSemana, elementoModificar);
            if (intIndex >= 0)
            {
                Console.WriteLine($"El valor {elementoModificar} se encuentra en la posición {intIndex} del vector");
                Console.Write("Ingrese un nuevo contenido:");
                tempSemana[intIndex] = double.Parse(Console.ReadLine());

            }
            else
            {
                Console.WriteLine($"El elemento {elementoModificar} no se encuentra en el vector");
            }
            SalidaDelMetodo(opcionElegida);
        }

        private static void ListarDatos(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            MostrarDatosEnTabla(tempSemana);
            SalidaDelMetodo(opcionElegida);
        }

        private static void MostrarDatosEnTabla(double[] tempSemana)
        {
            var tabla = new ConsoleTable("Día Nro", "Temperatura"); //Crea una tabla en consola
            for (int i = 0; i < tempSemana.Length; i++)
            {
                //Console.WriteLine($"{tempSemana[i]}");
                tabla.AddRow(i + 1, tempSemana[i]); //Agrega una fila a la tabla en consola
            }

            tabla.Write(); //Muestra la tabla en consola
        }

        private static void IngresoAlMetodo(string opcionElegida)
        {
            Console.Clear();
            Console.WriteLine($"{opcionElegida}");
        }

        private static void ModificarDatos(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            MostrarDatosEnTabla(tempSemana);
            var intIndex = 0;
            do
            {
                Console.Write("Ingrese el nro. de elemento a modificar:");
                if (!int.TryParse(Console.ReadLine(), out intIndex))
                {
                    Console.WriteLine("Indice mal ingresado");
                }
                else if (intIndex < 0 || intIndex > tempSemana.Length - 1)//me fijo que esté entre 0 y la cantidad de elementos menos 1
                {
                    Console.WriteLine("Indice fuera del rango permitido");
                }
                else
                {
                    break;
                }

            } while (true);
            Console.WriteLine($"El elemento {intIndex} del vector es {tempSemana[intIndex]}");
            Console.Write("Ingrese la nueva temperatura:");
            tempSemana[intIndex] = double.Parse(Console.ReadLine());
            SalidaDelMetodo(opcionElegida);

        }

        private static void IngresarDatos(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            //TODO:Desarrollar el ingreso de datos
            SalidaDelMetodo(opcionElegida);
        }

        private static void SalidaDelMetodo(string opcionElegida)
        {
            Console.WriteLine($"Fin de {opcionElegida}... Tecla para continuar");
            Console.ReadLine();
        }
    }
}
