using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication12
{
    public class Element
    {
        public int x;
        public Element next;
        public Element pred;
        public Element()
        {
            x = 6;
            next = null;
            pred = null;
        }
    }
    class Circle
    {
        public Element first;
        public Circle()
        {
             first = new Element();
            first.next = first;
           first.pred = first;
        
        }
        /*public void Add(int k)//добавление после первого элемента
        {
            Element temp = new Element();
            temp.x = k;
            temp.next = first.next;
            first.next.pred = temp;
            first.next = temp;
            temp.pred = first;
        }*/
        public void Add(int k)
        {
            Element temp = new Element();
            temp.x = k;
            temp.pred = first.pred.next;
            temp.next = first;
            first.pred.next = temp;
            first.pred = temp;
        }
        public void Peremest(int k)//перемещаем указатель по часовой стрелке, то есть вправо
        {
            Element temp;
            if (k < 0) return;
            for (int i = 1; i <= k; i++)
            {
                temp = first;
                first = first.next;
                first.pred = temp;
            }
        }
        public void Peremest_back(int k)//перемещаем указатель против часовой стрелки
        {
            if (k < 0) return;
            for (int i = 1; i <= k; i++)
            {
                first = first.pred;
            }
        }
        public void Delete(int k)
        {
            Peremest(k);
            Print();
            Element temp = first.next;
            Console.WriteLine(first.x);
            first.pred.next = first.next;
            first.next.pred = first.pred;
            first = temp;
        }
        public void Print()
        {
            Element temp = first;
            do
            {
                Console.WriteLine(temp.x);
                temp = temp.next;
            } while (temp != first);//распечатаем сначала все а потом узнаем конец ли это,а если сделать вначале while то оно проверит что конец и не распечатает последний элемент кольца
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Circle a = new Circle();
            a.Print();
            a.Add(7);
            a.Add(35);
            a.Add(36);
            a.Print();
            //a.Peremest_back(5);
            //a.Print();
            a.Delete(3);
            Console.WriteLine();
             a.Print();
                Console.ReadKey();
        }
    }
}
