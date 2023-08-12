using MVC_ONION_PROJECT.APPLICATION.DTo_s.Authors;
using MVC_ONION_PROJECT.DOMAIN.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_ONION_PROJECT.APPLICATION.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<IDataResult<AuthorDTo>> AddAsync(AuthorCreateDTo authorCreateDTo);
        Task<IDataResult<List<AuthorListDTo>>> GetAllAsync();
        Task<IDataResult<AuthorDTo>> GetByIdAsync(Guid id);
        Task<IDataResult<AuthorDTo>> UpdateAsync(AuthorUpdateDto authorUpdateDto);
        Task<IResult> DeleteAsync(Guid id);
    }
}
