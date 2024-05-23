﻿using SaunausiaKomanda.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace SaunausiaKomanda.API.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Value { get; set; } = null!;
        public ImageLocation ImageLocation { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Timestamp]
        public byte[] Version { get; set; } = null!;
    }
}
