using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using UnityEngine;

[GlobalConfig("Assets")]
public class PageGroupPreferences : GlobalConfig<PageGroupPreferences>
{
    public Color HeaderColor;
    public Color PageColor;
    public PageGroupGradient Gradient;
    public int HorizontalPadding = 6;
    public int VerticalPadding = 6;
    public int SpaceBefore = 2;
    public int SpaceAfter = 1;
    public int SpaceBetween = 6;
    public bool AlwaysExpanded;
    public bool Seperated = true;
    public bool HideControlsIfCollapsed = true;
    public bool BoldLabel;
    public bool BoldPageLabel;
    public bool HidePagingButtons;
    public bool HidePageDropdown;
  
    [PropertySpace(30f)]
    [InfoBox("Label colors will automatically switch between white and black depending on the header/page color to improve visibility.", InfoMessageType.Info)]
    public bool AdjustColors = true;

    [ListDrawerSettings(DraggableItems = false)]
    public List<PageGroupGradient> GradientsThatNeedColorAdjustment = new List<PageGroupGradient>
    {
        PageGroupGradient.Solid,
        PageGroupGradient.LeftToRight,
        PageGroupGradient.Inwards,
    };

    [PropertySpace(30f, 30f)]
    [InfoBox("You can hold down <b>Alt</b> while clicking on the group label/dropdown to expand and collapse all elements inside of it recursively.\n\n<b>Alt + Left Click</b> to expand\n<b>Alt + Right Click</b> to collapse", InfoMessageType.Info)]
    public bool EnableExpandAndCollapseShortcut = true;

    protected override void OnConfigAutoCreated()
    {
        #if UNITY_EDITOR

        var scriptPath = UnityEditor.AssetDatabase.GetAssetPath(
            UnityEditor.MonoScript.FromScriptableObject(this));

        var targetFolder = System.IO.Path.GetDirectoryName(scriptPath);

        UnityEditor.AssetDatabase.MoveAsset(
            UnityEditor.AssetDatabase.GetAssetPath(this),
            System.IO.Path.Combine(targetFolder, "PageGroupPreferences.asset"));

        #endif
    }

    #region Preview
    #if UNITY_EDITOR

    [ShowInInspector]
    [PageGroup("Preview", "Page 1", HeaderColor = "HeaderColor", PageColor = "PageColor", 
    Gradient = "Gradient", HorizontalPadding = "HorizontalPadding", VerticalPadding = "VerticalPadding", 
    SpaceBefore = "SpaceBefore", SpaceAfter = "SpaceAfter", SpaceBetween = "SpaceBetween", AlwaysExpanded = "AlwaysExpanded", 
    Separated = "Seperated", HideControlsIfCollapsed = "HideControlsIfCollapsed", BoldLabel = "BoldLabel", BoldPageLabel = "BoldPageLabel", 
    HidePagingButtons = "HidePagingButtons", HidePageDropdown = "HidePageDropdown", AdjustColors = "AdjustColors")]
    private TestData Preview1 = new TestData();
   
    [ShowInInspector]
    [PageGroup("Preview", "Page 1")]
    private TestData Preview2 = new TestData();
    
    [ShowInInspector]
    [PageGroup("Preview", "Page 1")]
    private TestData Preview3 = new TestData();
    
    [ShowInInspector]
    [PageGroup("Preview", "Page 2")]
    private TestData Preview4 = new TestData();
    
    [ShowInInspector]
    [PageGroup("Preview", "Page 2")]
    private TestData Preview5 = new TestData();
    
    [ShowInInspector]
    [PageGroup("Preview", "Page 2")]
    private TestData Preview6 = new TestData();
    
    [ShowInInspector]
    [PageGroup("Preview", "Page 3")]
    private TestData Preview7 = new TestData();
    
    [ShowInInspector]
    [PageGroup("Preview", "Page 3")]
    private TestData Preview8 = new TestData();
    
    [ShowInInspector]
    [PageGroup("Preview", "Page 3")]
    private TestData Preview9 = new TestData();

    [Serializable]
    [HideReferenceObjectPicker]
    private class TestData
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

    #endif
    #endregion
}
