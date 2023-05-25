using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoIOB.Models;
using System.Data.Entity.Core.Objects;
using System.Xml;
using System.Web.UI.WebControls;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;

namespace ProjetoIOB.Controllers
{
    public class ContatoController : Controller
    {
        IOBBDEntities db = new IOBBDEntities();              

        // GET: Contato
        public ActionResult Index()
        {
            List<sp_viewAllContato_Result> list = new List<sp_viewAllContato_Result>();
            list = db.sp_viewAllContato().ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CONTATO dados)
        {
            ObjectParameter obj = new ObjectParameter("idout", typeof(int));
            int result = db.sp_insertupdate_contato(dados.ID, dados.NOME, dados.TELEFONE, dados.TELEFONE_AUX,
                dados.EMAIL, dados.DATA_NASCIMENTO, dados.CEP, dados.RUA, dados.NUMERO, dados.COMPLEMENTO, dados.BAIRRO, dados.CIDADE,
                dados.ESTADO, obj);

            this.db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            sp_viewContatoById_Result contato = new sp_viewContatoById_Result();
            contato = db.sp_viewContatoById(id).FirstOrDefault();
            this.db.SaveChanges();

            return View(contato);
        }


        [HttpPost]
        public ActionResult Edit(CONTATO dados)
        {
            ObjectParameter obj = new ObjectParameter("idout", typeof(int));
            int result = db.sp_insertupdate_contato(dados.ID, dados.NOME, dados.TELEFONE, dados.TELEFONE_AUX,
                dados.EMAIL, dados.DATA_NASCIMENTO, dados.CEP, dados.RUA, dados.NUMERO, dados.COMPLEMENTO, dados.BAIRRO, dados.CIDADE,
                dados.ESTADO, obj);

            this.db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id) 
        {
            sp_viewContatoById_Result contato = new sp_viewContatoById_Result();
            contato = db.sp_viewContatoById(id).FirstOrDefault();
            this.db.SaveChanges();

            return View(contato);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            int result = db.sp_deleteContato(id);
            this.db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Backup()
        {
            List<sp_viewAllContato_Result> list = new List<sp_viewAllContato_Result>();
            list = db.sp_viewAllContato().ToList();

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {                
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = ("    ");
                settings.CloseOutput = true;
                settings.OmitXmlDeclaration = true;

                using (XmlWriter writer = XmlWriter.Create((dialog.FileName + @"\backup.xml"), settings))
                {
                    writer.WriteStartElement("Contatos");

                    foreach (var item in list)
                    {                        
                        writer.WriteElementString("ID", item.ID.ToString());
                        writer.WriteElementString("NOME", item.NOME);
                        writer.WriteElementString("TELEFONE", item.TELEFONE);
                        writer.WriteElementString("TELEFONE_AUX", item.TELEFONE_AUX);
                        writer.WriteElementString("EMAIL", item.EMAIL);
                        writer.WriteElementString("DATA_NASCIMENTO", item.DATA_NASCIMENTO.ToString());
                        writer.WriteElementString("CEP", item.CEP.ToString());
                        writer.WriteElementString("RUA", item.RUA);
                        writer.WriteElementString("NUMERO", item.NUMERO.ToString());
                        writer.WriteElementString("COMPLEMENTO", item.COMPLEMENTO);
                        writer.WriteElementString("BAIRRO", item.BAIRRO);
                        writer.WriteElementString("CIDADE", item.CIDADE);
                        writer.WriteElementString("ESTADO", item.ESTADO);
                    }

                    writer.WriteEndElement();
                    writer.Flush();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        
    }
}