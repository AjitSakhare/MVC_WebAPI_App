using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessComponent
{
    public class ContactInfoDC : IContactInfoDC
    {
        ContactInfoEntities contactInfoEntities = new ContactInfoEntities();

        private readonly IContactInfoDC _iContactInfoDC;

        private readonly ContactInfoEntities _context;

        public ContactInfoDC(ContactInfoEntities c)
        {
            this._context = c;
        }

        /// <summary>
        /// This DAL method is to insert record form Database
        /// </summary>
        /// <param name="dataAccessContactModel"></param>
        /// <returns></returns>
        public bool InsertDetails(zUserDetail dataAccessContactModel)
        {
            try
            {
                if (dataAccessContactModel == null)
                {
                    throw new ArgumentNullException(nameof(ExceptionTypes.ArgumentNullException));
                }
                contactInfoEntities.zUserDetails.Add(dataAccessContactModel);
                contactInfoEntities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This DAL method is to delete record form Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteRecord(int id)
        {
            try
            {
                zUserDetail contInfoId = contactInfoEntities.zUserDetails.ToList().Where(x => x.Id.Equals(id)).FirstOrDefault();
                contInfoId.Status = false;
                contactInfoEntities.Entry(contInfoId).State = EntityState.Modified;
                contactInfoEntities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// This DAL method is to get record in edit mode form Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public zUserDetail EditRecord(int id)
        {
            try
            {
                return contactInfoEntities.zUserDetails.ToList().Find(x => x.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This DAL method return all active status available list of contact from database
        /// </summary>
        /// <returns></returns>
        public List<zUserDetail> GetAllInfoList()
        {
            try
            {
                return contactInfoEntities.zUserDetails.ToList().Where(x => x.Status == true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This DAL method is to update details in database
        /// </summary>
        /// <param name="dataAccessContactModel"></param>
        /// <returns></returns>
        public bool UpdateDetails(zUserDetail dataAccessContactModel)
        {
            try
            {
                contactInfoEntities.Entry(dataAccessContactModel).State = EntityState.Modified;
                contactInfoEntities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
