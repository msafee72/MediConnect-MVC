using Microsoft.AspNetCore.Identity;
using System.Drawing;

namespace Medi_Connect.Models
{
    public class MyUser : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        //public string Role {  get; set; }

    }
}
