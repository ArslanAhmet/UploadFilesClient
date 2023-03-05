using AsyaLogic.Core.Entities;
using AsyaLogic.Core.ObjectMapper;
using AsyaLogic.Infrastructure.Data;
using AsyaLogic.Infrastructure.Helpers;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Mime;

namespace AsyaLogic.Controllers
{
    [ApiController]
    [Route("api/eventrecords")]
    public class EventRecordController : ControllerBase
    {
        public IEventRecordRepository _eventRecordRepository;
        private readonly IEventRecordMapService _mapper;
        public EventRecordController(IEventRecordRepository fileRepository,
            IEventRecordMapService mapper)
        {
            _eventRecordRepository = fileRepository ?? throw new ArgumentNullException(nameof(fileRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetEventRecords")]

        public async Task<IActionResult> GetEventRecordsAsync([FromQuery] PagingParameters filesResourceParameters)
        {
            List<EventRecord> eventsFromRepo = await _eventRecordRepository.GetEventRecords(filesResourceParameters);

            var eventRecords = _mapper.ToEventRecordDtoList(eventsFromRepo);
            return Ok(eventRecords);            
        }

        [HttpGet("changes", Name = "GetRecordChanges")]
        public async Task<IActionResult> GetRecordChangesAsync(int eventID, string name) 
        { 
            List<RecordChange> recordsFromRepo = await _eventRecordRepository.GetRecordChanges(eventID, name);

            var eventRecords = _mapper.ToRecordChangeDtoList(recordsFromRepo);

            return Ok(eventRecords);
        }

    }
}