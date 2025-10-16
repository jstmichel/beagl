// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.Domain.Core.Interfaces;

/// <summary>
/// Defines a contract for mapping between an entity (or aggregate root) and its DTO.
/// </summary>
/// <typeparam name="TEntity">The entity or aggregate root type.</typeparam>
/// <typeparam name="TDto">The DTO type.</typeparam>
public interface IEntityMapper<TEntity, TDto>
{
    /// <summary>
    /// Creates a new entity from a DTO.
    /// </summary>
    /// <param name="dto">The DTO to map from.</param>
    /// <returns>The created entity.</returns>
    public TEntity CreateFromDto(TDto dto);

    /// <summary>
    /// Updates an existing entity from a DTO.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <param name="dto">The DTO to map from.</param>
    public void UpdateFromDto(TEntity entity, TDto dto);

    /// <summary>
    /// Maps an entity to its DTO.
    /// </summary>
    /// <param name="entity">The entity to map from.</param>
    /// <returns>The mapped DTO.</returns>
    public TDto ToDto(TEntity entity);
}
