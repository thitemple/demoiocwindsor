using System.Data;
using System.Linq;
using System.Web.Mvc;
using Mvc4Windsor.Models;

namespace Mvc4Windsor.Controllers
{
    public class TarefaController : Controller
    {
        private TarefasContext db = new TarefasContext();

        //
        // GET: /Tarefa/

        public ActionResult Index()
        {
            return View(db.Tarefas.ToList());
        }

        //
        // GET: /Tarefa/Details/5

        public ActionResult Details(int id = 0)
        {
            Tarefa tarefa = db.Tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        //
        // GET: /Tarefa/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Tarefa/Create

        [HttpPost]
        public ActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Tarefas.Add(tarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tarefa);
        }

        //
        // GET: /Tarefa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tarefa tarefa = db.Tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        //
        // POST: /Tarefa/Edit/5

        [HttpPost]
        public ActionResult Edit(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }

        //
        // GET: /Tarefa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tarefa tarefa = db.Tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        //
        // POST: /Tarefa/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarefa tarefa = db.Tarefas.Find(id);
            db.Tarefas.Remove(tarefa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}