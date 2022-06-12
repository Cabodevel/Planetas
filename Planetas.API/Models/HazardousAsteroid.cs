﻿namespace Planetas.API.Models
{
    public class HazardousAsteroid
    {
        public string Name { get; set; }
        public decimal Diameter { get; set; }

        public decimal Speed { get; set; }

        public string Date { get; set; }

        public string Planet { get; set; }
    }
}