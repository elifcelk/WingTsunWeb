using Application.Admin.Models.Gallery;
using Application.Features.GalleryFeatures.Queries;
using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.GalleryFeatures.Queries
{
    public class GetAllGalleryQuery : IRequest<List<GalleryViewModel>>
    {
        public class GetAllGalleryQueryHandler : IRequestHandler<GetAllGalleryQuery, List<GalleryViewModel>>
        {
            private readonly IApplicationDbContext applicationDbContext;

            public GetAllGalleryQueryHandler(IApplicationDbContext applicationDbContext)
            {
                this.applicationDbContext = applicationDbContext;
            }

            public async Task<List<GalleryViewModel>> Handle(GetAllGalleryQuery request, CancellationToken cancellationToken)
            {
                List<GalleryViewModel> allGalleries = await applicationDbContext.Galleries.AsNoTracking().OrderByDescending(k => k.CreatedTime).Select(k => new GalleryViewModel()
                {
                    Id = k.Id,
                    PhotoPath = k.PhotoPath,
                    IsDeleted = k.IsDeleted,
                    IsActive = k.IsActive,
                }).ToListAsync();

                return allGalleries;
            }
        }
    }
}
