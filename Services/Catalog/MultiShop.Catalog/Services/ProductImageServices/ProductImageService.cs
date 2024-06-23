using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices;

public class ProductImageService : IProductImageService
{
    IMongoCollection<ProductImage> _productImageCollection;
    IMapper _mapper;

    public ProductImageService(IMapper mapper, IDatabaseSettings _datebaseSettings)
    {
        var client = new MongoClient(_datebaseSettings.ConnectionString);
        var database = client.GetDatabase(_datebaseSettings.DatabaseName);
        _productImageCollection = database.GetCollection<ProductImage>(_datebaseSettings.ProductImageCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
    {
        var value = _mapper.Map<ProductImage>(createProductImageDto);
        await _productImageCollection.InsertOneAsync(value);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _productImageCollection.DeleteOneAsync(x => x.ProductImageID == id);
    }

    public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
    {
        var values = await _productImageCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductImageDto>>(values);
    }

    public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
    {
        var value = await _productImageCollection.Find(x => x.ProductImageID == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductImageDto>(value);
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
    {
        var value = _mapper.Map<ProductImage>(updateProductImageDto);
        await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageID == value.ProductImageID, value);
    }
}
