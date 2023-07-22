using Application.Admin.DTOs.Slider;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Admin.Features.SliderFeatures.Commands
{
    public class AddSliderCommand : IRequest<Response<bool>>
    {
        public SliderDTO model { get; set; }

        public AddSliderCommand(SliderDTO model)
        {
            this.model = model;
        }
        public class AddSliderCommandHandler : IRequestHandler<AddSliderCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public AddSliderCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(AddSliderCommand request, CancellationToken cancellationToken)
            {
                if (request.model.ImageURL == null)
                    return new Response<bool>("Resim yüklemediniz.");

                Slider slider = new Slider
                {
                    Id = Guid.NewGuid(),
                    Description = request.model.Description,
                    Title = request.model.Title,
                    ImageURL = request.model.ImageURL,
                    CreatedTime = DateTime.Now,
                    IsActive = true
                };

                _context.Sliders.Add(slider);
                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
