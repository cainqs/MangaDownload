using MangeDownload.Models;
using Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Services
{
    public class RabbitMQService
    {
        static bool isLocal = false;
        //Connection
        static IConnection Connection;
        //Channel
        static IModel Channel;

        public static object JsonConvertEncoding { get; private set; }

        static RabbitMQService()
        {
            ConnectionFactory factory = new();

            if (isLocal)
            {
                factory.HostName = "localhost";
                factory.UserName = "admin";
                factory.Password = "admin";
                factory.Port = 21006;
                //factory.VirtualHost = "mangarabbitmq";
            }
            else
            {
                factory.HostName = "mangarabbitmq";
                factory.UserName = "admin";
                factory.Password = "admin";
                factory.Port = 5672;
                //factory.VirtualHost = "mangarabbitmq";
            }

            Connection = factory.CreateConnection();
            Channel = Connection.CreateModel();
        }

        public static bool PublishMessageToServer(string queueName, string message)
        {
            try
            {
                bool durable = true;
                Channel.QueueDeclare(queueName, durable, false, false, null);

                var messageBody = Encoding.UTF8.GetBytes(message);
                Channel.BasicPublish("", queueName, null, messageBody);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
