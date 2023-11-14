using Moq;
using Assesment.Application.Contracts.Persistence;
using Assesment.Domain.Entites;
using Assesment.Infrastructure.PasswordService;

namespace Assesment.Application.Tests.Mocks;

public class MockProductRepository
{
    public static Mock<IProductRepository> GetMockProductRepository()
    {

        var products = new List<Product>{
            new Product
            {
                Id = 1,
                UserId = 2;
                CategoryId = 3,
                Name = "user1",
                Description = "this good phone",
                CategoryName = "phones"
                Pricing = 10000;
                Availability = 1;

            }
            new Product
            {
                 Id = 2,
                UserId = 3;
                CategoryId = 4,
                Name = "user2",
                Description = "this good TV",
                CategoryName = "Tv"
                Pricing = 8000;
                Availability = 1;

            }
            new Product
            {
                Id = 3,
                UserId = 4;
                CategoryId = 5,
                Name = "user3",
                Description = "this good Laptop",
                CategoryName = "Computers"
                Pricing = 55000;
                Availability = 2;

            }

        };
        var productRepo = new Mock<IProductRepository>();

        productRepo.Setup(repo => repo.AddAsync(It.IsAny<Product>))
                   .ReturnsAsync((Product p))=>{
                    p.Id = products.Count+1;
                    Product.Add(P);
                    return p;
                   }

        productRepo.setup(repo=> repo.GetAsync(It.IsAny<int>))
                    .ReturnsAsync((int id))=>{
                        var result = products.FirstOrDefault(p=>p.Id==id);
                        return result;
                    }  
        productRepo.setup(repo=> repo.GetAsync())
            .ReturnsAsync(products);

        productRepo.Setup(repo=> repo.UpdateAsync(It.IsAny<Product>))
                   .Callback((Proudct p))=>{
                    var result = prodcuts.FirstOrDefault(x=>x.Id==p.Id);
                    if(rsutl != null){
                        result.Description = p.Description;
                        result.CategoryName = p.CategoryName;
                        result.CategoryId = p.CategoryId;
                    }

                   } 
        productRepo.Setup(repo=> repo.DeleteAsync(It.IsAny<Proudct>)) 
                    .ReturnsAsync((Product p))  =>{
                        prodcuts.RemoveAll(x=> x.Id == p.Id);


                    }    
        productRepo.Setup(repo=> repo.GetByName(It.IsAny<string>)) 
            .ReturnsAsync((string name)  => prudcts.Where(p => p.Name == name).ToList());

                         
        productRepo.Setup(repo=> repo.GetByCategoryName(It.IsAny<string>)) 
            .ReturnsAsync((string name)  => prudcts.Where(p => p.CategoryName == name).ToList());

     
        return productRepo;
    }
}



