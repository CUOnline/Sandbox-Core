﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SandboxCore.Clients
{
    public abstract class ClientBase : HttpClientWrapperBase
    {
        protected string ApiController;
        protected string ApiPath;

        protected ClientBase(string apiController, IConfiguration configuration) : base (configuration)
        {
            ApiController = apiController;
        }

        public async Task<IEnumerable<T>> GetAll<T>()
        {
            return await ExecuteGet<IEnumerable<T>>(ApiController);
        }

        public async Task<T> Get<T>(int modelId)
        {
            ApiPath = ApiController + "/" + modelId;
            return await ExecuteGet<T>(ApiPath);
        }
    }
}