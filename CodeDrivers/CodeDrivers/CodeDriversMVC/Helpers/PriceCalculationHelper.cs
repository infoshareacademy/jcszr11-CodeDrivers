namespace CodeDriversMVC.Helpers
{
    public static class PriceCalculationHelper
    {
        public static decimal CalculateTotalPrice(DateTime reservationFrom,  DateTime reservationTo, decimal pricePerDay)
        {
            var numberOfDays = (reservationTo - reservationFrom).TotalDays;
            return (decimal)numberOfDays * pricePerDay;
        }
    }
}
