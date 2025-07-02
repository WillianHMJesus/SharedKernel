using System.Threading;
using System.Threading.Tasks;

namespace WH.SharedKernel;

public interface IUnitOfWork
{
    Task<bool> CommitAsync(CancellationToken cancellationToken);
}
