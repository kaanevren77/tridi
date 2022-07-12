using System;
using System.Collections.Generic;

namespace Tridi.Data.Entities
{
    public partial class Message
    {
        public int Id { get; set; }
        public int? FromId { get; set; }
        public int? ToId { get; set; }
        public string? MessageText { get; set; }

        public virtual User? From { get; set; }
        public virtual User? To { get; set; }
    }
}
