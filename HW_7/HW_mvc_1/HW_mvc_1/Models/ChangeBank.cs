namespace HW_mvc_1.Models
{
    public class ChangeBank
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal Amount { get; set; }
        public decimal Result { get; set; }
    }

}
