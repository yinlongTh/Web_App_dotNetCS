using System.ComponentModel;

namespace YinlongWeb.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        [DisplayName("Your Name")]
        public string Name { get; set; }

        public string Country { get; set; }
        public string Comment { get; set; }
        
    }
}
