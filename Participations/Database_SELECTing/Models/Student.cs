﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Database_SELECTing.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string FavoriteColor { get; set; }

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();

    public override string ToString()
    {
        return $"{StudentId} {FirstName} {LastName}";
    }
}