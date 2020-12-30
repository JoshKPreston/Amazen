using System.Data;
using amazen_server.Models;
using Dapper;

namespace amazen_server.Repositories
{
    public class ProfileRepository
    {
    private readonly IDbConnection _db;

        public ProfileRepository(IDbConnection db)
        {
            _db = db;
        }
        public Profile GetByEmail(string email)
        {
            string sql = "select * from profiles where email = @Email";
            return _db.QueryFirstOrDefault<Profile>(sql, new { email });
        }
        public Profile Create(Profile userInfo)
        {
            string sql = @"
            insert into profiles
            (id, name, email, picture)
            values
            (@Id, @Name, @Email, @Picture)";
            _db.Execute(sql, userInfo);
            return userInfo;
        }
    }
}