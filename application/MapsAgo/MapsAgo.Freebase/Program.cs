using Google.Apis.Freebase.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsAgo.Freebase
{
    class Program {

        static void Main(string[] args)
        {
            Console.WriteLine("Freebase API Sample");
            Console.WriteLine("====================");

            // Create the service.
            var service = new FreebaseService(new FreebaseService.Initializer
            {
                ApplicationName = "Freebase Sample",
                ApiKey = "AIzaSyAq8f-ZUQUre00arIXI5hDl41XjaSPFqVI",
            });

            String query = "[{\"id\":null,\"name\":null,\"type\":\"/astronomy/planet\"}]";
            var resquest = service.Search();
            ServiceRequest request = service.Search();
            string response = request.Fetch();
            Console.WriteLine(response);
        }
    }
}