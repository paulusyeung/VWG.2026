// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DockedManagerHelper
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Layout;
using System;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  public static class DockedManagerHelper
  {
    /// <summary>Creates a split container.</summary>
    /// <param name="objDockedObjectDescriptor">The obj docked object descriptor.</param>
    /// <param name="objManager">The obj manager.</param>
    /// <returns></returns>
    private static DockedSplitContainer CreateSplitContainer(
      DockedObjectDescriptor objDockedObjectDescriptor,
      DockingManager objManager,
      Control objParentControl)
    {
      DockedSplitContainer objValue = new DockedSplitContainer(objManager);
      objParentControl?.Controls.Add((Control) objValue);
      if (objDockedObjectDescriptor != null)
        ((IDescriptable) objValue).Load(objDockedObjectDescriptor);
      return objValue;
    }

    /// <summary>Creates the zone.</summary>
    /// <param name="objDockedObjectDescriptor">The obj docked object descriptor.</param>
    /// <param name="enmDockState">State of the dock.</param>
    /// <param name="objManager">The obj manager.</param>
    /// <returns></returns>
    private static Zone CreateZone(
      DockedObjectDescriptor objDockedObjectDescriptor,
      DockState enmDockState,
      Control objParentControl,
      DockingManager objManager)
    {
      ZoneType enmZoneType;
      switch (enmDockState)
      {
        case DockState.Float:
          enmZoneType = ZoneType.Float;
          break;
        case DockState.Dock:
          enmZoneType = ZoneType.Dock;
          break;
        default:
          throw new Exception(string.Format("DockState not supported ({0}) for creating a new zone", (object) enmDockState.ToString()));
      }
      Zone objValue = new Zone(objManager, enmZoneType);
      objParentControl?.Controls.Add((Control) objValue);
      if (objDockedObjectDescriptor != null)
        ((IDescriptable) objValue).Load(objDockedObjectDescriptor);
      return objValue;
    }

    /// <summary>Enters the root zone from trace.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="objRootZone">The mobj root zone.</param>
    /// <param name="objDescriptorsTrace">The obj descriptors trace.</param>
    /// <param name="objDockedManager">The obj docked manager.</param>
    private static void EnterRootZoneFromTrace(
      Control objControl,
      Zone objRootZone,
      List<DockedObjectDescriptor> objDescriptorsTrace,
      DockingManager objDockedManager)
    {
      if (objDescriptorsTrace[0] is ZoneDescriptor)
        objControl.Controls.Add((Control) objRootZone);
      else
        DockedManagerHelper.EnterRootZoneFromTrace(DockedManagerHelper.GetControlForNextStep(objControl, objDescriptorsTrace, objDockedManager, DockState.Dock), objRootZone, objDescriptorsTrace, objDockedManager);
    }

    /// <summary>Gets the control for next step.</summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="objDescriptorsList">The obj descriptors list.</param>
    /// <param name="objManager">The obj manager.</param>
    /// <param name="objState">State of the obj.</param>
    /// <returns></returns>
    private static Control GetControlForNextStep(
      Control objControl,
      List<DockedObjectDescriptor> objDescriptorsList,
      DockingManager objManager,
      DockState objState)
    {
      Control controlForNextStep;
      if (objControl.Controls.Count == 0)
      {
        if (objDescriptorsList[0] is ZoneDescriptor)
        {
          controlForNextStep = (Control) DockedManagerHelper.CreateZone(objDescriptorsList[0], objState, objControl, objManager);
        }
        else
        {
          if (!(objDescriptorsList[0] is DockedSplitContainerDescriptor))
            throw new Exception(string.Format("Only '{0}' or '{1}' types are allowed inside an empty control. Given type was: '{2}'", (object) typeof (ZoneDescriptor).FullName, (object) typeof (DockedSplitContainerDescriptor).FullName, (object) objDescriptorsList[0].GetType().FullName));
          controlForNextStep = (Control) DockedManagerHelper.GetControlFromPanelSide(DockedManagerHelper.GetPanelSide(objDescriptorsList[1]), DockedManagerHelper.CreateSplitContainer(objDescriptorsList[0], objManager, objControl));
        }
        List<DockedObjectDescriptor> objectDescriptorList = objDescriptorsList;
        objectDescriptorList.Remove(objectDescriptorList[0]);
      }
      else if (objDescriptorsList[0] is DockedFormDescriptor)
      {
        controlForNextStep = (Control) objManager.GetFormFromDescriptor(objDescriptorsList[0] as DockedFormDescriptor);
        List<DockedObjectDescriptor> objectDescriptorList = objDescriptorsList;
        objectDescriptorList.Remove(objectDescriptorList[0]);
      }
      else
      {
        Control descriptableControl = DockedManagerHelper.GetDescriptableControl(objControl, out int _);
        switch (descriptableControl)
        {
          case null:
            throw new Exception("Control must be descriptable");
          case Zone _:
            controlForNextStep = DockedManagerHelper.GetControlForNextStepZone(descriptableControl as Zone, objDescriptorsList, objManager);
            break;
          case DockedSplitContainer _:
            controlForNextStep = DockedManagerHelper.GetControlForNextStepDockedSplitContainer(descriptableControl as DockedSplitContainer, objDescriptorsList, objManager);
            break;
          case DockedTabControl _:
            controlForNextStep = DockedManagerHelper.GetControlForNextStepDockedTabControl(descriptableControl as DockedTabControl, objDescriptorsList);
            break;
          default:
            throw new Exception("Type is: " + descriptableControl.GetType().FullName);
        }
      }
      return controlForNextStep;
    }

    /// <summary>
    /// Gets the control for next step docked split container.
    /// </summary>
    /// <param name="objDockedSplitContainer">The obj docked split container.</param>
    /// <param name="objDescriptorsList">The obj descriptors list.</param>
    /// <param name="objManager">The obj manager.</param>
    /// <returns></returns>
    private static Control GetControlForNextStepDockedSplitContainer(
      DockedSplitContainer objDockedSplitContainer,
      List<DockedObjectDescriptor> objDescriptorsList,
      DockingManager objManager)
    {
      int panelSide = DockedManagerHelper.GetPanelSide(objDescriptorsList[1]);
      Control dockedSplitContainer1 = (Control) null;
      if (objDescriptorsList[0] is ZoneDescriptor)
        throw new Exception("Check why a zone descriptor reached a Split container");
      if (!(objDescriptorsList[0] is DockedSplitContainerDescriptor))
        throw new Exception("Check why...");
      if (objDockedSplitContainer.DockedSplitContainerDescriptorInternal == objDescriptorsList[0])
      {
        dockedSplitContainer1 = (Control) DockedManagerHelper.GetControlFromPanelSide(panelSide, objDockedSplitContainer);
      }
      else
      {
        DockedSplitContainer dockedSplitContainer2 = DockedManagerHelper.SplitControl((Control) objDockedSplitContainer, (Control) null, Relation.Inside, objManager);
        ((IDescriptable) dockedSplitContainer2).Load(objDescriptorsList[0]);
        switch (panelSide)
        {
          case 1:
            dockedSplitContainer2.Panel2.Controls.Add((Control) objDockedSplitContainer);
            dockedSplitContainer1 = (Control) dockedSplitContainer2.Panel1;
            break;
          case 2:
            dockedSplitContainer2.Panel1.Controls.Add((Control) objDockedSplitContainer);
            dockedSplitContainer1 = (Control) dockedSplitContainer2.Panel2;
            break;
        }
      }
      List<DockedObjectDescriptor> objectDescriptorList = objDescriptorsList;
      objectDescriptorList.Remove(objectDescriptorList[0]);
      return dockedSplitContainer1;
    }

    /// <summary>Gets the control for next step docked tab control.</summary>
    /// <param name="objDockedTabControl">The obj docked tab control.</param>
    /// <param name="objDescriptorsList">The obj descriptors list.</param>
    /// <returns></returns>
    private static Control GetControlForNextStepDockedTabControl(
      DockedTabControl objDockedTabControl,
      List<DockedObjectDescriptor> objDescriptorsList)
    {
      if (!(objDescriptorsList[0] is DockedTabControlDescriptor))
        throw new Exception("Must be a DockedTabControlDescriptor: " + objDescriptorsList[0].GetType().Name);
      ((IDescriptable) objDockedTabControl).Load(objDescriptorsList[0]);
      List<DockedObjectDescriptor> objectDescriptorList = objDescriptorsList;
      objectDescriptorList.Remove(objectDescriptorList[0]);
      return (Control) objDockedTabControl;
    }

    /// <summary>Gets the control for next step zone.</summary>
    /// <param name="objZone">The obj zone.</param>
    /// <param name="objDescriptorsList">The obj descriptors list.</param>
    /// <param name="objManager">The obj manager.</param>
    /// <returns></returns>
    private static Control GetControlForNextStepZone(
      Zone objZone,
      List<DockedObjectDescriptor> objDescriptorsList,
      DockingManager objManager)
    {
      DockedObjectDescriptor objDescriptor1 = (DockedObjectDescriptor) null;
      DockedObjectDescriptor objDescriptor2 = (DockedObjectDescriptor) null;
      if (objDescriptorsList.Count > 0)
      {
        objDescriptor1 = objDescriptorsList[0];
        if (objDescriptorsList.Count > 1)
          objDescriptor2 = objDescriptorsList[1];
        objDescriptorsList.Remove(objDescriptor1);
      }
      switch (objDescriptor1)
      {
        case null:
        case DockedTabControlDescriptor _:
          return (Control) objZone.TabControl;
        case DockedSplitContainerDescriptor _:
          int panelSide = DockedManagerHelper.GetPanelSide(objDescriptor2);
          DockedSplitContainer dockedSplitContainer = DockedManagerHelper.SplitControl((Control) objZone, (Control) null, Relation.Inside, objManager);
          ((IDescriptable) dockedSplitContainer).Load(objDescriptor1);
          if (panelSide == 1)
          {
            dockedSplitContainer.Panel2.Controls.Add((Control) objZone);
            return (Control) dockedSplitContainer.Panel1;
          }
          if (panelSide != 2)
            throw new Exception("Panel side must be defined");
          dockedSplitContainer.Panel1.Controls.Add((Control) objZone);
          return (Control) dockedSplitContainer.Panel2;
        case ZoneDescriptor _:
          return (Control) objZone;
        default:
          throw new Exception();
      }
    }

    /// <summary>Gets the control from panel side.</summary>
    /// <param name="intSide">The int side.</param>
    /// <param name="objDockedSplitContainer">The obj docked split container.</param>
    /// <returns></returns>
    private static SplitterPanel GetControlFromPanelSide(
      int intSide,
      DockedSplitContainer objDockedSplitContainer)
    {
      if (intSide == 1)
        return objDockedSplitContainer.Panel1;
      if (intSide == 2)
        return objDockedSplitContainer.Panel2;
      throw new Exception();
    }

    /// <summary>Gets the descriptable control.</summary>
    /// <param name="objContainingControl">The obj containing control.</param>
    /// <param name="intControlIndex">Index of the int control.</param>
    /// <returns></returns>
    internal static Control GetDescriptableControl(
      Control objContainingControl,
      out int intControlIndex)
    {
      intControlIndex = -1;
      foreach (Control control in (ArrangedElementCollection) objContainingControl.Controls)
      {
        if (control is IDescriptable && !(control is DockedHiddenZonesPanel))
        {
          intControlIndex = objContainingControl.Controls.IndexOf(control);
          return control;
        }
      }
      return (Control) null;
    }

    /// <summary>Gets the panel side.</summary>
    /// <param name="objDescriptor">The obj descriptor.</param>
    /// <returns></returns>
    private static int GetPanelSide(DockedObjectDescriptor objDescriptor)
    {
      switch (objDescriptor)
      {
        case ZoneDescriptor _:
          return (objDescriptor as ZoneDescriptor).PanelSide;
        case DockedSplitContainerDescriptor _:
          return (objDescriptor as DockedSplitContainerDescriptor).PanelSide;
        default:
          throw new Exception();
      }
    }

    /// <summary>Enters the root zone.</summary>
    /// <param name="objRootZone">The mobj root zone.</param>
    /// <param name="objDockedManager">The docked manager.</param>
    internal static void EnterRootZone(Zone objRootZone, DockingManager objDockedManager) => DockedManagerHelper.EnterRootZoneFromTrace((Control) objDockedManager, objRootZone, DockedManagerHelper.GetDescriptorTrace((DockedObjectDescriptor) objDockedManager.DockedManagerDescriptorInternal.RootZoneDescriptor, true), objDockedManager);

    /// <summary>Gets the descriptor trace.</summary>
    /// <param name="objDescriptor">The obj descriptor.</param>
    /// <returns></returns>
    internal static List<DockedObjectDescriptor> GetDescriptorTrace(
      DockedObjectDescriptor objDescriptor,
      bool blnWithCurrent)
    {
      List<DockedObjectDescriptor> descriptorTrace = new List<DockedObjectDescriptor>();
      if (!blnWithCurrent)
        objDescriptor = objDescriptor.ParentDescriptor;
      while (true)
      {
        switch (objDescriptor)
        {
          case null:
          case DockedManagerDescriptor _:
            goto label_4;
          default:
            descriptorTrace.Add(objDescriptor);
            objDescriptor = objDescriptor.ParentDescriptor;
            continue;
        }
      }
label_4:
      descriptorTrace.Reverse();
      return descriptorTrace;
    }

    /// <summary>Gets the logical parent control.</summary>
    /// <param name="objDockedControl">The obj docked control.</param>
    /// <returns></returns>
    internal static Control GetLogicalParentControl(Control objDockedControl) => objDockedControl.Parent is SplitterPanel ? objDockedControl.Parent.Parent : objDockedControl.Parent;

    /// <summary>
    /// Loads a window from a descriptors trace.
    /// this function gets a Root-Control [objControl] and builds up the controls hierarchy according to the trace.
    /// finally adds the window to its rightful place
    /// </summary>
    /// <param name="objControl">The obj control.</param>
    /// <param name="objWindow">The obj window.</param>
    /// <param name="objDescriptorsList">The obj descriptors list.</param>
    /// <param name="objManager">The obj manager.</param>
    /// <param name="objState">State of the obj.</param>
    internal static void LoadWindowFromTrace(
      Control objControl,
      DockingWindow objWindow,
      List<DockedObjectDescriptor> objDescriptorsList,
      DockingManager objManager,
      DockState objState)
    {
      if (objControl is DockedTabControl && objDescriptorsList.Count == 0)
        (objControl as DockedTabControl).AddWindow(objWindow);
      else
        DockedManagerHelper.LoadWindowFromTrace(DockedManagerHelper.GetControlForNextStep(objControl, objDescriptorsList, objManager, objState), objWindow, objDescriptorsList, objManager, objState);
    }

    /// <summary>Splits the zone with a control.</summary>
    /// <param name="objOriginalControl">The obj original zone.</param>
    /// <param name="objNewControl">The obj new control.</param>
    /// <param name="enmSplitRelation">The enm split relation.</param>
    /// <param name="objManager">The obj manager.</param>
    internal static DockedSplitContainer SplitControl(
      Control objOriginalControl,
      Control objNewControl,
      Relation enmSplitRelation,
      DockingManager objManager)
    {
      DockedSplitContainer dockedSplitContainer = (DockedSplitContainer) null;
      Control parent = objOriginalControl.Parent;
      Control logicalParentControl = DockedManagerHelper.GetLogicalParentControl(objOriginalControl);
      if (parent != null)
      {
        dockedSplitContainer = DockedManagerHelper.CreateSplitContainer((DockedObjectDescriptor) null, objManager, (Control) null);
        int childIndex = parent.Controls.GetChildIndex(objOriginalControl, false);
        if (childIndex != -1)
        {
          if (logicalParentControl is IPreventExtraction)
            (logicalParentControl as IPreventExtraction).DisableExtraction(true);
          parent.Controls.Remove(objOriginalControl);
          if (objNewControl != null)
          {
            switch (enmSplitRelation)
            {
              case Relation.Above:
                dockedSplitContainer.Orientation = Orientation.Horizontal;
                dockedSplitContainer.Panel1.Controls.Add(objNewControl);
                dockedSplitContainer.Panel2.Controls.Add(objOriginalControl);
                break;
              case Relation.Below:
                dockedSplitContainer.Orientation = Orientation.Horizontal;
                dockedSplitContainer.Panel1.Controls.Add(objOriginalControl);
                dockedSplitContainer.Panel2.Controls.Add(objNewControl);
                break;
              case Relation.ToTheRight:
                dockedSplitContainer.Orientation = Orientation.Vertical;
                dockedSplitContainer.Panel1.Controls.Add(objOriginalControl);
                dockedSplitContainer.Panel2.Controls.Add(objNewControl);
                break;
              case Relation.ToTheLeft:
                dockedSplitContainer.Orientation = Orientation.Vertical;
                dockedSplitContainer.Panel1.Controls.Add(objNewControl);
                dockedSplitContainer.Panel2.Controls.Add(objOriginalControl);
                break;
              default:
                throw new Exception("DockedManagerHelper.SplitControlWithSplitter");
            }
          }
          parent.Controls.Add((Control) dockedSplitContainer);
          parent.Controls.SetChildIndex((Control) dockedSplitContainer, childIndex);
          if (logicalParentControl is IPreventExtraction)
            (logicalParentControl as IPreventExtraction).DisableExtraction(false);
        }
      }
      return dockedSplitContainer;
    }
  }
}
