using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{


    class Student
    {
        string name;
        public Student(string name)
        {
            this.name = name;
        }
    }
    class Program
    {
        public static void Change(object a,NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        Pastry newPastry = e.NewItems[0] as Pastry;
                        Console.WriteLine("Add object: " );
                        newPastry.Type();
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        Pastry oldPastry = e.OldItems[0] as Pastry;
                        Console.WriteLine("Del object: ");
                        oldPastry.Type();
                        break;
                    }
            }
        }

        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();
            Student student = new Student("Vitalya");
            Random rand = new Random();

            Console.WriteLine("Задание 1:");
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                arrayList.Add(rand.Next(0,100));
            }

            arrayList.Add("string");
            arrayList.Add(student);

            foreach(object i in arrayList)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            arrayList.RemoveAt(2);

            foreach (object i in arrayList)
            {
                
                Console.WriteLine(i);
            }
            Console.WriteLine();
            Console.WriteLine("Кол-во элементов:"+arrayList.Count);

            if (arrayList.Contains("string"))
            {
                Console.WriteLine("Это значение содержится");
            }
            else
            {
                Console.WriteLine("Это значение не содержится");
            }
            Console.WriteLine();

            Console.WriteLine("Задание 2:");
            Console.WriteLine();

            Dictionary<int, string> food = new Dictionary<int, string>(5);
            food.Add(1, "banana");
            food.Add(2, "pasta");
            food.Add(3, "pizza");
            food.Add(4, "chicken");
            food.Add(5, "potato");

            foreach(KeyValuePair<int, string> keyValue in food)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }

            int q = 2;
            for(int i = 0; i < q; i++)
            {
                food.Remove(i);
            }

            food[1] = "bread";
            food[2] = "eggs";

            Stack<string> stack = new Stack<string>();
            foreach (KeyValuePair<int, string> keyValue in food)
            {
                stack.Push(keyValue.Value);
            }

            Console.WriteLine();
            foreach(string i in stack)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            if (stack.Contains("brad"))
            {
                Console.WriteLine("Этот элемент содержится");
            }
            else
            {
                Console.WriteLine("Этот элемент не содержится");
            }
            Console.WriteLine();

            Console.WriteLine("Задание 3:");
            Console.WriteLine();

            Dictionary<int, Pastry> dictionarySweets = new Dictionary<int, Pastry>();
            dictionarySweets.Add(1, new Candy() );
            dictionarySweets.Add(2, new Cookie() );
            dictionarySweets.Add(3, new Caramel() );
            dictionarySweets.Add(4, new Chocolate() );
            dictionarySweets.Add(5, new Candy() );

            foreach(KeyValuePair<int, Pastry> keyValue in dictionarySweets)
            {
                Console.Write(keyValue.Key+" - ");
                dictionarySweets[keyValue.Key].Type();
                Console.WriteLine();
            }

            for (int i = 0; i < q; i++)
            {
                dictionarySweets.Remove(i);
            }

            dictionarySweets[1] = new Caramel() ;
            dictionarySweets[2] = new Chocolate() ;

            Stack<Pastry> stackSweets = new Stack<Pastry>();
            foreach (KeyValuePair<int, Pastry> keyValue in dictionarySweets)
            {
                stackSweets.Push(dictionarySweets[keyValue.Key]);
            }

            Console.WriteLine();
            foreach (Pastry i in stackSweets)
            {
                i.Type();
            }
            Console.WriteLine();

            if (stackSweets.Contains(dictionarySweets[1]))
            {
                Console.WriteLine("Этот элемент содержится");
            }
            else
            {
                Console.WriteLine("Этот элемент не содержится");
            }
            Console.WriteLine();

            Console.WriteLine("Задание 4:");
            Console.WriteLine();

            ObservableCollection<Pastry> pastries = new ObservableCollection<Pastry>();
            pastries.CollectionChanged += Change;
            pastries.Add(new Candy());
            pastries.Add(new Cookie());
            pastries.RemoveAt(1);
        }
    }
}
