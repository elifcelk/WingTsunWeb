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
    public class GetAnnouncementDetailQuery : IRequest<AnnouncementDetailModel>
    {
        public Guid Id { get; set; }
        public GetAnnouncementDetailQuery(Guid Id)
        {
            this.Id = Id;
        }

        public class GetAnnouncementDetailQueryHandler : IRequestHandler<GetAnnouncementDetailQuery, AnnouncementDetailModel>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetAnnouncementDetailQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<AnnouncementDetailModel> Handle(GetAnnouncementDetailQuery request, CancellationToken cancellationToken)
            {
                AnnouncementDetailModel announcement = await applicationDbContext.Announcements.Where(k => k.Id == request.Id && !k.IsDeleted).Select(k => new AnnouncementDetailModel()
                {
                    Id = k.Id,
                    Content = k.Content,
                    AnnouncementType = k.AnnouncementType,
                    MainImage = k.MainImage,
                    Title = k.Title,
                    CreatedTime = k.CreatedTime
                }).FirstOrDefaultAsync(cancellationToken: cancellationToken);

                return announcement;
            }
        }
    }
}
