using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Model.Entities
{
    /// <summary>
    ///  Table Entity class
    /// </summary>
    [Table("webpages_Membership")]
    public class Membership
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Membership"/> class.
        /// </summary>
        public Membership()
        {
        }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id.</value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column(Order = 0)]
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>The create date.</value>
        [DataType(DataType.DateTime)]
        public DateTime? CreateDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the confirmation token.
        /// </summary>
        /// <value>The confirmation token.</value>
        [Column(TypeName = "nvarchar"), StringLength(128)]
        public string ConfirmationToken
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is confirmed.
        /// </summary>
        /// <value><c>null</c> if [is confirmed] contains no value, <c>true</c> if [is confirmed]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool? IsConfirmed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the last password failure date.
        /// </summary>
        /// <value>The last password failure date.</value>
        [DataType(DataType.DateTime)]
        public DateTime? LastPasswordFailureDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the password failures since last success.
        /// </summary>
        /// <value>The password failures since last success.</value>
        [DefaultValue(0)]
        public int PasswordFailuresSinceLastSuccess
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        [Column(TypeName = "nvarchar"), StringLength(128)]
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the password changed date.
        /// </summary>
        /// <value>The password changed date.</value>
        [DataType(DataType.DateTime)]
        public DateTime? PasswordChangedDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the password salt.
        /// </summary>
        /// <value>The password salt.</value>
        [Column(TypeName = "nvarchar"), StringLength(128)]
        public string PasswordSalt
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the password verification token.
        /// </summary>
        /// <value>The password verification token.</value>
        [Column(TypeName = "nvarchar"), StringLength(128)]
        public string PasswordVerificationToken
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the password verification token expiration date.
        /// </summary>
        /// <value>The password verification token expiration date.</value>
        [DataType(DataType.DateTime)]
        public DateTime? PasswordVerificationTokenExpirationDate
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
    }
}