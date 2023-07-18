using Application.Admin.Models.Admin;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Admin.Features.AdminFeatures.Queries
{
    public class AdminUserLoginQuery : IRequest<Response<LoginModel>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public AdminUserLoginQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public class AdminUserLoginQueryHandler : IRequestHandler<AdminUserLoginQuery, Response<LoginModel>>
        {
            private readonly IApplicationDbContext dbContext;
            public AdminUserLoginQueryHandler(IApplicationDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public Task<Response<LoginModel>> Handle(AdminUserLoginQuery request, CancellationToken cancellationToken)
            {
                var admin = dbContext.AdminUsers.Where(k => k.UserName == request.UserName && k.Password == request.Password).FirstOrDefault();
                if (admin == null)
                {
                    return Task.FromResult(new Response<LoginModel>("Kullanıcı adı veya parolanızı yanlış girdiniz."));

                }
                LoginModel model = new LoginModel()
                {
                    Password = request.Password,
                    UserName = request.UserName
                };
                return Task.FromResult(new Response<LoginModel>(model, null));
            }
        }
    }
}
