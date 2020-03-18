
ComplexFaker
==========

ComplexFaker is fake data generator for complex model.
----------
> 
> [Get the NuGet Package: Install-Package ComplexFaker][1]
> 
### Generate fake/bogus/dummy/junk data for .NET POCO.

> Support for IEnumerable, List, Array and Dictionary.
> Based on GenFu.


```c#
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
	
	//Generate Complex.
        var obj6 = faker.GenerateComplex<OrderSummaryDto>();
```        

[Running Demo on dotnetfiddle][2]

[1]: https://nuget.org/packages/ComplexFaker/   "Get the NuGet Package: Install-Package ComplexFaker"
[2]: https://dotnetfiddle.net/a8KKQy   "Running Demo on dotnetfiddle"
