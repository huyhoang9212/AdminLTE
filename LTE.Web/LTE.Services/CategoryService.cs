using LTE.Core.Data;
using LTE.Core.Domain;
using LTE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTE.Services
{
    public interface ICategoryService
    {
        Category FindCategoryById(object id);

        void InsertCategory(Category category);
        void UpdateCategory(Category category);

        void DeleteCategory(Category category);

        IQueryable<Category> GetAllCategories();
    }


    public class CategoryService : ICategoryService
    {
        private IRepository<Category> _repository;
        private IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<Category>();
        }

        public void DeleteCategory(Category category)
        {
            try
            {
                _repository.Delete(category);
            }
            catch (Exception ex)
            {
                // Log ex
            }
        }

        public Category FindCategoryById(object id)
        {
            return _repository.FindById(id);
        }

        public IQueryable<Category> GetAllCategories()
        {
            return _repository.Table;
        }

        public void InsertCategory(Category category)
        {
            try
            {
                _repository.Insert(category);
            }
            catch(Exception ex)
            {
                // Log ex
            }            
        }

        public void UpdateCategory(Category category)
        {
            try
            {
                _repository.Update(category);
            }
            catch (Exception ex)
            {
                // Log ex
            }
        }
    }
}
