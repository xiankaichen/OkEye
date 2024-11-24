using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Kitware.mummy.Runtime;

namespace Kitware.VTK;

/// <summary>
///    vtkAffineRepresentation2D
/// </summary>
/// <remarks>
///    represent 2D affine transformations
///
/// This class is used to represent a vtkAffineWidget. This representation
/// consists of three parts: a box, a circle, and a cross. The box is used for
/// scaling and shearing, the circle for rotation, and the cross for
/// translation. These parts are drawn in the overlay plane and maintain a
/// constant size (width and height) specified in terms of normalized viewport
/// coordinates.
///
/// The representation maintains an internal transformation matrix (see
/// superclass' GetTransform() method). The transformations generated by this
/// widget assume that the representation lies in the x-y plane. If this is
/// not the case, the user is responsible for transforming this
/// representation's matrix into the correct coordinate space (by judicious
/// matrix multiplication). Note that the transformation matrix returned by
/// GetTransform() is relative to the last PlaceWidget() invocation. (The
/// PlaceWidget() sets the origin around which rotation and scaling occurs;
/// the origin is the center point of the bounding box provided.)
///
///
/// </remarks>
/// <seealso>
///
/// vtkAffineRepresentation vtkAffineWidget
/// </seealso>
public class vtkAffineRepresentation2D : vtkAffineRepresentation
{
	/// <summary>
	/// Automatically generated type registration mechanics.
	/// </summary>
	public new const string MRFullTypeName = "Kitware.VTK.vtkAffineRepresentation2D";

	/// <summary>
	/// Automatically generated type registration mechanics.
	/// </summary>
	public new static readonly string MRClassNameKey;

	/// <summary>
	/// Automatically generated type registration mechanics.
	/// </summary>
	static vtkAffineRepresentation2D()
	{
		MRClassNameKey = "class vtkAffineRepresentation2D";
		Methods.RegisterType(Assembly.GetExecutingAssembly(), MRClassNameKey, Type.GetType("Kitware.VTK.vtkAffineRepresentation2D"));
	}

