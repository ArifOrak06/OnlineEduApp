using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.DTOs.MessageDTOs;
using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.Exceptions;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Core.Services;
using OnlineEduApp.Core.Utilities.Uow;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.Service.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<MessageDtoForCreate>> CreateOneMessageAsync(MessageDtoForCreate messageDtoForCreate)
        {
            if(messageDtoForCreate == null)
                throw new ArgumentNullException(nameof(messageDtoForCreate));
            Message? newMessage = _mapper.Map<Message>(messageDtoForCreate);
            newMessage.CreatedDate = DateTime.UtcNow;
            newMessage.IsActive = true;
            newMessage.IsDeleted = false;
            newMessage.ModifiedDate = DateTime.UtcNow;
            await _repositoryManager.MessageRepository.CreateAsync(newMessage);

            await _unitOfWork.CommitAsync();
            return CustomResponseDto<MessageDtoForCreate>.Success(200, _mapper.Map<MessageDtoForCreate>(newMessage));
        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteOneMessageAsync(int messageId)
        {
            Message? currentMessage = await CheckMessageAsync(true, messageId);
            _repositoryManager.MessageRepository.Delete(currentMessage);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);

        }

        public async Task<(CustomResponseDto<List<MessageDto>> responseDto, MetaData metaData)> GetAllDeletedMessagesAsync(MessageParameters messageParameters)
        {
            PagedList<Message>? pagedItems = await _repositoryManager.MessageRepository.GetAllMessagesAsync(false,messageParameters,x => x.IsDeleted&&!x.IsActive);
            if(pagedItems is null)
                throw new ArgumentNullException(nameof(pagedItems));
            List<MessageDto> messageDtos = _mapper.Map<List<MessageDto>>(pagedItems);
            return (CustomResponseDto<List<MessageDto>>.Success(200, messageDtos), pagedItems.MetaData);
        }

        public async Task<(CustomResponseDto<List<MessageDto>> responseDto, MetaData metaData)> GetAllMessagesAsync(MessageParameters messageParameters)
        {
            PagedList<Message>? pagedItems = await _repositoryManager.MessageRepository.GetAllMessagesAsync(false, messageParameters, x => !x.IsDeleted && x.IsActive);
            if (pagedItems is null)
                throw new ArgumentNullException(nameof(pagedItems));
            List<MessageDto> messageDtos = _mapper.Map<List<MessageDto>>(pagedItems);
            return (CustomResponseDto<List<MessageDto>>.Success(200, messageDtos), pagedItems.MetaData);
        }

        public async Task<CustomResponseDto<List<MessageDto>>> GetAllNoPagingMessagesAsync()
        {
            List<Message>? messages = await _repositoryManager.MessageRepository.GetByFilter(false,x =>x.IsActive&&!x.IsDeleted).ToListAsync();
            if(messages is null)
                throw new ArgumentNullException(nameof(messages));
            return CustomResponseDto<List<MessageDto>>.Success(200, _mapper.Map<List<MessageDto>>(messages));
        }

        public async Task<CustomResponseDto<MessageDto>> GetOneMessageByIdAsync(int messageId)
        {
            Message? message = await CheckMessageAsync(false, messageId);
            return CustomResponseDto<MessageDto>.Success(200, _mapper.Map<MessageDto>(message));
        }

        public async Task<CustomResponseDto<NoContentDto>> SoftDeleteOneMessageAsync(int messageId)
        {
            Message? message = await CheckMessageAsync(true, messageId);
            message.IsActive = false;
            message.IsDeleted = true;
            message.ModifiedDate = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<MessageDtoForUpdate>> UpdateOneMessageAsync(int messageId, MessageDtoForUpdate messageDtoForUpdate)
        {
            if(messageDtoForUpdate is null && messageId != messageDtoForUpdate.Id)
                throw new EntityNotMatchedParameterBadRequestException();
            Message? message = await CheckMessageAsync(true, messageId);
            message.IsActive = messageDtoForUpdate.IsActive;
            message.IsDeleted = messageDtoForUpdate.IsActive ? false : true;
            message.ModifiedDate = DateTime.UtcNow;
            message.Email = messageDtoForUpdate.Email;
            message.Name = messageDtoForUpdate.Name;
            message.Subject = messageDtoForUpdate.Subject;  
            message.Content = messageDtoForUpdate.Content;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<MessageDtoForUpdate>.Success(200, _mapper.Map<MessageDtoForUpdate>(message));
        }

        private async Task<Message> CheckMessageAsync(bool trackChanges, int messageId)
        {
            Message? message = await _repositoryManager.MessageRepository.GetByFilter(trackChanges, x => x.Id.Equals(messageId)).SingleOrDefaultAsync();
            if (message is null)
                throw new MessageNotFoundException(messageId);
            return message;

        }
    }
}
