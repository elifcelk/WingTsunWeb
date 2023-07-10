using Application.Admin.DTOs.Announcement;
using Application.Admin.DTOs.School;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.AnnouncementFeatures.Queries
{
    public class GetAnnouncementDetailForAdminQuery : IRequest<AnnouncementDTO>
    {
        public Guid Id { get; set; }
        public GetAnnouncementDetailForAdminQuery(Guid ıd)
        {
            Id = ıd;
        }

        public class GetAnnouncementDetailQueryHandler : IRequestHandler<GetAnnouncementDetailForAdminQuery, AnnouncementDTO>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetAnnouncementDetailQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<AnnouncementDTO> Handle(GetAnnouncementDetailForAdminQuery request, CancellationToken cancellationToken)
            {
                AnnouncementDTO? announcementDetail = await applicationDbContext.Announcements!.Where(k => k.Id == request.Id).Select(k => new AnnouncementDTO()
                {
                    Id = k.Id,
                    Name = k.Title,
                    Content = k.Content,
                    MainImage = k.MainImage,
                    Type = (short)k.AnnouncementType
                }).FirstOrDefaultAsync();

                return announcementDetail;
            }
        }
    }
}
