using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Model.Entities
{
    /// <summary>
    /// webpages_UsersInRoles Table Entity class
    /// </summary>
    [Table("webpages_UsersInRoles")]
    public class UsersInRoles
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id.</value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1)]
        [Display(Name = "UsersInRoles_UserId")]
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the role id.
        /// </summary>
        /// <value>The role id.</value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 2)]
        [Display(Name = "UsersInRoles_RoleId")]
        public int RoleId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user profile.
        /// </summary>
        /// <value>The user profile.</value>
        [ForeignKey("UserId")]
        public virtual UserProfile UserProfile
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>The role.</value>
        [ForeignKey("RoleId")]
        public virtual Role Role
        {
            get;
            set;
        }
    }

}