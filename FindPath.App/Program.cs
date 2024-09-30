using System;
using System.Drawing;
using System.Collections.Generic;

namespace FindPath.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[,] static_arr = new int[25, 25]
            {
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0},
                {0, 0, 0, 0, 0, 0, 0, 6, 6, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0},
                {0, 0, 0, 0, 0, 0, 0, 6, 6, 0, 0, 0, 4, 4, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 6, 6, 0, 0, 0, 4, 4, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 7, 7, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0},
                {0, 0, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 7, 7, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0},
                {4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 0, 0, 0},
                {4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            int[,] randomArray = FillRandomArray(25, 25);

            // Для демонстрації: виведемо масив у консоль
            PrintArray(randomArray);

            static int[,] FillRandomArray(int rows, int columns)
            {
                Random random = new();
                int[,] array = new int[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        // Генеруємо випадкове число: 0, 4, 5, 6, 7
                        array[i, j] = random.Next(0, 5) == 0 ? 0 : random.Next(4, 8);
                    }
                }

                return array;
            }

            static void PrintArray(int[,] array)
            {
                int rows = array.GetLength(0);
                int columns = array.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write(array[i, j] + "   "); // Виводимо значення з пробілами
                    }
                    Console.WriteLine(); // Переходимо на новий рядок
                }
            }

            foreach (var point in FindShortestPath(static_arr))
            {
                Console.WriteLine(point);
            }

            Console.ReadKey();
        }

        private static readonly int[,] directions = new int[,] 
        {
              { 0, 1 },  // Вправо: переміститися на 1 клітинку вправо (координата x залишається тією самою, y збільшується на 1)
              { 1, 0 },  // Вниз: переміститися на 1 клітинку вниз (x збільшується на 1, y залишається тим самим)
              { 0, -1 }, // Вліво: переміститися на 1 клітинку вліво (x залишається тим самим, y зменшується на 1)
              { -1, 0 }, // Вгору: переміститися на 1 клітинку вгору (x зменшується на 1, y залишається тим самим)
              { 1, 1 },  // Діагональ вправо-вниз: пересування одночасно вниз і вправо (x збільшується на 1, y збільшується на 1)
              { -1, 1 }, // Діагональ вгору-вправо: пересування одночасно вгору і вправо (x зменшується на 1, y збільшується на 1)
              { -1, -1 },// Діагональ вгору-вліво: пересування одночасно вгору і вліво (x зменшується на 1, y зменшується на 1)
              { 1, -1 }  // Діагональ вниз-вліво: пересування одночасно вниз і вліво (x збільшується на 1, y зменшується на 1)
        };

        public static Point[] FindShortestPath(int[,] static_arr)
        {
            int n = static_arr.GetLength(0);


            var queue = new Queue<(int, int)>();
            bool[,] visited = new bool[n, n];
            var previous = new Dictionary<(int, int), (int, int)>(); // Для зберігання шляху

            queue.Enqueue((0, 0)); // Початкова точка
            visited[0, 0] = true;

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();

                if (x == n - 1 && y == n - 1)
                {
                    return ReconstructPath(previous, x, y); // Відновлення шляху
                }

                for (int i = 0; i < directions.GetLength(0); i++)
                {
                    int newX = x + directions[i, 0];
                    int newY = y + directions[i, 1];

                    if (IsValidMove(static_arr, visited, x, y, newX, newY))
                    {
                        queue.Enqueue((newX, newY));
                        visited[newX, newY] = true;
                        previous[(newX, newY)] = (x, y); // Запам'ятовуємо, звідки прийшли
                    }
                }
            }

            return new Point[0]; // Якщо шлях не знайдено
        }





        private static bool IsValidMove(int[,] static_arr, bool[,] visited, int x, int y, int newX, int newY)
        {
            int n = static_arr.GetLength(0);

            // Перевіряємо чи нові координати не виходять за межі масиву і чи точка не відвідана
            if (newX < 0 || newX >= n || newY < 0 || newY >= n || visited[newX, newY])
                return false;

            // Дозволяємо тільки горизонтальний або вертикальний рух для нульових значень
            if (static_arr[x, y] == 0 || static_arr[newX, newY] == 0)
                return (newX == x || newY == y); // Рух дозволяється тільки горизонтально або вертикально

            // Якщо обидві точки не є нулями, дозволяємо рух будь-яким чином
            return true;
        }




        private static Point[] ReconstructPath(Dictionary<(int, int), (int, int)> previous, int x, int y) //Після досягнення кінцевої точки ми використовуємо цей метод для побудови шляху, ідучи у зворотному напрямку через збережені попередні точки
        {
            var path = new Stack<Point>();
            var current = (x, y);

            // Відновлюємо шлях, проходячи по точкам у зворотному порядку
            while (previous.ContainsKey(current))
            {
                path.Push(new Point(current.Item1, current.Item2));
                current = previous[current];
            }

            // Додаємо початкову точку
            path.Push(new Point(0, 0));

            return path.ToArray();
        }
    }
}

