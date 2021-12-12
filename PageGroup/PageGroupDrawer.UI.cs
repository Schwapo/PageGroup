#if UNITY_EDITOR
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using System;
using UnityEditor;
using UnityEngine;

public partial class PageGroupDrawer
{
    private static readonly int ColorID = Shader.PropertyToID("_Color");
    private static readonly int DirectionID = Shader.PropertyToID("_Direction");
    private static readonly int TypeID = Shader.PropertyToID("_Type");

    public static Color darkLineColor = EditorGUIUtility.isProSkin 
        ? SirenixGUIStyles.BorderColor 
        : new Color(0, 0, 0, 0.2f);

    public static Color lightLineColor = EditorGUIUtility.isProSkin 
        ? new Color(1.000f, 1.000f, 1.000f, 0.103f) 
        : new Color(1, 1, 1, 1);
    
    private bool ColorNeedsToBeAdjusted => adjustColors.GetValue() 
        && PageGroupPreferences.Instance.GradientsThatNeedColorAdjustment.Contains(gradient.GetValue());

    private static Material _gradientMaterial;
    public static Material GradientMaterial
    {
        get
        {
            if (_gradientMaterial == null)
            {
                _gradientMaterial = new Material(Shader.Find("Unlit/PageGroupGradient"));
            }

            return _gradientMaterial;
        }
    }

    private static GUIStyle _labelStyle;
    public static GUIStyle LabelStyle
    {
        get
        {
            if (_labelStyle == null)
            {
                _labelStyle = new GUIStyle("label");
            }

            return _labelStyle;
        }
    }
   
    private static GUIStyle _foldoutStyle;
    public static GUIStyle FoldoutStyle
    {
        get
        {
            if (_foldoutStyle == null)
            {
                _foldoutStyle = new GUIStyle("foldout");
            }

            return _foldoutStyle;
        }
        set
        {
            _foldoutStyle = value;
        }
    } 

    private void DrawGroup(GUIContent label)
    {
        GUILayout.Space(spaceBefore.GetValue());

        DrawHeader(label);
        DrawPage();

        GUILayout.Space(spaceAfter.GetValue());
    }

    private void DrawHeader(GUIContent label)
    {
        var rect = SirenixEditorGUI.BeginHorizontalToolbar();
        
        DrawGradient(rect, headerColor.GetValue());
        DrawLabel(label);

        if (Property.State.Expanded || !hideControlsIfCollapsed.GetValue())
        {
            DrawPageDropdown();
            DrawPagingButtons();
        }
        
        SirenixEditorGUI.EndHorizontalToolbar();
    }

    private void DrawPage()
    {
        if (!Property.State.Expanded && !alwaysExpanded.GetValue()) return;

        GUILayout.Space(-1);

        var pageStyle = new GUIStyle(SirenixGUIStyles.ToolbarBackground)
        {
            padding = new RectOffset(
                horizontalPadding.GetValue(),
                horizontalPadding.GetValue(),
                verticalPadding.GetValue(),
                verticalPadding.GetValue())
        };

        if (ColorNeedsToBeAdjusted)
        {
            GUIHelper.PushLabelColor(ContrastColor(pageColor.GetValue()));
        }

        var rect = SirenixEditorGUI.BeginIndentedVertical(pageStyle);

        DrawGradient(rect, pageColor.GetValue());
        
        foreach (var property in pages[currentPageIndex].InspectorProperties)
        {
            GUIHelper.PushHierarchyMode(false);

            // HorizontaLineSeperator reservers a rect which pushes the elements to the right by 1
            // we also have to do it here to offset the first element which has no seperator
            GUILayoutUtility.GetRect(1, 1, GUILayoutOptions.ExpandWidth(true));

            if (property.Index != 0)
            {
                GUILayout.Space(spaceBetween.GetValue());

                if (separated.GetValue())
                {
                    HorizontalLineSeparator(darkLineColor);
                    HorizontalLineSeparator(lightLineColor);
                }

                GUILayout.Space(spaceBetween.GetValue());
            }
            
            // Since the property is not fetched through the
            // property system, ensure it's updated before drawing it.
            property.Update(); 
            property.Draw(property.Label);

            GUIHelper.PopHierarchyMode();
        }

        SirenixEditorGUI.EndIndentedVertical();
        SirenixEditorGUI.DrawBorders(rect, 1);

        if (ColorNeedsToBeAdjusted)
        {
            GUIHelper.PopLabelColor();
        }
    }

