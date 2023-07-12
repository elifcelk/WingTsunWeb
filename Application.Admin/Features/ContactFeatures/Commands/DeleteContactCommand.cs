using Application.Admin.Features.AnnouncementFeatures.Commands;
using Application.Admin.Models;
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
    public class DeleteContactCommand : IRequest<Response<bool>>
    {
        public ChangeModel model { get; set; }

        public DeleteContactCommand(ChangeModel model)
        {
            this.model = model;
        }
        public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public DeleteContactCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
            {
                Contact? contact = _context.Contacts.Where(k => k.Id == request.model.Id).FirstOrDefault();
                if (contact == null)
                {
                    return new Response<bool>("İletişim bulunamadı.");
                }

                contact.IsDeleted = true;

                contact.UpdatedTime = DateTime.Now;

                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
