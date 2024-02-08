using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task AddAsync(ProductDTO productDto)
        {
            var command = _mapper.Map<ProductCreateCommand>(productDto);
            await _mediator.Send(command);
        }


        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var command = new GetProductByIdQuery(id);
            var product = await _mediator.Send(command);
            return _mapper.Map<ProductDTO>(product);    
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var command = new GetProductsQuery();
            var products = await _mediator.Send(command);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task RemoveAsync(int id)
        {
            var command = new ProductRemoveCommand(id);
            var product = await _mediator.Send(command);
        }

        public async Task UpdateAsync(ProductDTO productDto)
        {
            var command = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(command);

        }
    }
}
