using MediatR;
using MyApp.Application.Features.User.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Category.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryResponse>
    {
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
    }
}
