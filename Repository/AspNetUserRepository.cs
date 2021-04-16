using MagazinJocuriVideo.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinJocuriVideo.Repository
{
    public class AspNetUserRepository
    {
        private MagazinJocuriVideoDataContextDataContext dbContext;
        public AspNetUserRepository()
        {
            dbContext = new MagazinJocuriVideoDataContextDataContext();
        }
        public AspNetUserRepository(MagazinJocuriVideoDataContextDataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void DeleteUser(Guid id)
        {
            AspNetUser user = dbContext.AspNetUsers.FirstOrDefault(x => x.Id == id.ToString());
            if(user!=null)
            {
                dbContext.AspNetUsers.DeleteOnSubmit(user);
                dbContext.SubmitChanges();
            }
        }
    }
}