using AsyaLogic.Core.Entities;
using AsyaLogic.Infrastructure.Data;
using AsyaLogic.Infrastructure.Helpers;
using AsyaLogic.Infrastructure.Helpers.FileParsing;
using AsyaLogic.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AsyaLogic.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FileUploadController : ControllerBase
    {
        public IEventRecordRepository _eventRecordRepository;
        readonly IFileUploadService _fileUploadService;
        private ILogger<FileUploadController> _logger;

        public FileUploadController(IEventRecordRepository evetRecordRepository,
            IFileUploadService fileUploadService,
            ILogger<FileUploadController> logger)
        {
            _eventRecordRepository = evetRecordRepository ?? throw new ArgumentNullException(nameof(evetRecordRepository));
            _fileUploadService = fileUploadService  ?? throw new ArgumentNullException(nameof(fileUploadService)); 
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.First();

            var fileName = await _fileUploadService.UploadFile(file);
            if (fileName == null) 
            {
                return BadRequest();
            }

            var fileParser = FileParserFactory.Create(fileName);
            var eventRecords = fileParser.Parse();

            _eventRecordRepository.AddEventRecords(eventRecords);

            await _eventRecordRepository.SaveChangesAsync();

            return Ok();
            
        }
    }
}