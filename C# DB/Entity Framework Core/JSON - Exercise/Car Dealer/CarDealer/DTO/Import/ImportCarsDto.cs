﻿namespace CarDealer.DTO
{
    using System.Collections.Generic;

    public class ImportCarsDto
    {

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public List<int> PartsId { get; set; }
    }
}
