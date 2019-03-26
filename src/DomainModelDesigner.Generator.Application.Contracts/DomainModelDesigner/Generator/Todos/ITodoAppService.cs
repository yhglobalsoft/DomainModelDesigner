using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace DomainModelDesigner.Generator.Todos
{
    public interface ITodoAppService
    {
        Task<PagedResultDto<TodoDto>> GetListAsync();
    }
}