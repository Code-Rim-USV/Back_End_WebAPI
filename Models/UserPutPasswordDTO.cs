﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Back_End_WebAPI.Models
{
    public class UserPutPasssordDTO
    {
        public int UserID {  get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}