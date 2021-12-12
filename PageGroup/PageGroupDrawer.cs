#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class PageGroupDrawer : OdinGroupDrawer<PageGroupAttribute>, IOnSelfStateChangedNotification
{    
    public const string CurrentPageIndexKey = "CurrentPageIndex";
    private ValueResolver<Color> headerColor;
    private ValueResolver<Color> pageColor;
    private ValueResolver<PageGroupGradient> gradient;
    private ValueResolver<int> spaceBefore;
    private ValueResolver<int> spaceAfter;
    private ValueResolver<int> spaceBetween;
    private ValueResolver<int> verticalPadding;
    private ValueResolver<int> horizontalPadding;
    private ValueResolver<bool> alwaysExpanded;
    private ValueResolver<bool> separated;
    private ValueResolver<bool> boldLabel;
    private ValueResolver<bool> boldPageLabel;
    private ValueResolver<bool> hideControlsIfCollapsed;
    private ValueResolver<bool> hidePagingButtons;
    private ValueResolver<bool> hidePageDropdown;
    private ValueResolver<bool> adjustColors;
    private ValueResolver<string> tooltip;
    private GenericSelector<Page> pageSelector;
    private int currentPageIndex;
    private List<Page> pages;
    
    protected override void Initialize()
    {
        ResolveValues();
        
        pages = new List<Page>();

        foreach (var child in Property.Children)
        {
            pages.Add(new Page(child.NiceName, child.Children));
        }

        Property.State.Create(CurrentPageIndexKey, true, 0);
        currentPageIndex = GetClampedCurrentIndex();

        pageSelector = new GenericSelector<Page>("", false, (p) => p.PageName, pages);
        pageSelector.EnableSingleClickToSelect();
        
        pageSelector.SelectionConfirmed += p =>
        {
            currentPageIndex = pages.IndexOf(p.Single());
            Property.State.Set(CurrentPageIndexKey, currentPageIndex);
        };
    }

    protected override void DrawPropertyLayout(GUIContent label)
    {
        DrawGroup(label);
    }

    private void ResolveValues()
    {
        var prop = Property;
        var attr = Attribute;
        var pref = PageGroupPreferences.Instance;

        headerColor             = ValueResolver.Get(prop, attr.HeaderColor,             pref.HeaderColor);
        pageColor               = ValueResolver.Get(prop, attr.PageColor,               pref.PageColor);
        gradient                = ValueResolver.Get(prop, attr.Gradient,                pref.Gradient);
        horizontalPadding       = ValueResolver.Get(prop, attr.HorizontalPadding,       pref.HorizontalPadding);
        verticalPadding         = ValueResolver.Get(prop, attr.VerticalPadding,         pref.VerticalPadding);
        spaceBefore             = ValueResolver.Get(prop, attr.SpaceBefore,             pref.SpaceBefore);
        spaceAfter              = ValueResolver.Get(prop, attr.SpaceAfter,              pref.SpaceAfter);
        spaceBetween            = ValueResolver.Get(prop, attr.SpaceBetween,            pref.SpaceBetween);
        alwaysExpanded          = ValueResolver.Get(prop, attr.AlwaysExpanded,          pref.AlwaysExpanded);
        separated               = ValueResolver.Get(prop, attr.Separated,               pref.Seperated);
        boldLabel               = ValueResolver.Get(prop, attr.BoldLabel,               pref.BoldLabel);
        boldPageLabel           = ValueResolver.Get(prop, attr.BoldPageLabel,           pref.BoldPageLabel);
        hideControlsIfCollapsed = ValueResolver.Get(prop, attr.HideControlsIfCollapsed, pref.HideControlsIfCollapsed);
        hidePagingButtons       = ValueResolver.Get(prop, attr.HidePagingButtons,       pref.HidePagingButtons);
        hidePageDropdown        = ValueResolver.Get(prop, attr.HidePageDropdown,        pref.HidePageDropdown);
        adjustColors            = ValueResolver.Get(prop, attr.AdjustColors,            pref.AdjustColors);
        tooltip                 = ValueResolver.GetForString(prop, attr.Tooltip);
    }

    private int GetClampedCurrentIndex()
    {
        var currentIndex = Property.State.Get<int>(CurrentPageIndexKey);

        if (currentIndex < 0)
        {
            currentIndex = 0;
            Property.State.Set(CurrentPageIndexKey, currentIndex);
        }
        else if (currentIndex >= pages.Count)
        {
            currentIndex = pages.Count - 1;
            Property.State.Set(CurrentPageIndexKey, currentIndex);
        }

        return currentIndex;
    }

    public void OnSelfStateChanged(string changedState)
    {
        if (changedState == CurrentPageIndexKey)
        {
            currentPageIndex = GetClampedCurrentIndex();
        }
    }

    private class Page
    {
        public string PageName;
        public IEnumerable<InspectorProperty> InspectorProperties;

        public Page(string pageName, IEnumerable<InspectorProperty> inspectorProperties) =>
            (PageName, InspectorProperties) = (pageName, inspectorProperties);
    }
}
#endif
