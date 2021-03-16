using Dapper;
using DapperLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DapperLesson.Data
{
    public class PlayerDataAcceess : DbDataAccess<Player>
    {
        public override void Delete(Player player)
        {
            connection.Execute("delete from Players where Id = @Id", player);
        }

        public override void Insert(Player player)
        {
            connection.Execute("insert into Players (Id, FullName, Number, TeamId ) values (@Id, @FullName, @Number, @TeamId)", player);
        }

        public override ICollection<Player> Select()
        {
            return connection.Query<Player>("select * from Teams").ToList();
        }

        public override void Update(Player player)
        {
            connection.Execute($"update Players set FullName = @FullName, Number = @Number, TeamId = @TeamId  where Id = @Id", player);
        }
    }
}
