using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Kitware.mummy.Runtime;

namespace Kitware.VTK;

/// <summary>
///    vtkParametricBoy
/// </summary>
/// <remarks>
///    Generate Boy's surface.
///
/// vtkParametricBoy generates Boy's surface.
/// This is a Model of the projective plane without singularities.
/// It was found by Werner Boy on assignment from David Hilbert.
///
/// For further information about this surface, please consult the
/// technical description "Parametric surfaces" in http://www.vtk.org/publications
/// in the "VTK Technical Documents" section in the VTk.org web pages.
///
/// @par Thanks:
/// Andrew Maclean andrew.amaclean@gmail.com for creating and contributing the
/// class.
///
/// </remarks>
public class vtkParametricBoy : vtkParametricFunction
{
	/// <summary>
	/// Automatically generated type registration mechanics.
	/// </summary>
	public new const string MRFullTypeName = "Kitware.VTK.vtkParametricBoy";

	/// <summary>
	/// Automatically generated type registration mechanics.
	/// </summary>
	public new static readonly string MRClassNameKey;

	/// <summary>
	/// Automatically generated type registration mechanics.
	/// </summary>
	static vtkParametricBoy()
	{
		MRClassNameKey = "class vtkParametricBoy";
		Methods.RegisterType(Assembly.GetExecutingAssembly(), MRClassNameKey, Type.GetType("Kitware.VTK.vtkParametricBoy"));
	}

	/// <summary>
	/// Automatically generated constructor - called from generated code.
	/// DO NOT call directly.
	/// </summary>
	public vtkParametricBoy(IntPtr rawCppThis, bool callDisposalMethod, bool strong)
		: base(rawCppThis, callDisposalMethod, strong)
	{
	}

