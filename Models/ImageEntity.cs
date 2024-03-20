﻿using System.ComponentModel.DataAnnotations;

namespace Imagestore.Models
{
    public class ImageEntity
    {
        [Key]
        public int Id { get; set; }

        public string? FileName { get; set; }

        public byte[] Data { get; set; }

    }
}
