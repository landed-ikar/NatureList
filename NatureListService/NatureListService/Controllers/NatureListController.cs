using DevExpress.Xpo;
using Microsoft.AspNetCore.Mvc;
using NatureListService.Services;
using NatureListService.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NatureListService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class NatureListController : ControllerBase {

        private readonly IDataStorageService dataStorage;
        public NatureListController(IDataStorageService dataStorage) {
            this.dataStorage = dataStorage;
        }

        // GET api/<NatureList>/id
        [Authorize(Roles = "Reader")]
        [HttpGet("{id}.{format?}")]
        public async Task<ActionResult> Get(
            uint id,
            string? format,
            [FromServices] IReportGeneratorService reportGenerator) {
            try {
                IEnumerable<CarriageDTO> carriages = await dataStorage.GetCarriageByTrainAsync(id);
                if(format == "xlsx") {
                    byte[] reportBytes = await reportGenerator.GetNatureListReportByTrain(carriages);
                    const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    HttpContext.Response.ContentType = contentType;

                    FileContentResult fileContentResult = new FileContentResult(reportBytes, contentType) {
                        FileDownloadName = $"NL_{id}.xlsx"
                    };
                    return fileContentResult;
                }
                if(format == "json") {
                    NatureListDTO result = await dataStorage.GetNatureListDataByTrainAsync(id);
                    JsonResult jsonResult = new JsonResult(result);
                    return jsonResult;
                }
                return BadRequest("Unexpected format");
            }
            catch(Exception exception) {
                return BadRequest(exception.Message);
            }
        }

        // POST api/<NatureList>
        [Authorize(Roles = "Writer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CarriageList value) {
            try {
                if(!ModelState.IsValid) {
                    return BadRequest(ModelState);
                }
                await dataStorage.SaveDataAsync(value.Carriages);
                return NoContent();
            }
            catch(Exception exception) {
                return BadRequest(exception);
            }

        }
    }
}
