﻿using SQLite;

namespace Lab1_4.Entities
{
    [Table("Teams")]
    public class Team
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Emblem { get; set; }
    }
}
