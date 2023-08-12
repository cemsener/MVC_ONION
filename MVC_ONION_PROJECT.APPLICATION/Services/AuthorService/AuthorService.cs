using AutoMapper;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.Authors;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.Books;
using MVC_ONION_PROJECT.APPLICATION.DTo_s.Categories;
using MVC_ONION_PROJECT.DOMAIN.ENTITIES;
using MVC_ONION_PROJECT.DOMAIN.Utilities.Results;
using MVC_ONION_PROJECT.DOMAIN.Utilities.Results.Concretes;
using MVC_ONION_PROJECT.INFRASTRUCTURE.Repositories.Concretes;
using MVC_ONION_PROJECT.INFRASTRUCTURE.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.APPLICATION.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;


        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<AuthorDTo>> AddAsync(AuthorCreateDTo authorCreateDTo)
        {
            var authorfullname = authorCreateDTo.Name + " " + authorCreateDTo.Surname;
            var hasAuthor = await _authorRepository.AnyAsync(x => x.Name.ToLower() + " " + x.Surname.ToLower() == authorfullname.ToLower());

            if (hasAuthor)
            {
                return new ErrorDataResult<AuthorDTo>("Yazar zaten kayıtlı");
            }

            var author = _mapper.Map<Author>(authorCreateDTo);

            await _authorRepository.AddAsync(author);
            await _authorRepository.SaveChangeAsync();
            return new SuccessDataResult<AuthorDTo>(_mapper.Map<AuthorDTo>(author), "Yazar ekleme başarılı");

        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            if (author is null)
            {
                return new ErrorResult("Yazar Bulunamadı");
            }

            await _authorRepository.DeletableAsync(author);
            await _authorRepository.SaveChangeAsync();
            return new SuccessResult("Yazar Silme Başarılı");
        }

        public async Task<IDataResult<List<AuthorListDTo>>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();

            if (authors.Count() <= 0)
            {
                return new ErrorDataResult<List<AuthorListDTo>>("Sistemde Yazar Bulunmuyor.");
            }

            return new SuccessDataResult<List<AuthorListDTo>>(_mapper.Map<List<AuthorListDTo>>(authors), "Yazar Listeleme Başarılı" );
        }

        public async Task<IDataResult<AuthorDTo>> GetByIdAsync(Guid id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
            {
                return new ErrorDataResult<AuthorDTo>("Yazar Bulunamadı");
            }
            return new SuccessDataResult<AuthorDTo>(_mapper.Map<AuthorDTo>(author), "Yazar Detayları Gösteriliyor");
        }

        public async Task<IDataResult<AuthorDTo>> UpdateAsync(AuthorUpdateDto authorUpdateDto)
        {
            var author = await _authorRepository.GetByIdAsync(authorUpdateDto.Id);
            if (author == null)
            {
                return new ErrorDataResult<AuthorDTo>("Yazar bulunamadı.");
            }
            var authors = await _authorRepository.GetAllAsync();

            var newAuthors = authors.ToList();
            newAuthors.Remove(author);

            var hasAuthor = newAuthors.Any(x => x.Name == authorUpdateDto.Name);

            if (hasAuthor)
            {
                return new ErrorDataResult<AuthorDTo>("Kitap Zaten Kayıtlı");
            }

            var updatedAuthor = _mapper.Map(authorUpdateDto, author);
            await _authorRepository.UpdateAsync(updatedAuthor);
            await _authorRepository.SaveChangeAsync();

            return new SuccessDataResult<AuthorDTo>(_mapper.Map<AuthorDTo>(updatedAuthor), "Kitap Güncelleme Başarılı");
        }
    }
}
