using System.ComponentModel.DataAnnotations;

namespace Yummy.Models
{
    public class TransactionBook
    {
        public int TransactionBookId { get; set; }
        [Display(Name ="Name")]
        public string TransactionBookName { get; set;}
        [Display(Name = "Message")]

        public string TransactionBookMessage { get; set;}
        [Display(Name = "Email")]

        public string TransactionBookEmail { get; set; }
        [Display(Name = "Number of People")]

        public int TransactionBookNumberOfPeople { get; set; }
        [Display(Name = "Date of Book")]

        [DataType(DataType.Date)]
        public DateTime TransactionBookDate { get; set; }
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public int TransactionBookPhone { get; set; }
        [Display(Name = "Time of Book")]
        [DataType(DataType.Time)]
        public DateTime TransactionBookTime { get; set; }

    }
}
