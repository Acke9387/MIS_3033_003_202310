﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EntityFramework_ReadingFromDatabase.Models;

public partial class FootballSchedule
{
    public int Id { get; set; }

    public int Season { get; set; }

    public string Opponent { get; set; }

    public DateTime Date { get; set; }

    public bool IsHomeGame { get; set; }

    public override string ToString()
    {
        return $"{Season} {Opponent} {Date.ToShortDateString()}";
    }
}