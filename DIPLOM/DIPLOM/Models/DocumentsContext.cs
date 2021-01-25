using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DIPLOM.Models
{
    public class DocumentsContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
    public class DocumentsDbInitializer : DropCreateDatabaseAlways<DocumentsContext>
    {
        protected override void Seed(DocumentsContext db)
        {
            //db.Documents.Add(new Document { Name = "Шашки.docx", Manager = "Лакунина О.Н.", Student = "Васильев А.В.", Type = "Лабораторная работа", Path = "C:", Sta});

            db.Types.Add(new Type { Name = "Лабораторная работа" });
            db.Types.Add(new Type { Name = "Курсовая работа" });
            db.Types.Add(new Type { Name = "Семинар" });
            db.Types.Add(new Type { Name = "ВКР" });
            db.Types.Add(new Type { Name = "Производственная практика" });
            db.Types.Add(new Type { Name = "НИР" });

            db.Subjects.Add(new Subject { Name = "Программирование на ЯВУ" });
            db.Subjects.Add(new Subject { Name = "Физкультура" });
            db.Subjects.Add(new Subject { Name = "Дискретная математика" });
            db.Subjects.Add(new Subject { Name = "Экология" });
            db.Subjects.Add(new Subject { Name = "Теория вероятности" });

            db.Groups.Add(new Group { Name = "ИДБ-16-01" });
            db.Groups.Add(new Group { Name = "ИДБ-16-02" });
            db.Groups.Add(new Group { Name = "ИДБ-16-03" });
            db.Groups.Add(new Group { Name = "ИДБ-16-09" });
            db.Groups.Add(new Group { Name = "ИДБ-16-10" });

            db.Statuses.Add(new Status { Name = "Проверено" });
            db.Statuses.Add(new Status { Name = "Не Проверено" });
            base.Seed(db);
        }
    }
}