using EntityFramework.Triggers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UserApi.Model
{
    public class EventLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdModel { get; set; }
        public string TableModel { get; set; }
        public string EventType { get; set; }
        public String TimesTamp { get; set; }  
    }
}
