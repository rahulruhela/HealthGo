using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthGoApp.Models
{
    public class CostModel
    {
        public string InsuranceCost { get; set; }
        public double TotalInsuranceCost { get; set; }
        public string Bmi { get; set; }
        public double BmiFloat { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }


    public class CustomerModel
    {
        public string Name { get; set; }
        public string YearlyIncome { get; set; }
        public int Age { get; set; }
        public string Zipcode { get; set; }
        public double Hight { get; set; }
        public double Weight { get; set; }    
        public int gender { get; set; }
        public int SelectTabacoAdict { get; set; }
    }

}