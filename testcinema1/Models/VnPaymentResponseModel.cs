namespace testcinema1.Models
{
    public class VnPaymentResponseModel
    {
        public bool Success { get; set; }
        public string PaymentMethod { get; set; }
        public string OrderDescription { get; set; }
        public string OrderId { get; set; }
        public string PaymentId { get; set; }
        public string TransactionId { get; set; }
        public string Token { get; set; }
        public string VnPayResponseCode { get; set; }
    }

    public class VnPaymentRequestModel
    {
        public int OrderId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    //tu them vao de test
    //public class PaymentDetails
    //{
    //    public double Amount { get; set; }
    //    public string TxtCardName { get; set; }
    //    public string TxtEmail { get; set; }
    //    public string TxtCustPhone { get; set; }
    //}
}
