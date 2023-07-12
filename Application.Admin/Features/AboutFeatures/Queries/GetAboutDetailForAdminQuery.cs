using Application.Admin.DTOs.About;
using Application.Admin.DTOs.Announcement;
using Application.Admin.Features.AnnouncementFeatures.Queries;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.AboutFeatures.Queries
{
    public class GetAboutDetailForAdminQuery : IRequest<AboutDTO>
    {
        public Guid Id { get; set; }
        public GetAboutDetailForAdminQuery(Guid ıd)
        {
            Id = ıd;
        }

        public class GetAboutDetailForAdminQueryHandler : IRequestHandler<GetAboutDetailForAdminQuery, AboutDTO>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetAboutDetailForAdminQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<AboutDTO> Handle(GetAboutDetailForAdminQuery request, CancellationToken cancellationToken)
            {
                AboutDTO? aboutDetail = await applicationDbContext.Abouts!.Where(k => k.Id == request.Id).Select(k => new AboutDTO()
                {
                    Id = k.Id,
                    Title = k.Title,
                    Text = k.Text
                }).FirstOrDefaultAsync();

                return aboutDetail;
            }
        }
    }
}
