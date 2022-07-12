using Tridi.Data.Dto;

namespace Tridi.Business.Interfaces
{
    public interface IMessageService
    {
        Task<CustomResponseDto<List<MessageDto>>> GetMessages(int fromUser, int toUser);
    }
}
