﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first, second, third;
            int per, vtor, tret;

            // Функция для чтения и проверки введенного значения стороны треугольника
            int ReadAndValidate(string storonName)
            {
                int side;
                int storona;
                do
                {
                    Console.Write($"Введите значение {storonName} стороны: ");
                    if (!int.TryParse(Console.ReadLine(), out storona) || storona < 1)
                    {
                        Console.WriteLine("Введено некорректное значение. Пожалуйста, введите число больше нуля.");
                    }
                }
                while (storona < 1);
                return storona;
            }


            // Проверка подходит ли для треугольника значения всех трёх сторон
            bool IfValuesTrue(int a, int b, int c)
            {
                return (a + b > c) && (a + c > b) && (b + c > a);
            }

            try
            {
                per = ReadAndValidate("первой");
                vtor = ReadAndValidate("второй");
                tret = ReadAndValidate("третьей");

                if (!IfValuesTrue(per, vtor, tret))
                {
                    Console.WriteLine("Треугольник с такими сторонами не существует.");
                    return;
                }

                // Функция расчета углов треугольника
                double AgleFunc(int a, int b, int c)
                {
                    // Используем формулу по теореме косинусов
                    return Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c)) * (180 / Math.PI);
                }

                double yglA = AgleFunc(per, vtor, tret);
                double yglB = AgleFunc(vtor, tret, per);
                double yglC = AgleFunc(tret, per, vtor);

                // Проверка на тип треугольника по углам
                if (yglA == 90.0 || yglB == 90.0 || yglC == 90.0)
                {
                    Console.WriteLine("Треугольник прямоугольный.");
                }
                else if (yglA > 90.0 || yglB > 90.0 || yglC > 90.0)
                {
                    Console.WriteLine("Треугольник тупоугольный.");
                }
                else if (yglA < 90.0 && yglB < 90.0 && yglC < 90.0)
                {
                    Console.WriteLine("Треугольник остроугольный.");
                }

                // Проверка на равенство сторон треугольника
                if (per == vtor && per == tret)
                {
                    Console.WriteLine("Треугольник равносторонний.");
                }
                else if (per == vtor || per == tret || vtor == tret)
                {
                    Console.WriteLine("Треугольник равнобедренный.");
                }
                else
                {
                    Console.WriteLine("Треугольник разносторонний.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при вводе данных: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
        }
    

