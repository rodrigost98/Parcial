using System;
using System.ComponentModel.DataAnnotations;

namespace APIparcial.Models
{


    public enum FriendType
    {
        Conocido,
        Compañero_de_estudio,
        Colega_de_trabajo,
        Amigo,
        Amigo_de_la_infancia,
        Pariente

    }

    public enum FriendStatus
    {
        Activo,
        inactivo
    }

    public class RodrigoSantistevanFriend
    {
        [Key]
        public int FriendID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthdate { get; set; }
        
        [Required]
        public FriendType Friend{ get; set; }
        public FriendStatus Status { get; set; }



    }
}