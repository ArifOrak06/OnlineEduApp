using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.DTOs.BannerDTOs;
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
    public class BannerService : IBannerService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BannerService(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<BannerDtoForCreate>> CreateOneBannerAsync(int bannerId, BannerDtoForCreate bannerDtoForCreate)
        {
            // Validation check DataAnnatation olarak Dto Propertyleri üzerinden yapılmakatadır.
            // Null Check
            if (bannerDtoForCreate == null)
                // Hatayı CustomResponseDto kalıbı içerisinde fırlatmadık,
                // çünkü globalExceptionHandler yapımız içerisinde Custom olarak fırlatılan hataları yakalayıp CustomResponseDto kalıbı içerisinde orada fırlatılacak şekilde ayarladık.
                throw new ArgumentNullException(nameof(bannerDtoForCreate), "Parametre olarak gönderilen obje null");

            Banner newBanner = _mapper.Map<Banner>(bannerDtoForCreate);
            newBanner.IsActive = true;
            newBanner.CreatedDate = DateTime.UtcNow;
            newBanner.ModifiedDate = DateTime.UtcNow;
            newBanner.IsDeleted = false;
            await _repositoryManager.BannerRepository.CreateAsync(newBanner);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<BannerDtoForCreate>.Success(200,_mapper.Map<BannerDtoForCreate>(newBanner));


        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteOneBannerAsync(int bannerId)
        {
            Banner? currentBanner = await _repositoryManager.BannerRepository.GetByFilter(true, b => b.Id.Equals(bannerId)).SingleOrDefaultAsync();
            if (currentBanner == null)
                throw new BannerNotFoundException(bannerId);
            _repositoryManager.BannerRepository.Delete(currentBanner);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);

        }

        public async Task<(CustomResponseDto<List<BannerDto>> bannerDtoList, MetaData metaData)> GetAllBannersAsync(BannerParameters bannerParameters)
        {
            PagedList<Banner> items = await _repositoryManager.BannerRepository.GetAllBannersAsync(false, bannerParameters);
            if(items == null)
                throw new ArgumentNullException(nameof(items), "Sistemde kayıtlı banner bulunmamaktadır.");

            var bannerListDto = _mapper.Map<List<BannerDto>>(items);

            return (CustomResponseDto<List<BannerDto>>.Success(200,bannerListDto), items.MetaData);
        }

        public async Task<(CustomResponseDto<List<BannerDto>> bannerListDto, MetaData metaData)> GetAllDeletedBannersAsync(BannerParameters bannerParameters)
        {
            PagedList<Banner> items = await _repositoryManager.BannerRepository.GetAllBannersAsync(false, bannerParameters, x => !x.IsActive && x.IsDeleted);

            if (items == null)
                throw new ArgumentNullException(nameof(items), "Sistemde kayıtlı banner bulunmamaktadır.");

            List<BannerDto>? deletedBannerListDto = _mapper.Map<List<BannerDto>>(items);

            return (CustomResponseDto<List<BannerDto>>.Success(200, deletedBannerListDto), items.MetaData);
        }

        public async Task<CustomResponseDto<BannerDto>> GetBannerDtoByIdAsync(int bannerId)
        {
            Banner? currentBanner = await _repositoryManager.BannerRepository.GetByFilter(false,b => b.Id.Equals(bannerId)).SingleOrDefaultAsync();

            if(currentBanner == null)
                throw new BannerNotFoundException(bannerId);

            return CustomResponseDto<BannerDto>.Success(200,_mapper.Map<BannerDto>(currentBanner));
        }

        public async Task<CustomResponseDto<NoContentDto>> SoftDeleteOneBannerAsync(int bannerId)
        {
            Banner? currentBanner =  _repositoryManager.BannerRepository.GetByFilter(true, b => b.Id.Equals(bannerId)).SingleOrDefault();
            if (currentBanner == null)
                throw new BannerNotFoundException(bannerId);
            currentBanner.IsActive = false;
            currentBanner.IsDeleted = true;
            currentBanner.ModifiedDate = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);

        }

        public async Task<CustomResponseDto<BannerDtoForUpdate>> UpdateOneBannerAsync(int bannerId, BannerDtoForUpdate bannerDtoForUpdate)
        {
            // Validation check DataAnnatation olarak Dto Propertyleri üzerinden yapılmakatadır.
            if(bannerId != bannerDtoForUpdate.Id && bannerDtoForUpdate is null)
                throw new ArgumentNullException("Banner ID request Body içerisinde nesnede yer alan Id bilgisi ile route üzerinden gelen Id değerleri eşleşmemektedir veyahut parametre olarak gönderilen obje null.");

            Banner? currentBanner = _repositoryManager.BannerRepository.GetByFilter(true, b => b.Id.Equals(bannerId)).SingleOrDefault();
            if (currentBanner == null)
                throw new BannerNotFoundException(bannerId);
            currentBanner.ModifiedDate = DateTime.UtcNow;
            currentBanner.IsActive = bannerDtoForUpdate.IsActive;
            currentBanner.IsDeleted = bannerDtoForUpdate.IsActive ? false : true;
            currentBanner.Title = bannerDtoForUpdate.Title;
            currentBanner.ImageUrl = bannerDtoForUpdate.ImageUrl;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<BannerDtoForUpdate>.Success(200,_mapper.Map<BannerDtoForUpdate>(currentBanner));
        }
    }
}
