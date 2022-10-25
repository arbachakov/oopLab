using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
     public class Cheque
     {
         private string _chequeBody;

         private double _cost;

         private double _discountedCost;

         private double _benefit;

         public Cheque(string chequeBody, double cost, 
             double discountedCost, double benefit)
         {
             ChequeBody = chequeBody;
             Cost = cost;
             DiscountedCost = discountedCost;
             Benefit = benefit;
         }
         public string ChequeBody
         {
             get => _chequeBody;
             set
             {
                 CheckChequeBody(value);
                 _chequeBody = value;
             }
         }

         public double Cost
         {
             get => _cost;
             set
             {
                 CheckValue(value);
                 _cost = value;
             }
         }

         public double DiscountedCost
         {
             get => _cost;
             set
             {
                 CheckValue(value);
                 _cost = value;
             }
         }

         public double Benefit
        {
             get => _benefit;
             set
             {
                 CheckValue(value);
                _benefit = value;
             }
         }

        private bool CheckChequeBody(string name)
         {
             if (name == "")
             {
                 throw new Exception("The body of cheque is not specified");
             }

             return true;
         }

        private bool CheckValue(double value)
        {
            if (value < 0)
            {
                throw new Exception
                ("This value " +
                 "cannot be less than 0");
            }

            return true;
        }

    }
}
