using Application.Admin.Features.SocialMediaFeatures.Queries;
using Application.Admin.Models.Admin;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.AdminFeatures.Queries
{
    public class GetAllAdminsForAdminQuery : IRequest<List<AdminIndexModel>>
    {
        public class GetAllAdminsForAdminQueryHandler : IRequestHandler<GetAllAdminsForAdminQuery, List<AdminIndexModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetAllAdminsForAdminQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<List<AdminIndexModel>> Handle(GetAllAdminsForAdminQuery request, CancellationToken cancellationToken)
            {
                List<AdminIndexModel> admins = await applicationDbContext.AdminUsers.OrderByDescending(k => k.CreatedTime).Select(k => new AdminIndexModel()
                {
                    Id = k.Id,
                    UserName = k.UserName,
                    CreatedTime = k.CreatedTime,
                }).ToListAsync();

                return admins;
            }
        }
    }
}
