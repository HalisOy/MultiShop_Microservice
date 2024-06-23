using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices;

public class ProductDetailService: IProductDetailService
{
    IMongoCollection<ProductDetail> _productDetailCollection;
    IMapper _mapper;

    public ProductDetailService(IMapper mapper, IDatabaseSettings _datebaseSettings)
    {
        var client = new MongoClient(_datebaseSettings.ConnectionString);
        var database = client.GetDatabase(_datebaseSettings.DatabaseName);
        _productDetailCollection = database.GetCollection<ProductDetail>(_datebaseSettings.ProductDetailCollectionName);
        _mapper = mapper;
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
    {
        var value = _mapper.Map<ProductDetail>(createProductDetailDto);
        await _productDetailCollection.InsertOneAsync(value);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailID == id);
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
    {
        var values = await _productDetailCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDetailDto>>(values);
    }

    public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
    {
        var value = await _productDetailCollection.Find(x => x.ProductDetailID == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDetailDto>(value);
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        var value = _mapper.Map<ProductDetail>(updateProductDetailDto);
        await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailID == value.ProductDetailID, value);
    }
}
