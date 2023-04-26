using Maphuong;
using System;
using System.Numerics;

namespace Maphuong

{
    public class Program
    {
        static void Main(string[] args)
        {
            lab:
            Console.Write("Nhap kich co cua ma phuong (n * n): ");
            int n = int.Parse(Console.ReadLine());
            int[,] Maphuong = new int[n,n];
           
            if (n%2 != 0) 
            {
                Maphuong = GiaiMaphuong.Type1(Maphuong, n);
            }
            else if  (n%4 ==0)
            {
                Maphuong = GiaiMaphuong.Type2(Maphuong, n);
            }
            else
            {
                Maphuong = GiaiMaphuong.Type3(Maphuong, n);
            }


            Console.WriteLine("------------------------------------------------");
            Console.Beep();
            GiaiMaphuong.Print(Maphuong);
            Console.WriteLine("------------------------------------------------");
            
            Console.WriteLine("Nhap lai? (Y)");
            char x = char.Parse(Console.ReadLine());
            if (x == 'y')
            {
                Console.Clear();
                goto lab;
            }
            else
            {
                Console.WriteLine("Hajimemashita onegaishimasu");
            }
        }
    }
}