
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DomainModelDesigner.Designer
{
    public class DesignerPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var moduleGroup = context.AddGroup(DesignerPermissions.GroupName, L("Permission:Designer"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DefaultResource>(name);
        }
    }
}