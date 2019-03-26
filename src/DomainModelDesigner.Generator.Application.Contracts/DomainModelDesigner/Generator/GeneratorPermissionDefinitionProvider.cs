using DomainModelDesigner.Generator.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DomainModelDesigner.Generator
{
    public class GeneratorPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var moduleGroup = context.AddGroup(GeneratorPermissions.GroupName, L("Permission:Generator"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<GeneratorResource>(name);
        }
    }
}