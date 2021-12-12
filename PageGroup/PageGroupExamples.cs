#if UNITY_EDITOR
using Sirenix.OdinInspector;
using System;
using UnityEditor;
using UnityEngine;

public class PageGroupExamples : MonoBehaviour
{
    #region Colors

    [FoldoutGroup("Colors")]
    [PageGroup("Colors/Pages 1", "Page", HideControlsIfCollapsed = "HideControls", HeaderColor = "rainbow", PageColor = "rainbow")]
    public TestData Pages1;    

    private static Color rainbow => Color.HSVToRGB((Mathf.Sin(Time.realtimeSinceStartup / 3.0f) + 1.0f) / 2.0f, 0.7f, 0.7f);

    #endregion

    #region Gradients
    
    [FoldoutGroup("Gradients")]
    [PageGroup("Gradients/Solid", "Page", HeaderColor = "rainbow", PageColor = "rainbow", Gradient = "@PageGroupGradient.Solid")]
    public TestData Page7;    
    
    [PageGroup("Gradients/LeftToRight", "Page", HeaderColor = "rainbow", PageColor = "rainbow", Gradient = "@PageGroupGradient.LeftToRight")]
    public TestData Page8;    
    
    [PageGroup("Gradients/RightToLeft", "Page", HeaderColor = "rainbow", PageColor = "rainbow", Gradient = "@PageGroupGradient.RightToLeft")]
    public TestData Page9;    
    
    [PageGroup("Gradients/Inwards", "Page", HeaderColor = "rainbow", PageColor = "rainbow", Gradient = "@PageGroupGradient.Inwards")]
    public TestData Page10;    
    
    [PageGroup("Gradients/Outwards", "Page", HeaderColor = "rainbow", PageColor = "rainbow", Gradient = "@PageGroupGradient.Outwards")]
    public TestData Page11;

    #endregion

    #region Bold Labels

    [FoldoutGroup("Bold Labels")]
    [PageGroup("Bold Labels/Bold Foldout", "Page 1", BoldLabel = "@true", BoldPageLabel = "@true")]
    public TestData Bold1;
    
    [PageGroup("Bold Labels/Bold Label", "Page 1", BoldLabel = "@true", BoldPageLabel = "@true", AlwaysExpanded = "@true")]
    public TestData Bold2;

    #endregion

    #region Hidden Controls While Collapsed

    [FoldoutGroup("Hidden Controls While Collapsed")]
    [PageGroup("Hidden Controls While Collapsed/Pages 13", "Page", HideControlsIfCollapsed = "@true")]
    public TestData Page13;

    #endregion

    #region Always Expanded

    [FoldoutGroup("Always Expanded")]
    [PageGroup("Always Expanded/Expanded", "Page 1", AlwaysExpanded = "@true")]
    public TestData Expanded1;

    [PageGroup("Always Expanded/Expanded", "Page 1")]
    public TestData Expanded2;

    [PageGroup("Always Expanded/Expanded", "Page 1")]
    public TestData Expanded3;

    [PageGroup("Always Expanded/Expanded", "Page 2")]
    public TestData Expanded4;

    [PageGroup("Always Expanded/Expanded", "Page 2")]
    public TestData Expanded5;

    [PageGroup("Always Expanded/Expanded", "Page 2")]
    public TestData Expanded6;
    
    [PageGroup("Always Expanded/Expanded", "Page 3")]
    public TestData Expanded7;

    [PageGroup("Always Expanded/Expanded", "Page 3")]
    public TestData Expanded8;

    [PageGroup("Always Expanded/Expanded", "Page 3")]
    public TestData Expanded9;

    #endregion

    #region Seperated

    [FoldoutGroup("Seperated")]
    [PageGroup("Seperated/Seperated Elements", "Page 1", Separated = "@true", AlwaysExpanded = "@true")]
    public TestData SeperatedElements1;
    
    [PageGroup("Seperated/Seperated Elements", "Page 1")]
    public TestData SeperatedElements2;
    
    [PageGroup("Seperated/Seperated Elements", "Page 1")]
    public TestData SeperatedElements3;

    [PageGroup("Seperated/Seperated Elements", "Page 2")]
    public TestData SeperatedElements4;
    
    [PageGroup("Seperated/Seperated Elements", "Page 2")]
    public TestData SeperatedElements5;

    [PageGroup("Seperated/Seperated Elements", "Page 2")]
    public TestData SeperatedElements6;
    
    [PageGroup("Seperated/Seperated Elements", "Page 3")]
    public TestData SeperatedElements7;

    [PageGroup("Seperated/Seperated Elements", "Page 3")]
    public TestData SeperatedElements8;
    
    [PageGroup("Seperated/Seperated Elements", "Page 3")]
    public TestData SeperatedElements9;

    #endregion

    #region Padding

    [FoldoutGroup("Padding")]
    public int HorizontalPadding = 4;

