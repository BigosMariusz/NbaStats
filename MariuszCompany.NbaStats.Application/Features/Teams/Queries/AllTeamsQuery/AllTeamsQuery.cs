using AutoMapper;
using MariuszCompany.NbaStats.Application.Interfaces.Repositories;
using MariuszCompany.NbaStats.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MariuszCompany.NbaStats.Application.Features.Teams.Queries.AllTeamsQuery
{
    public class AllTeamsQuery : IRequest<Response<IEnumerable<AllTeamsVM>>>
    {
    }
}
