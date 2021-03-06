﻿using ComplexFaker.ConsoleDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ComplexFaker.ConsoleDemo
{
    class Program
    {


        static void Main(string[] args)
        {

            IFakeDataService faker = new FakeDataService();

            //Generate Simple obj
            var obj1 = faker.Generate<OrderSummaryDto>();

            //Generate List of simple obj with default array length 2.
            var obj2 = faker.Generate<List<OrderSummaryDto>>();

            //Generate Simple obj user defined array length 5.
            var obj3 = faker.Generate<List<OrderSummaryDto>>(5);

            //Generate Complex list with default array length 2.
            var obj4 = faker.GenerateComplex<List<OrderSummaryDto>>();

            //Generate Complex list with user defined array length 5.
            var obj5 = faker.GenerateComplex<List<OrderSummaryDto>>(5);

            //Generate complex
            var obj6 = faker.GenerateComplex<OrderSummaryDto>();

            //Generic complex
            var obj7 = faker.GenerateComplex<List<GenericResponse<OrderSummaryDto>>>();


            Console.WriteLine(JsonConvert.SerializeObject(obj1, Formatting.Indented));
            Console.WriteLine(JsonConvert.SerializeObject(obj2, Formatting.Indented));
            Console.WriteLine(JsonConvert.SerializeObject(obj3, Formatting.Indented));
            Console.WriteLine(JsonConvert.SerializeObject(obj4, Formatting.Indented));
            Console.WriteLine(JsonConvert.SerializeObject(obj5, Formatting.Indented));
            Console.WriteLine(JsonConvert.SerializeObject(obj6, Formatting.Indented));
            Console.WriteLine(JsonConvert.SerializeObject(obj7, Formatting.Indented));



            Console.WriteLine("done!");

            Console.ReadLine();
        }

    }
}
