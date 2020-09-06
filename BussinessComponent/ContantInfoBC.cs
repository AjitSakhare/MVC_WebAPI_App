using DataAccessComponent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BussinessComponent
{

    public class ContactInfoBC : IContactInfoBC
    {
        IContactInfoDC contInfoDAL;

        public ContactInfoBC(IContactInfoDC contInfoDAL)
        {
            this.contInfoDAL = contInfoDAL;
        }

        /// <summary>
        /// This BAL method is to insert record
        /// </summary>
        /// <param name="dataAccessContactModel"></param>
        /// <returns></returns>
        public bool InsertDetails(ContactInfoBALEntity dataAccessContactModel)
        {
            try
            {
                zUserDetail userDetail = new zUserDetail();
                userDetail.FirstName = dataAccessContactModel.FirstName;
                userDetail.LastName = dataAccessContactModel.LastName;
                userDetail.Email = dataAccessContactModel.Email;
                userDetail.PhoneNumber = dataAccessContactModel.PhoneNumber;
                userDetail.Status = dataAccessContactModel.Status;
                contInfoDAL.InsertDetails(userDetail);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This BAL method is to detele record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteRecord(int id)
        {
            try
            {
                bool result = contInfoDAL.DeleteRecord(id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This BAL method is to return record for edit mode
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContactInfoBALEntity EditRecord(int id)
        {
            try
            {
                ContactInfoBALEntity contactInfoBALEntity = new ContactInfoBALEntity();
                zUserDetail userDetail = contInfoDAL.EditRecord(id);
                contactInfoBALEntity.Id = userDetail.Id;
                contactInfoBALEntity.FirstName = userDetail.FirstName;
                contactInfoBALEntity.LastName = userDetail.LastName;
                contactInfoBALEntity.Email = userDetail.Email;
                contactInfoBALEntity.PhoneNumber = userDetail.PhoneNumber;
                contactInfoBALEntity.Status = userDetail.Status;
                return contactInfoBALEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This BAL method is to get all available list of details
        /// </summary>
        /// <returns></returns>
        public List<ContactInfoBALEntity> GetAllInfoList()
        {

            List<ContactInfoBALEntity> contactInfoBALEntities = new List<ContactInfoBALEntity>();
            try
            {
                List<zUserDetail> userDetail = contInfoDAL.GetAllInfoList();
                contactInfoBALEntities = (from user in contInfoDAL.GetAllInfoList().ToList()
                                          select user).Select(p => new ContactInfoBALEntity()
                                          {
                                              Id = p.Id,
                                              FirstName = p.FirstName,
                                              LastName = p.LastName,
                                              Email = p.Email,
                                              PhoneNumber = p.PhoneNumber,
                                              Status = p.Status
                                          }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return contactInfoBALEntities;
        }

        /// <summary>
        /// This BAL method is to udpate details
        /// </summary>
        /// <param name="dataAccessContactModel"></param>
        /// <returns></returns>
        public bool UpdateDetails(ContactInfoBALEntity dataAccessContactModel)
        {
            try
            {
                zUserDetail userDetail = new zUserDetail();
                userDetail.Id = dataAccessContactModel.Id;
                userDetail.FirstName = dataAccessContactModel.FirstName;
                userDetail.LastName = dataAccessContactModel.LastName;
                userDetail.Email = dataAccessContactModel.Email;
                userDetail.PhoneNumber = dataAccessContactModel.PhoneNumber;
                userDetail.Status = dataAccessContactModel.Status;
                contInfoDAL.UpdateDetails(userDetail);
                return contInfoDAL.UpdateDetails(userDetail);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
