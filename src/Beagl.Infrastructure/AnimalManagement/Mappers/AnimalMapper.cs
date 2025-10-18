// MIT License - Copyright (c) 2025 Jonathan St-Michel

using Beagl.Application.AnimalManagement.DTOs;
using Beagl.Domain.AnimalManagement;
using Beagl.Domain.AnimalManagement.ValueObjects;
using Beagl.Domain.Core.Interfaces;
using Beagl.Domain.Core.ValueObjects;

namespace Beagl.Infrastructure.AnimalManagement.Mappers;

/// <summary>
/// Provides mapping methods between Animal aggregate and AnimalDto.
/// </summary>
public class AnimalMapper : IEntityMapper<Animal, AnimalDto>
{
    /// <summary>
    /// Maps an AnimalDto to an Animal aggregate.
    /// </summary>
    /// <param name="dto">The AnimalDto to map.</param>
    /// <returns>An Animal aggregate.</returns>
    public Animal CreateFromDto(AnimalDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        Gender gender = Gender.FromString(dto.Gender);
        Photo? photo = dto.PhotoBase64 != null ? new Photo(dto.PhotoBase64) : null;
        Microchip? microchip = dto.MicrochipNumber != null ? new Microchip(dto.MicrochipNumber) : null;
        DangerousDog? dangerousDog = dto.IsDangerousDog ? new DangerousDog(true, false, null) : null;
        OriginCityInfo? originCityInfo = new(dto.ComesFromAnotherCity, dto.CityName, dto.HadJudgmentInThatCity);

        Animal animal = Animal.Create(
            dto.Name,
            dto.SpeciesId,
            dto.PrimaryBreedId,
            dto.SecondaryBreedId,
            dto.ColorId,
            gender,
            dto.BirthDate,
            photo,
            microchip,
            dangerousDog,
            dto.IsAnAssistanceDog,
            dto.IsAnUnclawnedCat,
            originCityInfo,
            dto.DistinctiveDescription,
            dto.CreatedByUserId,
            dto.CreatedAt);

        return animal;
    }

    /// <summary>
    /// Maps an Animal aggregate to an AnimalDto.
    /// </summary>
    public AnimalDto ToDto(Animal entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        return new AnimalDto
        {
            Id = entity.Id,
            Name = entity.Name,
            SpeciesId = entity.SpeciesId,
            PrimaryBreedId = entity.PrimaryBreedId,
            SecondaryBreedId = entity.SecondaryBreedId,
            ColorId = entity.ColorId,
            DistinctiveDescription = entity.DistinctiveDescription ?? string.Empty,
            Gender = entity.Gender.ToString(),
            BirthDate = entity.DateOfBirth,
            PhotoBase64 = entity.Photo?.Base64Png,
            MicrochipNumber = entity.Microchip?.Value,
            IsDangerousDog = entity.DangerousDog?.IsDangerous ?? false,
            IsAnAssistanceDog = entity.IsAnAssistanceDog,
            IsAnUnclawnedCat = entity.IsAnUnclawnedCat,
            CityName = entity.OriginCityInfo?.CityName ?? string.Empty,
            ComesFromAnotherCity = entity.OriginCityInfo?.ComesFromAnotherCity ?? false,
            HadJudgmentInThatCity = entity.OriginCityInfo?.HadJudgmentInThatCity ?? false,
            HealthRecords = [], // TODO: Map health records if available
            MedalRecords = [],  // TODO: Map medal records if available
            CreatedAt = entity.Created?.At ?? DateTimeOffset.MinValue,
            CreatedByUserId = entity.Created?.UserId ?? Guid.Empty,
            ModifiedAt = entity.Modified?.At,
            ModifiedByUserId = entity.Modified?.UserId
        };
    }

    /// <summary>
    /// Updates an existing Animal aggregate from an AnimalDto.
    /// </summary>
    /// <param name="entity">The Animal aggregate to update.</param>
    /// <param name="dto">The AnimalDto to map from.</param>
    public void UpdateFromDto(Animal entity, AnimalDto dto)
    {
        // ArgumentNullException.ThrowIfNull(entity);
        // ArgumentNullException.ThrowIfNull(dto);

        // entity.Rename(dto.Name);
        // entity.ChangeSpecies(dto.Species ?? string.Empty);
        // entity.ChangeBreed(new Breed(dto.Breed ?? string.Empty, string.Empty));
        // entity.ChangeColor(dto.Color ?? string.Empty);
        // entity.SetDistinctiveDescription(dto.DistinctiveDescription);
        // if (Enum.TryParse<Gender>(dto.Gender, out var gender))
        //     entity.ChangeGender(gender);
        // entity.ChangeDateOfBirth(dto.BirthDate ?? DateTime.MinValue);
        // entity.SetPhoto(dto.PhotoBase64 != null ? new Photo(dto.PhotoBase64) : null);
        // entity.SetMicrochip(dto.MicrochipNumber != null ? new Microchip(dto.MicrochipNumber) : null);
        // entity.SetDangerousDog(dto.IsDangerousDog ? new DangerousDog(true, false, null) : null);
        // entity.SetAssistanceDog(dto.IsAnAssistanceDog);
        // entity.SetUnclawnedCat(dto.IsAnUnclawnedCat);
        // entity.SetOriginCityInfo((dto.OriginCityName != null || dto.OriginCityProvince != null || dto.OriginCityCountry != null)
        //     ? new OriginCityInfo(dto.OriginCityName, dto.OriginCityProvince, dto.OriginCityCountry, false, false)
        //     : null);

        // // Update HealthRecords: simplistic approach (clear and re-add)
        // if (dto.HealthRecords != null)
        // {
        //     List<HealthRecord> toRemove = entity.HealthRecords.ToList();
        //     foreach (HealthRecord hr in toRemove)
        //         entity.RemoveHealthRecord(hr);
        //     foreach (HealthRecordDto hrDto in dto.HealthRecords)
        //     {
        //         HealthRecord hr = new(entity);

        //         hr.SetModifiedAudit(hrDto.ModifiedByUserId, hrDto.ModifiedAt);

        //         if (hrDto.WeightValue.HasValue && !string.IsNullOrEmpty(hrDto.WeightUnit))
        //             hr.UpdateWeight(new Weight(hrDto.WeightValue.Value, hrDto.WeightUnit));
        //         if (hrDto.RabiesVaccinationDate.HasValue)
        //             hr.RecordRabiesVaccination(hrDto.RabiesVaccinationDate.Value);
        //         if (hrDto.IsSterilized)
        //             hr.Sterilize();
        //         entity.AddHealthRecord(hr);
        //     }
        // }
    }
}
