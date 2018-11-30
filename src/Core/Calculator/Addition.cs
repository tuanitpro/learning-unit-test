namespace Core
{
    public class Addition : BaseCalculation, ICalculation
    {
        public decimal Calculate()
        {
            return X + Y;
        }
    }
}