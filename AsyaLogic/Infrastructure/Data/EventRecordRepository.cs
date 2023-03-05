using AsyaLogic.Core.Entities;
using AsyaLogic.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AsyaLogic.Infrastructure.Data
{
    public class EventRecordRepository : IEventRecordRepository
    {
        private AsyaLogicContext _context;
        public EventRecordRepository(AsyaLogicContext context)
        {
            _context = context;
        }

        public void AddEventRecords(List<EventRecord> newRecords)
        {
            foreach (var newRecord in newRecords)
            {
                var record = _context.EventRecords.Where(a => a.EventID == newRecord.EventID).FirstOrDefault();
                if (record != null)
                {
                    long pointInTime = DateTime.Now.Ticks;
                    List<RecordChange> recordChanges = new List<RecordChange>();
                    if (record.EventType != newRecord.EventType)
                    {
                        recordChanges.Add(new RecordChange { EventID = newRecord.EventID, Name = "EventType", Value = newRecord.EventType, PointInTime = pointInTime });
                        record.EventType = newRecord.EventType;
                    }

                    if (record.Country != newRecord.Country)
                    {
                        recordChanges.Add(new RecordChange { EventID = newRecord.EventID, Name = "Country", Value = newRecord.Country, PointInTime = pointInTime });
                        record.Country = newRecord.Country;
                    }

                    if (record.League != newRecord.League)
                    {
                        recordChanges.Add(new RecordChange { EventID = newRecord.EventID, Name = "League", Value = newRecord.League, PointInTime = pointInTime });
                        record.League = newRecord.League;
                    }

                    if (record.HomeTeam != newRecord.HomeTeam)
                    {
                        recordChanges.Add(new RecordChange { EventID = newRecord.EventID, Name = "HomeTeam", Value = newRecord.HomeTeam, PointInTime = pointInTime });
                        record.HomeTeam = newRecord.HomeTeam;
                    }

                    if (record.AwayTeam != newRecord.AwayTeam)
                    {
                        recordChanges.Add(new RecordChange { EventID = newRecord.EventID, Name = "AwayTeam", Value = newRecord.AwayTeam, PointInTime = pointInTime });
                        record.AwayTeam = newRecord.AwayTeam;
                    }

                    if (record.EventTime != newRecord.EventTime)
                    {
                        recordChanges.Add(new RecordChange { EventID = newRecord.EventID, Name = "EventTime", Value = newRecord.EventTime.ToString(), PointInTime = pointInTime });
                        record.EventTime = newRecord.EventTime;
                    }

                    record.PointInTime = pointInTime;
                    
                    _context.RecordColumnChanges.AddRange(recordChanges);
                }
                else
                {
                    newRecord.Created = DateTime.UtcNow;
                    _context.EventRecords.Add(newRecord);
                }
            }
        }

        public async Task<List<EventRecord>> GetEventRecords(PagingParameters pagingParameters)
        {
            return await _context.EventRecords
                .OrderBy(x => x.ID).
                 Skip((pagingParameters.PageNumber) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize).ToListAsync();
        }

        public async Task<List<RecordChange>> GetRecordChanges(int eventID, string name)
        {
            return await _context.RecordColumnChanges.Where(r => r.EventID == eventID && r.Name == name)
                .OrderBy(x => x.ID).ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
