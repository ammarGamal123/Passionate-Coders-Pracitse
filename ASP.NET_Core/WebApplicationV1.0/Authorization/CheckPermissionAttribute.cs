using WebApplicationV1._0.Data;

namespace WebApplicationV1._0.Authorization
{
    [AttributeUsage(AttributeTargets.Method , AllowMultiple = false)]
    public class CheckPermissionAttribute : Attribute
    {
        public CheckPermissionAttribute(Permission permission)
        {
            Permission = permission;
        }

        public Permission Permission { get; }
    }
}
