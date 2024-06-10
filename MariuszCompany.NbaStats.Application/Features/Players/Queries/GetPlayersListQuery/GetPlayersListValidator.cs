using FluentValidation;
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
    public class GetPlayersListValidator : AbstractValidator<GetPlayersListQuery>
    {
        public GetPlayersListValidator()
        {
            RuleFor(p => p.DraftYear)
                .LessThanOrEqualTo(DateTime.UtcNow.Year)
                .WithMessage("DraftYear must be between 1900 and current year.")
                .GreaterThanOrEqualTo(1900)
                .WithMessage("DraftYear must be between 1900 and current year.");

            RuleFor(p => p.PageNumber)
                .NotNull()
                .WithMessage("PageNumber is required.")
                .Must(x =>
                {
                    if (x != null)
                        return x > 0;

                    return true;
                })
                .WithMessage("PageSize must be > than 0.");

            RuleFor(p => p.PageSize)
                .Must(x =>
                {
                    if (x != null)
                        return x > 0;

                    return true;
                })
                .WithMessage("PageSize must be > than 0.")
                .Must(x =>
                {
                    if (x != null)
                        return x <= 100;

                    return true;
                })
                .WithMessage("PageSize must be <= 100.");
        }
    }
}
