using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class RightsGranted
    {
        public static IDictionary<UserRoles, RoleRights[]> map
        {
            get{
                map = new Dictionary<UserRoles, RoleRights[]>();

                map.Add(UserRoles.ADMIN, new[] {  
                                            RoleRights.EDIT_USERS,
                                            RoleRights.READ_LOGS,
                                            RoleRights.READ_USERS});
                map.Add(UserRoles.ANONYMOUS, new[] {RoleRights.READ_USERS});

                map.Add(UserRoles.PROFESSOR, new[] { 
                                            RoleRights.EDIT_USERS, 
                                            RoleRights.READ_USERS});
                map.Add(UserRoles.INSPECTOR, new[] {
                                            RoleRights.READ_LOGS,
                                            RoleRights.READ_USERS});

                map.Add(UserRoles.STUDENT, new[] {RoleRights.READ_LOGS});
                return map;
            }
            set { }
        }

        
        
    }
}
