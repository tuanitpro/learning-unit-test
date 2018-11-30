using System;

namespace Core
{
    public class Subtraction : BaseCalculation, ICalculation
    {
        public decimal Calculate()
        {
            return X - Y;
        }
    }
}