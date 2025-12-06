using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
	public class ProductImageService : IProductImageService
	{
		private readonly IMapper _mapper;
		private readonly IMongoCollection<ProductImage> _productImage_Collection;

		public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_productImage_Collection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
			_mapper = mapper;
		}

		public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
		{
			var values = _mapper.Map<ProductImage>(createProductImageDto);
			await _productImage_Collection.InsertOneAsync(values);
		}

		public async Task DeleteProductImageAsync(string id)
		{
			await _productImage_Collection.DeleteOneAsync(x => x.ProductImageId == id);
		}

		public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
		{
			var values = await _productImage_Collection.Find(x => true).ToListAsync();
			return _mapper.Map<List<ResultProductImageDto>>(values);
		}

		public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
		{
			var values = await _productImage_Collection.Find<ProductImage>(x => x.ProductImageId == id).FirstOrDefaultAsync();
			return _mapper.Map<GetByIdProductImageDto>(values);
		}

		public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
		{
			var values = _mapper.Map<ProductImage>(updateProductImageDto);
			await _productImage_Collection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, values);
		}
	}
}

