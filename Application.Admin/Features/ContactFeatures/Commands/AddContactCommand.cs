using Application.Admin.DTOs.Announcement;
using Application.Admin.DTOs.Contact;
using Application.Admin.Features.AnnouncementFeatures.Commands;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.ContactFeatures.Commands
{
    public class AddContactCommand : IRequest<Response<bool>>
    {
        public ContactDTO model { get; set; }

        public AddContactCommand(ContactDTO model)
        {
            this.model = model;
        }
        public class AddContactCommandHandler : IRequestHandler<AddContactCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public AddContactCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(AddContactCommand request, CancellationToken cancellationToken)
            {
                Contact contact = new Contact
                {
                    Id = Guid.NewGuid(),
                    Title = request.model.Title,
                    PhoneNumber = request.model.PhoneNumber,
                    CreatedTime = DateTime.Now
                };

                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
