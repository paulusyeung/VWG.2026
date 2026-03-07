#define TRACE
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.SessionState;
using System.Web.UI;
using System.Xml;
using System.Xml.XPath;
using A;
using Gizmox.WebGUI;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Switches;
using Gizmox.WebGUI.Common.Tokens;
using Gizmox.WebGUI.Common.Tokens.Css;
using Gizmox.WebGUI.Common.Tokens.Html;
using Gizmox.WebGUI.Common.Tokens.JQT;
using Gizmox.WebGUI.Common.Tokens.JS;
using Gizmox.WebGUI.Common.Tokens.Reg;
using Gizmox.WebGUI.Common.Tokens.Xml;
using Gizmox.WebGUI.Common.Tokens.Xslt;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Hosting;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Skins.Resources;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Forms.Xaml;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization;
using Gizmox.WebGUI.Virtualization.IO;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Gizmox.WebGUI.Forms.VisualEffects
{
	[Serializable]
	[TypeConverter(typeof(TransformTypeConverter))]
	public class Transformation : ICloneable
	{
		private TransformType menmTransformType;

		private float mfltRotationDegrees;

		private float? mfltSkewX;

		private float? mfltSkewY;

		private Matrix mobjMatrix;

		private AxisValue mobjScaleValues;

		private AxisLengthAndUnits mobjTranslateValues;

		[Category("Matrix Transformation")]
		[Description("matrix(<number>, <number>, <number>, <number>, <number>, <number>). Specifies a 2D transformation in the form of a transformation matrix of six values. matrix(a,b,c,d,e,f) is equivalent to applying the transformation matrix [a b c d e f].")]
		public Matrix Matrix
		{
			get
			{
				return mobjMatrix;
			}
			set
			{
				mobjMatrix = value;
			}
		}

		[Category("Rotate Transformation")]
		[Description("Specifies a 2D rotation by the angle specified in the parameter about the origin of the element, as defined by the transform-origin property. For example, rotate(90deg) would cause elements to appear rotated one-quarter of a turn in the clockwise direction.")]
		public float RotationDegrees
		{
			get
			{
				return mfltRotationDegrees;
			}
			set
			{
				mfltRotationDegrees = value;
			}
		}

		[Description("Specifies a 2D scale operation by the [sx,sy] scaling vector described by the 2 parameters. If the second parameter is not provided, it is takes a value equal to the first. For example, scale(1, 1) would leave an element unchanged, while scale(2, 2) would cause it to appear twice as long in both the X and Y axes, or four times its typical geometric size.")]
		[Category("Scale Transformation")]
		public AxisValue ScaleValues
		{
			get
			{
				return mobjScaleValues;
			}
			set
			{
				mobjScaleValues = value;
			}
		}

		[Category("Skew Transformation")]
		[Description("Specifies a skew transformation along the X axis by the given angle.")]
		public float? SkewX
		{
			get
			{
				return mfltSkewX;
			}
			set
			{
				mfltSkewX = value;
			}
		}

		[Category("Skew Transformation")]
		[Description("Specifies a skew transformation along the Y axis by the given angle.")]
		public float? SkewY
		{
			get
			{
				return mfltSkewY;
			}
			set
			{
				mfltSkewY = value;
			}
		}

		[Description("Choose the type of transformation to show")]
		[Category("Common")]
		public TransformType TransformType
		{
			get
			{
				return menmTransformType;
			}
			set
			{
				menmTransformType = value;
			}
		}

		[Description("Specifies a 2D translation by the vector [tx, ty], where tx is the first translation-value parameter and ty is the optional second translation-value parameter. If <ty> is not provided, ty has zero as a value.")]
		[Category("Translate Transformation")]
		public AxisLengthAndUnits TranslateValues
		{
			get
			{
				return mobjTranslateValues;
			}
			set
			{
				mobjTranslateValues = value;
			}
		}

		public Transformation(TransformType enmTransformType, float fltRotationDegrees, Matrix objMatrix, float? fltSkewX, float? fltSkewY, AxisValue objScaleValues, AxisLengthAndUnits objTranslateValues)
		{
			menmTransformType = enmTransformType;
			mfltRotationDegrees = fltRotationDegrees;
			mobjMatrix = objMatrix;
			mfltSkewX = fltSkewX;
			mfltSkewY = fltSkewY;
			mobjScaleValues = objScaleValues;
			mobjTranslateValues = objTranslateValues;
		}

		public Transformation()
		{
			Matrix = new Matrix();
			mobjScaleValues = new AxisValue();
			mobjTranslateValues = new AxisLengthAndUnits();
		}

		private bool Use3DAcceleration(IContext objContext)
		{
			IContextParams contextParams = null;
			if (objContext != null)
			{
				contextParams = objContext as IContextParams;
			}
			else if (VWGContext.Current == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				contextParams = VWGContext.Current as IContextParams;
			}
			if (contextParams == null)
			{
				/*OpCode not supported: LdMemberToken*/;
				return false;
			}
			return (contextParams.CSS3BrowserCapabilities & CSS3BrowserCapabilities.CSSTransforms3d) == CSS3BrowserCapabilities.CSSTransforms3d;
		}

		public string SerializeToString()
		{
			string text = "null";
			if (!mfltSkewX.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text = mfltSkewX.Value.ToString();
			}
			string text2 = "null";
			if (!mfltSkewY.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				text2 = mfltSkewY.Value.ToString();
			}
			return CommonUtils.Join("!", (int)menmTransformType, Matrix.SerializeToString(), mfltRotationDegrees, text, text2, mobjScaleValues.SerializeToString(), mobjTranslateValues.SerializeToString());
		}

		private void RenderAxisValue(string strAxisType, AxisValue objAxisValue, StringBuilder objBuilder)
		{
			if (objAxisValue.All.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
				goto IL_005e;
			}
			if (!objAxisValue.X.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				if (objAxisValue.Y.HasValue)
				{
					goto IL_005e;
				}
				/*OpCode not supported: LdMemberToken*/;
			}
			if (objAxisValue.X.HasValue)
			{
				objBuilder.Append(strAxisType + "X(");
				objBuilder.Append(objAxisValue.X.Value);
			}
			else if (!objAxisValue.Y.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objBuilder.Append(strAxisType + "Y(");
				objBuilder.Append(objAxisValue.Y.Value);
			}
			goto IL_0176;
			IL_0176:
			objBuilder.Append(")");
			return;
			IL_005e:
			objBuilder.Append(strAxisType);
			objBuilder.Append("(");
			if (objAxisValue.All.HasValue)
			{
				objBuilder.Append(objAxisValue.All);
			}
			else
			{
				objBuilder.Append(objAxisValue.X.Value);
				objBuilder.Append(",");
				objBuilder.Append(objAxisValue.Y.Value);
			}
			goto IL_0176;
		}

		internal static Transformation DeserializeString(string strTransformation)
		{
			string[] array = strTransformation.Split('!');
			if (array.Length != 7)
			{
				/*OpCode not supported: LdMemberToken*/;
				return null;
			}
			Transformation transformation = new Transformation();
			transformation.menmTransformType = (TransformType)int.Parse(array[0]);
			transformation.mobjMatrix = Matrix.DeserializeString(array[1]);
			transformation.mfltRotationDegrees = float.Parse(array[2]);
			transformation.mfltSkewX = null;
			if (!(array[3] != "null"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				transformation.mfltSkewX = float.Parse(array[3]);
			}
			transformation.mfltSkewY = null;
			if (!(array[4] != "null"))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				transformation.mfltSkewY = float.Parse(array[4]);
			}
			transformation.mobjScaleValues = AxisValue.DeserializeString(array[5]);
			transformation.mobjTranslateValues = AxisLengthAndUnits.DeserializeString(array[6]);
			return transformation;
		}

		internal string ToHtmlString(IContext objContext)
		{
			StringBuilder stringBuilder = new StringBuilder();
			switch (TransformType)
			{
			case TransformType.Rotate:
				stringBuilder.Append("rotate(");
				stringBuilder.Append(RotationDegrees);
				stringBuilder.Append("deg)");
				break;
			case TransformType.Matrix:
				stringBuilder.Append(Matrix.ToHtmlString());
				break;
			case TransformType.Translate:
				RenderTranslateValue(objContext, stringBuilder);
				break;
			case TransformType.Scale:
				RenderAxisValue("scale", ScaleValues, stringBuilder);
				break;
			case TransformType.Skew:
				if (!SkewX.HasValue)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					stringBuilder.Append("skewX(");
					stringBuilder.Append(SkewX.Value);
					stringBuilder.Append("deg) ");
				}
				if (!SkewY.HasValue)
				{
					/*OpCode not supported: LdMemberToken*/;
					break;
				}
				stringBuilder.Append("skewY(");
				stringBuilder.Append(SkewY.Value);
				stringBuilder.Append("deg)");
				break;
			default:
				throw new NotImplementedException();
			}
			return stringBuilder.ToString();
		}

		private void RenderTranslateValue(IContext objContext, StringBuilder objBuilder)
		{
			objBuilder.Append("translate");
			if (TranslateValues.HorizontalLength.HasValue)
			{
				if (!TranslateValues.VerticalLength.HasValue)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (!Use3DAcceleration(objContext))
					{
						objBuilder.Append("(");
						objBuilder.Append(TranslateValues.HorizontalLength.Value);
						objBuilder.Append(VisualEffectCommon.GetUnitString(TranslateValues.HorizontalLengthUnits));
						objBuilder.Append(",");
						objBuilder.Append(TranslateValues.VerticalLength.Value);
						objBuilder.Append(VisualEffectCommon.GetUnitString(TranslateValues.VerticalLengthUnits));
						objBuilder.Append(")");
						return;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
			}
			if (Use3DAcceleration(objContext))
			{
				objBuilder.Append("3d(");
				if (!TranslateValues.HorizontalLength.HasValue)
				{
					/*OpCode not supported: LdMemberToken*/;
					objBuilder.Append("0");
				}
				else
				{
					objBuilder.Append(TranslateValues.HorizontalLength.Value);
					objBuilder.Append(VisualEffectCommon.GetUnitString(TranslateValues.HorizontalLengthUnits));
				}
				objBuilder.Append(",");
				if (!TranslateValues.VerticalLength.HasValue)
				{
					/*OpCode not supported: LdMemberToken*/;
					objBuilder.Append("0");
				}
				else
				{
					objBuilder.Append(TranslateValues.VerticalLength.Value);
					objBuilder.Append(VisualEffectCommon.GetUnitString(TranslateValues.VerticalLengthUnits));
				}
				objBuilder.Append(",");
				if (TranslateValues.DepthLength.HasValue)
				{
					objBuilder.Append(TranslateValues.DepthLength.Value);
					objBuilder.Append(VisualEffectCommon.GetUnitString(TranslateValues.DepthLengthUnits));
				}
				else
				{
					objBuilder.Append("0");
				}
				objBuilder.Append(")");
			}
			else if (!TranslateValues.HorizontalLength.HasValue)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (!TranslateValues.VerticalLength.HasValue)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (!TranslateValues.DepthLength.HasValue)
					{
						/*OpCode not supported: LdMemberToken*/;
						return;
					}
					objBuilder.Append("Z(");
					objBuilder.Append(TranslateValues.DepthLength.Value);
					objBuilder.Append(VisualEffectCommon.GetUnitString(TranslateValues.DepthLengthUnits));
					objBuilder.Append(")");
				}
				else
				{
					objBuilder.Append("Y(");
					objBuilder.Append(TranslateValues.VerticalLength.Value);
					objBuilder.Append(VisualEffectCommon.GetUnitString(TranslateValues.VerticalLengthUnits));
					objBuilder.Append(")");
				}
			}
			else
			{
				objBuilder.Append("X(");
				objBuilder.Append(TranslateValues.HorizontalLength.Value + VisualEffectCommon.GetUnitString(TranslateValues.HorizontalLengthUnits));
				objBuilder.Append(")");
			}
		}

		public object Clone()
		{
			Matrix objMatrix = null;
			if (Matrix == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				objMatrix = new Matrix(Matrix.A, Matrix.B, Matrix.C, Matrix.D, Matrix.E, Matrix.F);
			}
			AxisValue axisValue = new AxisValue();
			if (ScaleValues != null)
			{
				axisValue.X = ScaleValues.X;
				axisValue.Y = ScaleValues.Y;
			}
			AxisLengthAndUnits objTranslateValues = null;
			if (TranslateValues != null)
			{
				objTranslateValues = new AxisLengthAndUnits(TranslateValues.HorizontalLengthUnits, TranslateValues.VerticalLengthUnits, TranslateValues.DepthLengthUnits, TranslateValues.HorizontalLength, TranslateValues.VerticalLength, TranslateValues.DepthLength);
			}
			return new Transformation(TransformType, RotationDegrees, objMatrix, SkewX, SkewY, axisValue, objTranslateValues);
		}
	}
}
