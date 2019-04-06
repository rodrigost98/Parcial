using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIparcial.Models;

namespace APIparcial.Controllers
{
    public class RodrigoSantistevanFriendsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/RodrigoSantistevanFriends
        public IQueryable<RodrigoSantistevanFriend> GetRodrigoSantistevanFriends()
        {
            return db.RodrigoSantistevanFriends;
        }

        // GET: api/RodrigoSantistevanFriends/5
        [ResponseType(typeof(RodrigoSantistevanFriend))]
        public IHttpActionResult GetRodrigoSantistevanFriend(int id)
        {
            RodrigoSantistevanFriend rodrigoSantistevanFriend = db.RodrigoSantistevanFriends.Find(id);
            if (rodrigoSantistevanFriend == null)
            {
                return NotFound();
            }

            return Ok(rodrigoSantistevanFriend);
        }

        // PUT: api/RodrigoSantistevanFriends/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRodrigoSantistevanFriend(int id, RodrigoSantistevanFriend rodrigoSantistevanFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rodrigoSantistevanFriend.FriendID)
            {
                return BadRequest();
            }

            db.Entry(rodrigoSantistevanFriend).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RodrigoSantistevanFriendExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RodrigoSantistevanFriends
        [ResponseType(typeof(RodrigoSantistevanFriend))]
        public IHttpActionResult PostRodrigoSantistevanFriend(RodrigoSantistevanFriend rodrigoSantistevanFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RodrigoSantistevanFriends.Add(rodrigoSantistevanFriend);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rodrigoSantistevanFriend.FriendID }, rodrigoSantistevanFriend);
        }

        // DELETE: api/RodrigoSantistevanFriends/5
        [ResponseType(typeof(RodrigoSantistevanFriend))]
        public IHttpActionResult DeleteRodrigoSantistevanFriend(int id)
        {
            RodrigoSantistevanFriend rodrigoSantistevanFriend = db.RodrigoSantistevanFriends.Find(id);
            if (rodrigoSantistevanFriend == null)
            {
                return NotFound();
            }

            db.RodrigoSantistevanFriends.Remove(rodrigoSantistevanFriend);
            db.SaveChanges();

            return Ok(rodrigoSantistevanFriend);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RodrigoSantistevanFriendExists(int id)
        {
            return db.RodrigoSantistevanFriends.Count(e => e.FriendID == id) > 0;
        }
    }
}