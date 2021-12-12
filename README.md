# PageGroup

### Groups properties into pages similar to Odin's [TabGroup].
### Requires [Odin Inspector]

![](Example.gif)

### Installation
Simply put the downloaded PageGroup folder in your project
and start using the attribute as shown in the examples that are included in the downloaded folder.
You can move the files, but make sure that `PageGroupAttribute.cs`
is not in an editor folder or it will be removed during build, causing errors.

### Parameters

> Default Values for all of the parameters can be set in the PageGroupPreferences ScriptableObject that will automatically be created inside your main Assets folder.
> The location of the ScriptableObject can be changed after it was created.

> All parameters use [ValueResolvers] which means that they are strings that get resolved to a specific value using Odin's ValueResolver system.
> If you want to learn more about them, have a look at this [tutorial]. All of the types that you see listed here are the types that the string needs to resolve to.

Parameter               | Description                                                                                    | Type
----------------------- | ---------------------------------------------------------------------------------------------- | --------------------------
HorizontalPadding       | The horizontal padding of the group's pages                                                    | int
VerticalPadding         | The vertical padding of the group's pages                                                      | int
SpaceBefore             | The space before the group                                                                     | int
SpaceAfter              | The space after the group                                                                      | int
SpaceBetween            | The space between the elements of the group                                                    | int
AlwaysExpanded          | If true, the group will always be expanded                                                     | bool
Seperated               | If true, the elements of the group will be seperated by a horizontal line                      | bool
BoldLabel               | If true, the group's label/foldout will be drawn bold                                          | bool
BoldPageLabel           | If true, the page dropdown labels will be drawn bold                                           | bool
HideControlsIfCollapsed | If true, the group's controls will be hidden while the group is collapsed                      | bool
HidePagingButtons       | If true, the paging buttons will be hidden independent of the expanded state                   | bool
HidePageDropdown        | If true, the page dropdown will be hidden independent of the expanded state                    | bool
AdjustColors            | If true, label colors will be switched between black and white depending on the gradient color | bool
HeaderColor             | The color of the group's header                                                                | [UnityEngine.Color]
PageColor               | The color of the group's pages                                                                 | [UnityEngine.Color]
Gradient                | The gradient type                                                                              | PageGroupGradient (enum)
Tooltip                 | The tooltip to be shown when you hover over the group's label/foldout                          | string

[UnityEngine.Color]: https://docs.unity3d.com/ScriptReference/Color.html
[Odin Inspector]: https://odininspector.com/
[ValueResolvers]: https://odininspector.com/documentation/sirenix.odininspector.editor.valueresolvers.valueresolver-1
[tutorial]: https://odininspector.com/tutorials/value-and-action-resolvers/resolving-strings-to-stuff
[TabGroup]: https://odininspector.com/attributes/tab-group-attribute
[string]: https://docs.microsoft.com/bs-latn-ba/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type
