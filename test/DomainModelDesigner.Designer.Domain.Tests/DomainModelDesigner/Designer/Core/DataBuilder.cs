//using DomainModelDesigner.Designer.EntityDtos;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace DomainModelDesigner.Designer
//{
//    public class DataBuilder
//    {
//        public static CreateAppEDto Build_CreateAppEDto()
//        {
//            return new CreateAppEDto() {
//                AppName= "test_" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "").Replace(":", "").Replace(" ", ""),
//                Domains=new List<CreateAppEDtoDetails>() {
//                    new CreateAppEDtoDetails(){
//                        DomainName="domain_1",
//                        Remark="remark_1"
//                    }
//                }
//            };
//        }
//    }
//}
