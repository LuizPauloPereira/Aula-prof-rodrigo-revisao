using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            CRUDEntities1 ctx = new CRUDEntities1();

            var listaProdutos = ctx.PRODUTO.ToList();
            return View(listaProdutos); 
        }
       // C = CRIAR
        public ActionResult Create()
        {
            return View();
        }
       [HttpPost]
        public ActionResult Create(PRODUTO produto)
        {
            if (ModelState.IsValid)
            {
                CRUDEntities1 ctx = new CRUDEntities1();
                ctx.PRODUTO.Add(produto);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
                return View();
        }
        //U = UPDATE
        public ActionResult Edit(int id)
        {
            CRUDEntities1 ctx = new CRUDEntities1();

            var objetoEmEdicao = ctx.PRODUTO.Find(id);
            return View(objetoEmEdicao);
        }
        [HttpPost]
        public ActionResult Edit(PRODUTO produto)
        {
            if (ModelState.IsValid)
            {
                CRUDEntities1 ctx = new CRUDEntities1();
                ctx.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //D = Deletar
        public ActionResult Delete(int id)
        {
            CRUDEntities1 ctx = new CRUDEntities1();

            var objetoEmExclisao = ctx.PRODUTO.Find(id);
            return View(objetoEmExclisao);
        }
        [HttpPost]
        public ActionResult Delete(PRODUTO produto)
        {
        
            CRUDEntities1 ctx = new CRUDEntities1();
            var objetoEmExclusao = ctx.PRODUTO.Find(produto.ProdutoID);
            ctx.PRODUTO.Remove(objetoEmExclusao);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}