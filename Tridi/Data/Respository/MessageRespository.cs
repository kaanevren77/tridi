
using Microsoft.EntityFrameworkCore;
using Tridi.Data.Respository.Base;

namespace Tridi.Data.Respository
{
    public class MessageRespository : RespositoryBase<Tridi.Data.Entities.Message>, IMessageRespository
    {
        public MessageRespository(Entities.TridiContext context) : base(context)
        {
        }

        public async Task<List<Tridi.Data.Entities.Message>> GetMessages(int fromUser, int toUser)
        {
            return await _context.Messages.Include(x => x.From)
                .Include(x => x.From)
                .Where(x => (x.FromId == fromUser && x.ToId == toUser) || (x.ToId == fromUser && x.FromId == toUser))
                .ToListAsync();
        }
    }
}
