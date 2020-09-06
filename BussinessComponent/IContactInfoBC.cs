using System.Collections.Generic;

namespace BussinessComponent
{
    public interface IContactInfoBC
    {
        /// <summary> Method to  insert details. </summary>
        bool InsertDetails(ContactInfoBALEntity dataAccessContactModel);

        /// <summary> Method to  update details. </summary>
        bool UpdateDetails(ContactInfoBALEntity dataAccessContactModel);

        /// <summary> Method to  get view for edit mode. </summary>
        ContactInfoBALEntity EditRecord(int id);

        /// <summary> Method to delete record. </summary>
        bool DeleteRecord(int id);

        /// <summary> Method to get default view. </summary>
        List<ContactInfoBALEntity> GetAllInfoList();
    }
}
