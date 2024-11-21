﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VinotecaRecu.Data.Enum;

namespace VinotecaRecu.Data.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Nombre de usuario, requerido y único
        public string Username { get; set; } = string.Empty;

        // Contraseña, al menos 8 caracteres
        public string Password { get; set; }
        public Rol Rol { get; set; }
    }
}
