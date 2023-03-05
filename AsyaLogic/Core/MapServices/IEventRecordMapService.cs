using AsyaLogic.Core.Entities;
using AsyaLogic.Core.Models;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

namespace AsyaLogic.Core.ObjectMapper
{

    public interface IEventRecordMapService
    {
        public IEnumerable<EventRecordDto> ToEventRecordDtoList(IEnumerable<EventRecord> entities);
        public IEnumerable<RecordChangeDto> ToRecordChangeDtoList(IEnumerable<RecordChange> entities);
    }
}
