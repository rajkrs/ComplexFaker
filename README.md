# ComplexFaker is fake data generator for complex model.
Works with IEnumerable, List, Array and Dictionary. Based on GenFu.

Nuget Package:
	Install-Package ComplexFaker

Example:

            IFakeDataService faker = new FakeDataService();

            //Generate Simple obj
            var obj1 = faker.Generate<ChargeSummaryDto>();

            //Generate List of simple obj with default array length 2.
            var obj2 = faker.Generate<List<ChargeSummaryDto>>();

            //Generate Simple obj user defined array length 5.
            var obj3 = faker.Generate<List<ChargeSummaryDto>>(5);

            //Generate Complex list with default array length 2.
            var obj4 = faker.GenerateComplex<List<ChargeSummaryDto>>();

            //Generate Complex list with user defined array length 5.
            var obj5 = faker.GenerateComplex<List<ChargeSummaryDto>>(5);
