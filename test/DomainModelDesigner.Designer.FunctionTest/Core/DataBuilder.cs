using DomainModelDesigner.Designer.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelDesigner.Designer.FunctionTest.Core
{
    public class DataBuilder
    {
        public static async Task<T> BuildAsync<T>(string fileName) where T:class
        {
            var pth =Path.Combine(Directory.GetCurrentDirectory(), "TestDatas", fileName);

            var json=await System.IO.File.ReadAllTextAsync(pth);

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