    [FoldoutGroup("Padding")]
    public int VerticalPadding = 6;

    [PageGroup("Padding/Padded Elements", "Page 1", HorizontalPadding = "HorizontalPadding", VerticalPadding = "VerticalPadding", AlwaysExpanded = "@true")]
    public TestData PaddedElements1;
    
    [PageGroup("Padding/Padded Elements", "Page 1")]
    public TestData PaddedElements2;
    
    [PageGroup("Padding/Padded Elements", "Page 1")]
    public TestData PaddedElements3;

    [PageGroup("Padding/Padded Elements", "Page 2")]
    public TestData PaddedElements4;
    
    [PageGroup("Padding/Padded Elements", "Page 2")]
    public TestData PaddedElements5;

    [PageGroup("Padding/Padded Elements", "Page 2")]
    public TestData PaddedElements6;
    
    [PageGroup("Padding/Padded Elements", "Page 3")]
    public TestData PaddedElements7;

    [PageGroup("Padding/Padded Elements", "Page 3")]
    public TestData PaddedElements8;
    
    [PageGroup("Padding/Padded Elements", "Page 3")]
    public TestData PaddedElements9;

    #endregion

    #region Space

    [FoldoutGroup("Space")]
    public int SpaceBefore = 2;

    [FoldoutGroup("Space")]
    public int SpaceAfter = 1;
    
    [FoldoutGroup("Space")]
    public int SpaceBetween = 6;

    [PageGroup("Space/Spacing", "Page 1", SpaceBefore = "SpaceBefore", SpaceAfter = "SpaceAfter", SpaceBetween = "SpaceBetween", AlwaysExpanded = "@true")]
    public TestData Spacing1;
    
    [PageGroup("Space/Spacing", "Page 1")]
    public TestData Spacing2;
    
    [PageGroup("Space/Spacing", "Page 1")]
    public TestData Spacing3;

    [PageGroup("Space/Spacing", "Page 2")]
    public TestData Spacing4;
    
    [PageGroup("Space/Spacing", "Page 2")]
    public TestData Spacing5;

    [PageGroup("Space/Spacing", "Page 2")]
    public TestData Spacing6;
    
    [PageGroup("Space/Spacing", "Page 3")]
    public TestData Spacing7;

    [PageGroup("Space/Spacing", "Page 3")]
    public TestData Spacing8;
    
    [PageGroup("Space/Spacing", "Page 3")]
    public TestData Spacing9;

    #endregion

    #region Hidden Paging Buttons Or Page Dropdown

    [FoldoutGroup("Hidden Paging Buttons Or Page Dropdown")]
    [PageGroup("Hidden Paging Buttons Or Page Dropdown/HiddenPagingButtons", "Page 1", HidePagingButtons = "@true", AlwaysExpanded = "@true")]
    public TestData HiddenPagingButtons;
    
    [PageGroup("Hidden Paging Buttons Or Page Dropdown/HiddenPageDropdown", "Page 1", HidePageDropdown = "@true", AlwaysExpanded = "@true")]
    public TestData HiddenPageDropdown;

    #endregion

    #region Tooltip

    [FoldoutGroup("Tooltip")]
    [PageGroup("Tooltip/Label Tooltip", "Page 1", Tooltip = "This is a foldout/label tooltip")]
    public TestData Tooltip;

    #endregion

    #region AdjustColors

    [FoldoutGroup("Adjust Colors")]
    [PageGroup("Adjust Colors/Adjust Label Colors", "Page 1", AdjustColors = "@true", HeaderColor = "@Color.white", PageColor = "@Color.black", AlwaysExpanded = "@true")]
    public TestData AdjustColors;

    #endregion

    #region Test Data

    [Serializable]
    [InlineProperty, HideLabel]
    public class TestData
    {
        [HideLabel]
        [PreviewField(60f)]
        [HorizontalGroup("H", 60f)]
        [VerticalGroup("H/Left")]
        public Sprite SomeSprite;
        
        [VerticalGroup("H/Right")]
        public string SomeString;

        [VerticalGroup("H/Right")]
        public float SomeFloat;

        [VerticalGroup("H/Right")]
        public bool SomeBool;
    }

    #endregion

    #region Miscellaneous

    // Repaint constantly for rainbow color effect
    [OnInspectorGUI("@GUIHelper.RequestRepaint()")]

    [InfoBox("The page group has configurable preferences that can be set in the PageGroupPreferences ScriptableObject.\nIf these examples seem to be different from what they should be, its probably because you've changed the preferences :)"), PropertyOrder(-1)]
    private void InfoDummy() { }

    [Button]
    [PropertyOrder(-1)]
    [PropertySpace(0f, 20f)]
    private void OpenPageGroupPreferences() 
    {
        Selection.activeObject = PageGroupPreferences.Instance; 
    }

    #endregion
}
#endif
