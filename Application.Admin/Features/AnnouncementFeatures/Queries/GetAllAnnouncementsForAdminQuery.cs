using Application.Admin.Models.Announcement;
using Application.Features.NewsFeatures.Queries;
using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Admin.Features.AnnouncementFeatures.Queries
{
    public class GetAllAnnouncementsForAdminQuery : IRequest<List<AnnouncementIndexModel>>
    {
        public class GetAllAnnouncementsForAdminQueryHandler : IRequestHandler<GetAllAnnouncementsForAdminQuery, List<AnnouncementIndexModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetAllAnnouncementsForAdminQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<List<AnnouncementIndexModel>> Handle(GetAllAnnouncementsForAdminQuery request, CancellationToken cancellationToken)
            {
                List<AnnouncementIndexModel> announcements = await applicationDbContext.Announcements.OrderByDescending(k => k.CreatedTime).Select(k => new AnnouncementIndexModel()
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
