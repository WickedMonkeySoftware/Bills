using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebFront.Models;

namespace WebFront.Controllers
{
    public class BankController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Bank/
        public async Task<ActionResult> Index()
        {
            var balances = db.Banks.Include(c => c.BankAccounts.Select(d => d.Balances));

            foreach (var b in balances)
            {
                var test = (from ev in b.BankAccounts
                            from be in ev.Balances
                            where be.EndOfDay == ev.Balances.Max(e => e.EndOfDay)
                            select be.Balance);
                ViewData[b.BankID.ToString()] = test.ToList()[0] / 100.0M;
            }
            
            return View(await balances.ToListAsync());
        }

        // GET: /Bank/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = await db.Banks.FindAsync(id);

            if (bank == null)
            {
                return HttpNotFound();
            }

            //todo : rememver that this is a list of bank accounts


            ViewBag.Balance = (from ev in bank.BankAccounts
                               from be in ev.Balances
                               where be.EndOfDay == ev.Balances.Max(e => e.EndOfDay)
                               select be.Balance).ToList()[0] / 100.0M;

            return View(bank);
        }

        // GET: /Bank/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Bank/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="BankID,Title")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                db.Banks.Add(bank);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(bank);
        }

        // GET: /Bank/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = await db.Banks.FindAsync(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        // POST: /Bank/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="BankID,Title")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bank).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bank);
        }

        // GET: /Bank/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = await db.Banks.FindAsync(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        // POST: /Bank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Bank bank = await db.Banks.FindAsync(id);
            db.Banks.Remove(bank);
            await db.SaveChangesAsync();
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
