using Lookif.Layers.Core.Enums;
using Lookif.Layers.Core.MainCore.Base;
using Lookif.Library.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleExpenseManagement.Share.Models.Users
{
    /// <summary>
    /// This user entity is user projection for Reading concept
    /// </summary>
    public interface IUserSelectDto : IEntity, IActive
    {
          
        /// <summary>
        /// UserName of this entity
        /// </summary>
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
        /// <summary>
        /// Email(*@*.*)
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        public string ImagePath { get; set; }
 
        /// <summary>
        /// Fullname
        /// </summary>
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        /// <summary>
        /// Age
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Male or female
        /// </summary>
        public GenderType Gender { get; set; }
         

        /// <summary>
        /// More Detail about ME!
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Is he in charge or not
        /// </summary>
        public bool IsInRole { get; set; }


        public bool Block { get; set; }
    } 
}
