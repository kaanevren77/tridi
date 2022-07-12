using Tridi.Models;

namespace Tridi.Data.Dto
{
    public class MessageDto
    {
        public int? FromId { get; set; }
        public int? ToId { get; set; }
        public string? MessageText { get; set; }
        public UserModel? From { get; set; }
        public UserModel? To { get; set; }
    }
}
