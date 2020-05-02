using System.ComponentModel.DataAnnotations;

namespace MicroLib.DesignPatternsTests.MockData.Models
{
    public class MocProfileInfo
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
    }
}