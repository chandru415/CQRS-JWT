using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        public LoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            var user = await GetUserID();

            _logger.LogInformation("Rectitude Portal Profile Request: {Name} {User} {@Request}",
                requestName, user, request);
        }

        public async Task<string> GetUserID()
        {
            /** Here we need inject the identity server or application identity to get the user ID*/
            return await Task.FromResult<string>("User ID");
        }
    }
}
