namespace Common.Responses
{
    public class ResponsePayment
    {
        public string? ResponseCodeMessage { get; set; }
        public string? TransactionStatusMessage { get; set; }

        public VnPayResponse? VnPayResponse { get; set; }

    }
}