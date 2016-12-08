using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailoring.Data.Models {
    public enum ProductCategory {
        Women = 0,
        Men = 1
    }
    public enum TimeSlot {
        NineToTwelve = 0,
        TwelveToThree = 1
    }
    public enum RequestState {
        PickupSchedule = 1,
        PickupComplete = 2,
        AtBotique = 3,
        ReceivedFromBotique = 4,
        DeliveredToCustomer = 5
    }
    public enum ProductOptionType {

    }
}
