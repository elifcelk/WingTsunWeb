using Application.Admin.DTOs.Admin;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Admin.Features.AdminFeatures.Commands
{
    public class AddAdminCommand : IRequest<Response<bool>>
    {
        public AdminDTO model { get; set; }

        public AddAdminCommand(AdminDTO model)
        {
            this.model = model;
        }

        public class AddAdminCommandHandler : IRequestHandler<AddAdminCommand, Response<bool>>
        {
            IApplicationDbContext _context;
            IConfiguration configuration;

            public AddAdminCommandHandler(IApplicationDbContext context, IConfiguration configuration)
            {
                _context = context;
                this.configuration = configuration;
            }

            public async Task<Response<bool>> Handle(AddAdminCommand request, CancellationToken cancellationToken)
            {
                AdminUser admin = new AdminUser
                {
                    Id = Guid.NewGuid(),
                    UserName = request.model.Username,
                    Password = request.model.Password,
                    CreatedTime = DateTime.Now
                };

                _context.AdminUsers.Add(admin);
                await _context.SaveChangesAsync();

                return new Response<bool>(true);
            }
        }
    }
}
