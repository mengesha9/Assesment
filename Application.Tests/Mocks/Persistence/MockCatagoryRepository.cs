using Moq;
using Assesment.Application.Contracts.Persistence;
using Assesment.Domain.Entites;
using Assesment.Infrastructure.PasswordService;

namespace Assesment.Application.Tests.Mocks;

public class MockCategoryRepository
{
    public static Mock<ICatagoryRepository> GetMockCategoryRepository()
    {

        var categorys = new List<Category>{
            new Category
            {
                Id = 1,
                Name = "user1"
                Description = "phone catagory"

            }
            new Category
            {
                Id = 2,
                Name = "user2"
                Description = "Computer catagory"

            }
            new Category
            {
                Id = 3,
                Name = "user3"
                Description = "Tv catagory"

            }

        };
        var categoryRepo = new Mock<ICatagoryRepository>();

        categoryRepo.Setup(repo => repo.AddAsync(It.IsAny<Category>))
                   .ReturnsAsync((Category p))=>{
                    p.Id = categorys.Count+1;
                    categorys.Add(P);
                    return p;
                   }

        categoryRepo.setup(repo=> repo.GetAsync(It.IsAny<int>))
                    .ReturnsAsync((int id))=>{
                        var result = categorys.FirstOrDefault(p=>p.Id==id);
                        return result;
                    }  
        categoryRepo.setup(repo=> repo.GetAsync())
            .ReturnsAsync(categorys);

        categoryRepo.Setup(repo=> repo.UpdateAsync(It.IsAny<Category>))
                   .Callback((Category p))=>{
                    var result = categorys.FirstOrDefault(x=>x.Id==p.Id);
                    if(rsutl != null){
                        result.Description = p.Description;
                        result.Name = p.Name;
                    }

                   } 

        categoryRepo.Setup(repo=> repo.DeleteAsync(It.IsAny<Category>)) 
                    .ReturnsAsync((Category p))  =>{
                        categorys.RemoveAll(x=> x.Id == p.Id);
                    } 
        categoryRepo.setup(repo=> repo.GetNameAsync(It.IsAny<Category>))
            .ReturnsAsync((string Name))=>{
                var result = categorys.FirstOrDefault(p=>p.Name==Name);
                return result;
            }                
                     

        return categoryRepo;
    }
}



