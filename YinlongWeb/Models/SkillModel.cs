using System.ComponentModel;

namespace YinlongWeb.Models
{
    public class SkillModel
    {
        [DisplayName("Order")]
        public int Id { get; set; }

        [DisplayName("Skills")]
        public string Skill { get; set; }

        [DisplayName("Platforms | Programs")]
        public string Platform { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

    }
}
