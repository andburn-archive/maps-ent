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
                ApplicationName = "Any Old Name",
                ApiKey = "AIzaSyAq8f-ZUQUre00arIXI5hDl41XjaSPFqVI",
            });
            Console.WriteLine("BasePath: " + service.BasePath);
            Console.WriteLine("BaseUri: " + service.BaseUri);
            Console.WriteLine("Features: " + service.Features.Count);
            Console.WriteLine("Name: " + service.Name);

            FreebaseService.SearchRequest request = service.Search();
            //request.Query = "[{\"id\":null,\"name\":null,\"type\":\"/astronomy/planet\"}]";
            request.Query = args[0];
            //request.Filter = "(all type:/music/artist created:\"The Lady Killer\")";
            request.Filter = "(all type:/military/military_conflict)";
            request.Limit = 10;
            request.Indent = true;
            string response = "none";
            try
            {
                response = request.Execute();
            }
            catch (Google.GoogleApiException gae)
            {
                Console.WriteLine("Error: " + gae);
            }            
            Console.WriteLine(response);


            //var pre = new Google.Apis.Freebase.v1.FreebaseService();

            //List<string> topicsid = new List<string>();
            //topicsid.Add("/en/hugo_ayala");
            //Google.Apis.Util.Repeatable<string> t = new Google.Apis.Util.Repeatable<string>(topicsid);
            //Google.Apis.Freebase.v1.TextResource.GetRequest result = pre.Text.Get(t);
            //string res = result.Fetch().Result;


            //Console.WriteLine("Press any key to continue...");
            //Console.ReadKey();
        }
    }
}