using System;
using System.Collections.Generic;
using System.Text;

namespace ComplexFaker.ConsoleDemo.Models
{

    public class ChargeSummaryDto
    {
        public string CompanyCode { get; set; }
        public int[] PatientIds { get; set; }
        public DateTime? DateOfService { get; set; }
        public decimal Charge_amount { get; set; }
        public ChargeDetailsDto ChargeInfo { get; set; }
        public List<ChargeDetailsDto> ChargeInfoList { get; set; }
        public Dictionary<int ,ChargeDetailsDto> ChargeDictionary { get; set; }

    }

    public class ChargeDetailsDto
    {
        public string ChargeCode { get; set; }
        public int Units { get; set; }
        public ChargeNameDto ChargeName { get; set; }

    }



    public class ChargeNameDto
    {
        public string FullName { get; set; }
        public ChargeNameCodes NameCodes { get; set; }
    }

    public class ChargeNameCodes
    {
        public List<ChargeNameCodeData> Codes { get; set; }
    }


    public class ChargeNameCodeData
    {
        public int Id { get; set; }
        public string CodeInfo { get; set; }
    }


}
