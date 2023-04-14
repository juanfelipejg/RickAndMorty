﻿using System.Text.Json.Serialization;
using RickAndMorty.Domain.Models.Episodes;

namespace RickAndMorty.Domain.Models.Characters
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Species { get; set; }

        public string Type { get; set; }

        public string Gender { get; set; }

        public string Image { get; set; }

        public string Url { get; set; }

		[JsonIgnore]
		public List<Episode> Episodes { get; set; }
    }
}
