using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication10.Hubs;

namespace WebApplication10.Models
{
    public class MatchesRepository
    {
        readonly string _connString = ConfigurationManager.ConnectionStrings["BettingOddsContext"].ConnectionString;

        public IEnumerable<Match> GetAllMatches()
        {
            var matches = new List<Match>();
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT [id], [name] FROM [dbo].[Matches]", connection))
                {
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        matches.Add(item: new Match { Id = (string)reader["Id"], Name = (string)reader["Name"] });
                    }
                }

            }
            return matches;


        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                MatchesHub.SendMatches();
            }
        }
    }
}