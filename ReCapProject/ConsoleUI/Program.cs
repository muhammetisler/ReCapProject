﻿using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new InMemoryCarDal());

            foreach (var car in carService.GetCars())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
