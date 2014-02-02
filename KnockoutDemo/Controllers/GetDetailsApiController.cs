using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace KnockoutDemo.Controllers
{
    public class GetDetailsApiController : ApiController
    {
        private KnocoutDemoEntities db = new KnocoutDemoEntities();

        // GET api/GetDetailsApi
        public IEnumerable<UserDetail> GetUserDetails()
        {
            return db.UserDetails.AsEnumerable();
        }

        // GET api/GetDetailsApi/5
        public UserDetail GetUserDetail(string id)
        {
            UserDetail userdetail = db.UserDetails.Find(id);
            if (userdetail == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return userdetail;
        }

        // PUT api/GetDetailsApi/5
        public HttpResponseMessage PutUserDetail(string id, UserDetail userdetail)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != userdetail.UserID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(userdetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/GetDetailsApi
        public HttpResponseMessage PostUserDetail(UserDetail userdetail)
        {
            if (ModelState.IsValid)
            {
                db.UserDetails.Add(userdetail);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, userdetail);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = userdetail.UserID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/GetDetailsApi/5
        public HttpResponseMessage DeleteUserDetail(string id)
        {
            UserDetail userdetail = db.UserDetails.Find(id);
            if (userdetail == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.UserDetails.Remove(userdetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, userdetail);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}