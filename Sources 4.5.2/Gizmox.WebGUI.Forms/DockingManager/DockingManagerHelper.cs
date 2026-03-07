using System;
using System.Collections.Generic;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public static class DockedManagerHelper
    {
		#region Methods (15) 

		// Private Methods (10) 

        /// <summary>
        /// Creates a split container.
        /// </summary>
        /// <param name="objDockedObjectDescriptor">The obj docked object descriptor.</param>
        /// <param name="objManager">The obj manager.</param>
        /// <returns></returns>
        private static DockedSplitContainer CreateSplitContainer(DockedObjectDescriptor objDockedObjectDescriptor, DockingManager objManager, Control objParentControl)
        {
            DockedSplitContainer objDockedSplitContainer = new DockedSplitContainer(objManager);

            if (objParentControl != null)
            {
                objParentControl.Controls.Add(objDockedSplitContainer);
            }

            if (objDockedObjectDescriptor != null)
            {
                // Load the given descriptor
                (objDockedSplitContainer as IDescriptable).Load(objDockedObjectDescriptor);
            }

            return objDockedSplitContainer;
        }

        /// <summary>
        /// Creates the zone.
        /// </summary>
        /// <param name="objDockedObjectDescriptor">The obj docked object descriptor.</param>
        /// <param name="enmDockState">State of the dock.</param>
        /// <param name="objManager">The obj manager.</param>
        /// <returns></returns>
        private static Zone CreateZone(DockedObjectDescriptor objDockedObjectDescriptor, DockState enmDockState,Control objParentControl, DockingManager objManager)
        {
            ZoneType enmType = ZoneType.Root;

            // Deside the zone's type according to the dock state
            switch (enmDockState)
            {
                case DockState.Float:
                    enmType = ZoneType.Float;
                    break;
                case DockState.Dock:
                    enmType = ZoneType.Dock;
                    break;
                case DockState.Tabbed:
                case DockState.AutoHide:
                case DockState.Hidden:
                default:
                    throw new Exception(string.Format("DockState not supported ({0}) for creating a new zone", enmDockState.ToString()));
            }

            // Create the zone
            Zone objZone = new Zone(objManager, enmType);

            if (objParentControl != null)
            {
                objParentControl.Controls.Add(objZone);
            }

            // load the zone's desctriptor if exists
            if (objDockedObjectDescriptor != null)
            {
                (objZone as IDescriptable).Load(objDockedObjectDescriptor);
            }

            return objZone;
        }

        /// <summary>
        /// Enters the root zone from trace.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="objRootZone">The mobj root zone.</param>
        /// <param name="objDescriptorsTrace">The obj descriptors trace.</param>
        /// <param name="objDockedManager">The obj docked manager.</param>
        private static void EnterRootZoneFromTrace(Control objControl, Zone objRootZone, List<DockedObjectDescriptor> objDescriptorsTrace, DockingManager objDockedManager)
        {
            if (objDescriptorsTrace[0] is ZoneDescriptor)
            {
                objControl.Controls.Add(objRootZone);
            }
            else
            {
                EnterRootZoneFromTrace(GetControlForNextStep(objControl, objDescriptorsTrace, objDockedManager, DockState.Dock), objRootZone, objDescriptorsTrace, objDockedManager);
            }
        }

        /// <summary>
        /// Gets the control for next step.
        /// </summary>
        /// <param name="objControl">The obj control.</param>
        /// <param name="objDescriptorsList">The obj descriptors list.</param>
        /// <param name="objManager">The obj manager.</param>
        /// <param name="objState">State of the obj.</param>
        /// <returns></returns>
        private static Control GetControlForNextStep(Control objControl, List<DockedObjectDescriptor> objDescriptorsList, DockingManager objManager, DockState objState)
        {
            // Returned control Place holder
            Control objControlReturnValue = null;

            // In the case the given control has no children
            if (objControl.Controls.Count == 0)
            {
                if (objDescriptorsList[0] is ZoneDescriptor)
                {
                    // Create a zone
                    objControlReturnValue = CreateZone(objDescriptorsList[0], objState, objControl, objManager);
                }
                else if (objDescriptorsList[0] is DockedSplitContainerDescriptor)
                {
                    // Create a SplitContainer
                    int intPanelSide = GetPanelSide(objDescriptorsList[1]);
                    DockedSplitContainer objContainer = CreateSplitContainer(objDescriptorsList[0], objManager, objControl);
                    objControlReturnValue = GetControlFromPanelSide(intPanelSide, objContainer);
                }
                else
                {
                    throw new Exception(string.Format("Only '{0}' or '{1}' types are allowed inside an empty control. Given type was: '{2}'", typeof(ZoneDescriptor).FullName, typeof(DockedSplitContainerDescriptor).FullName, objDescriptorsList[0].GetType().FullName));
                }

                // Remove the current descriptor from the list
                objDescriptorsList.Remove(objDescriptorsList[0]);
            }
            else if (objDescriptorsList[0] is DockedFormDescriptor)
            {
                // Ask the manager for a form.
                objControlReturnValue = objManager.GetFormFromDescriptor(objDescriptorsList[0] as DockedFormDescriptor);

                // Remove the descriptor from the list
                objDescriptorsList.Remove(objDescriptorsList[0]);
            }
            else
            {
                int intDummy;
                
                // Get the descriptable control (There must be only one descriptable control)
                Control objDescriptableControl = GetDescriptableControl(objControl, out intDummy);

                if (objDescriptableControl == null)
                {
                    throw new Exception("Control must be descriptable");
                }
                // We reached a Zone
                if (objDescriptableControl is Zone)
                {
                    objControlReturnValue = GetControlForNextStepZone(objDescriptableControl as Zone, objDescriptorsList, objManager);
                }
                // We reached a split container
                else if (objDescriptableControl is DockedSplitContainer)
                {
                    objControlReturnValue = GetControlForNextStepDockedSplitContainer(objDescriptableControl as DockedSplitContainer, objDescriptorsList, objManager);
                }
                // We reached a tab control
                else if (objDescriptableControl is DockedTabControl)
                {
                    objControlReturnValue = GetControlForNextStepDockedTabControl(objDescriptableControl as DockedTabControl, objDescriptorsList);
                }
                else
                {
                    throw new Exception("Type is: " + objDescriptableControl.GetType().FullName);
                }
            }

            return objControlReturnValue;
        }

        /// <summary>
        /// Gets the control for next step docked split container.
        /// </summary>
        /// <param name="objDockedSplitContainer">The obj docked split container.</param>
        /// <param name="objDescriptorsList">The obj descriptors list.</param>
        /// <param name="objManager">The obj manager.</param>
        /// <returns></returns>
        private static Control GetControlForNextStepDockedSplitContainer(DockedSplitContainer objDockedSplitContainer, List<DockedObjectDescriptor> objDescriptorsList, DockingManager objManager)
        {
            // Get next control's panel side
            int intPanelSide = GetPanelSide(objDescriptorsList[1]);
            Control objReturnedControl = null;

            if (objDescriptorsList[0] is ZoneDescriptor)
            {
                throw new Exception("Check why a zone descriptor reached a Split container");
            }
            else if (objDescriptorsList[0] is DockedSplitContainerDescriptor)
            {
                if (objDockedSplitContainer.DockedSplitContainerDescriptorInternal == objDescriptorsList[0])
                {
                    objReturnedControl = GetControlFromPanelSide(intPanelSide, objDockedSplitContainer);
                }
                else
                {
                    DockedSplitContainer objContainer = SplitControl(objDockedSplitContainer, null, Relation.Inside, objManager);
                    (objContainer as IDescriptable).Load(objDescriptorsList[0]);

                    if (intPanelSide == 1)
                    {
                        objContainer.Panel2.Controls.Add(objDockedSplitContainer);
                        objReturnedControl = objContainer.Panel1;
                    }
                    else if (intPanelSide == 2)
                    {
                        objContainer.Panel1.Controls.Add(objDockedSplitContainer);
                        objReturnedControl = objContainer.Panel2;
                    }
                }
            }
            else
            {
                throw new Exception("Check why...");
            }

            // Remove descriptor from the list
            objDescriptorsList.Remove(objDescriptorsList[0]);

            return objReturnedControl;
        }

        /// <summary>
        /// Gets the control for next step docked tab control.
        /// </summary>
        /// <param name="objDockedTabControl">The obj docked tab control.</param>
        /// <param name="objDescriptorsList">The obj descriptors list.</param>
        /// <returns></returns>
        private static Control GetControlForNextStepDockedTabControl(DockedTabControl objDockedTabControl, List<DockedObjectDescriptor> objDescriptorsList)
        {
            if (objDescriptorsList[0] is DockedTabControlDescriptor)
            {
                (objDockedTabControl as IDescriptable).Load(objDescriptorsList[0]);

                objDescriptorsList.Remove(objDescriptorsList[0]);
                return objDockedTabControl;
            }
            else
            {
                throw new Exception("Must be a DockedTabControlDescriptor: " + objDescriptorsList[0].GetType().Name);
            }
        }

        /// <summary>
        /// Gets the control for next step zone.
        /// </summary>
        /// <param name="objZone">The obj zone.</param>
        /// <param name="objDescriptorsList">The obj descriptors list.</param>
        /// <param name="objManager">The obj manager.</param>
        /// <returns></returns>
        private static Control GetControlForNextStepZone(Zone objZone, List<DockedObjectDescriptor> objDescriptorsList, DockingManager objManager)
        {
            DockedObjectDescriptor objDescriptor = null;
            DockedObjectDescriptor objNextDescriptor = null;
            
            if (objDescriptorsList.Count > 0)
            {
                objDescriptor = objDescriptorsList[0];
                if (objDescriptorsList.Count > 1)
                {
                    objNextDescriptor = objDescriptorsList[1];
                }

                // Remove the descriptor from the list
                objDescriptorsList.Remove(objDescriptor);
            }

            // If we have no more Descriptor
            if (objDescriptor == null || objDescriptor is DockedTabControlDescriptor)
            {
                // Just return the tab control
                return objZone.TabControl;
            }
            else if (objDescriptor is DockedSplitContainerDescriptor)
            {
                // Get the panel side of the next control
                int intPanelSide = GetPanelSide(objNextDescriptor);

                // Create a Splitter instead of the zone
                DockedSplitContainer objSplitter = SplitControl(objZone, null, Relation.Inside, objManager);

                // Load the descriptor
                (objSplitter as IDescriptable).Load(objDescriptor);

                // Insert the existing control in the opposite side of the new control
                if (intPanelSide == 1)
                {
                    objSplitter.Panel2.Controls.Add(objZone);
                    return objSplitter.Panel1;
                }
                else if (intPanelSide == 2)
                {
                    objSplitter.Panel1.Controls.Add(objZone);
                    return objSplitter.Panel2;
                }
                else
                {
                    throw new Exception("Panel side must be defined");
                }
            }
            else if (objDescriptor is ZoneDescriptor)
            {
                // Just return the zone
                return objZone;
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets the control from panel side.
        /// </summary>
        /// <param name="intSide">The int side.</param>
        /// <param name="objDockedSplitContainer">The obj docked split container.</param>
        /// <returns></returns>
        private static SplitterPanel GetControlFromPanelSide(int intSide, DockedSplitContainer objDockedSplitContainer)
        {
            if (intSide == 1)
            {
                return objDockedSplitContainer.Panel1;
            }
            else if (intSide == 2)
            {
                return objDockedSplitContainer.Panel2;
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets the descriptable control.
        /// </summary>
        /// <param name="objContainingControl">The obj containing control.</param>
        /// <param name="intControlIndex">Index of the int control.</param>
        /// <returns></returns>
        internal static Control GetDescriptableControl(Control objContainingControl, out int intControlIndex)
        {
            intControlIndex = -1;
            foreach (Control objControl in objContainingControl.Controls)
            {
                if (objControl is IDescriptable && !(objControl is DockedHiddenZonesPanel))
                {
                    intControlIndex = objContainingControl.Controls.IndexOf(objControl);
                    return objControl;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the panel side.
        /// </summary>
        /// <param name="objDescriptor">The obj descriptor.</param>
        /// <returns></returns>
        private static int GetPanelSide(DockedObjectDescriptor objDescriptor)
        {
            if (objDescriptor is ZoneDescriptor)
            {
                return (objDescriptor as ZoneDescriptor).PanelSide;
            }
            else if (objDescriptor is DockedSplitContainerDescriptor)
            {
                return (objDescriptor as DockedSplitContainerDescriptor).PanelSide;
            }
            else
            {
                throw new Exception();
            }
        }
		// Internal Methods (5) 

        /// <summary>
        /// Enters the root zone.
        /// </summary>
        /// <param name="objRootZone">The mobj root zone.</param>
        /// <param name="objDockedManager">The docked manager.</param>
        internal static void EnterRootZone(Zone objRootZone, DockingManager objDockedManager)
        {
            EnterRootZoneFromTrace(objDockedManager, objRootZone, GetDescriptorTrace(objDockedManager.DockedManagerDescriptorInternal.RootZoneDescriptor, true), objDockedManager);
        }

        /// <summary>
        /// Gets the descriptor trace.
        /// </summary>
        /// <param name="objDescriptor">The obj descriptor.</param>
        /// <returns></returns>
        internal static List<DockedObjectDescriptor> GetDescriptorTrace(DockedObjectDescriptor objDescriptor, bool blnWithCurrent)
        {
            List<DockedObjectDescriptor> objDescriptorsTrace = new List<DockedObjectDescriptor>();

            if (!blnWithCurrent)
            {
                // No need for the current descriptor
                objDescriptor = objDescriptor.ParentDescriptor;
            }

            while (objDescriptor != null && !(objDescriptor is DockedManagerDescriptor))
            {
                objDescriptorsTrace.Add(objDescriptor);
                objDescriptor = objDescriptor.ParentDescriptor;
            }

            // Reverse the trace so that the root descriptor will be the first
            objDescriptorsTrace.Reverse();

            return objDescriptorsTrace;
        }

        /// <summary>
        /// Gets the logical parent control.
        /// </summary>
        /// <param name="objDockedControl">The obj docked control.</param>
        /// <returns></returns>
        internal static Control GetLogicalParentControl(Control objDockedControl)
        {
            // A SplitterPanel is not a logical parent in the docked-controls hierarchy
            if (objDockedControl.Parent is SplitterPanel)
            {
                return objDockedControl.Parent.Parent;
            }

            return objDockedControl.Parent;
        }

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
        internal static void LoadWindowFromTrace(Control objControl, DockingWindow objWindow, List<DockedObjectDescriptor> objDescriptorsList, DockingManager objManager, DockState objState)
        {
            // If we've reached a TabControl, just add the window
            if (objControl is DockedTabControl && objDescriptorsList.Count == 0)
            {
                (objControl as DockedTabControl).AddWindow(objWindow);
            }
            else
            {
                // Get/Build the next control for building the hirarchy
                Control objNextControl = GetControlForNextStep(objControl, objDescriptorsList, objManager, objState);

                // Recursive call to build the hierarchy from the trace. the previous function is responsible for removing items from the trace if needed
                LoadWindowFromTrace(objNextControl, objWindow, objDescriptorsList, objManager, objState);
            }
        }

        /// <summary>
        /// Splits the zone with a control.
        /// </summary>
        /// <param name="objOriginalControl">The obj original zone.</param>
        /// <param name="objNewControl">The obj new control.</param>
        /// <param name="enmSplitRelation">The enm split relation.</param>
        /// <param name="objManager">The obj manager.</param>
        internal static DockedSplitContainer SplitControl(Control objOriginalControl, Control objNewControl, Relation enmSplitRelation, DockingManager objManager)
        {
            DockedSplitContainer objNewSplitContainer = null;
            // Get the control's parent
            Control objParentContainer = objOriginalControl.Parent;

            // Get the control's logical parent
            Control objLogicalContainer = DockedManagerHelper.GetLogicalParentControl(objOriginalControl);

            if (objParentContainer != null)
            {
                // Create a new Split container to split the zone with
                objNewSplitContainer = CreateSplitContainer(null, objManager,null);

                // get the original zone's index in its parent container
                int intChildIndex = objParentContainer.Controls.GetChildIndex(objOriginalControl, false);

                if (intChildIndex != -1)
                {
                    // Disable removing logic in the logical container
                    if (objLogicalContainer is IPreventExtraction) (objLogicalContainer as IPreventExtraction).DisableExtraction(true);

                    // Remove the zone from its parent
                    objParentContainer.Controls.Remove(objOriginalControl);

                    if (objNewControl != null)
                    {
                        // Init the splitter according to the relation
                        switch (enmSplitRelation)
                        {
                            case Relation.Above:
                                objNewSplitContainer.Orientation = Orientation.Horizontal;
                                objNewSplitContainer.Panel1.Controls.Add(objNewControl);
                                objNewSplitContainer.Panel2.Controls.Add(objOriginalControl);
                                break;
                            case Relation.Below:
                                objNewSplitContainer.Orientation = Orientation.Horizontal;
                                objNewSplitContainer.Panel1.Controls.Add(objOriginalControl);
                                objNewSplitContainer.Panel2.Controls.Add(objNewControl);
                                break;
                            case Relation.ToTheRight:
                                objNewSplitContainer.Orientation = Orientation.Vertical;
                                objNewSplitContainer.Panel1.Controls.Add(objOriginalControl);
                                objNewSplitContainer.Panel2.Controls.Add(objNewControl);
                                break;
                            case Relation.ToTheLeft:
                                objNewSplitContainer.Orientation = Orientation.Vertical;
                                objNewSplitContainer.Panel1.Controls.Add(objNewControl);
                                objNewSplitContainer.Panel2.Controls.Add(objOriginalControl);
                                break;
                            case Relation.Inside:
                            default:
                                throw new Exception("DockedManagerHelper.SplitControlWithSplitter");
                        }
                    }

                    // Add the new contriner to replace the zone
                    objParentContainer.Controls.Add(objNewSplitContainer);
                    objParentContainer.Controls.SetChildIndex(objNewSplitContainer, intChildIndex);
                    
                    // Re-enable the extraction
                    if (objLogicalContainer is IPreventExtraction) (objLogicalContainer as IPreventExtraction).DisableExtraction(false);
                }
            }

            return objNewSplitContainer;
        }

		#endregion Methods 
    }
}