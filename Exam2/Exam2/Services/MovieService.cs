using Exam2.Dtos;
using Exam2.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Exam2.Services;


public class MovieService : IMoviceService
{
    private List<Movie> _movies = new List<Movie>();

    public void Add(MovieDto dto)
    {
        Movie movie = new Movie();
        movie.Id = Guid.NewGuid();
        movie.Title = dto.Title;
        movie.Director = dto.Director;
        movie.DurationMinutes = dto.DurationMinutes;
        movie.Rating = dto.Rating;
        movie.BoxOfficeEarnings = dto.BoxOfficeEarnings;
        movie.ReleaseDate = dto.ReleaseDate;

        _movies.Add(movie);
    }

    public void Update(Guid id, MovieDto dto)
    {
        foreach (Movie movie in _movies)
        {
            if (movie.Id == id)
            {
                movie.Title = dto.Title;
                movie.Director = dto.Director;
                movie.DurationMinutes = dto.DurationMinutes;
                movie.Rating = dto.Rating;
                movie.BoxOfficeEarnings = dto.BoxOfficeEarnings;
                movie.ReleaseDate = dto.ReleaseDate;
                break;
            }
        }
    }

    public void Delete(Guid id)
    {
        Movie found = null;

        foreach (Movie movie in _movies)
        {
            if (movie.Id == id)
            {
                found = movie;
                break;
            }
        }

        if (found != null)
            _movies.Remove(found);
    }

    public Movie GetById(Guid id)
    {
        foreach (Movie movie in _movies)
        {
            if (movie.Id == id)
                return movie;
        }
        return null;
    }

    public List<MovieDto> GetAllMoviesByDirector(string director)
    {
        List<MovieDto> result = new List<MovieDto>();

        foreach (Movie movie in _movies)
        {
            if (movie.Director == director)
            {
                result.Add(ToDto(movie));
            }
        }

        return result;
    }

    public MovieDto GetTopRatedMovie()
    {
        Movie best = null;

        foreach (Movie movie in _movies)
        {
            if (best == null || movie.Rating > best.Rating)
                best = movie;
        }

        return best == null ? null : ToDto(best);
    }

    public List<MovieDto> GetMoviesReleasedAfterYear(int year)
    {
        List<MovieDto> result = new List<MovieDto>();

        foreach (Movie movie in _movies)
        {
            if (movie.ReleaseDate.Year > year)
                result.Add(ToDto(movie));
        }

        return result;
    }

    public MovieDto GetHighestGrossingMovie()
    {
        Movie top = null;

        foreach (Movie movie in _movies)
        {
            if (top == null || movie.BoxOfficeEarnings > top.BoxOfficeEarnings)
                top = movie;
        }

        return top == null ? null : ToDto(top);
    }

    public List<MovieDto> SearchMoviesByTitle(string keyword)
    {
        List<MovieDto> result = new List<MovieDto>();

        foreach (Movie movie in _movies)
        {
            if (movie.Title.ToLower().Contains(keyword.ToLower()))
                result.Add(ToDto(movie));
        }

        return result;
    }

    public List<MovieDto> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes)
    {
        List<MovieDto> result = new List<MovieDto>();

        foreach (Movie movie in _movies)
        {
            if (movie.DurationMinutes >= minMinutes &&
                movie.DurationMinutes <= maxMinutes)
            {
                result.Add(ToDto(movie));
            }
        }

        return result;
    }

    public long GetTotalBoxOfficeEarningsByDirector(string director)
    {
        long sum = 0;

        foreach (Movie movie in _movies)
        {
            if (movie.Director == director)
                sum += movie.BoxOfficeEarnings;
        }

        return sum;
    }

    public List<MovieDto> GetMoviesSortedByRating()
    {
        List<Movie> temp = new List<Movie>(_movies);

       
for (int i = 0; i < temp.Count - 1; i++)
        {
            for (int j = i + 1; j < temp.Count; j++)
            {
                if (temp[i].Rating < temp[j].Rating)
                {
                    Movie t = temp[i];
                    temp[i] = temp[j];
                    temp[j] = t;
                }
            }
        }

        List<MovieDto> result = new List<MovieDto>();
        foreach (Movie movie in temp)
            result.Add(ToDto(movie));

        return result;
    }

    public List<MovieDto> GetRecentMovies(int years)
    {
        List<MovieDto> result = new List<MovieDto>();
        DateTime fromDate = DateTime.Now.AddYears(-years);

        foreach (Movie movie in _movies)
        {
            if (movie.ReleaseDate >= fromDate)
                result.Add(ToDto(movie));
        }

        return result;
    }

    private MovieDto ToDto(Movie movie)
    {
        MovieDto dto = new MovieDto();
        dto.Title = movie.Title;
        dto.Director = movie.Director;
        dto.DurationMinutes = movie.DurationMinutes;
        dto.Rating = movie.Rating;
        dto.BoxOfficeEarnings = movie.BoxOfficeEarnings;
        dto.ReleaseDate = movie.ReleaseDate;
        return dto;
    }
}