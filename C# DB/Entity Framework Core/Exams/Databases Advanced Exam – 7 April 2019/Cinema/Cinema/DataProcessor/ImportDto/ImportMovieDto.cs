namespace Cinema.DataProcessor.ImportDto
{
    using System;

    using Data.Models.Enums;

    public class ImportMovieDto
    {

        public string Title { get; set; }


        public Genre Genre { get; set; }


        public TimeSpan Duration { get; set; }


        public double Rating { get; set; }


        public string Director { get; set; }

    }
}
