﻿/**********************************************************************************************************************/
/*	Domain		:	MySql.Web.Security.OAuthMembership
/*	Creator		:	KIM-KIWON\xyz37(Kim Ki Won)
/*	Create		:	Thursday, April 11, 2013 10:36 AM
/*	Purpose		:	webpages_OAuthMembership Table Entity class
/*--------------------------------------------------------------------------------------------------------------------*/
/*	Modifier	:	
/*	Update		:	
/*	Changes		:	
/*--------------------------------------------------------------------------------------------------------------------*/
/*	Comment		:	
CREATE TABLE [dbo].[webpages_OAuthMembership] (
	[Provider]       NVARCHAR (30)  NOT NULL,
	[ProviderUserId] NVARCHAR (100) NOT NULL,
	[UserId]         INT            NOT NULL,
	PRIMARY KEY CLUSTERED ([Provider] ASC, [ProviderUserId] ASC)
);
/*--------------------------------------------------------------------------------------------------------------------*/
/*	Reviewer	:	Kim Ki Won
/*	Rev. Date	:	
/**********************************************************************************************************************/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.Model.Entities
{
    /// <summary>
    /// webpages_OAuthMembership Table Entity class
    /// </summary>
    [Table("webpages_OAuthMembership")]
    public class OAuthMembership
    {
        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        /// <value>The provider.</value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1, TypeName = "nvarchar"), StringLength(30)]
        public string Provider
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the provider user id.
        /// </summary>
        /// <value>The provider user id.</value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 2, TypeName = "nvarchar"), StringLength(100)]
        public string ProviderUserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>The user id.</value>
        [Column(Order = 3)]
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user profile.
        /// </summary>
        /// <value>The user.</value>
        [ForeignKey("UserId")]
        public virtual UserProfile UserProfile
        {
            get;
            set;
        }
    }
}