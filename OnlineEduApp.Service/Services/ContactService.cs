using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.DTOs.ContactDTOs;
using OnlineEduApp.Core.Entities.Concretes;
using OnlineEduApp.Core.Entities.Exceptions;
using OnlineEduApp.Core.Repositories;
using OnlineEduApp.Core.Services;
using OnlineEduApp.Core.Utilities.Uow;
using OnlineEduApp.SharedLibrary.Response;
using OnlineEduApp.SharedLibrary.ResponseResultPattern;

namespace OnlineEduApp.Service.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactService(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<ContactDtoForCreate>> CreateOneContactAsync(ContactDtoForCreate contactDtoForCreate)
        {
            if(contactDtoForCreate == null)
                throw new ArgumentNullException("Parametre olarak gönderilen obje null!");
            Contact? newContact= _mapper.Map<Contact>(contactDtoForCreate);
            newContact.IsActive= true;
            newContact.IsDeleted= false;
            newContact.ModifiedDate = DateTime.UtcNow;
            newContact.CreatedDate= DateTime.UtcNow;
            await _repositoryManager.ContactRepository.CreateAsync(newContact);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<ContactDtoForCreate>.Success(201,contactDtoForCreate);

        }

        public async Task<CustomResponseDto<NoContentDto>> DeleteOneContactAsync(int contactId)
        {
            Contact? currentContact = await CheckContactByIdAsync(true, contactId);
            _repositoryManager.ContactRepository.Delete(currentContact);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<List<ContactDto>>> GetAllContactsAsync()
        {
            List<Contact> contacts = await _repositoryManager.ContactRepository.GetByFilter(false,x => x.IsActive&&!x.IsDeleted).ToListAsync();
            if(contacts is null)
                throw new ArgumentNullException("Sistemde hiç kayıt bulunamadı!");
            List<ContactDto> contactDtos = _mapper.Map<List<ContactDto>>(contacts);
            return CustomResponseDto<List<ContactDto>>.Success(200,contactDtos);
        }

        public async Task<CustomResponseDto<List<ContactDto>>> GetAllDeletedContactsAsync()
        {
            List<Contact> contacts = await _repositoryManager.ContactRepository.GetByFilter(false, x => !x.IsActive && x.IsDeleted).ToListAsync();
            if (contacts is null)
                throw new ArgumentNullException("Sistemde hiç kayıt bulunamadı!");
            List<ContactDto> contactDtos = _mapper.Map<List<ContactDto>>(contacts);
            return CustomResponseDto<List<ContactDto>>.Success(200, contactDtos);
        }

        public async Task<CustomResponseDto<ContactDto>> GetContactByIdAsync(int contactId)
        {
            Contact? currentContact = await CheckContactByIdAsync(false, contactId);
            ContactDto contactDto = _mapper.Map<ContactDto>(currentContact);
            return CustomResponseDto<ContactDto>.Success(200,contactDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> SoftDeleteOneContactAsync(int contactId)
        {
            Contact? currentContact = await CheckContactByIdAsync(true, contactId);
            currentContact.IsActive = false;
            currentContact.IsDeleted = true;
            currentContact.ModifiedDate = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);

        }

        public async Task<CustomResponseDto<ContactDtoForUpdate>> UpdateOneContactAsync(int contactId, ContactDtoForUpdate contactDtoForUpdate)
        {
            if(contactDtoForUpdate == null && contactId != contactDtoForUpdate.Id)
                throw new ArgumentNullException("Parametre olarak gönderilen obje null veya id'ler uyuşmuyor!");
            Contact? currentContact = await CheckContactByIdAsync(true, contactId);
            currentContact.MapUrl = contactDtoForUpdate.MapUrl;
            currentContact.Address = contactDtoForUpdate.Address;
            currentContact.Phone = contactDtoForUpdate.Phone;
            currentContact.Email = contactDtoForUpdate.Email;
            currentContact.IsActive = contactDtoForUpdate.IsActive;
            currentContact.IsDeleted = contactDtoForUpdate.IsActive ? false : true;
            currentContact.ModifiedDate = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<ContactDtoForUpdate>.Success(200,contactDtoForUpdate);

        }
        private async Task<Contact> CheckContactByIdAsync(bool trackChanges,int contactId)
        {
            Contact? currentContact  = await _repositoryManager.ContactRepository.GetByFilter(trackChanges, x => x.Id.Equals(contactId)).SingleOrDefaultAsync();
            if(currentContact == null)
                throw new ContactNotFoundException(contactId);
            return currentContact;
        }
    }
}
