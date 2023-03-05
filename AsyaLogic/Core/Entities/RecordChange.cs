namespace AsyaLogic.Core.Entities
{
    public class RecordChange
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public long PointInTime { get; set; }
    }
}
