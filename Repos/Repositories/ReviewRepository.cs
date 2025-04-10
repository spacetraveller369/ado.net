using Repos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Repositories
{
    public class ReviewRepository
    {
        private readonly MyDbContext _context;

        public ReviewRepository(MyDbContext context)
        {
            _context = context;
        }

        public void Add(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public List<Review> GetAll()
        {
            return _context.Reviews.ToList();
        }

        public Review? GetById(int id)
        {
            return _context.Reviews.Find(id);
        }

        public void Update(Review review)
        {
            var existReview = _context.Reviews.FirstOrDefault(u => u.Id == review.Id);

            if (existReview == null)
            {
                Console.WriteLine($"Review with ID {review.Id} not found.");
                return;
            }

            existReview.Text = review.Text;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
            }
        }
    }
}
