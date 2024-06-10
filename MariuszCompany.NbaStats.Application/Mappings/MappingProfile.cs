using AutoMapper;
using MariuszCompany.NbaStats.Application.Dto.NbaIntegration;
using MariuszCompany.NbaStats.Application.Features.Games.Queries.TeamWonGamesCountQuery;
using MariuszCompany.NbaStats.Application.Features.Players.Queries.GetPlayersByTeamIdQuery;
using MariuszCompany.NbaStats.Application.Features.Teams.Queries.AllTeamsQuery;
using MariuszCompany.NbaStats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.NbaStats.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NbaGame, Game>()
                .ForMember(d => d.IntegrationId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.HomeTeamIntegrationId, o => o.MapFrom(s => s.Home_team != null ? s.Home_team.Id : (int?)null))
                .ForMember(d => d.VisitorTeamIntegrationId, o => o.MapFrom(s => s.Visitor_team != null ? s.Visitor_team.Id : (int?)null))
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.DateCreatedUtc, o => o.Ignore())
                .ForMember(d => d.DateModifiedUtc, o => o.Ignore())
                .ForMember(d => d.HomeTeamId, o => o.Ignore())
                .ForMember(d => d.VisitorTeamId, o => o.Ignore())
                .ForMember(d => d.HomeTeam, o => o.Ignore())
                .ForMember(d => d.VisitorTeam, o => o.Ignore());

            CreateMap<NbaPlayer, Player>()
                .ForMember(d => d.IntegrationId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.TeamIntegrationId, o => o.MapFrom(s => s.Team != null ? s.Team.Id : (int?)null))
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.DateCreatedUtc, o => o.Ignore())
                .ForMember(d => d.DateModifiedUtc, o => o.Ignore())
                .ForMember(d => d.TeamId, o => o.Ignore())
                .ForMember(d => d.Team, o => o.Ignore());

            CreateMap<NbaTeam, Team>()
                .ForMember(d => d.IntegrationId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.DateCreatedUtc, o => o.Ignore())
                .ForMember(d => d.DateModifiedUtc, o => o.Ignore())
                .ForMember(d => d.Players, o => o.Ignore())
                .ForMember(d => d.HomeGames, o => o.Ignore())
                .ForMember(d => d.VisitorGames, o => o.Ignore());

            CreateMap<Player, GetPlayersByTeamIdVM>();
            CreateMap<Player, GetPlayersListVM>();
            CreateMap<int, TeamWonGamesCountVM>()
                .ForMember(d => d.Count, o => o.MapFrom(s => s));

            CreateMap<Team, AllTeamsVM>();
        }
    }
}
