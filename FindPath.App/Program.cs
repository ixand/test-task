using System;
using System.Drawing;
using System.Collections.Generic;

namespace FindPath.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[25, 25]
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

            foreach (var point in FindShortestPath(arr))
            {
                Console.WriteLine(point);
            }

            Console.ReadKey();
        }

        private static readonly int[,] directions = new int[,] //Задаємо правила ходу 
        {
        { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 }, // Вправо, вниз, вліво, вгору
        { 1, 1 }, { -1, 1 }, { -1, -1 }, { 1, -1 } // Діагональні переміщення
        };

        public static Point[] FindShortestPath(int[,] arr)
        {
            int n = arr.GetLength(0);


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

                    if (IsValidMove(arr, visited, x, y, newX, newY))
                    {
                        queue.Enqueue((newX, newY));
                        visited[newX, newY] = true;
                        previous[(newX, newY)] = (x, y); // Запам'ятовуємо, звідки прийшли
                    }
                }
            }

            return new Point[0]; // Якщо шлях не знайдено
        }





        private static bool IsValidMove(int[,] arr, bool[,] visited, int x, int y, int newX, int newY)
        {
            int n = arr.GetLength(0);

            // Перевіряємо чи нові координати не виходять за межі масиву і чи точка не відвідана
            if (newX < 0 || newX >= n || newY < 0 || newY >= n || visited[newX, newY])
                return false;

            // Дозволяємо тільки горизонтальний або вертикальний рух для нульових значень
            if (arr[x, y] == 0 || arr[newX, newY] == 0)
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

