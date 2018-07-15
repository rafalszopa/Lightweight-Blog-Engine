namespace Blog.Persistance.Queries
{
    public static class UserQuery
    {
        public static string Add()
        {
            string query =
                "INSERT INTO Users(FirstName, LastName, Email, Bio, CreateDate, UserTypeId, IsActive)" +
                "VALUES(@FirstName, @LastName, @Email, @Bio, @CreateDate, @UserTypeId, @IsActive);" +
                "SELECT CAST(SCOPE_IDENTITY() as int);";

            return query;
        }

        public static string Update()
        {
            string query = 
                @"UPDATE Users
                SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Bio = @Bio, UserTypeId = @UserType, IsActive = @IsActive
                WHERE Id = @UserId;
                SELECT @@ROWCOUNT";

            return query;
        }

        public static string GetById()
        {
            string query = 
                @"SELECT Users.Id, Users.FirstName, Users.LastName, Users.Email, Users.Bio, Users.CreateDate, UserTypes.Type, Users.IsActive
                FROM Users
                JOIN UserTypes ON Users.UserTypeId = UserTypes.UserTypeId
                WHERE Id = @UserId;";

            return query;
        }

        public static string GetByPostId()
        {
            string query =
                @"SELECT Users.Id, Users.FirstName, Users.LastName, Users.Email, Users.Bio, Users.CreateDate CreatedOn, Users.UserTypeId Type
                FROM Users
                WHERE Users.Id = (SELECT UserId FROM Posts WHERE Id = @PostId);";

            return query;
        }

        public static string GetAll()
        {
            string query = @"SELECT
                            Users.Id,
                            Users.FirstName,
                            Users.LastName,
                            Users.Email,
                            Users.Bio,
                            Users.CreateDate,
                            UserTypes.Type,
                            Users.IsActive
                            FROM Users
                            JOIN UserTypes ON Users.UserTypeId = UserTypes.UserTypeId;";

            return query;
        }
    }
}
