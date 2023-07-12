using Application.Admin.Features.AnnouncementFeatures.Queries;
using Application.Admin.Models.Announcement;
using Application.Admin.Models.Contact;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.ContactFeatures.Queries
{
    public class GetAllContactForAdminQuery :IRequest<List<ContactIndexModel>>
    {
        public class GetAllContactForAdminQueryHandler : IRequestHandler<GetAllContactForAdminQuery, List<ContactIndexModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetAllContactForAdminQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<List<ContactIndexModel>> Handle(GetAllContactForAdminQuery request, CancellationToken cancellationToken)
            {
                List<ContactIndexModel> contacts = await applicationDbContext.Contacts.OrderByDescending(k => k.CreatedTime).Select(k => new ContactIndexModel()
                {
                    Id = k.Id,
                    Title = k.Title,
                    PhoneNumber = k.PhoneNumber,
                    CreatedTime = k.CreatedTime,
                }).ToListAsync();

                return contacts;
            }
        }
    }
}
