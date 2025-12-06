using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using ZstdSharp.Unsafe;

namespace MultiShop.Catalog.Services.ProductServices
{
	public class ProductService : IProductService
	{
		private readonly IMapper _mapper;
		private readonly IMongoCollection<Product> _product_Collection;

		public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_product_Collection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
			_mapper = mapper;
		}

		public async Task CreateProductAsync(CreateProductDto createProductDto)
		{
			var values = _mapper.Map<Product>(createProductDto);
			await _product_Collection.InsertOneAsync(values);
		}

		public async Task DeleteProductAsync(string id)
		{
			await _product_Collection.DeleteOneAsync(x => x.ProductId == id);
		}

		public async Task<List<ResultProductDto>> GetAllProductAsync()
		{
			var values = await _product_Collection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultProductDto>>(values);
		}

		public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
		{
			var values = await _product_Collection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdProductDto>(values);
		}

		public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
		{
			var values = _mapper.Map<Product>(updateProductDto);
			await _product_Collection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
		}
	}
}
