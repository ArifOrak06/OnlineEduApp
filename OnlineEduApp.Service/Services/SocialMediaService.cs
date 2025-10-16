using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.DTOs.SocialMediaDTOs;
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
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SocialMediaService(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<SocialMediaDtoForCreate>> CreateOneSocialMediaAsync(SocialMediaDtoForCreate socialMediaDtoForCreate)
        {
            if(socialMediaDtoForCreate == null)
                throw new ArgumentNullBadRequestException();
            SocialMedia? socialMedia = _mapper.Map<SocialMedia>(socialMediaDtoForCreate);
            socialMedia.CreatedDate = DateTime.UtcNow;
            socialMedia.ModifiedDate = DateTime.UtcNow;
            socialMedia.IsActive = true;
            socialMedia.IsDeleted = false;
            await _repositoryManager.SocialMediaRepository.CreateAsync(socialMedia);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<SocialMediaDtoForCreate>.Success(201, _mapper.Map<SocialMediaDtoForCreate>(socialMedia));

        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteOneSocialMediaAsync(int socialMediaId)
        {
            SocialMedia? currentMedia = await _repositoryManager.SocialMediaRepository.GetByFilter(true,x => x.Id.Equals(socialMediaId)).SingleOrDefaultAsync();
            if (currentMedia == null)
                throw new SocialMediaNotFoundException(socialMediaId);
            _repositoryManager.SocialMediaRepository.Delete(currentMedia);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<(CustomResponseDto<List<SocialMediaDto>> responseDto, MetaData metaData)> GetAllDeletedSocialMediasAsync(SocialMediaParameters socialMediaParameters)
        {
            PagedList<SocialMedia> socialMediaAndMetaData = await _repositoryManager.SocialMediaRepository.GetAllSocialMediasAsync(false, socialMediaParameters,x => x.IsDeleted&&!x.IsActive);
            if(socialMediaAndMetaData == null)
                throw new ArgumentException();
            List<SocialMediaDto> socialMediaDtos = _mapper.Map<List<SocialMediaDto>>(socialMediaAndMetaData);
            return (CustomResponseDto<List<SocialMediaDto>>.Success(200, socialMediaDtos), socialMediaAndMetaData.MetaData);
        }

        public async Task<(CustomResponseDto<List<SocialMediaDto>> responseDto, MetaData metaData)> GetAllSocialMediasAsync(SocialMediaParameters socialMediaParameters)
        {
            PagedList<SocialMedia> socialMediaAndMetaData = await _repositoryManager.SocialMediaRepository.GetAllSocialMediasAsync(false, socialMediaParameters, x => !x.IsDeleted && x.IsActive);
            if (socialMediaAndMetaData == null)
                throw new ArgumentException();
            List<SocialMediaDto> socialMediaDtos = _mapper.Map<List<SocialMediaDto>>(socialMediaAndMetaData);
            return (CustomResponseDto<List<SocialMediaDto>>.Success(200, socialMediaDtos), socialMediaAndMetaData.MetaData);
        }

        public async Task<CustomResponseDto<List<SocialMediaDto>>> GetAllSocialMediasNoPaggingAsync()
        {
            List<SocialMedia> socialMedias = await _repositoryManager.SocialMediaRepository.GetByFilter(false,x => x.IsActive).ToListAsync();
            if (socialMedias is null)
                throw new ArgumentException();
            List<SocialMediaDto> socialMediaDtos = _mapper.Map<List<SocialMediaDto>>(socialMedias);
            return CustomResponseDto<List<SocialMediaDto>>.Success(200, socialMediaDtos);


        }

        public async Task<CustomResponseDto<SocialMediaDto>> GetOneSocialMediaAsyncByIdAsync(int socialMediaId)
        {
            SocialMedia? currentMedia = await CheckEntityByIdAsync(false, socialMediaId);
            return CustomResponseDto<SocialMediaDto>.Success(200,_mapper.Map<SocialMediaDto>(currentMedia));    

        }

        public async Task<CustomResponseDto<NoContentDto>> SoftDeleteOneSocialMediaAsync(int socialMediaId)
        {
            SocialMedia? currentMedia = await CheckEntityByIdAsync(true, socialMediaId);
            currentMedia.IsActive = false;
            currentMedia.IsDeleted = true;
            currentMedia.ModifiedDate = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);


        }

        public async Task<CustomResponseDto<SocialMediaDtoForUpdate>> UpdateOneSocialMediaAsync(int socialMediaId,SocialMediaDtoForUpdate socialMediaDtoForUpdate)
        {
            if(socialMediaDtoForUpdate == null && socialMediaId != socialMediaDtoForUpdate.Id)
                throw new EntityNotMatchedParameterBadRequestException();

            SocialMedia? currentMedia = await CheckEntityByIdAsync(true, socialMediaId);
            currentMedia.Title = socialMediaDtoForUpdate.Title;
            currentMedia.Icon = socialMediaDtoForUpdate.Icon;
            currentMedia.Url = socialMediaDtoForUpdate.Url;
            currentMedia.ModifiedDate = DateTime.UtcNow;
            currentMedia.IsActive = socialMediaDtoForUpdate.IsActive;
            currentMedia.IsDeleted = socialMediaDtoForUpdate.IsActive ? false : true;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<SocialMediaDtoForUpdate>.Success(200,_mapper.Map<SocialMediaDtoForUpdate>(currentMedia));

        }
        private async Task<SocialMedia> CheckEntityByIdAsync(bool trackChanges,int socialMediaId)
        {
            SocialMedia? currentMedia  = await _repositoryManager.SocialMediaRepository.GetByFilter(trackChanges,x => x.Id.Equals(socialMediaId)).SingleOrDefaultAsync();
            if(currentMedia == null)
                throw new SocialMediaNotFoundException(socialMediaId);
            return currentMedia;
        }
    }
}
