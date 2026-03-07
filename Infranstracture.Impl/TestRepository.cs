using Domain.Menu;
using Domain.Account;

namespace Infranstracture.Test;

readonly struct TestRepository : IMenuRepository, IAccountRepository
{
}
