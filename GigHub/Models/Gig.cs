using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public bool IsCanceled { get; private set; }

        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public ICollection<Attendance> Attendances { get; private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            this.IsCanceled = true;

            var notification = Notification.GigCanceled(this);

            var attendees = Attendances
                .Select(a => a.Attendee)
                .ToList();

            foreach (var attendee in attendees)
            {
                attendee.Notify(notification);
            }
        }

        public void Update(string venue, System.DateTime dateTime, byte genreId)
        {
            var originalVenue = Venue;
            var originalDateTime = DateTime;

            Venue = venue;
            DateTime = dateTime;
            GenreId = genreId;

            Notification notification = Notification.GigUpdated(this, originalVenue, originalDateTime);
            
            var attendees = Attendances
                .Select(a => a.Attendee);

            foreach (var attendee in attendees)
            {
                attendee.Notify(notification);
            }
        }
    }
}