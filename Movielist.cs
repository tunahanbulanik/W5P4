using System;
using System.ComponentModel.DataAnnotations;

public class MovieList
{
    public string MovieName { get; set; }
    public double MovieScore { get; set; }

    public override string ToString()
    {
        return $"Film: {MovieName} Puan: {MovieScore}";
    }
}