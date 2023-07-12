using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.HomeFeatures.Queries
{
    public class GetAllContactQuery : IRequest<List<ContactIndexModel>>
    {
        public class GetAllContactQueryHandler : IRequestHandler<GetAllContactQuery, List<ContactIndexModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetAllContactQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<List<ContactIndexModel>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
            {
                List<ContactIndexModel> contacts = await applicationDbContext.Contacts.OrderBy(k => k.CreatedTime).Select(k => new ContactIndexModel()
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
