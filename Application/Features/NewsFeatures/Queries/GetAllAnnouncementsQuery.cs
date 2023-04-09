using Application.Features.SchoolsFeatures.Queries;
using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NewsFeatures.Queries
{
    public class GetAllAnnouncementsQuery : IRequest<List<AnnouncementModel>>
    {
        public class GetAllAnnouncementsQueryHandler : IRequestHandler<GetAllAnnouncementsQuery, List<AnnouncementModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetAllAnnouncementsQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<List<AnnouncementModel>> Handle(GetAllAnnouncementsQuery request, CancellationToken cancellationToken)
            {
                List<AnnouncementModel> announcements = await applicationDbContext.Announcements.OrderByDescending(k => k.CreatedTime).Select(k => new AnnouncementModel()
                {
                    Id = k.Id,
                    Title = k.Title,
                    AnnouncementType = k.AnnouncementType,
                    CreatedTime = k.CreatedTime,
                    MainImage = k.MainImage
                }).ToListAsync();

                return announcements;
            }
        }
    }
}
