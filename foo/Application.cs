using foo;

public class CaptureCommandHandler 
{
    public string ShipmentDetail { get; set; }
    public string OrderDetail { get; set; }

    public ICaptureRepository _catureRepository { get; set; }
    public IPaymentRepository _paymentRepository { get; set; }

    public CaptureCommandHandler(ICaptureRepository captureRepository, IPaymentRepository paymentRepository)
    {
        _catureRepository = captureRepository;
        _paymentRepository = paymentRepository;
    }

    public void Handle()
    {
        Capture capture = new(_catureRepository, _paymentRepository);
        capture.GetLinkedCapturePayment(ShipmentDetail, OrderDetail);
        // Call or send msg to call a Capture API
        // If it is called from here call capture.Post()
    }
}

