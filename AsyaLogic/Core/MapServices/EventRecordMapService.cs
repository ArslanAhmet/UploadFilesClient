using AsyaLogic.Core.Entities;
using AsyaLogic.Core.Models;
using AsyaLogic.Core.ObjectMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AsyaLogic.Core.MapServices
{
    public class EventRecordMapService : IEventRecordMapService
    {
        public IEnumerable<EventRecordDto> ToEventRecordDtoList(IEnumerable<EventRecord> entities)
        {
            var entityDtos = new List<EventRecordDto>();

            foreach (var entity in entities)
            {
                var reportDto = new EventRecordDto
                {
                    EventID = entity.EventID,
                    EventType = entity.EventType,
                    Country = entity.Country,
                    League = entity.League,
                    HomeTeam = entity.HomeTeam,
                    AwayTeam = entity.AwayTeam,
                    EventTime = entity.EventTime
                };
                entityDtos.Add(reportDto);
            }
            return entityDtos;
        }

        public IEnumerable<RecordChangeDto> ToRecordChangeDtoList(IEnumerable<RecordChange> entities)
        {
            var entityDtos = new List<RecordChangeDto>();

            foreach (var entity in entities)
            {
                var reportDto = new RecordChangeDto
                {
                    EventID = entity.EventID,
                    Name = entity.Name,
                    Value = entity.Value
                };
                entityDtos.Add(reportDto);
            }
            return entityDtos;
        }
    }
}
