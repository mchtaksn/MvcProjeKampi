using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key] 
        public int MessageID { get; set; }
        [StringLength(100)]
        public string? SenderMail { get; set; }
        [StringLength(100)]
        public string? ReceiverMail { get; set; }
        [StringLength(100)]
        public String? Subject { get; set; }
        public String? MessageContent { get; set; }
        public DateTime? MassageDate { get; set; }
    }
}
