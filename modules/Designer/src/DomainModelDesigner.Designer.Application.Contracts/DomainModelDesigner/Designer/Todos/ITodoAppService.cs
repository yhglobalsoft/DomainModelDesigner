using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace DomainModelDesigner.Designer.Todos
{
    public interface ITodoAppService
    {
        Task<PagedResultDto<TodoDto>> GetListAsync();
    }
}