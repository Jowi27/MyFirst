using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//1. Rellenar matriz A
//2. Rellenar Matriz B
//3. Visualizar matrices.
//4. Sumar matrices.
//5. Producto por un escalar.
//6. Producto de matrices.
//7. Traspuesta.
//8. Salir.

namespace Matrices{
    class Program{
        /// <summary>
        /// Procedimiento para dimensionar y asignar valores a cada posición del a matriz.
        /// </summary>
        /// <autor>Joel Casañas.</autor>
        /// <fechacreacion>15/1/2016, 13:30.</fechacreacion>
        /// <param name="matrix">Vector bidimensional que rellenaremos.</param>
        static void RellenarMatriz(ref int[,] matrix){
            Console.WriteLine("·Introduciremos las dimensiones de la matriz.");
            Console.Write("Nº de filas: ");
            int M = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nº de columnas: ");
            int N = Convert.ToInt32(Console.ReadLine());
            matrix = new int[M, N];
            for (int i=0;i<M; i++){
                for(int j=0;j< N; j++){
                    Console.Write("Introduzca el valor ({0},{1}) de la matriz: ", i + 1, j + 1);
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        //Función para mostrar las matrices
        public static void MostrarMatriz(int[,] matrix){
            for(int i = 0;i< matrix.GetLength(0); i++){
                for(int j=0; j< matrix.GetLength(1); j++){
                    Console.Write(string.Format("{0,6:D}", matrix[i, j]));
                }
                Console.WriteLine(" ");
            }
        }
        //Función para sumar dos matrces
        public static int[,] SumarMatrices(int[,] matrix1, int[,] matrix2){
            int[,] matrixSuma = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            for(int i=0;i< matrixSuma.GetLength(0); i++){
                for(int j=0;j< matrixSuma.GetLength(1); j++){
                    matrixSuma[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return matrixSuma;
        }
        public static int[,] MultiplicarMatrices(int[,] matrix1, int[,] matrix2){
            int[,] matrixResultado = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            for(int i = 0; i < matrixResultado.GetLength(0); i++){
                for(int j = 0; j < matrixResultado.GetLength(1); j++){
                    for(int k = 0; k < matrix1.GetLength(1); k++){
                        matrixResultado[i, j] = matrixResultado[i, j] + (matrix1[i, k] * matrix2[k, j]);
                    }
                }
            }
            return matrixResultado;
        }
        public static int[,] MultiplicarMatrizPorEscalar(int[,] matrix, int producto){
            int[,] matrizResultado = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for(int i=0;i<matrizResultado.GetLength(0); i++){
                for(int j=0;j<matrizResultado.GetLength(1); j++){
                    matrizResultado[i,j] = matrix[i, j] * producto;
                }
            }
            return matrizResultado;
        }
        public static int[,] CalcularMatrizTraspuesta(int[,] matrix){
            int[,] matrixTraspuesta = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for(int i = 0; i < matrixTraspuesta.GetLength(0); i++){
                for (int j = 0; j < matrixTraspuesta.GetLength(1); j++){
                    matrixTraspuesta[i, j] = matrix[j, i];
                }
            }
            return matrixTraspuesta;
        }
        public static void RealizarMenu(int[,] matriz1,int[,] matriz2){
            int opcion;
            do{
                Console.Clear();
                Console.WriteLine("~~~~~~MENÚ~~~~~~");
                Console.WriteLine("1. Rellenar la primera matriz.");
                Console.WriteLine("2. Rellenar la segunda matriz.");
                Console.WriteLine("3. Visualizar matrices.");
                Console.WriteLine("4. Sumar matrices.");
                Console.WriteLine("5. Multiplicar matriz por escalar.");
                Console.WriteLine("6. Multiplicar dos matrices.");
                Console.WriteLine("7. Realizar matriz traspuesta.");
                Console.WriteLine("8. Salir del programa.");
                Console.WriteLine("~~~~~~~~~~~~~~~~");
                Console.Write("¿Cuál es su opción?:");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion) {
                    case (8):
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    case (1):
                        //matriz1 = new int[M, N];
                        RellenarMatriz(ref matriz1);
                        break;
                    case (2):
                        //matriz2 = new int[M, N];
                        RellenarMatriz(ref matriz2);
                        break;
                    case (3):
                        if (matriz1 == null) {
                            Console.WriteLine("La primera matriz no está inicializada. Por favor, ejecute la primera opción del menú.");
                        }
                        else {
                            if (matriz2 == null) {
                                Console.WriteLine("La segunda matriz no está inicializada. Por favor, ejecute la segunda opción del menú.");
                            }
                            else {
                                Console.WriteLine("~~Matriz A~~");
                                MostrarMatriz(matriz1);
                                Console.WriteLine("~~Matriz B~~");
                                MostrarMatriz(matriz2);
                            }
                        }
                        break;
                    case (4):
                        if (matriz1 == null) {
                            Console.WriteLine("La primera matriz no está inicializada. Por favor, ejecute la primera opción del menú primero.");
                        }
                        else {
                            if (matriz2 == null) {
                                Console.WriteLine("La segunda matriz no está inicializada. Por favor, ejecute la segunda opción del menú primero.");
                            }
                            else {
                                if (matriz1.GetLength(0) == matriz2.GetLength(0) && matriz2.GetLength(1) == matriz1.GetLength(1)) {
                                    int[,] MatrizSuma = SumarMatrices(matriz1, matriz2);
                                    Console.WriteLine("Se sumarán las siguientes matrices: ");
                                    Console.WriteLine("~~Matriz A~~");
                                    MostrarMatriz(matriz1);
                                    Console.WriteLine("~~Matriz B~~");
                                    MostrarMatriz(matriz2);
                                    Console.WriteLine("~~Matriz Suma~~");
                                    MostrarMatriz(MatrizSuma);
                                }
                                else {
                                    Console.WriteLine("No se pueden sumar las matrices porque no poseen las mismas dimensiones.");
                                }
                            }
                        }
                        break;
                    case (5):
                        Console.WriteLine("¿Qué matriz desea multiplicar: A o B?");
                        char selectMatriz = Convert.ToChar(Console.ReadLine());
                        if (selectMatriz == 'A') {
                            Console.Write("¿Por qué número desea multiplicar la matriz?: ");
                            int producto = Convert.ToInt32(Console.ReadLine());
                            int[,] matrizProducto = MultiplicarMatrizPorEscalar(matriz1, producto);
                            MostrarMatriz(matrizProducto);
                        }
                        else if (selectMatriz == 'B') {
                            Console.Write("¿Por qué número desea multiplicar la matriz?: ");
                            int producto = Convert.ToInt32(Console.ReadLine());
                            int[,] matrizProducto = MultiplicarMatrizPorEscalar(matriz2, producto);
                            MostrarMatriz(matrizProducto);
                        }
                        else {
                            Console.WriteLine("No se ha seleccionado una opción correcta.");
                        }
                        break;
                    case (6):
                        if (matriz1.GetLength(1) == matriz2.GetLength(0)) {
                            Console.WriteLine("Se multiplicarán las siguientes matrices: ");
                            Console.WriteLine("~~Matriz A~~");
                            MostrarMatriz(matriz1);
                            Console.WriteLine("~~Matriz B~~");
                            MostrarMatriz(matriz2);
                            int[,] MatrizMultiplicacion = MultiplicarMatrices(matriz1, matriz2);
                            Console.WriteLine("~~Matriz resultante~~");
                            MostrarMatriz(MatrizMultiplicacion);
                        }
                        else
                        {
                            Console.WriteLine("No se pueden multiplicar las matrices por problemas de dimensión.");
                            Console.WriteLine("El número de columnas de la primera matriz debe ser igual al número de filas de la segunda matriz.");
                        }
                        break;
                    case (7):
                        Console.WriteLine("¿De qué matriz desea calcular la traspuesta: A/B?");
                        char tras = Convert.ToChar(Console.ReadLine());
                        if (tras == 'A'){
                            if (matriz1 == null) Console.WriteLine("");
                            else{
                                MostrarMatriz(matriz1);
                                int[,] matrizTraspuesta = CalcularMatrizTraspuesta(matriz1);
                                Console.WriteLine("~~~~Matriz A Traspuesta~~~~");
                                MostrarMatriz(matrizTraspuesta);
                            }
                        }
                        else if (tras == 'B'){
                            if (matriz2 == null) Console.WriteLine("");
                            else{
                                MostrarMatriz(matriz2);
                                int[,] matrizTraspuesta = CalcularMatrizTraspuesta(matriz2);
                                Console.WriteLine("~~~~Matrz B Traspuesta~~~~");
                                MostrarMatriz(matrizTraspuesta);
                            }
                        }
                        else Console.WriteLine("No ha seleccionado una opción correta.");
                        
                        break;
                    default:
                        Console.WriteLine("No ha seleccionado una opción correcta. Vuelva a intentarlo.");
                        break;
                }
                if (opcion!=8) Console.WriteLine("Proceso finalizado. Volviendo al menú...");
                Console.ReadKey();
            } while (opcion != 8);
        }
        static void Main(string[] args){
            int[,] matriz1 = null;
            int[,] matriz2 = null;
            RealizarMenu(matriz1,matriz2);
        }
    }
}
