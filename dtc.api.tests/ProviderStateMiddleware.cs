using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.String;

namespace dtc.api.tests
{
    public class ProviderStateMiddleware
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private readonly IDictionary<string, Action<IDictionary<string, string>>> providerStates;

        private readonly RequestDelegate next;

        public ProviderStateMiddleware(RequestDelegate next)
        {
            this.next = next;

            this.providerStates = new Dictionary<string, Action<IDictionary<string, string>>>
            {
                {
                    "there are events ",
                    this.InsertEventsIntoDatabase
                },
                {
                    "there is a single event",
                    this.InsertSingleEventIntoDatabase
                },
                {
                    "there is single DetailsView event",
                    this.EnsureSingleDetailsViewEventExists
                }
            };    
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(!(context.Request.Path.Value?.StartsWith("provider-states") ?? false))
            {
                await this.next.Invoke(context);
                return;
            }

            context.Response.StatusCode = (int)HttpStatusCode.OK;

            if(context.Request.Method == HttpMethods.Post.ToString())
            {
                string json;
                using(var reader = new StreamReader(context.Request.Body, Encoding.UTF8))
                {
                    json = await reader.ReadToEndAsync();
                }

                var providerState = JsonSerializer.Deserialize<ProviderState>(json, Options);

                if(!IsNullOrEmpty(providerState?.State))
                {
                    this.providerStates[providerState.State].Invoke(providerState.Params);
                }

                await context.Response.WriteAsync(Empty);
            }
        }

        private void EnsureSingleDetailsViewEventExists(IDictionary<string, string> obj)
        {
            throw new NotImplementedException();
        }

        private void InsertSingleEventIntoDatabase(IDictionary<string, string> obj)
        {
            throw new NotImplementedException();
        }

        private void InsertEventsIntoDatabase(IDictionary<string, string> obj)
        {
            throw new NotImplementedException();
        }
    }
}