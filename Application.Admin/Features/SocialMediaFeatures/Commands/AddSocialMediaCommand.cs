using Application.Admin.DTOs.Contact;
using Application.Admin.DTOs.SocialMedia;
using Application.Admin.Features.ContactFeatures.Commands;
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

namespace Application.Admin.Features.SocialMediaFeatures.Commands
{
    public class AddSocialMediaCommand : IRequest<Response<bool>>
    {
        public SocialMediaDTO model { get; set; }

        public AddSocialMediaCommand(SocialMediaDTO model)
        {
            this.model = model;
        }

        public class AddSocialMediaCommandHandler : IRequestHandler<AddSocialMediaCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public AddSocialMediaCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(AddSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia socialMedia = new SocialMedia
                {
                    Id = Guid.NewGuid(),
                    Title = request.model.Title,
                    Path = request.model.Path,
                    CreatedTime = DateTime.Now
                };

                _context.SocialMedias.Add(socialMedia);
                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}

