//using DomainModelDesigner.Designer.Dtos;
//using DomainModelDesigner.Designer.ValueObjects;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;
//using System.Threading.Tasks;

//namespace DomainModelDesigner.Designer
//{
//    public class DataBuilder
//    {
//        public static CreateAppInputDto Build_CreateAppInputDto()
//        {
//            return new CreateAppInputDto() {
//                Name="test_"+System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-","").Replace(":","").Replace(" ",""),
//                Domains=new List<DomainDto>() {
//                    new DomainDto(){
//                         DomainName="Domain1",
//                         Remark="Domain1_Remark"
//                    }
//                }
//            };
//        }

//        public static CreateValueObjectInputDto Build_CreateValueObjectInputDto(Guid domainId)
//        {
//            return new CreateValueObjectInputDto() {
//                 DomainId= domainId,
//                 Name= "test_" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", "").Replace(" ", ""),
//                 Desc="remark_1",
//                Fields =new List<FieldDto>() {
//                    new FieldDto(){
//                        FieldDescription="价格",
//                        FieldLen="(20,4)",
//                        FieldName="Price",
//                        FieldTypeId= FieldTypeEnum.DECIMAL.Id.ToString(),
//                        IsConstructorParameter=true,
//                        IsMultiple=false
//                    }
//                 }
//            };
//        }

//        public static async Task<T> BuildAsync<T>(string fileName) where T:class
//        {
//            var pth =Path.Combine(Directory.GetCurrentDirectory(), 
//                "DomainModelDesigner", "Designer","TestDatas", fileName);

//            var json=await System.IO.File.ReadAllTextAsync(pth);

//            return JsonConvert.DeserializeObject<T>(json);
//        }
//    }
//}
