using Exam2.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam2.Services;

public interface IMoviceService 
{
    public List<MovieDto> GetAllMoviesByDirector(string  director);
    public MovieDto GetTopRatedMovie();
    public List<MovieDto> GetMoviesReleasedAfterYear(int year);
    public MovieDto GetHighestGrossingMovie();
    public List<MovieDto> SearchMoviesWithinDurationRange(int minMinutes, int maxMinutes);
    public long GetTotalBoxOfficeEarningsByDirector(string director);
    public List<MovieDto> GetMoviesSortedByRating();
    public List<MovieDto> GetRecentMovies(int years);

}
