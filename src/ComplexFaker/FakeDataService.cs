using GenFu;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace ComplexFaker.ConsoleDemo.Faker
{
    public class FakeDataService : IFakeDataService
    {

        private T GenerateFake<T>(bool isPopulateComplex = true, int row = 2) where T : class, new()
        {
            var type = typeof(T);
            var obj = Activator.CreateInstance(type);
            if (typeof(IEnumerable<object>).IsAssignableFrom(type) || type.IsArray)
            {
                Type itemType = type.IsArray ? type.GetElementType() : type.GetGenericArguments().FirstOrDefault();

                //Without complex array
                var data = A.ListOf(itemType, row);

                if (isPopulateComplex)
                {
                    //With complex array
                    data.ForEach(d =>
                    {
                        d = GenerateFakeComplexRow(d, row);
                    });
                }

                var jsonData = JsonConvert.SerializeObject(data);
                obj = JsonConvert.DeserializeObject(jsonData, type);


            }
            else
            {

                //Without complex
                obj = GenFu.GenFu.New<T>();

                if (isPopulateComplex)
                {
                    obj = GenerateFakeComplexRow<T>((T)obj, row);
                }

            }


            return (T)obj;
        }



        private T GenerateFakeComplexRow<T>(T obj, int row = 1) where T : class, new()
        {


            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                var type = propertyInfo.PropertyType;

                //Static casting
                if (typeof(IEnumerable<string>).IsAssignableFrom(type))
                {
                    var usergroups = A.ListOf<MusicArtistNameFiller>(5);
                    var strdata = usergroups.Select(o => o.GetValue("Name"));
                    var jsonData = JsonConvert.SerializeObject(strdata);
                    var convertedDataForType = JsonConvert.DeserializeObject(jsonData, type);
                    propertyInfo.SetValue(obj, convertedDataForType, null);
                }
                else if (typeof(IEnumerable<int>).IsAssignableFrom(type))
                {
                    var usergroups = A.ListOf<AgeFiller>(5);
                    var strdata = usergroups.Select(o => o.GetValue("Name"));
                    var jsonData = JsonConvert.SerializeObject(strdata);
                    var convertedDataForType = JsonConvert.DeserializeObject(jsonData, type);
                    propertyInfo.SetValue(obj, convertedDataForType, null);
                }
                else if (typeof(IEnumerable<decimal>).IsAssignableFrom(type))
                {
                    var usergroups = A.ListOf<PriceFiller>(5);
                    var strdata = usergroups.Select(o => o.GetValue("Name"));
                    var jsonData = JsonConvert.SerializeObject(strdata);
                    var convertedDataForType = JsonConvert.DeserializeObject(jsonData, type);
                    propertyInfo.SetValue(obj, convertedDataForType, null);
                }
                //User defined single object
                else if (!type.IsArray && !type.IsValueType && !type.IsPrimitive && (type.Namespace == null || !type.Namespace.StartsWith("System")))
                {

                    var data = A.New(type);
                    var jsonData = JsonConvert.SerializeObject(data);
                    var propObj = JsonConvert.DeserializeObject(jsonData, type);
                    var propData = GenerateFakeComplexRow<object>(propObj, row);

                    propertyInfo.SetValue(obj, Convert.ChangeType(propData, type), null);

                }
                else if (typeof(IEnumerable<object>).IsAssignableFrom(type) || type.IsArray)
                {
                    Type itemType = type.IsArray ? type.GetElementType() : type.GetGenericArguments().FirstOrDefault();

                    var data = A.ListOf(itemType, row);

                    data.ForEach(d =>
                    {
                        d = GenerateFakeComplexRow<object>(d, row);
                    });

                    var jsonData = JsonConvert.SerializeObject(data);
                    var propObj = JsonConvert.DeserializeObject(jsonData, type);
                    propertyInfo.SetValue(obj, Convert.ChangeType(propObj, type), null);
                }
            }
            return obj;
        }










        public T GenerateComplex<T>() where T : class, new()
        {
            return GenerateFake<T>(true, 2);
        }
        public T GenerateComplex<T>(int row = 2) where T : class, new()
        {
            return GenerateFake<T>(true, row);
        }

        public T Generate<T>() where T : class, new()
        {
            return GenerateFake<T>(false, 2);
        }

        public T Generate<T>(int row = 2) where T : class, new()
        {
            return GenerateFake<T>(false, row);
        }
        public List<string> GenerateString(int length)
        {
            var names = A.ListOf<MusicArtistNameFiller>(length);
            return names.Select(o => o.GetValue("Name").ToString()).ToList();
        }

        public List<int> GenerateInt(int length)
        {
            var ages = A.ListOf<AgeFiller>(length);
            return ages.Select(o => Convert.ToInt32(o.GetValue("Name"))).ToList();
        }

        public List<decimal> GenerateDecimal(int length)
        {
            var prices = A.ListOf<PriceFiller>(length);
            return prices.Select(o => Convert.ToDecimal(o.GetValue("Name"))).ToList();
        }
    }
}

