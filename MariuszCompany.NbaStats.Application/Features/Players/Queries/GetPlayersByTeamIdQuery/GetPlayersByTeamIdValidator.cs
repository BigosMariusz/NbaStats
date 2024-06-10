﻿using FluentValidation;
using MariuszCompany.NbaStats.Application.Features.Players.Queries.GetPlayersByTeamIdQuery;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MariuszCompany.NbaStats.Application.Features.Players.Queries.GetPlayersByTeamIdQuery
{
    public class GetPlayersByTeamIdValidator : AbstractValidator<GetPlayersByTeamIdQuery>
    {
        public GetPlayersByTeamIdValidator()
        {
            RuleFor(p => p.TeamId)
                .NotNull()
                .WithMessage("TeamId is required.");
        }
    }
}
