﻿namespace CarApplication.Models.Car
{
    public class CarDeleteViewModel
    {
        public Guid? Id { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
