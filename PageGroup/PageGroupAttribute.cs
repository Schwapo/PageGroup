using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public enum PageGroupGradient
{
    Solid,
    LeftToRight,
    RightToLeft,
    Inwards,
    Outwards,
}

[Conditional("UNITY_EDITOR")]
[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
public class PageGroupAttribute : PropertyGroupAttribute, ISubGroupProviderAttribute
{
    public string PageName;
    public List<string> PageNames { get; private set; }

    private string _horizontalPadding;
    private string _verticalPadding;
    private string _spaceBefore;
    private string _spaceAfter;
    private string _spaceBetween;
    private string _alwaysExpanded;
    private string _separated;
    private string _boldLabel;
    private string _boldPageLabel;
    private string _hideControlsIfCollapsed;
    private string _hidePagingButtons;
    private string _hidePageDropdown;
    private string _headerColor;
    private string _pageColor;
    private string _gradient;
    private string _adjustColors;
    private string _tooltip;

    public bool HasDefinedHorizontalPadding { get; private set; }
    public bool HasDefinedVerticalPadding { get; private set; }
    public bool HasDefinedSpaceBefore { get; private set; }
    public bool HasDefinedSpaceAfter { get; private set; }
    public bool HasDefinedSpaceBetween { get; private set; }
    public bool HasDefinedAlwaysExpanded { get; private set; }
    public bool HasDefinedSeparated { get; private set; }
    public bool HasDefinedBoldLabel { get; private set; }
    public bool HasDefinedBoldPageLabel { get; private set; }
    public bool HasDefinedHideControlsIfCollapsed { get; private set; }
    public bool HasDefinedHidePagingButtons { get; private set; }
    public bool HasDefinedHidePageDropdown { get; private set; }
    public bool HasDefinedHeaderColor { get; private set; }
    public bool HasDefinedPageColor { get; private set; }
    public bool HasDefinedGradient { get; private set; }
    public bool HasDefinedAdjustColors { get; private set; }
    public bool HasDefinedTooltip { get; private set; }

    /// <summary>
    /// The horizontal padding of the group's pages. <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string HorizontalPadding
    {
        get => _horizontalPadding;
        set { _horizontalPadding = value; HasDefinedHorizontalPadding = true; }
    }

    /// <summary>
    /// The vertical padding of the group's pages. <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string VerticalPadding
    {
        get => _verticalPadding;
        set { _verticalPadding = value; HasDefinedVerticalPadding = true; }
    }

    /// <summary>
    /// The space before the group. <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string SpaceBefore
    {
        get => _spaceBefore;
        set { _spaceBefore = value; HasDefinedSpaceBefore = true; }
    }

    /// <summary>
    /// The space after the group. <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string SpaceAfter
    {
        get => _spaceAfter;
        set { _spaceAfter = value; HasDefinedSpaceAfter = true; }
    }

    /// <summary>
    /// The space between the elements of the group. <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string SpaceBetween
    {
        get => _spaceBetween;
        set { _spaceBetween = value; HasDefinedSpaceBetween = true; }
    }

    /// <summary>
    /// If true, the group will always be expanded. <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string AlwaysExpanded
    {
        get => _alwaysExpanded;
        set { _alwaysExpanded = value; HasDefinedAlwaysExpanded = true; }
    }
    
    /// <summary>
    /// If true, the elements of the group will be seperated by a horizontal line. <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string Separated
    {
        get => _separated;
        set { _separated = value; HasDefinedSeparated = true; }
    }

    /// <summary>
    /// If true, the group's label/foldout will be drawn bold. <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string BoldLabel
    {
        get => _boldLabel;
        set { _boldLabel = value; HasDefinedBoldLabel = true; }
    }

    /// <summary>
    /// If true, the page dropdown labels will be drawn bold. <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string BoldPageLabel
    {
        get => _boldPageLabel;
        set { _boldPageLabel = value; HasDefinedBoldPageLabel = true; }
    }
    
    /// <summary>
    /// If true, the group's controls will be hidden while the group is collapsed. <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string HideControlsIfCollapsed
    {
        get => _hideControlsIfCollapsed;
        set { _hideControlsIfCollapsed = value; HasDefinedHideControlsIfCollapsed = true; }
    }

    /// <summary>
    /// If true, the paging buttons will be hidden independent of the expanded state. <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string HidePagingButtons
    {
        get => _hidePagingButtons;
        set { _hidePagingButtons = value; HasDefinedHidePagingButtons = true; }
    }
    
    /// <summary>
    /// If true, the page dropdown will be hidden independent of the expanded state. <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string HidePageDropdown
    {
        get => _hidePageDropdown;
        set { _hidePageDropdown = value; HasDefinedHidePageDropdown = true; }
    }

    /// <summary>
    /// The color of the group's header. <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string HeaderColor
    {
        get => _headerColor;
        set { _headerColor = value; HasDefinedHeaderColor = true; }
    }

    /// <summary>
    /// The color of the group's pages. <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string PageColor
    {
        get => _pageColor;
        set { _pageColor = value; HasDefinedPageColor = true; }
    }
   
    /// <summary>
    /// The gradient type. Possible values are: PageGroupGradient.(Solid, LeftToRight, RightToLeft, Inwards, Outwards). <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string Gradient
    {
        get => _gradient;
        set { _gradient = value; HasDefinedGradient = true; }
    }
    
    /// <summary>
    /// If true, label colors will be switched between black and white depending on the gradient color. Which gradients trigger this can be adjusted in the PageGroupPreference ScriptableObject. <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string AdjustColors
    {
        get => _adjustColors;
        set { _adjustColors = value; HasDefinedAdjustColors = true; }
    }

    /// <summary>
    /// The tooltip to be shown when you hover over the group's label/foldout. <see href="https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1">Resolved Value</see>
    /// </summary>
    public string Tooltip
    {
        get => _tooltip;
        set { _tooltip = value; HasDefinedTooltip = true; }
    }

    public PageGroupAttribute(string groupId, string pageName, float order = 0) : base(groupId, order)
    {
        PageName = pageName;
        PageNames = new List<string>();

        if (pageName != null)
        {
            PageNames.Add(pageName);
        }
    }

    protected override void CombineValuesWith(PropertyGroupAttribute other)
    {
        base.CombineValuesWith(other);

        var otherPage = other as PageGroupAttribute;

        if (otherPage.PageName != null)
        {
            if (otherPage.HasDefinedHorizontalPadding) HorizontalPadding = otherPage.HorizontalPadding;
            if (otherPage.HasDefinedVerticalPadding) VerticalPadding = otherPage.VerticalPadding;
            if (otherPage.HasDefinedSpaceBefore) SpaceBefore = otherPage.SpaceBefore;
            if (otherPage.HasDefinedSpaceAfter) SpaceAfter = otherPage.SpaceAfter;
            if (otherPage.HasDefinedSpaceBetween) SpaceBetween = otherPage.SpaceBetween;
            if (otherPage.HasDefinedAlwaysExpanded) AlwaysExpanded = otherPage.AlwaysExpanded;
            if (otherPage.HasDefinedSeparated) Separated = otherPage.Separated;
            if (otherPage.HasDefinedHideControlsIfCollapsed) HideControlsIfCollapsed = otherPage.HideControlsIfCollapsed;
            if (otherPage.HasDefinedBoldLabel) BoldLabel = otherPage.BoldLabel;
            if (otherPage.HasDefinedBoldPageLabel) BoldPageLabel = otherPage.BoldPageLabel;
            if (otherPage.HasDefinedHidePagingButtons) HidePagingButtons = otherPage.HidePagingButtons;
            if (otherPage.HasDefinedHidePageDropdown) HidePageDropdown = otherPage.HidePageDropdown;
            if (otherPage.HasDefinedHeaderColor) HeaderColor = otherPage.HeaderColor;
            if (otherPage.HasDefinedPageColor) PageColor = otherPage.PageColor;
            if (otherPage.HasDefinedGradient) Gradient = otherPage.Gradient;
            if (otherPage.HasDefinedAdjustColors) AdjustColors = otherPage.AdjustColors;
            if (otherPage.HasDefinedTooltip) Tooltip = otherPage.Tooltip;

            if (!PageNames.Contains(otherPage.PageName))
            {
                PageNames.Add(otherPage.PageName);
            }
        }
    }

    IList<PropertyGroupAttribute> ISubGroupProviderAttribute.GetSubGroupAttributes()
    {
        var count = 0;
        var result = new List<PropertyGroupAttribute>(PageNames.Count);

        foreach (var pageName in PageNames)
        {
            result.Add(new PageSubGroupAttribute(GroupID + "/" + pageName, count++));
        }

        return result;
    }

    string ISubGroupProviderAttribute.RepathMemberAttribute(PropertyGroupAttribute attribute)
    {
        var page = (PageGroupAttribute)attribute;

        return GroupID + "/" + page.PageName;
    }

    [Conditional("UNITY_EDITOR")]
    public class PageSubGroupAttribute : PropertyGroupAttribute
    {
        public PageSubGroupAttribute(string groupId, float order) : base(groupId, order) { }
    }
}
