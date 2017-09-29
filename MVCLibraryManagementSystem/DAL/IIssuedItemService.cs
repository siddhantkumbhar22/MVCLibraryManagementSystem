using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCLibraryManagementSystem.Models;

namespace MVCLibraryManagementSystem.DAL
{
    public interface IIssuedItemService
    {
        List<IssuedItem> GetAllIssuedItems();
        void Add(IssuedItem i);
        void Update(IssuedItem i);
        void Delete(int id);
        IssuedItem GetIssuedItemById(int? id);

        /// <summary>
        /// Get all Acc. Record instance available for issue
        /// </summary>
        /// <returns>Acc. Records that aren't in the IssuedItems list</returns>
        List<AccessionRecord> GetAllUnissuedAccRecords();
    }
}
