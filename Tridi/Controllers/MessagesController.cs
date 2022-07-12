using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tridi.Business.Interfaces;
using Tridi.Controllers.Base;
using Tridi.Data.Dto;
using Tridi.Data.Entities;

namespace Tridi.Controllers
{
    public class MessagesController : CustomBaseController
    {

        private readonly IMessageService _messageService;
        private readonly IService<Message> _service;
        private readonly IMapper _mapper;
        public MessagesController(IUserService userService, IService<Message> service, IMessageService messageService, IMapper mapper)
        {

            _messageService = messageService;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessages(int id)
        {
            var messages = await _messageService.GetMessages(1, id);

            return CreateActionResult(messages);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(int id, string messageText)
        {
            var userId = GetSessionUser().Id;
            MessageDto dto = new MessageDto
            {
                FromId = userId,
                ToId = id,
                MessageText = messageText
            };

            var message = await _service.AddAsync(_mapper.Map<Message>(dto));
            var messageDto = _mapper.Map<MessageDto>(message);
            return CreateActionResult(CustomResponseDto<MessageDto>.Success(201, messageDto));
        }
    }
}
