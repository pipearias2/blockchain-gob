using Abp.Authorization;
using blockchainGob.Authorization.Roles;
using blockchainGob.Authorization.Users;

namespace blockchainGob.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
