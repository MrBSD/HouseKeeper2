using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseKeeper2.Core.Models
{
    public class Counter
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string SerialNumber { get; set; }

        [Required]
        public int CurrentMeasurementId { get; set; }
        public Measurement CurrentMeasurement { get; set; }
        public ICollection<Measurement> MeasurementHistory { get; set; }

        public Counter()
        {
            MeasurementHistory = new List<Measurement>();
        }

        private void AddMeaserment(Measurement measurement)
        {
            CurrentMeasurementId = measurement.Id;
            CurrentMeasurement = measurement;
            MeasurementHistory.Add(measurement);
        }
    }
}