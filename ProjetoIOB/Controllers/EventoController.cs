using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoIOB.Models;
using System.Data.Entity.Core.Objects;

namespace ProjetoIOB.Controllers
{
    public class EventoController : Controller
    {
        IOBBDEntities db = new IOBBDEntities();

        // GET: Contato
        public ActionResult Index()
        {
            List<sp_viewAllEvento_Result> list = new List<sp_viewAllEvento_Result>();
            list = db.sp_viewAllEvento().ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EVENTO dados)
        {
            ObjectParameter obj = new ObjectParameter("idout", typeof(int));
            int result = db.sp_insertupdate_evento(dados.ID, dados.NOME, dados.DATA, dados.DESCRICAO, obj);

            this.db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            sp_viewEventoById_Result evento = new sp_viewEventoById_Result();
            evento = db.sp_viewEventoById(id).FirstOrDefault();
            this.db.SaveChanges();

            return View(evento);
        }


        [HttpPost]
        public ActionResult Edit(EVENTO dados)
        {
            ObjectParameter obj = new ObjectParameter("idout", typeof(int));
            int result = db.sp_insertupdate_evento(dados.ID, dados.NOME, dados.DATA, dados.DESCRICAO, obj);

            this.db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            sp_viewEventoById_Result evento = new sp_viewEventoById_Result();
            evento = db.sp_viewEventoById(id).FirstOrDefault();
            this.db.SaveChanges();

            return View(evento);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            int result = db.sp_deleteEvento(id);
            this.db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}