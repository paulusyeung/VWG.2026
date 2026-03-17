# Legacy Name Gaps

This file records the 40 legacy compile file names that did not have an exact filename match in the current NetCore Forms tree during the 2026-03-18 coverage scan.

Important: these are name gaps, not proven behavior gaps.

## Category Summary

- Intentional host-path exclusions: 7
- Clear split or rename mappings: 25
- Designer partial or SDK metadata cleanup: 5
- PropertyGrid area present but worth spot-testing if used: 3

Total: 40

## 1. Intentional Host-Path Exclusions

These files belong to the ASP hosting path that is intentionally excluded by the current SDK project.

| Legacy file | Category | Recommended action | Notes |
| --- | --- | --- | --- |
| `Hosts\AspControlBoxBase.cs` | Intentional exclusion | Leave excluded unless ASP hosting must work | Present under `Generated/Gizmox/WebGUI/Forms/Hosts/`, but `Gizmox.WebGUI.Forms.csproj` removes `Hosts/Asp*.cs`. |
| `Hosts\AspControlBoxBaseSkin.cs` | Intentional exclusion | Leave excluded unless ASP hosting must work | Present under `Generated/Gizmox/WebGUI/Forms/Hosts/Skins/`, but `Gizmox.WebGUI.Forms.csproj` removes `Hosts/Skins/Asp*.cs`. |
| `Hosts\AspEvents.cs` | Intentional exclusion | Do not restore as a single legacy file | Host event types are split in the generated host files and are outside the current runtime baseline. |
| `Hosts\AspPageBase.cs` | Intentional exclusion | Leave excluded unless ASP hosting must work | Present under `Generated/Gizmox/WebGUI/Forms/Hosts/`, but excluded from compile. |
| `Hosts\AspPageBox.cs` | Intentional exclusion | Leave excluded unless ASP hosting must work | Present under `Generated/Gizmox/WebGUI/Forms/Hosts/`, but excluded from compile. |
| `Hosts\AspPageBoxSkin.cs` | Intentional exclusion | Leave excluded unless ASP hosting must work | Present under `Generated/Gizmox/WebGUI/Forms/Hosts/Skins/`, but excluded from compile. |
| `Hosts\AspPipeLinePage.cs` | Intentional exclusion | Leave excluded unless ASP hosting must work | Present under `Generated/Gizmox/WebGUI/Forms/Hosts/`, but excluded from compile. |

## 2. Clear Split Or Rename Mappings

These names are best explained by file splitting, singular/plural renames, genericization, or legacy file/class naming mismatches.

| Legacy file | Category | Recommended action | Notes |
| --- | --- | --- | --- |
| `Bindings.cs` | Split aggregate | No legacy file restore needed | Logic is represented by dedicated files such as `Binding.cs`, `BindingsCollection.cs`, `BindingSource.cs`, `BindingCompleteContext.cs`, and `BindingCompleteState.cs`. |
| `DataGridViewCells.cs` | Split aggregate | No legacy file restore needed | DataGridView cell types are split across dedicated files such as `DataGridViewCell.cs` and derived cell types. |
| `DataGridViewCollections.cs` | Split aggregate | No legacy file restore needed | Collection types are split into dedicated files rather than kept in one bucket file. |
| `DataGridViewColumns.cs` | Split aggregate | No legacy file restore needed | Column types are split into dedicated files such as `DataGridViewColumn.cs` and derived column classes. |
| `DataGridViewConvertors.cs` | Split aggregate | No legacy file restore needed | Converter types appear to have been separated into dedicated files instead of a single legacy bucket. |
| `DataGridViewEnums.cs` | Split aggregate | No legacy file restore needed | Enum types are split into dedicated files in the generated tree. |
| `DataGridViewEvents.cs` | Split aggregate | No legacy file restore needed | Event args and delegates are split into files such as `QuestionEventArgs.cs`, `GroupingChangedEventArgs.cs`, `GroupingChangedEventHandler.cs`, and `GroupHeaderFormattingEventArgs.cs`. |
| `DataGridViewObjects.cs` | Split aggregate | No legacy file restore needed | Supporting object types are distributed across dedicated DataGridView files. |
| `DeviceIntegration\Abstract\MultipleCallMethodStore.cs` | Genericized rename | No legacy file restore needed | Current file is ``MultipleCallMethodStore`1.cs`` in the generated tree. |
| `DeviceIntegration\Abstract\SingleCallMethodStore.cs` | Genericized rename | No legacy file restore needed | Current file is ``SingleCallMethodStore`1.cs`` in the generated tree. |
| `DockingManager\DockedObjectDescriptors\DockingManagerDescriptor.cs` | Legacy file/class naming mismatch | No legacy file restore needed | Legacy file already declared `DockedManagerDescriptor`; current file is `DockedManagerDescriptor.cs`. |
| `DockingManager\DockingManagerHelper.cs` | Legacy file/class naming mismatch | No legacy file restore needed | Legacy file already declared `DockedManagerHelper`; current file is `DockedManagerHelper.cs`. |
| `Enums.cs` | Split aggregate | No legacy file restore needed | Legacy root enum bucket is split into files such as `TextImageRelation.cs`, `ScrollerType.cs`, `ToolTipIcon.cs`, and `DataFormats.cs`. |
| `Events.cs` | Split aggregate | No legacy file restore needed | Root event args and delegates are split into per-type files across the Forms tree. |
| `IButton.cs` | Legacy file/class naming mismatch | No legacy file restore needed | Legacy file already declared `IButtonControl`; current file is `IButtonControl.cs`. |
| `Proxy\ProxyEventArgs.cs` | Split aggregate | No legacy file restore needed | Proxy event args are split into `ProxyFireEventArgs.cs`, `ProxyPropertyValueEventArgs.cs`, and `ProxyFilterPropertiesEventArgs.cs`. |
| `Proxy\ProxyNavigationCommands.cs` | Singular rename | No legacy file restore needed | Current file is `ProxyNavigationCommand.cs`. |
| `SelectedIndicator.cs` | Legacy file/class naming mismatch | No legacy file restore needed | Legacy file contained `SelectedIndicatorStyleValue`; current files include `SelectedIndicatorStyleValue.cs`, `SelectedIndicatorSizeValue.cs`, and related converters. |
| `SkinValues.cs` | Split aggregate | No legacy file restore needed | Skin value types are split into files such as `BorderValue.cs`, `PaddingValue.cs`, `HorizontalAlignment.cs`, and `VerticalAlignment.cs`. |
| `TableLayoutPanelCell.cs` | Split aggregate | No legacy file restore needed | Types were separated into `TableLayoutCellPaintEventArgs.cs`, `TableLayoutPanelCellPosition.cs`, and related table-layout files. |
| `ToolStripEnums.cs` | Split aggregate | No legacy file restore needed | ToolStrip enum types are split across many dedicated `ToolStrip*.cs` files. |
| `ToolStripEvents.cs` | Split aggregate | No legacy file restore needed | ToolStrip event args and handlers are split across dedicated `ToolStrip*EventArgs.cs` and `ToolStrip*EventHandler.cs` files. |
| `ToolStripMiscellaneous.cs` | Split aggregate | No legacy file restore needed | Miscellaneous ToolStrip helpers and support types are distributed across the generated ToolStrip files. |
| `Virtualization\Management\ApplicationNode.cs` | Rename or refinement | No legacy file restore needed | Current counterpart is `ApplicationDOMNode.cs`. |
| `Virtualization\Management\XmlNode.cs` | Rename or refinement | No legacy file restore needed | Current counterpart is `XmlNodeNode.cs`. |

