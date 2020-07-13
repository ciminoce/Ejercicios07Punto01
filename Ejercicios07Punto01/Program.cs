using System;
using ConsoleTables;

namespace Ejercicios07Punto01
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] tempSemana = new[] {14.5, 10.7, 8.7, 10, 12, 14, 18};//se define e inicializa el vector
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
                        IngresarDatos(opcionElegida,tempSemana);
                        break;
                    case 2://Modificar datos
                        opcionElegida = "Modificación de Datos";
                        ModificarDatos(opcionElegida,tempSemana);
                        break;
                    case 4://Listar Datos
                        opcionElegida = "Listado de Datos";
                        ListarDatos(opcionElegida,tempSemana);
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

                #endregion

            } while (true);

        }

        private static void ListarDatos(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);
            var tabla=new ConsoleTable("Día Nro","Temperatura");//Crea una tabla en consola
            for (int i = 0; i < tempSemana.Length; i++)
            {
                //Console.WriteLine($"{tempSemana[i]}");
                tabla.AddRow(i+1,tempSemana[i]);//Agrega una fila a la tabla en consola
            }
            tabla.Write();//Muestra la tabla en consola
            SalidaDelMetodo(opcionElegida);
        }

        private static void IngresoAlMetodo(string opcionElegida)
        {
            Console.Clear();
            Console.WriteLine($"{opcionElegida}");
        }

        private static void ModificarDatos(string opcionElegida, double[] tempSemana)
        {
            IngresoAlMetodo(opcionElegida);

            var tabla = new ConsoleTable("Día Nro", "Temperatura");//Crea una tabla en consola
            for (int i = 0; i < tempSemana.Length; i++)
            {
                //Console.WriteLine($"{tempSemana[i]}");
                tabla.AddRow(i + 1, tempSemana[i]);//Agrega una fila a la tabla en consola
            }
            tabla.Write();//Muestra la tabla en consola
            var intIndex=0;
            do
            {
                Console.Write("Ingrese el nro. de elemento a modificar:");
                if (!int.TryParse(Console.ReadLine(),out intIndex))
                {
                    Console.WriteLine("Indice mal ingresado");
                }else if (intIndex<0 || intIndex>tempSemana.Length-1)//me fijo que esté entre 0 y la cantidad de elementos menos 1
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
