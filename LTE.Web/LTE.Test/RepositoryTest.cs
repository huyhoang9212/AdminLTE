using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LTE.Core.Domain;
using LTE.Core.Data;
using LTE.Core;
using LTE.Data;
using System.Linq;
using LTE.Services;

namespace LTE.Test
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            LTEDbContext dbContext = new LTEDbContext();
            IRepository<Category> repository = new Repository<Category>(dbContext);
            var category = repository.Table.Where(c => c.Name == "Computer").FirstOrDefault();
            if (category == null)
            {
                repository.Insert(new Category()
                {
                    Name = "Computer",
                    Description = "Category description"
                });
            }
            else
            {
                category.Description = "description changed3223";
                //repository.Update(category);
            }

            dbContext.SaveChanges();
            category = repository.Table.Where(c => c.Name == "Computer").FirstOrDefault();
            Assert.IsNotNull(category);
        }

        [TestMethod]
        public void TestUnitOfWork()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            var repository = unitOfWork.GetRepository<Category>();
            var category = repository.Table.Where(c => c.Name == "Iphone").FirstOrDefault();

            // Delete
            if (category != null)
            {
                repository.Delete(category);
                unitOfWork.SaveChanges();
                category = repository.Table.Where(c => c.Name == "Iphone").FirstOrDefault();
                Assert.IsNull(category);
            }

            // Insert
            repository.Insert(new Category()
            {
                Name = "Iphone",
                Description = "Iphone"
            });
            unitOfWork.SaveChanges();
            category = repository.Table.Where(c => c.Name == "Iphone").FirstOrDefault();
            Assert.IsNotNull(category);

            // Update
            category.Description = "Iphone changed";
            repository.Update(category);
            unitOfWork.SaveChanges();
            category = repository.Table.Where(c => c.Name == "Iphone").FirstOrDefault();
            Assert.IsTrue(category.Description == "Iphone changed");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestService()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            var repository = unitOfWork.GetRepository<Category>();
            ICategoryService service = new CategoryService(unitOfWork);

            var category = service.GetAllCategories().Where(c => c.Name == "Iphone").FirstOrDefault();

            // Delete
            if (category != null)
            {
                service.DeleteCategory(category);
                unitOfWork.SaveChanges();
                category = service.GetAllCategories().Where(c => c.Name == "Iphone").FirstOrDefault();
                Assert.IsNull(category);
            }

            // Insert
            service.InsertCategory(new Category()
            {
                Name = "Iphone",
                Description = "Iphone"
            });
            unitOfWork.SaveChanges();
            category = service.GetAllCategories().Where(c => c.Name == "Iphone").FirstOrDefault();
            Assert.IsNotNull(category);

            // Update
            category.Description = "Iphone changed";
            service.UpdateCategory(category);
            unitOfWork.SaveChanges();
            category = service.GetAllCategories().Where(c => c.Name == "Iphone").FirstOrDefault();
            Assert.IsTrue(category.Description == "Iphone changed");
            Assert.IsTrue(true);
        }
    }
}
