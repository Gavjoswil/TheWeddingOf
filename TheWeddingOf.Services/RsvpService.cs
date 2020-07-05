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
                    FoodTwo = model.FoodTwo,
                    YayOrNay  = model.YayOrNay,
                    Comments =  model.Comments
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
                                    RsvpId = e.RsvpId,
                                    Names = e.Names,
                                }
                                                    
                            );
                return query.ToArray();
            }
        }

        public bool UpdateRsvp(RsvpEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rsvps
                        .Single(e => e.RsvpId ==  model.RsvpId);

                entity.FoodOne = model.FoodOne;
                entity.FoodTwo = model.FoodTwo;
                entity.YayOrNay = model.YayOrNay;
                entity.Comments = model.Comments;

                return ctx.SaveChanges() == 1;
            }
        }

        public RsvpEdit GetRsvpById(int rsvpId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Rsvps
                        .Single(e => e.RsvpId == rsvpId);
                return
                    new RsvpEdit
                    {
                        RsvpId = entity.RsvpId,
                        Names = entity.Names,
                        FoodOne = entity.FoodOne,
                        FoodTwo = entity.FoodTwo,
                        YayOrNay = entity.YayOrNay,
                        Comments = entity.Comments
                    };
            }
        }

    }
}
