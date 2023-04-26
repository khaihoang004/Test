using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maphuong
{
    class GiaiMaphuong
    {
        public static void Print(int[,] Matrix)
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write("{0,-3}{1,-1}", Matrix[i, j], "|");
                }
                Console.WriteLine();
            }
        }
        public static int[,] Type1(int[,] Matrix, int n)
        {
            

            //Hang cheo chinh
            for (int i = 0; i < n; i++)
            {
                Matrix[n - 1 - i, i] = (n * (n - 1) / 2 + 1) + i;
            }

            //Hang cheo ngay lien ben phai hang cheo chinh
            for (int i = 1; i < n; i++)
            {
                Matrix[n - i, i] = (i + (n + 1) / 2) % n;
                Matrix[(n + 1) / 2, (n - 1) / 2] = n;
            }

            //Nua duoi hang cheo chinh
            for (int k = n + 1; k < 2 * n - 1; k++)
            {
                for (int i = k - n + 1; i < n; i++)
                {
                    Matrix[i, k - i] = Matrix[i - 1, k - i - 1] + n;
                }
            }

            //Phan con lai
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    Matrix[i, j] = n * n + 1 - Matrix[n - 1 - i, n - j - 1];
                }
            }
            return Matrix;
        }

        public static int[,] Type2(int[,] Matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j % n < n/4 || j % n >= 3*n / 4)
                    {
                        Matrix[i, j] = i * n + j + 1;
                    }
                    else
                    {
                        Matrix[i, j] = (n - i) * n - j - 1;
                    }
                }
            }

            return Matrix;
        }


        public static void LTypeFill(int[,] Matrix, int i, int j)
        {
            Matrix[i, j+1] = Matrix[i, j]-3 ;
            Matrix[i+1, j] = Matrix[i, j]-2;
            Matrix[i+1, j+1] = Matrix[i, j]-1;
        }
        public static void UTypeFill(int[,] Matrix, int i, int j)
        {
            Matrix[i, j + 1] = Matrix[i, j];
            Matrix[i + 1, j] = Matrix[i, j] - 2;
            Matrix[i + 1, j + 1] = Matrix[i, j] - 1;
            Matrix[i, j] = Matrix[i, j + 1] - 3;

        }
        public static void XTypeFill(int[,] Matrix, int i, int j)
        {
            Matrix[i, j + 1] = Matrix[i, j];
            Matrix[i + 1, j] = Matrix[i, j]-1;
            Matrix[i + 1, j + 1] = Matrix[i, j]-2;
            Matrix[i, j] = Matrix[i, j + 1] - 3;
        }
        public static int[,] Type3(int[,] Matrix, int n)
        {
            //Cach 1: Giai bai toan dang 2n+1 sau do nhan 4 len dua vao cac o M[2i,2j], sau do dung cac cach Fill de dien vao cac o con lai cua moi o vuong 2 * 2

            int n0 = (n - 2) / 4;
            Matrix = Type1(Matrix, 2*n0+1);

            for (int i = 2*n0; i >= 0; i--)
            {
                for (int j = 2*n0; j >= 0; j--)
                {
                    Matrix[2 * i, 2 * j] = 4*Matrix[i, j];
                }
            }


            for (int i = 0; i < n0 + 1; i++)
            {
                for (int j = 0; j < 2 * n0 + 1; j++)
                {
                    GiaiMaphuong.LTypeFill(Matrix, 2 * i, 2 * j);
                }
            }

            for (int i = n0+1; i < 2*n0 ; i++)
            {
                for (int j = 0; j < 2 * n0 + 1; j++)
                {
                    GiaiMaphuong.XTypeFill(Matrix, 2 * i, 2 * j);
                }
            }

            {
                int i = 2 * n0;

                for (int j = 0; j < 2 * n0 + 1; j++)
                {
                    GiaiMaphuong.UTypeFill(Matrix, 2 * i, 2 * j);
                }
            }


            //Cach 2: Sap xep cac so lan luot tu 1 den (2n+1)^2 vao cac o M[2i,2j], dung cac cach Fill de dien vao cac o con lai moi o vuong 2* 2 

            return Matrix;
        }
        
    }
}