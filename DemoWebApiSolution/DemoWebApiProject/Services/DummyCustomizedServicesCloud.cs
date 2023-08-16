namespace DemoWebApiProject.Services
{
    public class DummyCustomizedServicesCloud : IDummyCustomizedServices
    {
        private string _dummyMailTo = "sachielsc@gmail.com";
        private string _dummyMailFrom = "noreply@mycompany.com";

        public void Send(string subject, string content)
        {
            // mimic the sending operation: output to console
            Console.WriteLine($"Mail from {_dummyMailFrom} to {_dummyMailTo},\n"
                + $"with the customized service: {nameof(DummyCustomizedServicesCloud)}.");
            Console.WriteLine($"The subject is {subject}.");
            Console.WriteLine($"The mail content is {content}.");
        }
    }
}
