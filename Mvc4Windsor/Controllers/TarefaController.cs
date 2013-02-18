using System.Linq;
using System.Web.Mvc;
using Mvc4Windsor.Models;
using Mvc4Windsor.Models.Repository;

namespace Mvc4Windsor.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController() : this(new TarefaEntityFrameworkRepository())
        {
            
        }

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        //
        // GET: /Tarefa/

        public ActionResult Index()
        {
            return View(_tarefaRepository.All().ToList());
        }

        //
        // GET: /Tarefa/Details/5

        public ActionResult Details(int id = 0)
        {
            Tarefa tarefa = _tarefaRepository.Find(id);
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
                _tarefaRepository.Add(tarefa);
                return RedirectToAction("Index");
            }

            return View(tarefa);
        }

        //
        // GET: /Tarefa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tarefa tarefa = _tarefaRepository.Find(id);
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
                _tarefaRepository.Update(tarefa);
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }

        //
        // GET: /Tarefa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tarefa tarefa = _tarefaRepository.Find(id);
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
            _tarefaRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}