using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hm_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Exmpl04();            
        }

        public static void Exmpl01()
        {
            //1.	Создать коллекцию List <int> . 
            //Вывести на экран позицию и значение элемента, являющегося вторым максимальным значением в коллекции. 
            //Вывести на экран сумму элементов на четных позициях.
            Random rnd = new Random();
            Console.Write("введите длину массива: ");
            int len = Int32.Parse(Console.ReadLine());
            List<int> l = new List<int>();
            int sum = 0;
            for (int i = 0; i < len; i++)
            {
                l.Add(rnd.Next(100));
                if (i % 2 == 0)
                    sum += l[i];
            }          
            
            int m=l.Where(x => !x.Equals(l.Max())).Max();
            int ind = l.IndexOf(m);
            
            Console.WriteLine("Сумма элементов на четных позициях = {0}", sum);
            Console.WriteLine("Позиция и значение элемента, яв-ся вторым макс.значением в коллекции: {0} и {1}", ind, m);
        }

        public static void Exmpl02()
        {
            //2.	Удалить все нечетные элементы списка List<int>
            Random rnd = new Random();
            Console.Write("введите длину массива: ");
            int len = Int32.Parse(Console.ReadLine());
            List<int> l = new List<int>();
            List<int> tmp = new List<int>();
            for (int i = 0; i < len; i++)
            {
                l.Add(rnd.Next(100));
                if (i % 2 == 0)
                    tmp.Add(l[i]);
                Console.WriteLine(l[i]);
            }

            l.Clear();
            l = tmp;
            Console.WriteLine("-----------------");
            foreach (int item in l)
            {
                Console.WriteLine(item);
            }
        }

        public static void Exmpl03()
        {
            //3.	Дана коллекция типа List<double>. Вывести на экран элементы списка, значение которых больше среднего арифметического всех элементов коллекции.
            Random rnd = new Random();
            Console.Write("введите длину массива: ");
            int len = Int32.Parse(Console.ReadLine());
            List<int> l = new List<int>();
            for (int i = 0; i < len; i++)
            {
                l.Add(rnd.Next(100));
                Console.WriteLine(l[i]);
            }
            Console.WriteLine("--------------------");
            foreach (int i in l)
            {
                if (i>l.Average())
                    Console.WriteLine(i);
            } 
        }

        public static void Exmpl04()
        {
            //4.	Напечатать содержимое текстового файла t, выписывая литеры каждой его строки в обратном порядке.
            string file = @"text.txt";
            string str;
            using (StreamReader sr=new StreamReader(file))
            {
                str = sr.ReadToEnd();
                sr.Close();
            }
            var tmp = str.ToCharArray().Reverse();
            foreach (char i in tmp)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }

        public static void Exmpl05()
        {
            //5.	Даны 2 строки s1 и s2. Из каждой можно читать по одному символу. Выяснить, является ли строка s2 обратной s1.
            Console.Write("введите строку s1: ");
            string s1 = Console.ReadLine();
            Console.Write("введите строку s2: ");
            string s2 = Console.ReadLine();
            char[] arr = s2.ToCharArray();
            Array.Reverse(arr);
            string tmp = new string(arr);
            Console.WriteLine("Является ли строка s2 обратной s1? {0}", s1==tmp);
        }

        public static void Exmpl06()
        {
            //6.	Дан текстовый файл. За один просмотр файла напечатать элементы файла в следующем порядке: 
            //сначала все слова, начинающиеся на гласную букву, потом все слова, начинающиеся на согласную букву, сохраняя исходный порядок в каждой группе слов.

            string file = @"text.txt";
            string str;
            using (StreamReader sr=new StreamReader(file))
            {
                str = sr.ReadToEnd();
                sr.Close();
            }
            
            string[] tmp = str.Split(' ');
            var s1 = tmp.Where(x => IsVowel(x[0])).ToList();            
            foreach (string i in s1)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();
            Console.WriteLine();
            var s2= tmp.Where(x => !IsVowel(x[0])).ToList();
            foreach (string i in s2)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();
        }

        public static bool IsVowel(char ch)
        {
            return (ch == 'а' || ch == 'е' || ch == 'и' || ch == 'о' || ch == 'у' || ch == 'ы' || ch == 'э' || ch == 'ю' || ch == 'я' || ch == 'ё');
        }

        public static void Exmpl07()
        {
            //7.	Дан файл, содержащий числа. За один просмотр файла напечатать элементы файла в следующем порядке: сначала все положительные числа, 
            //потом все отрицательные числа, сохраняя исходный порядок в каждой группе чисел.
            Random rnd = new Random();
            string writePath = @"numbers.txt";
            using (StreamWriter sw=new StreamWriter(writePath))
            {
                for (int i = 0; i < 20; i++)
                {
                    sw.WriteLine(rnd.Next(-100,100));
                }
                sw.Close();
            }

            
            string readPath= @"numbers.txt";
            string str;
            using (StreamReader sr=new StreamReader(readPath))
            {
                str = sr.ReadToEnd();
                sr.Close();
            }

            string[] tmp = str.Split('\n');
            List<int> num = new List<int>();
            foreach (string i in tmp)
            {
                int x;
                if (int.TryParse(i, out x))
                    num.Add(x);
            }

            Console.WriteLine("Положительные числа:");
            foreach (int i in num.Where(x=>x>=0))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Отрицательные числа:");
            foreach (int i in num.Where(x=>x<0))
            {
                Console.WriteLine(i);
            }
        }
    }
}
