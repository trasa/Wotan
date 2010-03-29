using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;

namespace Microsoft.ServiceModel.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Uri("http://localhost:5555/Service");
            var selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);
            try
            {
                selfHost.AddServiceEndpoint(
                    typeof(ICalculator),
                    new WSHttpBinding(),
                    "CalculatorService");

                var smb = new ServiceMetadataBehavior {HttpGetEnabled = true};
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();
            }
            catch (CommunicationException ex)
            {
                selfHost.Abort();
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
            
        }
    }
}