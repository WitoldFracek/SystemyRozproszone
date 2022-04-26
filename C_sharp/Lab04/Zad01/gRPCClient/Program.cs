using Grpc.Net.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using InfoPresenter;

namespace gRPCClient
{
    class Program
    {
        static async Task Main(string[] args)
        {

            MyData.Info();

            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            Console.WriteLine("Starting gRPC Client");
            using var channel = GrpcChannel.ForAddress("https://localhost:5001",
                new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new GrpcService.GrpcServiceClient(channel);

            // Podstawowe zadanie
            Console.WriteLine("Enter name: ");
            String str = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            int age = Int32.Parse(Console.ReadLine());
            var reply = await client.GrpcProcAsync(new GrpcRequest { Name = str, Age = age });

            Console.WriteLine($"From server: {reply.Message}");
            Console.WriteLine($"From server: {age} years = {reply.Days} days");

            // BMI
            Console.WriteLine("Enter mass: ");
            float mass = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter height: ");
            int height = int.Parse(Console.ReadLine());
            var bmiReply = await client.CalculateBMIAsync(new BMIRequest { Mass = mass, Height = height });

            Console.WriteLine($"BMI from server: {bmiReply.Bmi}.\nDescription: {bmiReply.Description}");

            // Pole trojkata
            Console.WriteLine("Enter vector parameters v1[x1, y1] v2[x2, y2]");
            List<float> coordinates = new List<float>();
            for(int i=0; i<4; i++)
            {
                float val = float.Parse(Console.ReadLine());
                coordinates.Add(val);
            }
            var area = await client.TriangleAreaAsync(new TriangleRequest
            {
                X1 = coordinates[0],
                Y1 = coordinates[1],
                X2 = coordinates[2],
                Y2 = coordinates[3]
            });

            Console.WriteLine($"Area from server: {area.Area}");

            Console.WriteLine($"Press any key to exit...");
            Console.ReadKey();
            channel.ShutdownAsync().Wait();
        }
    }
}
