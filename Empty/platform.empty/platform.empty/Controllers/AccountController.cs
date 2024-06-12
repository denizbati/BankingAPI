using Banking.ApiContract.Contract;
using Banking.ApiContract.Request.Commands;
using Banking.ApiContract.Request.Queries;
using Banking.ApiContract.Response.Commands;
using Banking.ApiContract.Response.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Route("v1/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor method
        /// </summary>
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Create account with request
        /// </summary>
        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(ResponseBase<CreateAccountResponse>))]
        public async Task<IActionResult> CreateAccount(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CreateAccountCommand() { }, cancellationToken);
            return Ok(result);
        }
        /// <summary>
        /// Deposit money into a spesific account
        /// </summary>
        [HttpPost("{id}/deposit")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<CreateDepositMoneyResponse>))]
        public async Task<IActionResult> CreateDepositMoney(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CreateDepositMoneyCommand() { AccountId=id }, cancellationToken);
            return Ok(result);
        }
        /// <summary>
        /// Withdraw money into a spesific account
        /// </summary>
        [HttpPost("{id}/withdraw")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<CreateWithdrawWithAccountResponse>))]
        public async Task<IActionResult> CreateWithdrawWithAccount(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CreateWithdrawWithAccountCommand() { AccountId = id }, cancellationToken);
            return Ok(result);
        }
        /// <summary>
        /// Withdraw money into a spesific account
        /// </summary>
        [HttpGet("{id}/balance")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<GetBalanceWithAccountResponse>))]
        public async Task<IActionResult> GetBalanceWithAccount(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBalanceWithAccountCommand() { AccountId=id}, cancellationToken);
            return Ok(result);
        }

    }
}
