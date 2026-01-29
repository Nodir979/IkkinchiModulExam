using Exam2.Dtos;
using Exam2.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam2.Models;

internal class Movie : MovieService
{


    public  Guid Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public int DurationMinutes { get; set; }
    public double Rating { get; set; }
    public long BoxOfficeEarnings { get; set; }
    public DateTime ReleaseDate { get; set; }


}
