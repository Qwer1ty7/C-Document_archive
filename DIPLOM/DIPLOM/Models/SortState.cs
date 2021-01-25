using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIPLOM.Models
{
    public enum SortState
    {
        NameAsc, // по имени по возрастанию
        NameDesc, // по имени по убыванию
        TypeAsc,
        TypeDesc,
        ManagerAsc,
        ManagerDesc,
        StudentAsc,
        StudentDesc,
        DateCreateAsc,
        DateCreateDesc,
        StatusAsc,
        StatusDesc,
        GroupAsc,
        GroupDesc,
        SubjectAsc,
        SubjectDesc
    }
}