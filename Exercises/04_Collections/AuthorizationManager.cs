using System;
using System.Collections.Generic;

namespace Exercises._04_Collections
{
    public class AuthorizationManager
    {
        private readonly IUserRepository _iUserRepository;
        
        public AuthorizationManager(IUserRepository iUserRepository) => _iUserRepository = iUserRepository;

        public bool CheckPermissions(Guid userId, params Permission[] requiredPermissions)
        {
            var userPermissions = new HashSet<Permission>(_iUserRepository.GetPermissions(userId));
            return userPermissions.IsSupersetOf(requiredPermissions);
        }
    }
}