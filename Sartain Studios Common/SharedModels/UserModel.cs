using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DatabaseInteraction.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace SharedModels
{
    public class UserModel : EntityBaseWithoutUserId
    {
        [BsonElement("username")]
        [Required]
        [MinLength(3)]
        public string Username { get; set; }

        [BsonElement("password")]
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [BsonElement("email")] [EmailAddress] public string Email { get; set; }

        [BsonElement("firstname")]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [BsonElement("lastname")]
        [MaxLength(30)]
        public string Lastname { get; set; }

        [BsonElement("profilephoto")] public string ProfilePhoto { get; set; }

        [BsonElement("roles")] public List<string> Roles { get; set; }

        [BsonElement("accountcreateddatetime")]
        [DataType(DataType.DateTime)]
        public DateTime? AccountCreatedDateTime { get; set; }

        [BsonElement("accountlastaccesseddatetime")]
        [DataType(DataType.DateTime)]
        public string? AccountLastAccessedDateTime { get; set; }

        [BsonElement("accountaccessdatetimes")]
        public List<string>? AccountAccessDateTimes { get; set; }

        [BsonElement("sitesused")]
        public List<string>? SitesUsed { get; set; }
    }
}