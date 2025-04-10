using Repos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Repositories
{
    public class CategoryRepository
    {
        private readonly MyDbContext _context;

        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }

        //public void Add(Category category)
        //{
        //    _context.Categories.Add(category);
        //    _context.SaveChanges();
        //}

        public void Add(Category category)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(category);
            if (!Validator.TryValidateObject(category, validationContext, validationResults, true))
            {
                foreach (var validationResult in validationResults)
                {
                    Console.WriteLine($"Validation Error: {validationResult.ErrorMessage}");
                }
                return;
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category? GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public void Update(Category category)
        {
            var existCategory = _context.Categories.FirstOrDefault(u => u.Id == category.Id);

            if (existCategory == null)
            {
                Console.WriteLine($"Category with ID {category.Id} not found.");
                return;
            }

            existCategory.Name = category.Name;
   
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