## 3. Designer Partial Or SDK Metadata Cleanup

These files are not strong signals of missing runtime behavior.

| Legacy file | Category | Recommended action | Notes |
| --- | --- | --- | --- |
| `..\ProductInfo.cs` | SDK metadata cleanup | Do not restore unless versioning logic explicitly depends on it | This is solution-level product metadata, not Forms runtime logic. |
| `Administration\Abstract\AdministrationFormBase.Designer.cs` | Designer partial merge | Do not restore unless designer generation must round-trip | The runtime type exists as `AdministrationFormBase.cs`; the split designer partial file is not required for runtime compilation. |
| `Administration\AdministrationForm.Designer.cs` | Designer partial merge | Do not restore unless designer generation must round-trip | The runtime type exists as `AdministrationForm.cs`; the split designer partial file is not required for runtime compilation. |
| `DataGridViewGroupingHeader.Designer.cs` | Designer partial merge | Do not restore unless designer generation must round-trip | The runtime type exists as `DataGridViewGroupingHeader.cs`; the designer partial split is not required for runtime compilation. |
| `Properties\AssemblyInfo.cs` | SDK metadata cleanup | Do not restore | SDK-style projects typically move assembly metadata into the project file or generated assembly info. |

## 4. PropertyGrid Area Present, But Spot-Test If Used

These filenames most likely reflect file splitting, but PropertyGrid behavior is specialized enough that it deserves a quick runtime check if your application uses it heavily.

| Legacy file | Category | Recommended action | Notes |
| --- | --- | --- | --- |
| `PropertyGridEnums.cs` | Likely split aggregate | Spot-test only if PropertyGrid is used | Surrounding files exist, including `PropertyGrid.cs`, `PropertySort.cs`, `GridItem.cs`, `GridItemCollection.cs`, and `GridItemType.cs`. |
| `PropertyGridEvents.cs` | Likely split aggregate | Spot-test only if PropertyGrid is used | Event files exist, including `PropertyValueChangedEventArgs.cs`, `PropertyTabChangedEventArgs.cs`, and `PropertyTabChangedEventHandler.cs`. |
| `PropertyGridInternals.cs` | Likely split or moved internals | Spot-test only if PropertyGrid is used | Internal logic appears to be distributed into `PropertyGridInternal/PropertyGridView.cs` and surrounding PropertyGrid files. |

## Recommendation

- Do not try to restore all 40 legacy filenames.
- Treat the 7 host-path files as intentionally excluded unless ASP hosting is back in scope.
- Treat the 25 clear split or rename cases as accounted for.
- Treat the 5 designer or metadata files as non-runtime gaps.
- Only spend more time on the 3 PropertyGrid files if PropertyGrid behavior matters in real application flows.