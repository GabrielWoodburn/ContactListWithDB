using ContactsListDBWoodburn.Models;
using System.ComponentModel.DataAnnotations;

namespace ContactsListDBWoodburn.Models
{
    public class Contact
    {
        // EF will instruct the database to automatically generate this value
        public int ContactId { get; set; }

        [StringLength(70)]
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter an Address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a comment.")]

        public string CommentId { get; set; }

        public Comment Comment { get; set; }

        public string Slug =>
            Name?.Replace(' ', '-').ToLower();

    }
}
