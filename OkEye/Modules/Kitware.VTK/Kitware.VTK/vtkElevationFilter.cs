using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Kitware.mummy.Runtime;

namespace Kitware.VTK;

/// <summary>
///    vtkElevationFilter
/// </summary>
/// <remarks>
///    generate scalars along a specified direction
///
/// vtkElevationFilter is a filter to generate scalar values from a
/// dataset.  The scalar values lie within a user specified range, and
/// are generated by computing a projection of each dataset point onto
/// a line. The line can be oriented arbitrarily. A typical example is
/// to generate scalars based on elevation or height above a plane.
///
/// @warning
/// vtkSimpleElevationFilter may be easier to use in many cases; e.g.,
/// compute vertical elevation above zero z-point.
///
/// @warning
/// This class has been threaded with vtkSMPTools. Using TBB or other
/// non-sequential type (set in the CMake variable
/// VTK_SMP_IMPLEMENTATION_TYPE) may improve performance significantly.
///
/// </remarks>
/// <seealso>
///
/// vtkSimpleElevationFilter
/// </seealso>
public class vtkElevationFilter : vtkDataSetAlgorithm
{
	/// <summary>
	/// Automatically generated type registration mechanics.
	/// </summary>
	public new const string MRFullTypeName = "Kitware.VTK.vtkElevationFilter";

	/// <summary>
	/// Automatically generated type registration mechanics.
	/// </summary>
	public new static readonly string MRClassNameKey;

	/// <summary>
	/// Automatically generated type registration mechanics.
	/// </summary>
	static vtkElevationFilter()
	{
		MRClassNameKey = "class vtkElevationFilter";
		Methods.RegisterType(Assembly.GetExecutingAssembly(), MRClassNameKey, Type.GetType("Kitware.VTK.vtkElevationFilter"));
	}

