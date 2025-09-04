namespace Silverness.SharedKernel;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
