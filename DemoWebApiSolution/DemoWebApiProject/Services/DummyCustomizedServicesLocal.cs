namespace DemoWebApiProject.Services
{
    public class DummyCustomizedServicesLocal : IDummyCustomizedServices
    {
        private readonly string _dummyMailTo;
        private readonly string _dummyMailFrom;

        public DummyCustomizedServicesLocal(IConfiguration configuration) {
            _dummyMailTo = configuration["DummyCustomizedServicesSettings:dummyMailTo"] ?? "blank recipient";
            _dummyMailFrom = configuration["DummyCustomizedServicesSettings:dummyMailFrom"] ?? "blank mail content";
        }

        public void Send(string subject, string content)
        {
            // mimic the sending operation: output to console
            Console.WriteLine($"Mail from {_dummyMailFrom} to {_dummyMailTo},\n"
                + $"with the customized service: {nameof(DummyCustomizedServicesLocal)}");
            Console.WriteLine($"The subject is: {subject}");
            Console.WriteLine($"The mail content is: {content}");
        }
    }
}
