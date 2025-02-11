﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PlanIt.Models
{
    public class Club_memberController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Club_member
        public ActionResult Index()
        {
            var club_member = db.Club_member.Include(c => c.Club).Include(c => c.Position).Include(c => c.Student);
            return View(club_member.ToList());
        }

        // GET: Club_member/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club_member club_member = db.Club_member.Find(id);
            if (club_member == null)
            {
                return HttpNotFound();
            }
            return View(club_member);
        }

        // GET: Club_member/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club_member club_member = db.Club_member.Find(id);
            if (club_member == null)
            {
                return HttpNotFound();
            }
             //ViewBag.Club_idClub = db.Clubs.Where(t => t.idClub == club_member.Club_idClub).Select(t => t.Name);
//            @Html.EditorFor(model => model.Club_idClub, new { htmlAttributes = new { @class = "form-control" } });

             ViewBag.Club_idClub = new SelectList(db.Clubs, "idClub", "Name", club_member.Club_idClub);
   
            ViewBag.Positions_idPositions = new SelectList(db.Positions, "idPositions", "Name", club_member.Positions_idPositions);
            ViewBag.Student_idStudent = new SelectList(db.Students, "idStudent", "Name", club_member.Student_idStudent);
            return View(club_member);
        }

        // POST: Club_member/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idClub_members,Positions_idPositions,Student_idStudent,Club_idClub")] Club_member club_member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(club_member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Club_idClub = new SelectList(db.Clubs, "idClub", "Name", club_member.Club_idClub);
            ViewBag.Positions_idPositions = new SelectList(db.Positions, "idPositions", "Name", club_member.Positions_idPositions);
            ViewBag.Student_idStudent = new SelectList(db.Students, "idStudent", "Name", club_member.Student_idStudent);
            return View(club_member);
        }

        // GET: Club_member/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club_member club_member = db.Club_member.Find(id);
            if (club_member == null)
            {
                return HttpNotFound();
            }
            return View(club_member);
        }

        // POST: Club_member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Club_member club_member = db.Club_member.Find(id);
            db.Club_member.Remove(club_member);
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
