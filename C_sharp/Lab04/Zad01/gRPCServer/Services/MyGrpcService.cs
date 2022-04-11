﻿using Grpc.Core;
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

    }
}
