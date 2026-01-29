using Exam2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam2.Dtos;

public class MovieDto
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int DurationMinutes { get; set; }
    public double Rating { get; set; }
    public long BoxOfficeEarnings { get; set; }
    public DateTime ReleaseDate { get; set; }
}
