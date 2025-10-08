// MIT License - Copyright (c) 2025 Jonathan St-Michel

namespace Beagl.WebApp.Pages.Shared;

/// <summary>
/// Model for configuring the reusable delete confirmation modal partial view.
/// </summary>
internal sealed class DeleteModalModel
{
    /// <summary>
    /// Gets or sets the modal HTML id.
    /// </summary>
    public string ModalId { get; set; } = "deleteModal";

    /// <summary>
    /// Gets or sets the modal label HTML id.
    /// </summary>
    public string ModalLabelId { get; set; } = "deleteModalLabel";

    /// <summary>
    /// Gets or sets the modal title (localization key).
    /// </summary>
    public string Title { get; set; } = "Confirm Delete";

    /// <summary>
    /// Gets or sets the label for the close button (localization key).
    /// </summary>
    public string CloseLabel { get; set; } = "Close";

    /// <summary>
    /// Gets or sets the label for the cancel button (localization key).
    /// </summary>
    public string CancelLabel { get; set; } = "Cancel";

    /// <summary>
    /// Gets or sets the label for the confirm button (localization key).
    /// </summary>
    public string ConfirmLabel { get; set; } = "Delete";

    /// <summary>
    /// Gets or sets the page handler name for the form.
    /// </summary>
    public string Handler { get; set; } = "Delete";

    /// <summary>
    /// Gets or sets the form HTML id.
    /// </summary>
    public string FormId { get; set; } = "deleteForm";

    /// <summary>
    /// Gets or sets the entity id input HTML id.
    /// </summary>
    public string EntityIdInputId { get; set; } = "deleteEntityId";

    /// <summary>
    /// Gets or sets the entity id value.
    /// </summary>
    public string? EntityId { get; set; }

    /// <summary>
    /// Gets or sets the page number value.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Gets or sets the filter model to be passed as hidden fields.
    /// </summary>
    public object? FilterModel { get; set; }

    /// <summary>
    /// Gets or sets the modal body HTML (localized and formatted).
    /// </summary>
    public required string BodyHtml { get; set; } = string.Empty;
}
