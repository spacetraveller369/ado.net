using Repos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Repositories
{
    public class UserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        //public void Add(User user)
        //{
        //    _context.Users.Add(user);
        //    _context.SaveChanges();
        //}

        public void Add(User user)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, validationContext, validationResults, true))
            {
                foreach (var validationResult in validationResults)
                {
                    Console.WriteLine($"Validation Error: {validationResult.ErrorMessage}");
                }
                return;
            }

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public void Update(User user)
        {
            var existUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);

            if (existUser == null)
            {
                Console.WriteLine($"User with ID {user.Id} not found.");
                return;
            }

            existUser.Name = user.Name;
            existUser.Age = user.Age;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
