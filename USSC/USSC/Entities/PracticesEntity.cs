﻿using System.ComponentModel.DataAnnotations.Schema;

namespace USSC.Entities;

public class PracticesEntity : BaseEntity
{
    public  string? Description { get; set; }
    public  string? Info { get; set; }
    public  string? Name { get; set; }
    public  string? Path { get; set; }
    public List<DirectionsEntity>? Directions { get; set; }
}