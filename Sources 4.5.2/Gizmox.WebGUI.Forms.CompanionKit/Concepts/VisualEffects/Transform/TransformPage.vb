Namespace CompanionKit.Concepts.VisualEffects.Transform

	Public Class TransformPage
        'Define Transform visual effect
        Public mobjTransformEffect As New Gizmox.WebGUI.Forms.VisualEffects.TransformVisualEffect(New Gizmox.WebGUI.Forms.VisualEffects.Transformation() {New Gizmox.WebGUI.Forms.VisualEffects.Transformation(Gizmox.WebGUI.Forms.VisualEffects.TransformType.Rotate, 0.0F, New Gizmox.WebGUI.Forms.VisualEffects.Matrix(1.0F, 0.0F, 0.0F, 1.0F, 0.0F, 0.0F), Nothing, Nothing, New Gizmox.WebGUI.Forms.VisualEffects.AxisValue(), _
         New Gizmox.WebGUI.Forms.VisualEffects.AxisLengthAndUnits(Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Nothing, Nothing, Nothing)), New Gizmox.WebGUI.Forms.VisualEffects.Transformation(Gizmox.WebGUI.Forms.VisualEffects.TransformType.Translate, 0.0F, New Gizmox.WebGUI.Forms.VisualEffects.Matrix(1.0F, 0.0F, 0.0F, 1.0F, 0.0F, 0.0F), Nothing, Nothing, New Gizmox.WebGUI.Forms.VisualEffects.AxisValue(), _
         New Gizmox.WebGUI.Forms.VisualEffects.AxisLengthAndUnits(Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Nothing, Nothing, Nothing)), New Gizmox.WebGUI.Forms.VisualEffects.Transformation(Gizmox.WebGUI.Forms.VisualEffects.TransformType.Scale, 0.0F, New Gizmox.WebGUI.Forms.VisualEffects.Matrix(1.0F, 0.0F, 0.0F, 1.0F, 0.0F, 0.0F), Nothing, Nothing, New Gizmox.WebGUI.Forms.VisualEffects.AxisValue(), _
         New Gizmox.WebGUI.Forms.VisualEffects.AxisLengthAndUnits(Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Nothing, Nothing, Nothing)), New Gizmox.WebGUI.Forms.VisualEffects.Transformation(Gizmox.WebGUI.Forms.VisualEffects.TransformType.Skew, 0.0F, New Gizmox.WebGUI.Forms.VisualEffects.Matrix(1.0F, 0.0F, 0.0F, 1.0F, 0.0F, 0.0F), Nothing, Nothing, New Gizmox.WebGUI.Forms.VisualEffects.AxisValue(), _
         New Gizmox.WebGUI.Forms.VisualEffects.AxisLengthAndUnits(Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Nothing, Nothing, Nothing))}, New Gizmox.WebGUI.Forms.VisualEffects.Location(Gizmox.WebGUI.Forms.VisualEffects.HorizontalDirection.None, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Percent, Gizmox.WebGUI.Forms.VisualEffects.VerticalDirection.None, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Percent, 50.0F, 50.0F))
		Public Sub New()

			' This call is required by the Visual WebGui UserControl Designer.
			InitializeComponent()

        End Sub
        ''' <summary>
        ''' Transforms the type checked changed.
        ''' </summary>
        ''' <param name="sender">The sender.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub TransformTypeCheckedChanged(sender As System.Object, e As System.EventArgs) Handles mobjRotateRB.CheckedChanged, mobjScaleRB.CheckedChanged, mobjScewRB.CheckedChanged, mobjTranslateRB.CheckedChanged

            'Define Rotation Degree
            Dim intDegree As Integer
            If mobjRotateRB.Checked Then intDegree = 30 Else intDegree = 0
            'Define Translate Value
            Dim intDelta As Integer
            If mobjTranslateRB.Checked Then intDelta = 50 Else intDelta = 0
            'Define Scale Values
            Dim floatScaleX As Single
            If mobjScaleRB.Checked Then floatScaleX = 1.5F Else floatScaleX = 1.0F
            Dim floatScaleY As Single
            If mobjScaleRB.Checked Then floatScaleY = 0.5F Else floatScaleY = 1.0F
            'Define Scew Values
            Dim intScewX As Integer
            If mobjScewRB.Checked Then intScewX = 5 Else intScewX = 0
            Dim intScewY As Integer
            If mobjScewRB.Checked Then intScewY = 10 Else intScewY = 0
            'Change Transform properties
            mobjTransformEffect.Transformations(0).RotationDegrees = intDegree
            mobjTransformEffect.Transformations(1).TranslateValues.DepthLength = intDelta
            mobjTransformEffect.Transformations(1).TranslateValues.HorizontalLength = intDelta
            mobjTransformEffect.Transformations(1).TranslateValues.VerticalLength = intDelta
            mobjTransformEffect.Transformations(2).ScaleValues.X = floatScaleX
            mobjTransformEffect.Transformations(2).ScaleValues.Y = floatScaleY
            mobjTransformEffect.Transformations(3).SkewX = intScewX
            mobjTransformEffect.Transformations(3).SkewY = intScewY
            'Update Panel
            mobjPanel.VisualEffect = mobjTransformEffect
            mobjPanel.Update()

        End Sub
    End Class

End Namespace