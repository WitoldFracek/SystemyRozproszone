using Grpc.Net.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace gRPCClient
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            Console.WriteLine("Starting gRPC Client");
            using var channel = GrpcChannel.ForAddress("https://25.77.52.172:5001",
                new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new GrpcService.GrpcServiceClient(channel);
            Console.WriteLine("Enter name: ");
            String str = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            int age = Int32.Parse(Console.ReadLine());
            var reply = await client.GrpcProcAsync(new GrpcRequest { Name = str, Age = age });

            Console.WriteLine($"From server: {reply.Message}");
            Console.WriteLine($"From server: {age} years = {reply.Days} days");
            Console.WriteLine($"Press any key to exit...");
            Console.ReadKey();
            channel.ShutdownAsync().Wait();
        }
    }
}
