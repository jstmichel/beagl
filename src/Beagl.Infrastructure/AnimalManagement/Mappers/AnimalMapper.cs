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

        Breed breed = new(dto.Breed, string.Empty);
        Gender gender = Gender.FromString(dto.Gender);
        Photo? photo = dto.PhotoBase64 != null ? new Photo(dto.PhotoBase64) : null;
        Microchip? microchip = dto.MicrochipNumber != null ? new Microchip(dto.MicrochipNumber) : null;
        DangerousDog? dangerousDog = dto.IsDangerousDog ? new DangerousDog(true, false, null) : null;
        OriginCityInfo? originCityInfo = new(dto.ComesFromAnotherCity, dto.CityName, dto.HadJudgmentInThatCity);

        Animal animal = Animal.Create(
            dto.Name,
            dto.Species,
            breed,
            dto.Color,
            gender,
            dto.BirthDate,
            dto.CreatedByUserId,
            dto.CreatedAt,
            photo,
            microchip,
            dangerousDog,
            dto.IsAnAssistanceDog,
            dto.IsAnUnclawnedCat,
            originCityInfo
        );

        return animal;
    }

    /// <summary>
    /// Maps an Animal aggregate to an AnimalDto.
    /// </summary>
    public AnimalDto ToDto(Animal entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        // return new AnimalDto
        // {
        //     Id = entity.Id,
        //     Name = entity.Name,
        //     Species = entity.Species,
        //     Breed = entity.Breed?.Primary,
        //     Color = entity.Color,
        //     DistinctiveDescription = entity.DistinctiveDescription,
        //     Gender = entity.Gender.ToString(),
        //     BirthDate = entity.DateOfBirth,
        //     PhotoBase64 = entity.Photo?.Base64Png,
        //     MicrochipNumber = entity.Microchip?.Value,
        //     IsDangerousDog = entity.DangerousDog?.IsDangerous ?? false,
        //     IsAnAssistanceDog = entity.IsAnAssistanceDog,
        //     IsAnUnclawnedCat = entity.IsAnUnclawnedCat,
        //     CityName = entity.OriginCityInfo?.CityName,
        //     ComesFromAnotherCity = entity.OriginCityInfo?.ComesFromAnotherCity,
        //     HadJudgmentInThatCity = entity.OriginCityInfo?.HadJudgmentInThatCity,
        //     HealthRecords = entity.HealthRecords?.Select(hr => new HealthRecordDto
        //     {
        //         Id = hr.Id,
        //         IsSterilized = hr.IsSterilized,
        //         WeightValue = hr.Weight?.Value,
        //         WeightUnit = hr.Weight?.Unit,
        //         RabiesVaccinationDate = hr.RabiesVaccinationDate,
        //         CreatedAt = hr.Created.At,
        //         CreatedByUserId = hr.CreatedByUserId,
        //         ModifiedAt = hr.Modified.At,
        //         ModifiedByUserId = hr.ModifiedByUserId,
        //     }).ToList() ?? [],
        //     MedalRecords = entity.MedalRecords?.Select(mr => new MedalRecordDto
        //     {
        //         Id = mr.Id,
        //         MedalNumber = mr.MedalNumber,
        //         Reason = mr.Reason,
        //         AssignedDate = mr.AssignedDate,
        //         CreatedAt = mr.Created?.At,
        //         CreatedByUserId = mr.Created?.UserId,
        //         ModifiedAt = mr.Modified?.At,
        //         ModifiedByUserId = mr.Modified?.UserId,
        //     }).ToList() ?? [],
        // };

        return null!;
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
