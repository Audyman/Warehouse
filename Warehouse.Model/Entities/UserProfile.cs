using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Model.Entities
{
    /// <summary>
    /// UserProfile Table Entity class
    /// </summary>
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(Order = 0)]
        public int UserId { get; set; }

        [Required, Column(Order = 1)]
        public string UserName { get; set; }

        [MaxLength(110), Column(Order = 2)]
        public string Email { get; set; }

        [MaxLength(100), Column(Order = 3)]
        public string FirstName { get; set; }

        [MaxLength(100), Column(Order = 4)]
        public string LastName { get; set; }
    }
}