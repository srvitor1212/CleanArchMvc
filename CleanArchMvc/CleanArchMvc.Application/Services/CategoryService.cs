using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;


        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
