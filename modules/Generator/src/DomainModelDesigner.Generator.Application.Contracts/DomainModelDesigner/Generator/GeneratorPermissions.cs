namespace DomainModelDesigner.Generator
{
    public class GeneratorPermissions
    {
        public const string GroupName = "Generator";

        public static string[] GetAll()
        {
            return new[]
            {
                GroupName
            };
        }
    }
}