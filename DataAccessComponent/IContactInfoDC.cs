using System.Collections.Generic;

namespace DataAccessComponent
{
    public interface IContactInfoDC
    {
        /// <summary> Method to  insert details. </summary>
        bool InsertDetails(zUserDetail dataAccessContactModel);
        /// <summary> Method to  update details. </summary>
        bool UpdateDetails(zUserDetail dataAccessContactModel);
        /// <summary> Method to  get view for edit mode. </summary>
        zUserDetail EditRecord(int id);
        /// <summary> Method to delete record. </summary>
        bool DeleteRecord(int id);
        /// <summary> Method to get default view. </summary>
        List<zUserDetail> GetAllInfoList();
    }

}
