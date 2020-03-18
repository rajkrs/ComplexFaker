using System;
using System.Collections.Generic;
using System.Text;

namespace ComplexFaker.ConsoleDemo.Models
{



    public class OrderSummaryDto
    {
        public string CompanyCode { get; set; }
        public int[] ProductIds { get; set; }
        public DateTime? DateOfService { get; set; }
        public decimal? Order_amount { get; set; }
        public OrderDetailsDto OrderInfo { get; set; }
        public List<OrderDetailsDto> OrderInfoList { get; set; }
        public Dictionary<decimal, OrderDetailsDto> OrderDictionary { get; set; }

    }

    public class OrderDetailsDto
    {
        public string OrderCode { get; set; }
        public int Units { get; set; }
        public OrderNameDto OrderName { get; set; }

    }



    public class OrderNameDto
    {
        public string FullName { get; set; }
        public OrderNameCodes NameCodes { get; set; }
    }

    public class OrderNameCodes
    {
        public List<OrderNameCodeData> Codes { get; set; }
    }


    public class OrderNameCodeData
    {
        public int Id { get; set; }
        public string CodeInfo { get; set; }
    }


    public class GenericResponse<T>
    {
        public T Data { get; set; }
        public int DataId { get; set; }
    }

}
