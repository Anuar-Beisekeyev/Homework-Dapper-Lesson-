using Dapper;
using DapperLesson.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DapperLesson.Data 
{
    public class TeamDataAccess : DbDataAccess<Team>
    {
        public override void Insert(Team team)
        {
            connection.Execute("insert into Teams (Id, Name) values (@Id, @Name)", team);
        }

        public override void Update(Team team)
        {
            connection.Execute($"update Teams set Name = @Name  where Id = @Id",team);
        }
        public override void Delete(Team team)
        {
            connection.Execute("delete from Teams where Id = @Id", team);
        }
        public override ICollection<Team> Select()
        {
            return connection.Query<Team>("select * from Teams").ToList();            
        }
    }
}
