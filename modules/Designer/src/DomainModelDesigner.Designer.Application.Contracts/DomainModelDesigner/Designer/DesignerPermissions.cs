namespace DomainModelDesigner.Designer
{
    public class DesignerPermissions
    {
        public const string GroupName = "Designer";

        public static string[] GetAll()
        {
            return new[]
            {
                GroupName
            };
        }
    }
}