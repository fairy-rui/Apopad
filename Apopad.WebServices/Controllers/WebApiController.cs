using Apopad.Common.Repositories;
using log4net;
using System.Web.Http;

namespace Apopad.WebServices.Controllers
{
    public class WebApiController : ApiController
    {
        private readonly IRepositoryContext repositoryContext;

        private static readonly ILog log = LogManager.GetLogger("Apopad.WebServices.Logger");

        protected WebApiController(IRepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        protected IRepositoryContext RepositoryContext => repositoryContext;
    }
}