	[DllImport("Kitware.VTK.CommonComputationalGeometry.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkParametricBoy_New(ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	/// Construct Boy's surface with the following parameters:
	/// MinimumU = 0, MaximumU = Pi,
	/// MinimumV = 0, MaximumV = Pi,
	/// JoinU = 1, JoinV = 1,
	/// TwistU = 1, TwistV = 1;
	/// ClockwiseOrdering = 0,
	/// DerivativesAvailable = 1,
	/// ZScale = 0.125.
	/// </summary>
	public new static vtkParametricBoy New()
	{
		vtkParametricBoy result = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkParametricBoy_New(ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			result = (vtkParametricBoy)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var _);
		}
		return result;
	}

	/// <summary>
	/// Construct Boy's surface with the following parameters:
	/// MinimumU = 0, MaximumU = Pi,
	/// MinimumV = 0, MaximumV = Pi,
	/// JoinU = 1, JoinV = 1,
	/// TwistU = 1, TwistV = 1;
	/// ClockwiseOrdering = 0,
	/// DerivativesAvailable = 1,
	/// ZScale = 0.125.
	/// </summary>
	public vtkParametricBoy()
		: base(IntPtr.Zero, callDisposalMethod: false, strong: false)
	{
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr rawCppThis = vtkParametricBoy_New(ref mteStatus, ref mteIndex, ref rawRefCount);
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

	[DllImport("Kitware.VTK.CommonComputationalGeometry.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkParametricBoy_Evaluate_01(HandleRef pThis, IntPtr uvw, IntPtr Pt, IntPtr Duvw);

	/// <summary>
	/// Boy's surface.
	///
	/// This function performs the mapping \f$f(u,v) \rightarrow (x,y,x)\f$, returning it
	/// as Pt. It also returns the partial derivatives Du and Dv.
	/// \f$Pt = (x, y, z), Du = (dx/du, dy/du, dz/du), Dv = (dx/dv, dy/dv, dz/dv)\f$ .
	/// Then the normal is \f$N = Du X Dv\f$ .
	/// </summary>
	public override void Evaluate(IntPtr uvw, IntPtr Pt, IntPtr Duvw)
	{
		vtkParametricBoy_Evaluate_01(GetCppThis(), uvw, Pt, Duvw);
	}

	[DllImport("Kitware.VTK.CommonComputationalGeometry.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern double vtkParametricBoy_EvaluateScalar_02(HandleRef pThis, IntPtr uvw, IntPtr Pt, IntPtr Duvw);

	/// <summary>
	/// Calculate a user defined scalar using one or all of uvw, Pt, Duvw.
	///
	/// uvw are the parameters with Pt being the cartesian point,
	/// Duvw are the derivatives of this point with respect to u, v and w.
	/// Pt, Duvw are obtained from Evaluate().
	///
	/// This function is only called if the ScalarMode has the value
	/// vtkParametricFunctionSource::SCALAR_FUNCTION_DEFINED
	///
	/// If the user does not need to calculate a scalar, then the
	/// instantiated function should return zero.
	/// </summary>
	public override double EvaluateScalar(IntPtr uvw, IntPtr Pt, IntPtr Duvw)
	{
		return vtkParametricBoy_EvaluateScalar_02(GetCppThis(), uvw, Pt, Duvw);
	}

	[DllImport("Kitware.VTK.CommonComputationalGeometry.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkParametricBoy_GetDimension_03(HandleRef pThis);

	/// <summary>
	/// Return the parametric dimension of the class.
	/// </summary>
	public override int GetDimension()
	{
		return vtkParametricBoy_GetDimension_03(GetCppThis());
	}

	[DllImport("Kitware.VTK.CommonComputationalGeometry.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern long vtkParametricBoy_GetNumberOfGenerationsFromBase_04(HandleRef pThis, string type);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public override long GetNumberOfGenerationsFromBase(string type)
	{
		return vtkParametricBoy_GetNumberOfGenerationsFromBase_04(GetCppThis(), type);
	}

	[DllImport("Kitware.VTK.CommonComputationalGeometry.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern long vtkParametricBoy_GetNumberOfGenerationsFromBaseType_05(string type);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new static long GetNumberOfGenerationsFromBaseType(string type)
	{
		return vtkParametricBoy_GetNumberOfGenerationsFromBaseType_05(type);
	}

	[DllImport("Kitware.VTK.CommonComputationalGeometry.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern double vtkParametricBoy_GetZScale_06(HandleRef pThis);

	/// <summary>
	/// Set/Get the scale factor for the z-coordinate.
	/// Default is 1/8, giving a nice shape.
	/// </summary>
	public virtual double GetZScale()
	{
		return vtkParametricBoy_GetZScale_06(GetCppThis());
	}

	[DllImport("Kitware.VTK.CommonComputationalGeometry.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkParametricBoy_IsA_07(HandleRef pThis, string type);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public override int IsA(string type)
	{
		return vtkParametricBoy_IsA_07(GetCppThis(), type);
	}

	[DllImport("Kitware.VTK.CommonComputationalGeometry.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkParametricBoy_IsTypeOf_08(string type);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new static int IsTypeOf(string type)
	{
		return vtkParametricBoy_IsTypeOf_08(type);
	}

	[DllImport("Kitware.VTK.CommonComputationalGeometry.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkParametricBoy_NewInstance_10(HandleRef pThis, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new vtkParametricBoy NewInstance()
	{
		vtkParametricBoy result = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkParametricBoy_NewInstance_10(GetCppThis(), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			result = (vtkParametricBoy)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var _);
		}
		return result;
	}

	[DllImport("Kitware.VTK.CommonComputationalGeometry.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkParametricBoy_SafeDownCast_11(HandleRef o, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new static vtkParametricBoy SafeDownCast(vtkObjectBase o)
	{
		vtkParametricBoy vtkParametricBoy2 = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkParametricBoy_SafeDownCast_11(o?.GetCppThis() ?? default(HandleRef), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			vtkParametricBoy2 = (vtkParametricBoy)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var found);
			if (found)
			{
				vtkParametricBoy2.Register(null);
			}
		}
		return vtkParametricBoy2;
	}

	[DllImport("Kitware.VTK.CommonComputationalGeometry.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkParametricBoy_SetZScale_12(HandleRef pThis, double _arg);

	/// <summary>
	/// Set/Get the scale factor for the z-coordinate.
	/// Default is 1/8, giving a nice shape.
	/// </summary>
	public virtual void SetZScale(double _arg)
	{
		vtkParametricBoy_SetZScale_12(GetCppThis(), _arg);
	}
}