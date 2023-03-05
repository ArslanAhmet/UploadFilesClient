﻿namespace AsyaLogic.Core.Entities
{
    public class EventRecord 
    {
        public int ID { get; set; }
        public int EventID { get; set; }        
        public string EventType { get; set; }
        public string Country { get; set; }
        public string League { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime EventTime { get; set; }
        public DateTime Created { get; set; }
        
        public long PointInTime { get; set; }
    }
}
