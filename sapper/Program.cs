using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите высоту поля: ");
            int height = Convert.ToInt32(Console.ReadLine());
            if (height <= 0)
            {
                Console.Write("Значение высоты должно быть больше нуля.\nВведите высоту поля: ");
                height = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Введите ширину поля: ");
            int width = Convert.ToInt32(Console.ReadLine());  
            if (width <= 0)
            {
                Console.Write("Значение ширины должно быть больше нуля.\nВведите ширину поля: ");
                width = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Введите количество мин: ");
            int mines = Convert.ToInt32(Console.ReadLine());
            if (mines > height * width)
            {
                Console.Write("Количество мин не может быть больше количества элементов поля.\nВведите количество мин: ");
                mines = Convert.ToInt32(Console.ReadLine());
            }
            if (mines == height * width)
            {
                Console.Write("Мины не могут занимать всё поле.\nВведите количество мин: ");
                mines = Convert.ToInt32(Console.ReadLine());
            }
            int[,] Field = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++)
                {
                    Field[i, k] = 0;
                }
            }
            Random rand = new Random();
            int n = 0;
            do
            {
                int row = rand.Next(height);
                int column = rand.Next(width);
                if (Field[row, column] != -1)
                {
                    Field[row, column] = -1;
                    n++;
                }
            }
            while (n != mines);
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++)
                {                    
                    if (Field[i, k] != -1)
                    {   int num = 0;
                        if (i - 1 >= 0 && i - 1 < height && k - 1 >= 0 && k - 1 < width && Field[i - 1, k - 1] == -1) num++;
                        if (i - 1 >= 0 && i - 1 < height && Field[i - 1, k] == -1) num++;
                        if (i -1 >= 0 && i - 1 < height && k +1 >= 0 && k + 1 < width && Field[i - 1, k + 1] == -1) num++;
                        if (k - 1 >= 0 && k - 1 < width && Field[i, k - 1] == -1) num++;
                        if (k + 1 >= 0 && k + 1 < width && Field[i, k + 1] == -1) num++;
                        if (i + 1 >= 0 && i + 1 < height && k - 1 >= 0 && k - 1 < width && Field[i + 1, k - 1] == -1) num++;
                        if (i + 1 >= 0 && i + 1 < height && Field[i + 1, k] == -1) num++;
                        if (i + 1 >= 0 && i + 1 < height && k + 1 >= 0 && k + 1 < width && Field[i + 1, k + 1] == -1) num++;

                        Field[i, k] = num;
                        
                       
                    }
                                     
                }
            }
            for (int j = 0; j < height; j++)
            {
                for (int l = 0; l < width; l++)
                {
                    Console.Write(String.Format("{0,3}", Field[j, l]));
                    
                }
                Console.WriteLine();

            }
            Console.ReadKey();
        }
    }
}
