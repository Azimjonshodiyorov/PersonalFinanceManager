﻿using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Application.ViewModel.Request.RevenueCategory;

public class CreateRevenueCategoryRequest
{
    [Required(ErrorMessage ="The Name is Required")]
    [MinLength(3)]
    [MaxLength(30)]
    public string Name { get; private set; }

    [Required(ErrorMessage ="The Description is Required")]
    [MinLength(3)]
    [MaxLength(60)]
    public string Description { get; private set; }
}