	/// <summary>
	/// Automatically generated constructor - called from generated code.
	/// DO NOT call directly.
	/// </summary>
	public vtkAffineRepresentation2D(IntPtr rawCppThis, bool callDisposalMethod, bool strong)
		: base(rawCppThis, callDisposalMethod, strong)
	{
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkAffineRepresentation2D_New(ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	/// Instantiate this class.
	/// </summary>
	public new static vtkAffineRepresentation2D New()
	{
		vtkAffineRepresentation2D result = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkAffineRepresentation2D_New(ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			result = (vtkAffineRepresentation2D)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var _);
		}
		return result;
	}

	/// <summary>
	/// Instantiate this class.
	/// </summary>
	public vtkAffineRepresentation2D()
		: base(IntPtr.Zero, callDisposalMethod: false, strong: false)
	{
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr rawCppThis = vtkAffineRepresentation2D_New(ref mteStatus, ref mteIndex, ref rawRefCount);
		SetCppThis(rawCppThis, callDisposalMethod: true, (mteStatus != 0 && rawRefCount >= 2) ? true : false);
	}

	/// <summary>
	/// Automatically generated protected Dispose method - called from
	/// public Dispose or the C# destructor. DO NOT call directly.
	/// </summary>
	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_BuildRepresentation_01(HandleRef pThis);

	/// <summary>
	/// Subclasses of vtkAffineRepresentation2D must implement these methods. These
	/// are the methods that the widget and its representation use to
	/// communicate with each other. Note: PlaceWidget() reinitializes the
	/// transformation matrix (i.e., sets it to identity). It also sets the
	/// origin for scaling and rotation.
	/// </summary>
	public override void BuildRepresentation()
	{
		vtkAffineRepresentation2D_BuildRepresentation_01(GetCppThis());
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkAffineRepresentation2D_ComputeInteractionState_02(HandleRef pThis, int X, int Y, int modify);

	/// <summary>
	/// Subclasses of vtkAffineRepresentation2D must implement these methods. These
	/// are the methods that the widget and its representation use to
	/// communicate with each other. Note: PlaceWidget() reinitializes the
	/// transformation matrix (i.e., sets it to identity). It also sets the
	/// origin for scaling and rotation.
	/// </summary>
	public override int ComputeInteractionState(int X, int Y, int modify)
	{
		return vtkAffineRepresentation2D_ComputeInteractionState_02(GetCppThis(), X, Y, modify);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_DisplayTextOff_03(HandleRef pThis);

	/// <summary>
	/// Enable the display of text with numeric values characterizing the
	/// transformation. Rotation and shear are expressed in degrees; translation
	/// the distance in world coordinates; and scale normalized (sx,sy) values.
	/// </summary>
	public virtual void DisplayTextOff()
	{
		vtkAffineRepresentation2D_DisplayTextOff_03(GetCppThis());
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_DisplayTextOn_04(HandleRef pThis);

	/// <summary>
	/// Enable the display of text with numeric values characterizing the
	/// transformation. Rotation and shear are expressed in degrees; translation
	/// the distance in world coordinates; and scale normalized (sx,sy) values.
	/// </summary>
	public virtual void DisplayTextOn()
	{
		vtkAffineRepresentation2D_DisplayTextOn_04(GetCppThis());
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_EndWidgetInteraction_05(HandleRef pThis, IntPtr eventPos);

	/// <summary>
	/// Subclasses of vtkAffineRepresentation2D must implement these methods. These
	/// are the methods that the widget and its representation use to
	/// communicate with each other. Note: PlaceWidget() reinitializes the
	/// transformation matrix (i.e., sets it to identity). It also sets the
	/// origin for scaling and rotation.
	/// </summary>
	public override void EndWidgetInteraction(IntPtr eventPos)
	{
		vtkAffineRepresentation2D_EndWidgetInteraction_05(GetCppThis(), eventPos);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_GetActors2D_06(HandleRef pThis, HandleRef arg0);

	/// <summary>
	/// Methods to make this class behave as a vtkProp.
	/// </summary>
	public override void GetActors2D(vtkPropCollection arg0)
	{
		vtkAffineRepresentation2D_GetActors2D_06(GetCppThis(), arg0?.GetCppThis() ?? default(HandleRef));
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkAffineRepresentation2D_GetAxesWidth_07(HandleRef pThis);

	/// <summary>
	/// Specify the width of the various parts of the representation (in
	/// pixels).  The three parts are of the representation are the translation
	/// axes, the rotation circle, and the scale/shear box. Note that since the
	/// widget resizes itself so that the width and height are always the
	/// same, only the width needs to be specified.
	/// </summary>
	public virtual int GetAxesWidth()
	{
		return vtkAffineRepresentation2D_GetAxesWidth_07(GetCppThis());
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkAffineRepresentation2D_GetAxesWidthMaxValue_08(HandleRef pThis);

	/// <summary>
	/// Specify the width of the various parts of the representation (in
	/// pixels).  The three parts are of the representation are the translation
	/// axes, the rotation circle, and the scale/shear box. Note that since the
	/// widget resizes itself so that the width and height are always the
	/// same, only the width needs to be specified.
	/// </summary>
	public virtual int GetAxesWidthMaxValue()
	{
		return vtkAffineRepresentation2D_GetAxesWidthMaxValue_08(GetCppThis());
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkAffineRepresentation2D_GetAxesWidthMinValue_09(HandleRef pThis);

	/// <summary>
	/// Specify the width of the various parts of the representation (in
	/// pixels).  The three parts are of the representation are the translation
	/// axes, the rotation circle, and the scale/shear box. Note that since the
	/// widget resizes itself so that the width and height are always the
	/// same, only the width needs to be specified.
	/// </summary>
	public virtual int GetAxesWidthMinValue()
	{
		return vtkAffineRepresentation2D_GetAxesWidthMinValue_09(GetCppThis());
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkAffineRepresentation2D_GetBoxWidth_10(HandleRef pThis);

	/// <summary>
	/// Specify the width of the various parts of the representation (in
	/// pixels).  The three parts are of the representation are the translation
	/// axes, the rotation circle, and the scale/shear box. Note that since the
	/// widget resizes itself so that the width and height are always the
	/// same, only the width needs to be specified.
	/// </summary>
	public virtual int GetBoxWidth()
	{
		return vtkAffineRepresentation2D_GetBoxWidth_10(GetCppThis());
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkAffineRepresentation2D_GetBoxWidthMaxValue_11(HandleRef pThis);

	/// <summary>
	/// Specify the width of the various parts of the representation (in
	/// pixels).  The three parts are of the representation are the translation
	/// axes, the rotation circle, and the scale/shear box. Note that since the
	/// widget resizes itself so that the width and height are always the
	/// same, only the width needs to be specified.
	/// </summary>
	public virtual int GetBoxWidthMaxValue()
	{
		return vtkAffineRepresentation2D_GetBoxWidthMaxValue_11(GetCppThis());
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkAffineRepresentation2D_GetBoxWidthMinValue_12(HandleRef pThis);

	/// <summary>
	/// Specify the width of the various parts of the representation (in
	/// pixels).  The three parts are of the representation are the translation
	/// axes, the rotation circle, and the scale/shear box. Note that since the
	/// widget resizes itself so that the width and height are always the
	/// same, only the width needs to be specified.
	/// </summary>
	public virtual int GetBoxWidthMinValue()
	{
		return vtkAffineRepresentation2D_GetBoxWidthMinValue_12(GetCppThis());
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkAffineRepresentation2D_GetCircleWidth_13(HandleRef pThis);

	/// <summary>
	/// Specify the width of the various parts of the representation (in
	/// pixels).  The three parts are of the representation are the translation
	/// axes, the rotation circle, and the scale/shear box. Note that since the
	/// widget resizes itself so that the width and height are always the
	/// same, only the width needs to be specified.
	/// </summary>
	public virtual int GetCircleWidth()
	{
		return vtkAffineRepresentation2D_GetCircleWidth_13(GetCppThis());
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkAffineRepresentation2D_GetCircleWidthMaxValue_14(HandleRef pThis);

	/// <summary>
	/// Specify the width of the various parts of the representation (in
	/// pixels).  The three parts are of the representation are the translation
	/// axes, the rotation circle, and the scale/shear box. Note that since the
	/// widget resizes itself so that the width and height are always the
	/// same, only the width needs to be specified.
	/// </summary>
	public virtual int GetCircleWidthMaxValue()
	{
		return vtkAffineRepresentation2D_GetCircleWidthMaxValue_14(GetCppThis());
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkAffineRepresentation2D_GetCircleWidthMinValue_15(HandleRef pThis);

	/// <summary>
	/// Specify the width of the various parts of the representation (in
	/// pixels).  The three parts are of the representation are the translation
	/// axes, the rotation circle, and the scale/shear box. Note that since the
	/// widget resizes itself so that the width and height are always the
	/// same, only the width needs to be specified.
	/// </summary>
	public virtual int GetCircleWidthMinValue()
	{
		return vtkAffineRepresentation2D_GetCircleWidthMinValue_15(GetCppThis());
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkAffineRepresentation2D_GetDisplayText_16(HandleRef pThis);

	/// <summary>
	/// Enable the display of text with numeric values characterizing the
	/// transformation. Rotation and shear are expressed in degrees; translation
	/// the distance in world coordinates; and scale normalized (sx,sy) values.
	/// </summary>
	public virtual int GetDisplayText()
	{
		return vtkAffineRepresentation2D_GetDisplayText_16(GetCppThis());
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern long vtkAffineRepresentation2D_GetNumberOfGenerationsFromBase_17(HandleRef pThis, string type);

	/// <summary>
	/// Standard methods for instances of this class.
	/// </summary>
	public override long GetNumberOfGenerationsFromBase(string type)
	{
		return vtkAffineRepresentation2D_GetNumberOfGenerationsFromBase_17(GetCppThis(), type);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern long vtkAffineRepresentation2D_GetNumberOfGenerationsFromBaseType_18(string type);

	/// <summary>
	/// Standard methods for instances of this class.
	/// </summary>
	public new static long GetNumberOfGenerationsFromBaseType(string type)
	{
		return vtkAffineRepresentation2D_GetNumberOfGenerationsFromBaseType_18(type);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkAffineRepresentation2D_GetOrigin_19(HandleRef pThis);

	/// <summary>
	/// Specify the origin of the widget (in world coordinates). The origin
	/// is the point where the widget places itself. Note that rotations and
	/// scaling occurs around the origin.
	/// </summary>
	public virtual double[] GetOrigin()
	{
		IntPtr intPtr = vtkAffineRepresentation2D_GetOrigin_19(GetCppThis());
		double[] array = null;
		if (IntPtr.Zero != intPtr)
		{
			array = new double[3];
			Marshal.Copy(intPtr, array, 0, array.Length);
		}
		return array;
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_GetOrigin_20(HandleRef pThis, ref double _arg1, ref double _arg2, ref double _arg3);

	/// <summary>
	/// Specify the origin of the widget (in world coordinates). The origin
	/// is the point where the widget places itself. Note that rotations and
	/// scaling occurs around the origin.
	/// </summary>
	public virtual void GetOrigin(ref double _arg1, ref double _arg2, ref double _arg3)
	{
		vtkAffineRepresentation2D_GetOrigin_20(GetCppThis(), ref _arg1, ref _arg2, ref _arg3);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_GetOrigin_21(HandleRef pThis, IntPtr _arg);

	/// <summary>
	/// Specify the origin of the widget (in world coordinates). The origin
	/// is the point where the widget places itself. Note that rotations and
	/// scaling occurs around the origin.
	/// </summary>
	public virtual void GetOrigin(IntPtr _arg)
	{
		vtkAffineRepresentation2D_GetOrigin_21(GetCppThis(), _arg);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkAffineRepresentation2D_GetProperty_22(HandleRef pThis, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	/// Set/Get the properties when unselected and selected.
	/// </summary>
	public virtual vtkProperty2D GetProperty()
	{
		vtkProperty2D vtkProperty2D2 = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkAffineRepresentation2D_GetProperty_22(GetCppThis(), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			vtkProperty2D2 = (vtkProperty2D)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var found);
			if (found)
			{
				vtkProperty2D2.Register(null);
			}
		}
		return vtkProperty2D2;
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkAffineRepresentation2D_GetSelectedProperty_23(HandleRef pThis, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	/// Set/Get the properties when unselected and selected.
	/// </summary>
	public virtual vtkProperty2D GetSelectedProperty()
	{
		vtkProperty2D vtkProperty2D2 = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkAffineRepresentation2D_GetSelectedProperty_23(GetCppThis(), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			vtkProperty2D2 = (vtkProperty2D)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var found);
			if (found)
			{
				vtkProperty2D2.Register(null);
			}
		}
		return vtkProperty2D2;
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkAffineRepresentation2D_GetTextProperty_24(HandleRef pThis, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	/// Set/Get the properties when unselected and selected.
	/// </summary>
	public virtual vtkTextProperty GetTextProperty()
	{
		vtkTextProperty vtkTextProperty2 = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkAffineRepresentation2D_GetTextProperty_24(GetCppThis(), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			vtkTextProperty2 = (vtkTextProperty)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var found);
			if (found)
			{
				vtkTextProperty2.Register(null);
			}
		}
		return vtkTextProperty2;
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_GetTransform_25(HandleRef pThis, HandleRef t);

	/// <summary>
	/// Retrieve a linear transform characterizing the affine transformation
	/// generated by this widget. This method copies its internal transform into
	/// the transform provided. Note that the PlaceWidget() method initializes
	/// the internal matrix to identity. All subsequent widget operations (i.e.,
	/// scale, translate, rotate, shear) are concatenated with the internal
	/// transform.
	/// </summary>
	public override void GetTransform(vtkTransform t)
	{
		vtkAffineRepresentation2D_GetTransform_25(GetCppThis(), t?.GetCppThis() ?? default(HandleRef));
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkAffineRepresentation2D_IsA_26(HandleRef pThis, string type);

	/// <summary>
	/// Standard methods for instances of this class.
	/// </summary>
	public override int IsA(string type)
	{
		return vtkAffineRepresentation2D_IsA_26(GetCppThis(), type);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkAffineRepresentation2D_IsTypeOf_27(string type);

	/// <summary>
	/// Standard methods for instances of this class.
	/// </summary>
	public new static int IsTypeOf(string type)
	{
		return vtkAffineRepresentation2D_IsTypeOf_27(type);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkAffineRepresentation2D_NewInstance_29(HandleRef pThis, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	/// Standard methods for instances of this class.
	/// </summary>
	public new vtkAffineRepresentation2D NewInstance()
	{
		vtkAffineRepresentation2D result = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkAffineRepresentation2D_NewInstance_29(GetCppThis(), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			result = (vtkAffineRepresentation2D)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var _);
		}
		return result;
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_PlaceWidget_30(HandleRef pThis, IntPtr bounds);

	/// <summary>
	/// Subclasses of vtkAffineRepresentation2D must implement these methods. These
	/// are the methods that the widget and its representation use to
	/// communicate with each other. Note: PlaceWidget() reinitializes the
	/// transformation matrix (i.e., sets it to identity). It also sets the
	/// origin for scaling and rotation.
	/// </summary>
	public override void PlaceWidget(IntPtr bounds)
	{
		vtkAffineRepresentation2D_PlaceWidget_30(GetCppThis(), bounds);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_ReleaseGraphicsResources_31(HandleRef pThis, HandleRef arg0);

	/// <summary>
	/// Methods to make this class behave as a vtkProp.
	/// </summary>
	public override void ReleaseGraphicsResources(vtkWindow arg0)
	{
		vtkAffineRepresentation2D_ReleaseGraphicsResources_31(GetCppThis(), arg0?.GetCppThis() ?? default(HandleRef));
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkAffineRepresentation2D_RenderOverlay_32(HandleRef pThis, HandleRef viewport);

	/// <summary>
	/// Methods to make this class behave as a vtkProp.
	/// </summary>
	public override int RenderOverlay(vtkViewport viewport)
	{
		return vtkAffineRepresentation2D_RenderOverlay_32(GetCppThis(), viewport?.GetCppThis() ?? default(HandleRef));
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkAffineRepresentation2D_SafeDownCast_33(HandleRef o, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	/// Standard methods for instances of this class.
	/// </summary>
	public new static vtkAffineRepresentation2D SafeDownCast(vtkObjectBase o)
	{
		vtkAffineRepresentation2D vtkAffineRepresentation2D2 = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkAffineRepresentation2D_SafeDownCast_33(o?.GetCppThis() ?? default(HandleRef), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			vtkAffineRepresentation2D2 = (vtkAffineRepresentation2D)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var found);
			if (found)
			{
				vtkAffineRepresentation2D2.Register(null);
			}
		}
		return vtkAffineRepresentation2D2;
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_SetAxesWidth_34(HandleRef pThis, int _arg);

	/// <summary>
	/// Specify the width of the various parts of the representation (in
	/// pixels).  The three parts are of the representation are the translation
	/// axes, the rotation circle, and the scale/shear box. Note that since the
	/// widget resizes itself so that the width and height are always the
	/// same, only the width needs to be specified.
	/// </summary>
	public virtual void SetAxesWidth(int _arg)
	{
		vtkAffineRepresentation2D_SetAxesWidth_34(GetCppThis(), _arg);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_SetBoxWidth_35(HandleRef pThis, int _arg);

	/// <summary>
	/// Specify the width of the various parts of the representation (in
	/// pixels).  The three parts are of the representation are the translation
	/// axes, the rotation circle, and the scale/shear box. Note that since the
	/// widget resizes itself so that the width and height are always the
	/// same, only the width needs to be specified.
	/// </summary>
	public virtual void SetBoxWidth(int _arg)
	{
		vtkAffineRepresentation2D_SetBoxWidth_35(GetCppThis(), _arg);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_SetCircleWidth_36(HandleRef pThis, int _arg);

	/// <summary>
	/// Specify the width of the various parts of the representation (in
	/// pixels).  The three parts are of the representation are the translation
	/// axes, the rotation circle, and the scale/shear box. Note that since the
	/// widget resizes itself so that the width and height are always the
	/// same, only the width needs to be specified.
	/// </summary>
	public virtual void SetCircleWidth(int _arg)
	{
		vtkAffineRepresentation2D_SetCircleWidth_36(GetCppThis(), _arg);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_SetDisplayText_37(HandleRef pThis, int _arg);

	/// <summary>
	/// Enable the display of text with numeric values characterizing the
	/// transformation. Rotation and shear are expressed in degrees; translation
	/// the distance in world coordinates; and scale normalized (sx,sy) values.
	/// </summary>
	public virtual void SetDisplayText(int _arg)
	{
		vtkAffineRepresentation2D_SetDisplayText_37(GetCppThis(), _arg);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_SetOrigin_38(HandleRef pThis, IntPtr o);

	/// <summary>
	/// Specify the origin of the widget (in world coordinates). The origin
	/// is the point where the widget places itself. Note that rotations and
	/// scaling occurs around the origin.
	/// </summary>
	public void SetOrigin(IntPtr o)
	{
		vtkAffineRepresentation2D_SetOrigin_38(GetCppThis(), o);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_SetOrigin_39(HandleRef pThis, double ox, double oy, double oz);

	/// <summary>
	/// Specify the origin of the widget (in world coordinates). The origin
	/// is the point where the widget places itself. Note that rotations and
	/// scaling occurs around the origin.
	/// </summary>
	public void SetOrigin(double ox, double oy, double oz)
	{
		vtkAffineRepresentation2D_SetOrigin_39(GetCppThis(), ox, oy, oz);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_SetProperty_40(HandleRef pThis, HandleRef arg0);

	/// <summary>
	/// Set/Get the properties when unselected and selected.
	/// </summary>
	public void SetProperty(vtkProperty2D arg0)
	{
		vtkAffineRepresentation2D_SetProperty_40(GetCppThis(), arg0?.GetCppThis() ?? default(HandleRef));
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_SetSelectedProperty_41(HandleRef pThis, HandleRef arg0);

	/// <summary>
	/// Set/Get the properties when unselected and selected.
	/// </summary>
	public void SetSelectedProperty(vtkProperty2D arg0)
	{
		vtkAffineRepresentation2D_SetSelectedProperty_41(GetCppThis(), arg0?.GetCppThis() ?? default(HandleRef));
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_SetTextProperty_42(HandleRef pThis, HandleRef arg0);

	/// <summary>
	/// Set/Get the properties when unselected and selected.
	/// </summary>
	public void SetTextProperty(vtkTextProperty arg0)
	{
		vtkAffineRepresentation2D_SetTextProperty_42(GetCppThis(), arg0?.GetCppThis() ?? default(HandleRef));
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_ShallowCopy_43(HandleRef pThis, HandleRef prop);

	/// <summary>
	/// Methods to make this class behave as a vtkProp.
	/// </summary>
	public override void ShallowCopy(vtkProp prop)
	{
		vtkAffineRepresentation2D_ShallowCopy_43(GetCppThis(), prop?.GetCppThis() ?? default(HandleRef));
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_StartWidgetInteraction_44(HandleRef pThis, IntPtr eventPos);

	/// <summary>
	/// Subclasses of vtkAffineRepresentation2D must implement these methods. These
	/// are the methods that the widget and its representation use to
	/// communicate with each other. Note: PlaceWidget() reinitializes the
	/// transformation matrix (i.e., sets it to identity). It also sets the
	/// origin for scaling and rotation.
	/// </summary>
	public override void StartWidgetInteraction(IntPtr eventPos)
	{
		vtkAffineRepresentation2D_StartWidgetInteraction_44(GetCppThis(), eventPos);
	}

	[DllImport("Kitware.VTK.InteractionWidgets.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkAffineRepresentation2D_WidgetInteraction_45(HandleRef pThis, IntPtr eventPos);

	/// <summary>
	/// Subclasses of vtkAffineRepresentation2D must implement these methods. These
	/// are the methods that the widget and its representation use to
	/// communicate with each other. Note: PlaceWidget() reinitializes the
	/// transformation matrix (i.e., sets it to identity). It also sets the
	/// origin for scaling and rotation.
	/// </summary>
	public override void WidgetInteraction(IntPtr eventPos)
	{
		vtkAffineRepresentation2D_WidgetInteraction_45(GetCppThis(), eventPos);
	}
}
