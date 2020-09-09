using BussinessComponent;
using ContactInfo.Web.ViewModel;
using NLog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ContactInfo.Web.Controllers
{
    [Route("api/ContInfoAPI/")]
    public class ContInfoAPIController : ApiController
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();
        IContactInfoBC contInfoBAL;
        public ContInfoAPIController(IContactInfoBC contInfoBAL)
        {
            this.contInfoBAL = contInfoBAL;
        }

        #region Manage Contact Information
        /// <summary>
        /// This API method is insert new data in database
        /// </summary>
        /// <param name="contactModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveInformation")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage InsertDetails(ContactModel contactModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return InsertModalDetails(contactModel);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "At GetAllInfoList API Method");
            }
            return RedirectToHomePage();
        }
        /// <summary>
        /// This method call Bussineess access layer insert method and pass contact modal
        /// </summary>
        /// <param name="contactModel"></param>
        /// <returns></returns>
        private HttpResponseMessage InsertModalDetails(ContactModel contactModel)
        {
            ContactInfoBALEntity contactBALModel = new ContactInfoBALEntity();
            contactBALModel.FirstName = contactModel.FirstName;
            contactBALModel.LastName = contactModel.LastName;
            contactBALModel.Email = contactModel.Email;
            contactBALModel.Status = true;
            contactBALModel.PhoneNumber = contactModel.PhoneNumber;
            contInfoBAL.InsertDetails(contactBALModel);
            return RedirectToHomePage();
        }

        /// <summary>
        /// This method redirect user to home page once data insertion completed
        /// </summary>
        /// <returns></returns>
        private HttpResponseMessage RedirectToHomePage()
        {
            string HomePageUrl = this.Url.Link("Default", new
            {
                Controller = "ContInfoWebMethod",
                Action = "ManageView"
            });
            var response = Request.CreateResponse(HttpStatusCode.Moved);
            response.Headers.Location = new Uri(HomePageUrl);
            return response;
        }

        /// <summary>
        /// This API method return list of all contact details which are active only
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllInfoList")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage GetAllInfoList()
        {
            try
            {
                List<ContactInfoBALEntity> contactModel = new List<ContactInfoBALEntity>();
                contactModel = contInfoBAL.GetAllInfoList();
                if(contactModel.Count>0)
                return Request.CreateResponse(HttpStatusCode.OK, contactModel);
                else
                return Request.CreateResponse(HttpStatusCode.OK, "No Record Found");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "At GetAllInfoList API Method");
                return Request.CreateResponse(HttpStatusCode.InternalServerError); ;
            }
        }

        /// <summary>
        /// This API method is to get record by using id to modify or change values
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("EditContDetails")]
        [EnableCors(origins: "*", headers: "*", methods: "GET")]
        public HttpResponseMessage EditDetails(int id)
        {
            try
            {
                ContactInfoBALEntity contactInfoBALEntity = new ContactInfoBALEntity();
                contactInfoBALEntity = contInfoBAL.EditRecord(id);
                return Request.CreateResponse(HttpStatusCode.OK, contactInfoBALEntity);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "At GetAllInfoList API Method");
                return Request.CreateResponse(HttpStatusCode.InternalServerError); ;
            }
        }

        /// <summary>
        /// This API method is to change the status of record from active to non active
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteContDetails")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage DeleteRecord(int id)
        {
            try
            {
                bool result = contInfoBAL.DeleteRecord(id);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "At GetAllInfoList API Method");
                return Request.CreateResponse(HttpStatusCode.InternalServerError); ;
            }
        }

        /// <summary>
        /// This method is to update or save modified details
        /// </summary>
        /// <param name="contactModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateContDetails")]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public HttpResponseMessage UpdateDetails(ContactModel contactModel)
        {
            try
            {
                return UpdateModalDetails(contactModel);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "At GetAllInfoList API Method");
                return Request.CreateResponse(HttpStatusCode.InternalServerError); ;
            }

        }
        /// <summary>
        /// This API method call Bussiness access layer method and pass object to update details
        /// </summary>
        /// <param name="contactModel"></param>
        /// <returns></returns>
        private HttpResponseMessage UpdateModalDetails(ContactModel contactModel)
        {
            if (ModelState.IsValid)
            {
                ContactInfoBALEntity contactBALModel = new ContactInfoBALEntity();
                contactBALModel.Id = contactModel.Id;
                contactBALModel.FirstName = contactModel.FirstName;
                contactBALModel.LastName = contactModel.LastName;
                contactBALModel.Email = contactModel.Email;
                contactBALModel.Status = contactModel.Status;
                contactBALModel.PhoneNumber = contactModel.PhoneNumber;
                contInfoBAL.UpdateDetails(contactBALModel);
                return Request.CreateResponse(HttpStatusCode.OK, "Updated Successfully");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }
        #endregion
    }
}
