using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Tailoring.Data.Models {
    public class RequestOrder {
        [BsonId]
        public object _id { get; set; }
      //  public long UserId { get; set; }
        public Product Product { get; set; }
        public List<ProductOption> ProductOptions { get; set;}
        public RequestState State { get; set; }
        public TimeSlot TimeSlotId { get; set; }
        public Nullable<DateTime> ScheduleDate { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
        public int Amount { get; set; }
    }
}
