using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BuildAzureAPIApp.Controllers
{
    [Route("api/[controller]")]
    public class MyWordsController : Controller
    {
        [HttpPost]
        public void Post()
        {
            var client = QueueClient.CreateFromConnectionString(
                "Endpoint=sb://build-mini-2015.servicebus.windows.net/;SharedAccessKeyName=PostWords;SharedAccessKey=869UEIyyqLU+BeYNL+aqFkvFaR94SuakuFdfbP7UYZ8=",
                "MyWords");

            using (MemoryStream stream = new MemoryStream())
            {
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(Request.Form["MyWords"]);
                writer.Flush();
                stream.Position = 0;
                StreamReader reader = new StreamReader(stream);

                var msg = new BrokeredMessage(reader.ReadToEnd());
                client.Send(msg);

                reader.Close();
            }
        }
    }
}
