﻿namespace SurveyApp.Database.Models
{
    public class Question
    {

        public long Id { get; set; }

        public string? Content { get; set; }

        public long SurveyId { get; set; }

        public Survey? SurveyDetailsViewModel { get; set; }
    }
}
