using Apopad.Common.ExcelParse;
using Apopad.Common.Repositories;
using Apopad.Domain.Model;
using Apopad.Domain.Service;
using Apopad.ViewModels.Paper;
using Apopad.WebServices.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Apopad.WebServices.Controllers
{
    public class PaperController : WebApiController
    {
        private readonly IRepository<int, Paper> repository;
        private readonly IPretreatmentService pretreatmentService;
        private readonly ILookUpService lookUpService;

        public PaperController(IRepositoryContext repositoryContext,
            IPretreatmentService pretreatmentService,
            ILookUpService lookUpService)
            : base(repositoryContext)
        {
            this.pretreatmentService = pretreatmentService;
            this.lookUpService = lookUpService;

            repository = repositoryContext.GetRepository<int, Paper>();
        }

        public HttpResponseMessage Get()
        {
            var xmlName = HttpContext.Current.Server.MapPath("~/App_Data/paper.xml");
            var fileName = HttpContext.Current.Server.MapPath("~/upload/SCI-2016-test.xlsx");
            var service = new ExcelImportService(fileName, xmlName);
            var result = service.ValidateExcel();
            if (!result.Success)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    result.Message + result.ExcelFileErrorPositions);
            }

            var dtos = service.Import<PaperDto4E>();
            var papers = dtos.Select(s => s.MapTo<Paper>());
            foreach(var paper in papers)
            {
                paper.Status = PaperStatus.PRETREATMENT;
                repository.Add(paper);
            }
            RepositoryContext.Commit();

            return Request.CreateResponse(HttpStatusCode.OK);   
        }

        [Route("api/paper/pre")]
        public HttpResponseMessage GetByPre()
        {
            pretreatmentService.pretreatPaper();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/paper/look")]
        public HttpResponseMessage GetByLook()
        {
            lookUpService.LookupPaperAuthors();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
