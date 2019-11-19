using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWeddingOf.Data;
using TheWeddingOf.Models;

namespace TheWeddingOf.Services
{
    public class RsvpService
    {
        private readonly Guid _userId;

        public RsvpService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRsvp(RsvpCreate model)
        {
            var entity =
                new Rsvp()
                {
                    Names = model.Names,
                    FoodOne = model.FoodOne,
                    FoodTwo = model.FoodTwo
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Rsvps.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RsvpListItem> GetRsvps()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Rsvps
                        .Select(
                            e =>
                                new RsvpListItem
                                {
                                    Names = e.Names,
                                    FoodOne = e.FoodOne,
                                    FoodTwo = e.FoodTwo
                                }
                                                    
                            );
                return query.ToArray();
            }
        }
    }
}
