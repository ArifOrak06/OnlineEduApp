using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.DTOs.SubscriberDTOs;
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
    public class SubscriberService : ISubscriberService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubscriberService(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<SubscriberDtoForCreate>> CreateOneSubscriberAsync(SubscriberDtoForCreate subscriberDtoForCreate)
        {
            if (subscriberDtoForCreate == null)
                throw new ArgumentNullBadRequestException();
            Subscriber? newSubscriber = _mapper.Map<Subscriber>(subscriberDtoForCreate);
            newSubscriber.IsActive = true;
            newSubscriber.IsDeleted = false;
            newSubscriber.CreatedDate = DateTime.UtcNow;
            newSubscriber.ModifiedDate = DateTime.UtcNow;
            await _repositoryManager.SubscriberRepository.CreateAsync(newSubscriber);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<SubscriberDtoForCreate>.Success(204,_mapper.Map<SubscriberDtoForCreate>(newSubscriber));
        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteOneSubscriberAsync(int subscriberId)
        {
            Subscriber? currentSubscriber = await CheckEntityAsync(true, subscriberId);
            _repositoryManager.SubscriberRepository.Delete(currentSubscriber);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(201);

        }

        public async Task<(CustomResponseDto<List<SubscriberDto>> responseDto, MetaData metaData)> GetAllDeletedSubscribersAsync(SubscriberParameters subscriberParameters)
        {
            PagedList<Subscriber>? subsAndMetaData = await _repositoryManager.SubscriberRepository.GetAllSubscribersAsync(false, x => x.IsActive && !x.IsDeleted, subscriberParameters);
            if (subsAndMetaData.Count < 1)
                throw new ArgumentException(nameof(subsAndMetaData));
            List<SubscriberDto> subscriberDtos = _mapper.Map<List<SubscriberDto>>(subsAndMetaData);
            return (CustomResponseDto<List<SubscriberDto>>.Success(200, subscriberDtos), subsAndMetaData.MetaData);
        }

        public async Task<(CustomResponseDto<List<SubscriberDto>> responseDto, MetaData metaData)> GetAllSubscribersAsync(SubscriberParameters subscriberParameters)
        {
            PagedList<Subscriber>? subsAndMetaData = await _repositoryManager.SubscriberRepository.GetAllSubscribersAsync(false, x => !x.IsActive && x.IsDeleted, subscriberParameters);
            if (subsAndMetaData.Count < 1)
                throw new ArgumentException(nameof(subsAndMetaData));
            List<SubscriberDto> subscriberDtos = _mapper.Map<List<SubscriberDto>>(subsAndMetaData);
            return (CustomResponseDto<List<SubscriberDto>>.Success(200, subscriberDtos), subsAndMetaData.MetaData);
        }

        public async Task<CustomResponseDto<List<SubscriberDto>>> GetAllSubscribersNoPaggingAsync()
        {
            List<Subscriber>? subs = await _repositoryManager.SubscriberRepository.GetByFilter(false, x => x.IsActive && !x.IsDeleted).ToListAsync();
            if(subs is null)
                throw new ArgumentNullException(nameof(subs));
            return CustomResponseDto<List<SubscriberDto>>.Success(200, _mapper.Map<List<SubscriberDto>>(subs));
        }

        public async Task<CustomResponseDto<SubscriberDto>> GetOneSubscriberByIdAsync(int subscriberId)
        {
            Subscriber? currentSubscriber = await CheckEntityAsync(false, subscriberId);
            return CustomResponseDto<SubscriberDto>.Success(200, _mapper.Map<SubscriberDto>(currentSubscriber));
        }

        public async Task<CustomResponseDto<NoContentDto>> SoftDeleteOneSubscriberAsync(int subscriberId)
        {
            Subscriber? currentSubscriber = await CheckEntityAsync(true, subscriberId);
            currentSubscriber.IsDeleted = true;
            currentSubscriber.IsActive = false;
            currentSubscriber.ModifiedDate = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(201);

        }

        public async Task<CustomResponseDto<SubscriberDtoForUpdate>> UpdateOneSubscriberAsync(int subscriberId, SubscriberDtoForUpdate subscriberDtoForUpdate)
        {
            if(subscriberId != subscriberDtoForUpdate.Id)
                throw new EntityNotMatchedParameterBadRequestException();
            if (subscriberDtoForUpdate is null)
                throw new ArgumentNullBadRequestException();
            Subscriber? currentSubscriber = await CheckEntityAsync(true, subscriberId);
            currentSubscriber.IsActive = subscriberDtoForUpdate.IsActive;
            currentSubscriber.ModifiedDate = DateTime.UtcNow;
            currentSubscriber.Email = subscriberDtoForUpdate.Email;
            currentSubscriber.IsDeleted = subscriberDtoForUpdate.IsActive ? false : true;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<SubscriberDtoForUpdate>.Success(201,_mapper.Map<SubscriberDtoForUpdate>(subscriberDtoForUpdate));

        }
        private async Task<Subscriber> CheckEntityAsync(bool trackChanges, int subscriberId)
        {
            Subscriber? currentSubscriber = await _repositoryManager.SubscriberRepository.GetByFilter(trackChanges, x => x.Id.Equals(subscriberId)).SingleOrDefaultAsync();
            if (currentSubscriber == null) 
                throw new SubscriberNotFoundException(subscriberId);
            return currentSubscriber;
        }
    }
}
