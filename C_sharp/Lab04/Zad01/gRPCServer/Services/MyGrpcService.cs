using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRPCServer
{
    public class MyGrpcService: GrpcService.GrpcServiceBase
    {
        public override Task<GrpcResponse> GrpcProc(GrpcRequest request, ServerCallContext context)
        {
            string msg;
            int val;
            val = request.Age * 12 * 365;
            msg = $"Hello {request.Name} being {request.Age} years old.";
            Console.WriteLine(msg);
            return Task.FromResult(new GrpcResponse { Message = msg, Days = val });
        }

        public override Task<BMIResponse> CalculateBMI(BMIRequest request, ServerCallContext ctx)
        {
            float mass = request.Mass;
            int height = request.Height;
            float meters = (float)height / 100;
            float bmi = mass / (meters * meters);
            Console.WriteLine($"Mass: {mass}\nHeight: {height}\nBMI: {bmi}");
            string description = "W normie";
            if(bmi < 18.5)
            {
                description = "Niedowaga";
            }
            else if(bmi > 24.5)
            {
                description = "Nadwaga";
            }
            return Task.FromResult(new BMIResponse { Bmi = bmi, Description = description });
        }

        public override Task<TriangleResponse> TriangleArea(TriangleRequest request, ServerCallContext ctx)
        {
            float x1 = request.X1;
            float y1 = request.Y1;
            float x2 = request.X2;
            float y2 = request.Y2;
            Console.WriteLine($"Point 1: ({x1}, {y1}");
            Console.WriteLine($"Point 2: ({x2}, {y2}");
            float area = 0.5f * Math.Abs(x1 * y2 - x2 * y1);
            Console.WriteLine($"Area: {area}");
            return Task.FromResult(new TriangleResponse { Area = area });
        }

    }
}
