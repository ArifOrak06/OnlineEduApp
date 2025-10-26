using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.DTOs.AboutDTOs;
using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.RequestFeatures;
using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Core.Services;
using OnlineEduApp.Core.Utilities.Uow;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.Service.Services
{
    public class AboutService : IAboutService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AboutService(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<AboutDtoForCreate>> CreateOneAboutAsync(AboutDtoForCreate aboutDtoForCreate)
        {
            // Validation Kuralları Data Annotation olarak propertyler üzerinden işletilmektedir.

            if(aboutDtoForCreate is null)
                throw new ArgumentNullException(nameof(aboutDtoForCreate));

            var newAbout = _mapper.Map<About>(aboutDtoForCreate);
            newAbout.IsActive = true;

            newAbout.CreatedDate = DateTime.UtcNow;
            newAbout.ModifiedDate = DateTime.UtcNow;
            await _repositoryManager.AboutRepository.CreateOneAboutAsync(newAbout);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<AboutDtoForCreate>.Success(200,_mapper.Map<AboutDtoForCreate>(newAbout));

        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteOneAboutAsync(int aboutId)
        {

            var currentEntity = await _repositoryManager.AboutRepository.GetByFilterAbouts(true,x => x.Id.Equals(aboutId)).SingleOrDefaultAsync();
            if(currentEntity is null)
                throw new Exception(nameof(aboutId));
            _repositoryManager.AboutRepository.DeleteOneAbout(currentEntity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<List<AboutDto>>> GetAllAboutsNoPaggingAsync()
        {
            List<About>? abouts = await _repositoryManager.AboutRepository.GetByFilter(false, x => x.IsActive && !x.IsDeleted).ToListAsync();
            if(abouts is null)
                throw new ArgumentException(nameof(abouts));
            return CustomResponseDto<List<AboutDto>>.Success(200,_mapper.Map<List<AboutDto>>(abouts));  
        }

        public async Task<(CustomResponseDto<List<AboutDto>> responseDtoList, MetaData metaData)> GetAllActiveAboutsAsync(AboutParameters aboutParameters)
        {
            var items = await _repositoryManager.AboutRepository.GetAllAboutsAsync(false,aboutParameters);

            if (items == null)
                throw new ArgumentNullException(nameof(items));

            var newAboutDtoList = _mapper.Map<List<AboutDto>>(items);

            return (CustomResponseDto<List<AboutDto>>.Success(200, newAboutDtoList), items.MetaData);
        }

        public async Task<(CustomResponseDto<List<AboutDto>> responseDtoList, MetaData metaData)> GetAllDeletedAboutsAsync(AboutParameters aboutParameters)
        {
            var items = await _repositoryManager.AboutRepository.GetAllAboutsAsync(false, aboutParameters,x => !x.IsActive&&x.IsDeleted);
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            var newItemList = _mapper.Map<List<AboutDto>>(items);
            return (CustomResponseDto<List<AboutDto>>.Success(200,newItemList), items.MetaData);
        }

        public async Task<CustomResponseDto<AboutDto>> GetOneAboutByIdAsync(int aboutId)
        {
            var currentItem = await _repositoryManager.AboutRepository.GetAboutByIdAsync(false, aboutId);
            if(currentItem == null)
                throw new ArgumentNullException(nameof(currentItem));
            return CustomResponseDto<AboutDto>.Success(200,_mapper.Map<AboutDto>(currentItem));  
        }

        public async Task<CustomResponseDto<NoContentDto>> SoftDeleteOneAboutAsync(int aboutId)
        {
            var currentItem = await _repositoryManager.AboutRepository.GetByFilterAbouts(true, x => x.Id == aboutId).SingleOrDefaultAsync();
            if (currentItem == null)
                throw new ArgumentNullException(nameof(currentItem));
            currentItem.IsActive = false;
            currentItem.IsDeleted = true;
            currentItem.ModifiedDate = DateTime.Now;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<AboutDtoForUpdate>> UpdateOneAboutAsync(int aboutId, AboutDtoForUpdate aboutDtoForUpdate)
        {
            // Validation Kuralları Data Annotation olarak propertyler üzerinden işletilmektedir.
            if (aboutDtoForUpdate == null && aboutId != aboutDtoForUpdate.Id)
                throw new ArgumentNullException(nameof(aboutDtoForUpdate));

            var currentItem = await _repositoryManager.AboutRepository.GetByFilterAbouts(true, x => x.Id.Equals(aboutId)).SingleOrDefaultAsync();

            if (currentItem == null)
                throw new ArgumentNullException(nameof(currentItem));

            currentItem.IsActive = aboutDtoForUpdate.IsActive;
            currentItem.IsDeleted = currentItem.IsActive  ? false : true;
            currentItem.ModifiedDate = DateTime.Now;
            currentItem.Description = aboutDtoForUpdate.Description;
            currentItem.ImageUrl = aboutDtoForUpdate.ImageUrl;
            currentItem.ItemOne = aboutDtoForUpdate.ItemOne;
            currentItem.ItemTwo = aboutDtoForUpdate.ItemTwo;
            currentItem.ItemThree = aboutDtoForUpdate.ItemThree;
            currentItem.ItemFour = aboutDtoForUpdate.ItemFour;
            currentItem.ImageUrlTwo = aboutDtoForUpdate.ImageUrlTwo;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<AboutDtoForUpdate>.Success(200,_mapper.Map<AboutDtoForUpdate>(currentItem));
        }
    }
}
