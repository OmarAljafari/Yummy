using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class TransactionContactUs
    {
        public int TransactionContactUsId { get; set; }
        [Display(Name ="Name")]
        public string TransactionContactUsName { get; set; }
        [Display(Name = "Message")]

        public string TransactionContactUsMessage { get; set; }
        [Display(Name = "Subject")]

        public string TransactionContactUsSubject { get; set; }
        [Display(Name = "Email")]

        public string TransactionContactUsEmail { get; set; }

    }
}
