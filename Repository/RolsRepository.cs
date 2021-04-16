using MagazinJocuriVideo.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagazinJocuriVideo.Repository
{
    public class RolsRepository
    {
        private MagazinJocuriVideoDataContextDataContext dbContext;
        public RolsRepository()
        {
            dbContext = new MagazinJocuriVideoDataContextDataContext();
        }
        public RolsRepository(MagazinJocuriVideoDataContextDataContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void TakeRols(string email)
        {
            AspNetUserRole rol = new AspNetUserRole();
            var id= dbContext.AspNetUsers.FirstOrDefault(x => x.Email == email);
            rol.UserId =id.Id;
            rol.RoleId = "1";
            dbContext.AspNetUserRoles.InsertOnSubmit(rol);
            dbContext.SubmitChanges();
        }
        public void DeleteUserRol(Guid id)
        {
            AspNetUserRole userRol = dbContext.AspNetUserRoles.FirstOrDefault(x => x.UserId == id.ToString());
            if(userRol!=null)
            {
                dbContext.AspNetUserRoles.DeleteOnSubmit(userRol);
                dbContext.SubmitChanges();
            }
        }

    }
}