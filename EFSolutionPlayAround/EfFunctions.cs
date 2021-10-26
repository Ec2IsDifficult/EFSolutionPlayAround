using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EFSolutionPlayAround.Domain;

namespace EFSolutionPlayAround
{
    public interface IFunctions
    {
        IList<Category> GetCategories();
        bool CreateCategory(Category category);
    }

    public class EfFunctions : IFunctions
    {
        public bool CreateCategory(Category category)
        {
            var ctx = new NorthWindContext();
            category.Id = ctx.Categories.Max(x => x.Id) + 1;
            ctx.Add(category);
            return ctx.SaveChanges() > 0;
        }

        public IList<Category> GetCategories()
        {
            var ctx = new NorthWindContext();
            return ctx.Categories.ToList();
        }
    }
}