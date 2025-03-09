using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum EnquiryStatus
    {
        New,                   // Initial Stage
        PendingReview,
        InProgress,            // Processing Stage
        AwaitingCustomerResponse,
        QuoteSent,
        Modified,

        Accepted,              // Decision Stage
        RejectedByCustomer,
        RejectedByAgency,

        BookingConfirmed,      // Booking Stage
        PaymentPending,
        PaymentCompleted,

        TripOngoing,           // Post-Booking Stage
        Completed,
        Cancelled,

        Expired,               // Special Cases
        FollowUpRequired
    }
}
