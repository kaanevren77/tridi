

namespace Tridi.Data.Respository
{
    public interface IMessageRespository
    {
        Task<List<Tridi.Data.Entities.Message>> GetMessages(int fromUser, int toUser);
    }
}
