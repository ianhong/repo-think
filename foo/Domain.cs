namespace foo;

public class Capture
{
    private readonly ICaptureRepository _captureRepository;
    private readonly IPaymentRepository _paymentRepository;

    public Capture(ICaptureRepository captureRepository, IPaymentRepository paymentRepository)
    {
        _captureRepository = captureRepository;
        _paymentRepository = paymentRepository;
    }
    public string GetLinkedCapturePayment(string shipmentDetail, string orderDetail)
    {
        // Calcuate capture amount business logic from shipmentDetail and orderDetail
        var captureAmount = "100";

        var payment = new Payment(_paymentRepository);
        var authCode = payment.RetrieveAuthCode(shipmentDetail, orderDetail);

        if(authCode == "Expired")
        {
            return "NOAUTH ERROR";
        }

        return  "LinkedCapturRequestData" + captureAmount;
    }

    public void PostCapture()
    {

    }
}

public class Payment
{
    private readonly IPaymentRepository _paymentRepository;
    public Payment(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public string RetrieveAuthCode(string shipmentDetail, string orderDetail)
    {
        /* Business Logic for
            OrderDetail + shipmentDetail -> PaymentId
        */
        var paymentDetails = _paymentRepository.GetPaymentDetail("orderId");

        // More business Logic
        // expiration date, or some other check check

        var isAuthValid = true;
        if(isAuthValid)
        {
            return "AuthCode";
        }
        return "Expired";
    }
}

public interface ICaptureRepository
{
    void Read();
    void Save(Capture settlement);
}

public interface IPaymentRepository
{
    string GetPaymentDetail(string paymentId);
    void Save(Payment payment);
}