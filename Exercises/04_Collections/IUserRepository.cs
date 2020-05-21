using System;
using System.Collections.Generic;

namespace Exercises._04_Collections
{
    public interface IUserRepository
    {
        IEnumerable<Permission> GetPermissions(Guid userId);
    }
}