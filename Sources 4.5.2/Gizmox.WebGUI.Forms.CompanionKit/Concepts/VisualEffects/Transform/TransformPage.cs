using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.VisualEffects.Transform
{
    public partial class TransformPage : UserControl
    {
        //Define Transform visual effect
        public Gizmox.WebGUI.Forms.VisualEffects.TransformVisualEffect mobjTransformEffect = new Gizmox.WebGUI.Forms.VisualEffects.TransformVisualEffect(new Gizmox.WebGUI.Forms.VisualEffects.Transformation[] {
            new Gizmox.WebGUI.Forms.VisualEffects.Transformation(Gizmox.WebGUI.Forms.VisualEffects.TransformType.Rotate, 0F, new Gizmox.WebGUI.Forms.VisualEffects.Matrix(1F, 0F, 0F, 1F, 0F, 0F), null, null, new Gizmox.WebGUI.Forms.VisualEffects.AxisValue(), new Gizmox.WebGUI.Forms.VisualEffects.AxisLengthAndUnits(Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, null, null, null)),
            new Gizmox.WebGUI.Forms.VisualEffects.Transformation(Gizmox.WebGUI.Forms.VisualEffects.TransformType.Translate, 0F, new Gizmox.WebGUI.Forms.VisualEffects.Matrix(1F, 0F, 0F, 1F, 0F, 0F), null, null, new Gizmox.WebGUI.Forms.VisualEffects.AxisValue(), new Gizmox.WebGUI.Forms.VisualEffects.AxisLengthAndUnits(Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, null, null, null)),
            new Gizmox.WebGUI.Forms.VisualEffects.Transformation(Gizmox.WebGUI.Forms.VisualEffects.TransformType.Scale, 0F, new Gizmox.WebGUI.Forms.VisualEffects.Matrix(1F, 0F, 0F, 1F, 0F, 0F), null, null, new Gizmox.WebGUI.Forms.VisualEffects.AxisValue(), new Gizmox.WebGUI.Forms.VisualEffects.AxisLengthAndUnits(Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, null, null, null)),
            new Gizmox.WebGUI.Forms.VisualEffects.Transformation(Gizmox.WebGUI.Forms.VisualEffects.TransformType.Skew, 0F, new Gizmox.WebGUI.Forms.VisualEffects.Matrix(1F, 0F, 0F, 1F, 0F, 0F), null, null, new Gizmox.WebGUI.Forms.VisualEffects.AxisValue(), new Gizmox.WebGUI.Forms.VisualEffects.AxisLengthAndUnits(Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, null, null, null))}, new Gizmox.WebGUI.Forms.VisualEffects.Location(Gizmox.WebGUI.Forms.VisualEffects.HorizontalDirection.None, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Percent, Gizmox.WebGUI.Forms.VisualEffects.VerticalDirection.None, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Percent, 50F, 50F));

        public TransformPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Transforms the type checked changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TransformTypeCheckedChanged(object sender, EventArgs e)
        {
            //Define Rotation Degree
            int intDegree = mobjRotateRB.Checked ? 30 : 0;
            //Define Translate Value
            int intDelta = mobjTranslateRB.Checked ? 50 : 0;
            //Define Scale Values
            float floatScaleX = mobjScaleRB.Checked ? 1.5f : 1f;
            float floatScaleY = mobjScaleRB.Checked ? 0.5f : 1f;
            //Define Scew Values
            int intScewX = mobjScewRB.Checked ? 5 : 0;
            int intScewY = mobjScewRB.Checked ? 10 : 0;
            //Change Transform properties
            mobjTransformEffect.Transformations[0].RotationDegrees = intDegree;
            mobjTransformEffect.Transformations[1].TranslateValues.DepthLength = intDelta;
            mobjTransformEffect.Transformations[1].TranslateValues.HorizontalLength = intDelta;
            mobjTransformEffect.Transformations[1].TranslateValues.VerticalLength = intDelta;
            mobjTransformEffect.Transformations[2].ScaleValues.X = floatScaleX;
            mobjTransformEffect.Transformations[2].ScaleValues.Y = floatScaleY;
            mobjTransformEffect.Transformations[3].SkewX = intScewX;
            mobjTransformEffect.Transformations[3].SkewY = intScewY;
            //Update Panel
            mobjPanel.VisualEffect = mobjTransformEffect;
            mobjPanel.Update();
        }

    }
}