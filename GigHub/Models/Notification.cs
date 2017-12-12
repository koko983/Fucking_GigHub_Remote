using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }

        [Required]
        public Gig Gig { get; set; }

        protected Notification()
        {

        }

        private Notification(Gig gig, NotificationType type)
        {
            if (gig == null)
            {
                throw new ArgumentNullException("gig");
            }

            Type = type;
            Gig = gig;
            DateTime = DateTime.Now;
        }

        public static Notification GigCanceled(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCanceled);
        }

        public static Notification GigUpdated(Gig gig, string originalVenue, DateTime originalDateTime)
        {
            var instance = new Notification(gig, NotificationType.GigUpdated);
            instance.OriginalDateTime = originalDateTime;
            instance.OriginalVenue = originalVenue;

            return instance;
        }
    }
}