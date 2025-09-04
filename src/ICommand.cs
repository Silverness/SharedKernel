namespace Silverness.SharedKernel;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
