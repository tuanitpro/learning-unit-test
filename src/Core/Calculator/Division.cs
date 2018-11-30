namespace Core
{
    public class Division : BaseCalculation, ICalculation
    {
        public decimal Calculate()
        {
            return X / Y;
        }
    }
}