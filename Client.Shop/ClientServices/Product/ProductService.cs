﻿using Shope.Common.DTO.Product;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using Shope.Common.DTO.Base;

namespace Client.Shop.ClientServices.Product;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<Response<List<ProductDto>>?> GetProduct()
    {
        var result = await _httpClient.GetFromJsonAsync<Response<List<ProductDto>>>($"api/Product?page=1&pageSize=15&search={""}");
        return result;


    }

    public async Task<Response<bool>> DeleteProduct(int id)
    {

        var result = await _httpClient.DeleteFromJsonAsync<Response<bool>>($"api/Product/{id}");
        return result;
    }
    public async Task<Response<ProductDto>> GetProductById(int id)
    {

        var result = await _httpClient.GetFromJsonAsync<Response<ProductDto>>($"api/Product/{id}");
        return result;
    }


    public async Task<Response<bool>> CreatProduct(ProductDto product)
    {
        string jsonContent = JsonConvert.SerializeObject(product);
        StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpClient.PostAsync("api/Product", content);
        if (response.IsSuccessStatusCode)
        {
            // Optionally, you can read the response content and deserialize it if needed
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<bool>>(responseContent);

            // Return the success resultreturn new Response<bool> { Data = success, IsSucces = true,Message = "Product created successfully" };
        }
        else
        {
            // Handle the case where the request was not successful, e.g., by logging or returning an error response
            // You can create a custom error response based on your application needs
            // For example:
            return new Response<bool> { Data = false, IsSucces = false, Message = "Failed to create the product" };
        }
    }
    public async Task<Response<ProductDto>?> EditProduct(ProductDto product)
    {
        string jsonContent = JsonConvert.SerializeObject(product);
        StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpClient.PutAsync("api/Product", content);
        if (response.IsSuccessStatusCode)
        {
            // Optionally, you can read the response content and deserialize it if needed
            string responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ProductDto>>(responseContent);

            // Return the success resultreturn new Response<bool> { Data = success, IsSucces = true,Message = "Product created successfully" };
        }
        else
        {
            // Handle the case where the request was not successful, e.g., by logging or returning an error response
            // You can create a custom error response based on your application needs
            // For example:
            return new Response<ProductDto> { Data = null, IsSucces = false, Message = "Failed to create the product" };
        }
    }
    

}