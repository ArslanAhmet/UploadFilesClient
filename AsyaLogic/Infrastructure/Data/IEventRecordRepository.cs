using AsyaLogic.Core.Entities;
using AsyaLogic.Infrastructure.Helpers;

namespace AsyaLogic.Infrastructure.Data
{
    public interface IEventRecordRepository
    {
        void AddEventRecords(List<EventRecord> newRecords);
        Task<List<EventRecord>> GetEventRecords(PagingParameters entityResourceParameters);
        Task<List<RecordChange>> GetRecordChanges(int eventID, string name);
        Task SaveChangesAsync();
    }
}
