﻿using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Application.ViewModel.Request.UserRole;

public class UpdateUserRoleRequest
{
    [Required(ErrorMessage ="The Name is Required")]
    [MinLength(3)]
    [MaxLength(30)]
    public string Name { get;  set; }

    [Required(ErrorMessage ="The Description is Required")]
    [MinLength(3)]
    [MaxLength(60)]
    public string Description { get;  set; }
}