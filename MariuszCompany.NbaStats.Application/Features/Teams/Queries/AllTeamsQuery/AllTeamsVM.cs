using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariuszCompany.NbaStats.Application.Features.Teams.Queries.AllTeamsQuery
{
    public class AllTeamsVM
    {
        public Guid Id { get; set; }
        public string? Conference { get; set; }
        public string? Division { get; set; }
        public string? City { get; set; }
        public string? Name { get; set; }
        public string? Full_name { get; set; }
        public string? Abbreviation { get; set; }
    }
}
