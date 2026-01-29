using Exam2.Dtos;
using Exam2.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Exam2.Services;

public class MovieService : IMoviceService
{
    private readonly List<Movie> _movies = new();

    // CREATE
    public void Add(Movie movie)
    {
        _movies.Add(movie);
    }

    // READ
    public List<MovieDto> GetAll()
    {
        return _movies.Select(ToDto).ToList();
    }

    // UPDATE
    public void Update(Movie movie)
    {
        var existing = _movies.FirstOrDefault(x => x.Id == movie.Id);
        if (existing == null) return;

        existing.Title = movie.Title;
        existing.Director = movie.Director;
        existing.DurationMinutes = movie.DurationMinutes;
        existing.Rating = movie.Rating;
        existing.BoxOfficeEarnings = movie.BoxOfficeEarnings;
        existing.ReleaseDate = movie.ReleaseDate;
    }

    // DELETE
    public void Delete(int id)
    {
        var movie = _movies.FirstOrDefault(x => x.Id == id);
        if (movie != null)
            _movies.Remove(movie);
    }

    // 1. Director bo‘yicha filmlar
    public List<MovieDto> GetAllMoviesByDirector(string director)
    {
        return _movies
            .Where(x => x.Director == director)
            .Select(ToDto)
            .ToList();
    }

    // 2. Eng yuqori rating
    public MovieDto GetTopRatedMovie()
    {
        return _movies
            .OrderByDescending(x => x.Rating)
            .Select(ToDto)
            .FirstOrDefault();
    }

    // 3. Yildan keyin chiqqanlar
    public List<MovieDto> GetMoviesReleasedAfterYear(int year)
    {
        return _movies
            .Where(x => x.ReleaseDate.Year > year)
            .Select(ToDto)
            .ToList();
    }

    // 4. Eng ko‘p daromad
    public MovieDto GetHighestGrossingMovie()
    {
        return _movies
            .OrderByDescending(x => x.BoxOfficeEarnings)
            .Select(ToDto)
            .FirstOrDefault();
    }

    // 5. Title bo‘yicha qidirish
    public List<MovieDto> SearchMoviesByTitle(string keyword)
    {
        return _movies
            .Where(x => x.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .Select(ToDto)
            .ToList();
    }

    // 6. Duration oralig‘i
    public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
    {
        return _movies
            .Where(x => x.DurationMinutes >= minMinutes && x.DurationMinutes <= maxMinutes)
            .Select(ToDto)
            .ToList();
    }

    // 7. Director bo‘yicha jami daromad
    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
        return _movies
            .Where(x => x.Director == director)
            .Sum(x => x.BoxOfficeEarnings);
    }

    // 8. Rating bo‘yicha sort (katta → kichik)
    public List<MovieDto> GetMoviesSortedByRating()
    {
        return _movies
            .OrderByDescending(x => x.Rating)
            .Select(ToDto)
            .ToList();
    }

    // 9. So‘nggi yillar ichida chiqanlar
    public List<MovieDto> GetRecentMovies(int years)
    {
        var fromDate = DateTime.Now.AddYears(-years);
        return _movies
            .Where(x => x.ReleaseDate >= fromDate)
            .Select(ToDto)
            .ToList();
    }

    private MovieDto ToDto(Movie m)
    {
        return new MovieDto
        {
            Id = m.Id,
            Title = m.Title,
            Director = m.Director,
            DurationMinutes = m.DurationMinutes,
            Rating = m.Rating,
            BoxOfficeEarnings = m.BoxOfficeEarnings,
            ReleaseDate = m.ReleaseDate
        };
    }

    List<MovieDto> IMoviceService.GetAllMoviesByDirector(string director)
    {
        throw new NotImplementedException();
    }

    MovieDto IMoviceService.GetTopRatedMovie()
    {
        throw new NotImplementedException();
    }

    List<MovieDto> IMoviceService.GetMoviesReleasedAfterYear(int year)
    {
        throw new NotImplementedException();
    }

    MovieDto IMoviceService.GetHighestGrossingMovie()
    {
        throw new NotImplementedException();
    }

    List<MovieDto> IMoviceService.SearchMoviesWithinDurationRange(int minMinutes, int maxMinutes)
    {
        throw new NotImplementedException();
    }

    long IMoviceService.GetTotalBoxOfficeEarningsByDirector(string director)
    {
        throw new NotImplementedException();
    }

    List<MovieDto> IMoviceService.GetMoviesSortedByRating()
    {
        throw new NotImplementedException();
    }

    List<MovieDto> IMoviceService.GetRecentMovies(int years)
    {
        throw new NotImplementedException();
    }
}

