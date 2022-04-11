using CK.Core;
using CK.SqlServer;

namespace CK.DB.User.NamedUser
{
    [SqlTable( "tUser", Package = typeof( Package ))]
    [Versions( "1.0.0" )]
    [SqlObjectItem( "transform:vUser" )]
    public abstract class UserTable : Actor.UserTable
    {
        void StObjConstruct() { }

        /// <summary>
        /// Edits an existing user.
        /// </summary>
        /// <param name="context">The call context.</param>
        /// <param name="actorId">The acting actor identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="lastName">The last name. Must not be null.</param>
        /// <param name="firstName">The first name. Must not be null.</param>
        /// <returns>The awaitable.</returns>
        [SqlProcedure( "sNamedUserEdit" )]
        public abstract Task EditNameAsync( ISqlCallContext context, int actorId, int userId, string firstName, string lastName );

        /// <summary>
        /// Tries to create a new user. If the user name is not unique, returns -1.
        /// </summary>
        /// <param name="ctx">The call context.</param>
        /// <param name="actorId">The acting actor identifier.</param>
        /// <param name="userName">The user name (when not unique, a " (n)" suffix is automatically added).</param>
        /// <param name="lastName">The last name. Must not be null.</param>
        /// <param name="firstName">The first name. Must not be null.</param>
        /// <returns>The user identifier.</returns>
        [SqlProcedure( "transform:sUserCreate" )]
        public abstract Task<int> CreateUserAsync( ISqlCallContext ctx,
                                                   int actorId,
                                                   string userName,
                                                   string lastName,
                                                   string firstName );

    }
}
