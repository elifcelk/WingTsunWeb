using Application.Admin.Models;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Admin.Features.SocialMediaFeatures.Commands
{
    public class DeleteSocialMediaCommand : IRequest<Response<bool>>
    {
        public ChangeModel model { get; set; }

        public DeleteSocialMediaCommand(ChangeModel model)
        {
            this.model = model;
        }
        public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, Response<bool>>
        {
            IApplicationDbContext _context;

            public DeleteSocialMediaCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Response<bool>> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia? socialMedia = _context.SocialMedias.Where(k => k.Id == request.model.Id).FirstOrDefault();
                if (socialMedia == null)
                {
                    return new Response<bool>("Sosyal medya kaydı bulunamadı.");
                }

                _context.SocialMedias.Remove(socialMedia);

                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
