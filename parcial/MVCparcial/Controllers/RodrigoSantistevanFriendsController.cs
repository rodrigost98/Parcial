using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCparcial.Models;

namespace MVCparcial.Controllers
{
    public class RodrigoSantistevanFriendsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: RodrigoSantistevanFriends
        public ActionResult Index()
        {
            return View(db.RodrigoSantistevanFriends.ToList());
        }

        // GET: RodrigoSantistevanFriends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RodrigoSantistevanFriend rodrigoSantistevanFriend = db.RodrigoSantistevanFriends.Find(id);
            if (rodrigoSantistevanFriend == null)
            {
                return HttpNotFound();
            }
            return View(rodrigoSantistevanFriend);
        }

        // GET: RodrigoSantistevanFriends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RodrigoSantistevanFriends/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FriendID,Nombre,Nickname,Birthdate,Friend,Status")] RodrigoSantistevanFriend rodrigoSantistevanFriend)
        {
            if (ModelState.IsValid)
            {
                db.RodrigoSantistevanFriends.Add(rodrigoSantistevanFriend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rodrigoSantistevanFriend);
        }

        // GET: RodrigoSantistevanFriends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RodrigoSantistevanFriend rodrigoSantistevanFriend = db.RodrigoSantistevanFriends.Find(id);
            if (rodrigoSantistevanFriend == null)
            {
                return HttpNotFound();
            }
            return View(rodrigoSantistevanFriend);
        }

        // POST: RodrigoSantistevanFriends/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FriendID,Nombre,Nickname,Birthdate,Friend,Status")] RodrigoSantistevanFriend rodrigoSantistevanFriend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rodrigoSantistevanFriend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rodrigoSantistevanFriend);
        }

        // GET: RodrigoSantistevanFriends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RodrigoSantistevanFriend rodrigoSantistevanFriend = db.RodrigoSantistevanFriends.Find(id);
            if (rodrigoSantistevanFriend == null)
            {
                return HttpNotFound();
            }
            return View(rodrigoSantistevanFriend);
        }

        // POST: RodrigoSantistevanFriends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RodrigoSantistevanFriend rodrigoSantistevanFriend = db.RodrigoSantistevanFriends.Find(id);
            db.RodrigoSantistevanFriends.Remove(rodrigoSantistevanFriend);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
