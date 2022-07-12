using AutoMapper;
using Tridi.Business.Interfaces;
using Tridi.Data.Dto;
using Tridi.Data.Entities;
using Tridi.Data.Respository;
using Tridi.Data.Respository.Base;
using Tridi.Data.Respository.UnitOfWork;

namespace Tridi.Business.Services
{
    public class MessageService : Service<Tridi.Data.Entities.Message>, IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IMessageRespository _messageRespository;
        public MessageService(IRespositoryBase<Tridi.Data.Entities.Message> repository, IMessageRespository messageRespository,IUnitOfWork unitOfWork,IMapper mapper) : base(repository, unitOfWork)
        {
            _messageRespository = messageRespository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<MessageDto>>> GetMessages(int fromUser, int toUser)
        {
            var messages = await _messageRespository.GetMessages(fromUser, toUser);
            var list = _mapper.Map<List<MessageDto>>(messages);
            return CustomResponseDto<List<MessageDto>>.Success(200, list);
        }
    }
}
