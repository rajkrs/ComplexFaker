
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComplexFaker
{

    public interface IFakeDataService
    {

        T GenerateComplex<T>() where T : class, new();

        T GenerateComplex<T>(int row) where T : class, new();

        T Generate<T>() where T : class, new();

        T Generate<T>(int row) where T : class, new();

        List<string> GenerateString(int length);
        List<int> GenerateInt(int length);
        List<decimal> GenerateDecimal(int length);

    }

}
