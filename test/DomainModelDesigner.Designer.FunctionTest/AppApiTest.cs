using DomainModelDesigner.Designer.Dtos;
using DomainModelDesigner.Designer.FunctionTest.Core;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DomainModelDesigner.Designer.FunctionTest
{
    public class AppApiTest
    {
        [Fact]
        public async Task CreateAsync_Result_ShouleNotBe_EmptyGuid()
        {
            var api = "/api/app/create";

            var dto =await DataBuilder.BuildAsync<CreateAppInputDto>("CreateAppInputDto.json");

            var response=await TestHelper.Execute<CreateAppInputDto>(api, dto);

            var result=await response.Content.ReadAsStringAsync();

            Assert.NotEqual(result.ToLower(), Guid.Empty.ToString().ToLower());
        }
    }
}
