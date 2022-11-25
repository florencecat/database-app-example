using DAL.Entities;
using System;

namespace BLL.Models
{
    public class ManagerModel
    {
        public Guid userID { get; set; }
        public Guid organization { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public ManagerModel() { }
        public ManagerModel(Manager m)
        {
            this.userID = m.userID;
            this.organization = m.organization;
            this.name = m.name;
            this.nickname = m.nickname;
            this.email = m.email;
            this.password = m.password;
        }
    }
}
