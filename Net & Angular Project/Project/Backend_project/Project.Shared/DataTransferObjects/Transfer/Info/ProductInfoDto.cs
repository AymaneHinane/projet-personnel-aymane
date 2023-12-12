

using Project.Entities.Models;

namespace Project.Shared.Dto;



public class ProductInfoDto{
    public Guid Id{get;set;}
    public string? Name{get;set;}
    public Category Category{get;set;}
}