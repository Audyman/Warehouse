using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Model.Entities
{
    /// <summary>
    /// webpages_Roles Table Entity class
    /// </summary>
    [Table("webpages_Roles")]
    public class Role
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Role"/> class.
        /// </summary>
        public Role()
        {
        }

        /// <summary>
        /// Gets or sets the role id.
        /// </summary>
        /// <value>The role id.</value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Role_RoleId")]
        public int RoleId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>The name of the role.</value>
        [Column(TypeName = "nvarchar"), StringLength(256)]
        [Display(Name = "Role_RoleName")]
        public string RoleName
        {
            get;
            set;
        }
    }
}