using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DIPLOM.Models;
using System.Data.Entity;

namespace DIPLOM.Controllers
{
    public class HomeController : Controller
    {
        DocumentsContext db = new DocumentsContext();

        public ActionResult Index(string Name, string Subject, string Group, string Type, string Student, string Manager, string Status, DateTime? DateCreate, DateTime? DateChange)
        {
            ViewBag.Documents = db.Documents;
            ViewBag.FName = Name;
            ViewBag.FSubject = Subject;
            ViewBag.FGroup = Group;
            ViewBag.FType = Type;
            ViewBag.FStudent = Student;
            ViewBag.FManager = Manager;
            ViewBag.FStatus = Status;
            if (Name != null || Subject != null || Group != null || Type != null || Student != null || Manager != null || Status != null)
                ViewBag.Filtr = 1;
            else
                ViewBag.Filtr = 0;
            return View();
        }
        
        [HttpGet]
        public ActionResult Create(int? id)
        {
            Document b = db.Documents.Find(id);
            ViewBag.Documents = db.Documents;
            ViewBag.currentId = id;
            ViewBag.Typ = db.Types;
            ViewBag.Sub = db.Subjects;
            ViewBag.Group = db.Groups;
            ViewBag.Status = db.Statuses;
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Document document, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                document.Name = System.IO.Path.GetFileName(upload.FileName);
                System.IO.Directory.CreateDirectory(Server.MapPath("~\\App_Data\\UploadedFiles\\") + document.Manager + "\\" + document.Subject + "\\" + document.Type + "\\" + document.Group + "\\" + document.Student);
                document.Path = Server.MapPath("~\\App_Data\\UploadedFiles\\" + document.Manager + "\\" + document.Subject + "\\" + document.Type + "\\" + document.Group + "\\" + document.Student + "\\" + document.Name);
                upload.SaveAs(document.Path);
            }
            document.DateChange = DateTime.Now;
            db.Entry(document).State = System.Data.Entity.EntityState.Modified; 
            db.SaveChanges();
            return Redirect("/Home/Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Document document, HttpPostedFileBase upload)
        {
            if (upload!=null)
            {
                document.Name = System.IO.Path.GetFileName(upload.FileName);
                System.IO.Directory.CreateDirectory(Server.MapPath("~\\App_Data\\UploadedFiles\\") + document.Manager + "\\" + document.Subject + "\\" + document.Type + "\\" + document.Group + "\\" + document.Student);
                document.Path = Server.MapPath("~\\App_Data\\UploadedFiles\\" + document.Manager + "\\" + document.Subject + "\\" + document.Type + "\\" + document.Group + "\\" + document.Student + "\\" + document.Name);
                upload.SaveAs(document.Path);
            }
            document.DateCreate = DateTime.Now;
            document.DateChange = DateTime.Now;
            db.Documents.Add(document);
            db.SaveChanges();
            return Redirect("/Home/Index");
        }

        public ActionResult Delete(int id)
        {
            Document b = db.Documents.Find(id);
            if(b!=null)
            {
                if(System.IO.File.Exists(b.Path))
                {
                    System.IO.File.Delete(b.Path);
                }
                db.Documents.Remove(b);
                db.SaveChanges();
            }
            return Redirect("/Home/Index");
        }

        public FileResult GetFile(string Path, int id)
        {
            Document b = db.Documents.Find(id);
            string file_type = "application/octet-stream";
            return File(b.Path, file_type, b.Name);
        }
    }
}