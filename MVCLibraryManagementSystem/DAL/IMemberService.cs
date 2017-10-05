using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCLibraryManagementSystem.Models;

namespace MVCLibraryManagementSystem.DAL
{
    public interface IMemberService: IDisposable
    {
        List<Member> GetAllMembers();
        Member GetMemberById(int? memberid);
        void Add(Member m);
        void Update(Member m);
        void Delete(int id);
    }
}
