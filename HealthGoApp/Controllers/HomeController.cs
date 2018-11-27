using HealthGoApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthGoApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        [HttpPost]
        public ActionResult CalculateCost(CustomerModel objCustomerModel)
        {
            CostModel objCostModel = new CostModel();


            //int x = 1;
            //int y = 2;
            objCostModel.FullName = objCustomerModel.Name;
            string progToRun = "C:/Research/Healthcare_Cost_Predictor.py";
            double _heightMtr = (objCustomerModel.Hight) / 100;
            double height_sqr = _heightMtr * _heightMtr;
            int calculate_bmi =Convert.ToInt32(objCustomerModel.Weight / height_sqr);
            objCostModel.BmiFloat = calculate_bmi;
            int getAge=Convert.ToInt32(objCustomerModel.Age);

            Process proc = new Process();
            proc.StartInfo.FileName = "C:/Users/rruhela1/AppData/Local/Programs/Python/Python37/python.exe";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;

            // call hello.py to concatenate passed parameters
            proc.StartInfo.Arguments = string.Concat(progToRun, " ", getAge, " ", calculate_bmi, " ", objCustomerModel.SelectTabacoAdict);
            proc.Start();

            StreamReader sReader = proc.StandardOutput;
            //char[] splitter = null;
            char[] spliter = { '\r' };
            string[] output = sReader.ReadToEnd().Split(spliter);
            //objCalcModel.add = Convert.ToInt32(output[0]);
            string tt = output[1].Replace("\n", ""); ;
            double insurancecost_double = Convert.ToDouble(tt);
            objCostModel.TotalInsuranceCost = Math.Round(insurancecost_double, 2); 
            objCostModel.InsuranceCost = tt;
          

            return Json(objCostModel, JsonRequestBehavior.AllowGet);

        }





        [HttpGet]
        public ActionResult HealthCostPredict2(int age, int bmi, int smoke)
        {
            CostModel objCostModel = new CostModel();


            //int x = 1;
            //int y = 2;
            string progToRun = "C:/Research/Healthcare_Cost_Predictor.py";


            Process proc = new Process();
            proc.StartInfo.FileName = "C:/Users/rruhela1/AppData/Local/Programs/Python/Python37/python.exe";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;

            // call hello.py to concatenate passed parameters
            proc.StartInfo.Arguments = string.Concat(progToRun, " ", age, " ", bmi, " ", smoke);
            proc.Start();

            StreamReader sReader = proc.StandardOutput;
            //char[] splitter = null;
            char[] spliter = { '\r' };
            string[] output = sReader.ReadToEnd().Split(spliter);
            //objCalcModel.add = Convert.ToInt32(output[0]);
            string tt = output[1].Replace("\n", ""); ;

            objCostModel.InsuranceCost = tt;
            objCostModel.FullName = tt;
            objCostModel.Bmi = tt;

            return Json(objCostModel, JsonRequestBehavior.AllowGet);

        }
    }
}