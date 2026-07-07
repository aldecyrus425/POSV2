using MediatR;
using MyApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Product.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommands, CreateProductResponse>
    {
        private readonly IProductRepository _productRepo;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepo = productRepository;
        }

        public Task<CreateProductResponse> Handle(CreateProductCommands request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
