using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelDesigner.Designer.FunctionTest.Core
{
    public static class TestHelper
    {
        private static readonly TestServer _server = null;
        static TestHelper()
        {
            _server = CreateTestServer();
        }

        public static async Task<HttpResponseMessage> Execute<T>(string api, T obj) where T : class
        {
            using (var client = _server.CreateClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(obj), UTF8Encoding.UTF8, "application/json");

                return await client.PostAsync(api, content);
            }
        }

        #region 私有
        private static TestServer CreateTestServer()
        {
            var builder = WebHost.CreateDefaultBuilder();
            builder.UseStartup<TestStartup>();

            //指定配置文件
            builder.UseContentRoot(Directory.GetCurrentDirectory());
            builder.ConfigureAppConfiguration((builderContext, config) =>
            {
                config.AddJsonFile("appsettings.json");
            });

            return new TestServer(builder);
        }
        #endregion

    }
}
