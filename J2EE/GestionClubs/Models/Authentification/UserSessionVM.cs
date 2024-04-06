using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Authentification
{
    public class UserSessionVM
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string AdresseMail { get; set; }
    }
}
