using Exam2.Dtos;
using Exam2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam2.Services;

public interface IMoviceService 
{
   
    void Add(MovieDto dto);
    void Update(Guid id, MovieDto dto);
    void Delete(Guid id);
    Movie GetById(Guid id);

    List<MovieDto> GetAllMoviesByDirector(string director);
    MovieDto GetTopRatedMovie();
    List<MovieDto> GetMoviesReleasedAfterYear(int year);
    MovieDto GetHighestGrossingMovie();
    List<MovieDto> SearchMoviesByTitle(string keyword);
    List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes);
    long GetTotalBoxOfficeEarningsByDirector(string director);
    List<MovieDto> GetMoviesSortedByRating();
    List<MovieDto> GetRecentMovies(int years);

}
