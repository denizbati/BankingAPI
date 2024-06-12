using MediatR;
using platform.empty.ApiContract.Request.Queries;

namespace platform.empty.ApplicationService.Handler.Queries
{
    public class HealthCheckQueryHandler : IRequestHandler<HealthCheckQuery, int>
    {
        public Task<int> Handle(HealthCheckQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}
