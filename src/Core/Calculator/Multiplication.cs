namespace Core
{
    public class Multiplication : BaseCalculation, ICalculation
    {
        public decimal Calculate()
        {
            return X * Y;
        }
    }
}