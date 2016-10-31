using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChitChatter.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ChitChatter.Controllers
{
    public class ChitChatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChitChats
        public ActionResult Index()
        {
            return View(db.ChitChats.ToList());
        }

        // GET: ChitChats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChitChat chitChat = db.ChitChats.Find(id);
            if (chitChat == null)
            {
                return HttpNotFound();
            }
            return View(chitChat);
        }

        // GET: ChitChats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChitChats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChitChatID,ChitChatText,Id")] ChitChat chitChat)
        {
            if (ModelState.IsValid)
            {
                //Added by Valerie to get Curretn User
                UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());
                chitChat.ApplicationUser = currentUser;

                db.ChitChats.Add(chitChat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chitChat);
        }

        // GET: ChitChats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChitChat chitChat = db.ChitChats.Find(id);
            if (chitChat == null)
            {
                return HttpNotFound();
            }
            return View(chitChat);
        }

        // POST: ChitChats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChitChatID,ChitChatText")] ChitChat chitChat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitChat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chitChat);
        }

        // GET: ChitChats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChitChat chitChat = db.ChitChats.Find(id);
            if (chitChat == null)
            {
                return HttpNotFound();
            }
            return View(chitChat);
        }

        // POST: ChitChats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChitChat chitChat = db.ChitChats.Find(id);
            db.ChitChats.Remove(chitChat);
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
