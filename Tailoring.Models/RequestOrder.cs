using System;
using System.Collections.Generic;

namespace Tailoring.Models {
    public class RequestOrder: EntityBase {

        public RequestOrder() {
            this.Product = new Product();
            this.ProductOptions = new List<ProductOption>();
        }

        public Product Product { get; set; }
        public List<ProductOption> ProductOptions { get; set; }
        public RequestState State { get; set; }
        public TimeSlot TimeSlotId { get; set; }
        public Nullable<DateTime> ScheduleDate { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
        public int Amount { get; set; }
    }
}