	/// <summary>
	/// Automatically generated constructor - called from generated code.
	/// DO NOT call directly.
	/// </summary>
	public vtkElevationFilter(IntPtr rawCppThis, bool callDisposalMethod, bool strong)
		: base(rawCppThis, callDisposalMethod, strong)
	{
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkElevationFilter_New(ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new static vtkElevationFilter New()
	{
		vtkElevationFilter result = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkElevationFilter_New(ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			result = (vtkElevationFilter)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var _);
		}
		return result;
	}

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public vtkElevationFilter()
		: base(IntPtr.Zero, callDisposalMethod: false, strong: false)
	{
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr rawCppThis = vtkElevationFilter_New(ref mteStatus, ref mteIndex, ref rawRefCount);
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

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkElevationFilter_GetHighPoint_01(HandleRef pThis);

	/// <summary>
	/// Define other end of the line (large scalar values).  Default is
	/// (0,0,1).
	/// </summary>
	public virtual double[] GetHighPoint()
	{
		IntPtr intPtr = vtkElevationFilter_GetHighPoint_01(GetCppThis());
		double[] array = null;
		if (IntPtr.Zero != intPtr)
		{
			array = new double[3];
			Marshal.Copy(intPtr, array, 0, array.Length);
		}
		return array;
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkElevationFilter_GetHighPoint_02(HandleRef pThis, IntPtr data);

	/// <summary>
	/// Define other end of the line (large scalar values).  Default is
	/// (0,0,1).
	/// </summary>
	public virtual void GetHighPoint(IntPtr data)
	{
		vtkElevationFilter_GetHighPoint_02(GetCppThis(), data);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkElevationFilter_GetLowPoint_03(HandleRef pThis);

	/// <summary>
	/// Define one end of the line (small scalar values).  Default is
	/// (0,0,0).
	/// </summary>
	public virtual double[] GetLowPoint()
	{
		IntPtr intPtr = vtkElevationFilter_GetLowPoint_03(GetCppThis());
		double[] array = null;
		if (IntPtr.Zero != intPtr)
		{
			array = new double[3];
			Marshal.Copy(intPtr, array, 0, array.Length);
		}
		return array;
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkElevationFilter_GetLowPoint_04(HandleRef pThis, IntPtr data);

	/// <summary>
	/// Define one end of the line (small scalar values).  Default is
	/// (0,0,0).
	/// </summary>
	public virtual void GetLowPoint(IntPtr data)
	{
		vtkElevationFilter_GetLowPoint_04(GetCppThis(), data);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern long vtkElevationFilter_GetNumberOfGenerationsFromBase_05(HandleRef pThis, string type);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public override long GetNumberOfGenerationsFromBase(string type)
	{
		return vtkElevationFilter_GetNumberOfGenerationsFromBase_05(GetCppThis(), type);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern long vtkElevationFilter_GetNumberOfGenerationsFromBaseType_06(string type);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new static long GetNumberOfGenerationsFromBaseType(string type)
	{
		return vtkElevationFilter_GetNumberOfGenerationsFromBaseType_06(type);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkElevationFilter_GetScalarRange_07(HandleRef pThis);

	/// <summary>
	/// Specify range to map scalars into.  Default is [0, 1].
	/// </summary>
	public virtual double[] GetScalarRange()
	{
		IntPtr intPtr = vtkElevationFilter_GetScalarRange_07(GetCppThis());
		double[] array = null;
		if (IntPtr.Zero != intPtr)
		{
			array = new double[2];
			Marshal.Copy(intPtr, array, 0, array.Length);
		}
		return array;
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkElevationFilter_GetScalarRange_08(HandleRef pThis, IntPtr data);

	/// <summary>
	/// Specify range to map scalars into.  Default is [0, 1].
	/// </summary>
	public virtual void GetScalarRange(IntPtr data)
	{
		vtkElevationFilter_GetScalarRange_08(GetCppThis(), data);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkElevationFilter_IsA_09(HandleRef pThis, string type);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public override int IsA(string type)
	{
		return vtkElevationFilter_IsA_09(GetCppThis(), type);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkElevationFilter_IsTypeOf_10(string type);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new static int IsTypeOf(string type)
	{
		return vtkElevationFilter_IsTypeOf_10(type);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkElevationFilter_NewInstance_12(HandleRef pThis, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new vtkElevationFilter NewInstance()
	{
		vtkElevationFilter result = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkElevationFilter_NewInstance_12(GetCppThis(), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			result = (vtkElevationFilter)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var _);
		}
		return result;
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkElevationFilter_SafeDownCast_13(HandleRef o, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new static vtkElevationFilter SafeDownCast(vtkObjectBase o)
	{
		vtkElevationFilter vtkElevationFilter2 = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkElevationFilter_SafeDownCast_13(o?.GetCppThis() ?? default(HandleRef), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			vtkElevationFilter2 = (vtkElevationFilter)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var found);
			if (found)
			{
				vtkElevationFilter2.Register(null);
			}
		}
		return vtkElevationFilter2;
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkElevationFilter_SetHighPoint_14(HandleRef pThis, double _arg1, double _arg2, double _arg3);

	/// <summary>
	/// Define other end of the line (large scalar values).  Default is
	/// (0,0,1).
	/// </summary>
	public virtual void SetHighPoint(double _arg1, double _arg2, double _arg3)
	{
		vtkElevationFilter_SetHighPoint_14(GetCppThis(), _arg1, _arg2, _arg3);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkElevationFilter_SetHighPoint_15(HandleRef pThis, IntPtr _arg);

	/// <summary>
	/// Define other end of the line (large scalar values).  Default is
	/// (0,0,1).
	/// </summary>
	public virtual void SetHighPoint(IntPtr _arg)
	{
		vtkElevationFilter_SetHighPoint_15(GetCppThis(), _arg);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkElevationFilter_SetLowPoint_16(HandleRef pThis, double _arg1, double _arg2, double _arg3);

	/// <summary>
	/// Define one end of the line (small scalar values).  Default is
	/// (0,0,0).
	/// </summary>
	public virtual void SetLowPoint(double _arg1, double _arg2, double _arg3)
	{
		vtkElevationFilter_SetLowPoint_16(GetCppThis(), _arg1, _arg2, _arg3);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkElevationFilter_SetLowPoint_17(HandleRef pThis, IntPtr _arg);

	/// <summary>
	/// Define one end of the line (small scalar values).  Default is
	/// (0,0,0).
	/// </summary>
	public virtual void SetLowPoint(IntPtr _arg)
	{
		vtkElevationFilter_SetLowPoint_17(GetCppThis(), _arg);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkElevationFilter_SetScalarRange_18(HandleRef pThis, double _arg1, double _arg2);

	/// <summary>
	/// Specify range to map scalars into.  Default is [0, 1].
	/// </summary>
	public virtual void SetScalarRange(double _arg1, double _arg2)
	{
		vtkElevationFilter_SetScalarRange_18(GetCppThis(), _arg1, _arg2);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkElevationFilter_SetScalarRange_19(HandleRef pThis, IntPtr _arg);

	/// <summary>
	/// Specify range to map scalars into.  Default is [0, 1].
	/// </summary>
	public void SetScalarRange(IntPtr _arg)
	{
		vtkElevationFilter_SetScalarRange_19(GetCppThis(), _arg);
	}
}