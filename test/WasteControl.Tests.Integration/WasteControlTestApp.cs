using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WasteControl.Tests.Integration
{
    internal sealed class WasteControlTestApp : WebApplicationFactory<Program>
    {
        public HttpClient Client { get; }

        public WasteControlTestApp()
        {
            Client = base.WithWebHostBuilder(builder => 
            {
                builder.UseEnvironment("Integration");
            }).CreateClient();
        }

        
    }
}