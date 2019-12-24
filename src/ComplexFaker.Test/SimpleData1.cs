using ComplexFaker.ConsoleDemo.Models;
using System;
using Xunit;

namespace ComplexFaker.Test
{

     
    public class SimpleData
    {
        [Fact]
        public void GenerateSimple()
        {
            IFakeDataService faker = new FakeDataService();
            //Generate Simple obj
            var obj1 = faker.Generate<ChargeSummaryDto>();

            Assert.Equal(obj1.DateOfService, DateTime.Now);

        }



        [Fact]
        public void GenerateComplex()
        {
            IFakeDataService faker = new FakeDataService();
            //Generate Simple obj
            var obj1 = faker.GenerateComplex<ChargeSummaryDto>();

            Assert.Equal(2, obj1.ChargeInfoList.Count );

        }


    }
}