    private void DrawLabel(GUIContent label)
    {
        var rect = EditorGUILayout.GetControlRect();
        var evt = Event.current;

        if (rect.Contains(evt.mousePosition))
        {
            // We draw the tooltip ourselves since Unity's default tooltip
            // seems to be very unreliable when it comes to positioning
            DrawTooltip();

            if (PageGroupPreferences.Instance.EnableExpandAndCollapseShortcut 
                && evt.type == EventType.MouseDown && evt.alt)
            {
                evt.Use();

                foreach (var property in pages[currentPageIndex].InspectorProperties)
                {
                    SetExpandedStateRecursively(property, evt.button == 0);
                }
            }
        }

        if (ColorNeedsToBeAdjusted)
        {
            GUIHelper.PushColor(ContrastColor(headerColor.GetValue()));
        }

        if (alwaysExpanded.GetValue())
        {
            LabelStyle.fontStyle = boldLabel.GetValue() ? FontStyle.Bold : FontStyle.Normal;

            EditorGUI.LabelField(rect, label, LabelStyle);
        }
        else
        {
            FoldoutStyle.fontStyle = boldLabel.GetValue() ? FontStyle.Bold : FontStyle.Normal;

            Property.State.Expanded = SirenixEditorGUI.Foldout(
                rect, Property.State.Expanded, label, FoldoutStyle);
        }

        if (ColorNeedsToBeAdjusted)
        {
            GUIHelper.PopColor();
        }
    }

    private void DrawPageDropdown()
    {
        if (hidePageDropdown.GetValue()) return;

        var defaultStyle = SirenixGUIStyles.ToolbarButton.fontStyle;
        SirenixGUIStyles.ToolbarButton.fontStyle = boldPageLabel.GetValue() ? FontStyle.Bold : defaultStyle;

        if (SirenixEditorGUI.ToolbarButton(
            GUIHelper.TempContent(pages[currentPageIndex].PageName, 
            EditorIcons.TriangleDown.Active)))
        {
            pageSelector.ShowInPopup();
        }

        SirenixGUIStyles.ToolbarButton.fontStyle = defaultStyle;
    }

    private void DrawPagingButtons()
    {
        if (hidePagingButtons.GetValue()) return;

        if (SirenixEditorGUI.ToolbarButton(EditorIcons.TriangleLeft))
        {
            currentPageIndex--;

            if (currentPageIndex < 0)
            {
                currentPageIndex = pages.Count - 1;
            }

            Property.State.Set(CurrentPageIndexKey, currentPageIndex);
        }

        if (SirenixEditorGUI.ToolbarButton(EditorIcons.TriangleRight))
        {
            currentPageIndex++;
            
            if (currentPageIndex >= pages.Count)
            {
                currentPageIndex = 0;
            }
            
            Property.State.Set(CurrentPageIndexKey, currentPageIndex);
        }
    }

    private void DrawGradient(Rect rect, Color color)
    {
        var gradientValue = gradient.GetValue();

        if (gradientValue == PageGroupGradient.Solid)
        {
            EditorGUI.DrawRect(rect, color);
        }

        var direction = gradientValue == PageGroupGradient.LeftToRight 
            || gradientValue == PageGroupGradient.Inwards ? 1f : 0f;

        var type = gradientValue == PageGroupGradient.Inwards 
            || gradientValue == PageGroupGradient.Outwards ? 1f : 0f;

        GradientMaterial.SetColor(ColorID, color);
        GradientMaterial.SetFloat(DirectionID, direction);
        GradientMaterial.SetFloat(TypeID, type);

        EditorGUI.DrawPreviewTexture(
            rect, 
            EditorGUIUtility.whiteTexture, 
            GradientMaterial, 
            ScaleMode.StretchToFill);
    }
  
    private void DrawTooltip()
    {
        var tooltipContent = GUIHelper.TempContent("", tooltip.GetValue());
        var tooltipSize = GUI.skin.label.CalcSize(tooltipContent);
        var tooltipRect = new Rect(Event.current.mousePosition, tooltipSize);
        EditorGUI.LabelField(tooltipRect, tooltipContent);
    }

    private void SetExpandedStateRecursively(InspectorProperty property, bool expanded)
    {
        property.State.Expanded = expanded;

        foreach (var child in property.Children)
        {
            SetExpandedStateRecursively(child, expanded);
        }
    }

    private Color ContrastColor(Color color)
    {
        var luminance = (Mathf.Pow(color.r / 1f, 2.2f) * 0.2126f) 
            + (Math.Pow(color.g / 1f, 2.2f) * 0.7152f) 
            + (Math.Pow(color.b / 1f, 2.2f) * 0.0722f);

        return luminance > 0.4f ? Color.black : Color.white;
    }

    private static void HorizontalLineSeparator(Color color, int lineWidth = 1)
    {
        Rect rect = GUILayoutUtility.GetRect(
            lineWidth, 
            lineWidth, 
            GUILayoutOptions.ExpandWidth(true));

        SirenixEditorGUI.DrawSolidRect(rect, color, true);
    }
}
#endif
