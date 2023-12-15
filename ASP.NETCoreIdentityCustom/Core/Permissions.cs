namespace Bornholm_Sleagts.Core
{
    public class Permissions
    {
        public static List<string> GeneratePermissionsFromModule(string module)
        {
            return new List<string>
            {
                $"Permissions.{module}.View",
                $"Permissions.{module}.Create",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete"
            };
        }

        public static List<string> PermissionsList()
        {
            var allPermissions = new List<string>();

            foreach (var module in Enum.GetValues(typeof(Helper.PermissionModuleName)))
                allPermissions.AddRange(GeneratePermissionsFromModule(module.ToString()));
            return allPermissions;
        }

    }
}
