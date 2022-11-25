using DAL.Entities;
using System;

namespace BLL.Models
{
    public class EventModel
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Guid authorID { get; set; }
        public DateTime date { get; set; }

        public EventModel() { }
        public EventModel(Event e)
        {
            this.id = e.id;
            this.name = e.event_name;
            this.description = e.description;
            this.authorID = e.authorID;
            this.date = e.date;
        }
    }
}
