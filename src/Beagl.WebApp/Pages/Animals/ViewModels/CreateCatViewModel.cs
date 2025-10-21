// MIT License - Copyright (c) 2025 Jonathan St-Michel

using System.ComponentModel.DataAnnotations;

namespace Beagl.WebApp.Pages.Animals.ViewModels;

/// <summary>
/// ViewModel for creating a cat.
/// </summary>
internal sealed class CreateCatViewModel : CreateAnimalViewModel
{
    /// <summary>
    /// Gets or sets whether the cat is an unclawned cat.
    /// </summary>
    [Required]
    public bool IsAnUnclawnedCat { get; set; }
}
