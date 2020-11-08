using System.ComponentModel.DataAnnotations;

namespace blockchainGob.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}