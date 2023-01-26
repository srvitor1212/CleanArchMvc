using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository ??
                throw new ArgumentNullException(nameof(productRepository));
        }

        public Task<IEnumerable<ProductDTO>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetProductCategory(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Add(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
