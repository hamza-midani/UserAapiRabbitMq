using EntityFramework.Triggers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserApi.Interface; 
namespace UserApi.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cin { get; set; }
        public String toString()
        {
            return " Id : " + Id + " Firstname : " + Firstname + " Lastname : " + Lastname + " Created Date : " + CreatedDate;
        }
    }
}
