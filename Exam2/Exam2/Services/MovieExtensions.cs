using Exam2.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam2.Services;

public static class MovieExtensions
{
    public static double DurationInHours(this MovieDto movie)
    {
        return movie.DurationMinutes / 60.0;
    }

    public static long TotalBoxOffice(this List<MovieDto> movies)
    {
        long sum = 0;

        foreach (MovieDto movie in movies)
        {
            sum += movie.BoxOfficeEarnings;
        }

        return sum;
    }
}
