using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLibraryManagementSystem.Models
{
    public enum MEMBERTYPE
    {
        Faculty,
        Student
    }
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public MEMBERTYPE MemberType { get; set; }
    }
}