﻿using System.ComponentModel.DataAnnotations;

namespace PersonalFinance.Application.ViewModel.Request.Expenditure;

public class CreateExpenditureRequest
{
    [Required(ErrorMessage ="The Name is Required")]
    [MinLength(3)]
    [MaxLength(30)]
    public string Name { get; set; }
        
    [Required(ErrorMessage ="The Date is Required")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage ="The Value is Required")]
    public decimal Value { get; set; }

    [Required(ErrorMessage ="The Description is Required")]
    [MinLength(3)]
    [MaxLength(60)]
    public string Description { get; set; }

    public int ExpenditureCategoryId { get; set; }
}