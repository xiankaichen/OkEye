using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Kitware.mummy.Runtime;

namespace Kitware.VTK;

/// <summary>
///    vtkTrimmedExtrusionFilter
/// </summary>
/// <remarks>
///    extrude polygonal data trimmed by a second input surface
///
/// vtkTrimmedExtrusionFilter is a modeling filter. It takes polygonal data as
/// input and generates polygonal data on output. The input dataset is swept
/// along a specified direction forming a "skirt" from the boundary edges 2D
/// primitives (i.e., edges used by only one polygon); and/or from vertices
/// and lines. The extent of the sweeping is limited by a second input:
/// defined where the sweep intersects a user-specified surface.
///
/// Capping of the extrusion can be enabled. In this case the input,
/// generating primitive is copied inplace as well as to the end of the
/// extrusion skirt. (See warnings below on what happens if the intersecting
/// sweep does not intersect, or partially intersects the trim surface.)
///
/// Note that this filter operates in two fundamentally different modes based
/// on the extrusion strategy. If the strategy is BOUNDARY_EDGES, then only the
/// boundary edges of the input's 2D primitives are extruded (verts and lines
/// are extruded to generate lines and quads). However, if the extrusions
/// strategy is ALL_EDGES, then every edge of the 2D primitives is used to
/// sweep out a quadrilateral polygon (again verts and lines are swept to
/// produce lines and quads).
///
/// @warning
/// The extrusion direction is assumed to define an infinite line. The
/// intersection with the trim surface is along a ray from the - to +
/// direction, however only the first intersection is taken.
///
/// @warning
/// Some polygonal objects have no free edges (e.g., sphere). When swept, this
/// will result in two separate surfaces if capping is on and BOUNDARY_EDGES
/// enabled, or no surface if capping is off and BOUNDARY_EDGES is enabled.
///
/// @warning
/// If all the extrusion lines emanating from an extruding primitive do not
/// intersect the trim surface, then no output for that primitive will be
/// generated. In extreme cases, it is possible that no output whatsoever will
/// be generated by the filter.
///
/// @warning
/// This class has been threaded with vtkSMPTools. Using TBB or other
/// non-sequential type (set in the CMake variable
/// VTK_SMP_IMPLEMENTATION_TYPE) may improve performance significantly.
///
/// </remarks>
/// <seealso>
///
/// vtkLinearExtrusionFilter vtkRotationalExtrusionFilter
/// </seealso>
public class vtkTrimmedExtrusionFilter : vtkPolyDataAlgorithm
{
	/// <summary>
	/// Specify a strategy for extrusion. If the strategy is set to
	/// "BOUNDARY_EDGES" then the boundary edges of the input polygons and
	/// triangle strips are swept. (A boundary edge is an edge used by only one
	/// 2D primitive, e.g., polygon or triangle.) Alternatively, all edges can
	/// be swept. (This is particularly useful when only sinple disconnected
	/// polygons exist in the input and so boundary calculation can be avoided.)
	/// By default boundary edges are extruded.
	/// </summary>
	public enum CappingStrategy
	{
		/// <summary>enum member</summary>
		AVERAGE_DISTANCE = 3,
		/// <summary>enum member</summary>
		INTERSECTION = 0,
		/// <summary>enum member</summary>
		MAXIMUM_DISTANCE = 2,
		/// <summary>enum member</summary>
		MINIMUM_DISTANCE = 1
	}

	/// <summary>
	/// Turn on/off the capping of the extruded skirt.
	/// </summary>
	public enum ExtrusionStrategy
	{
		/// <summary>enum member</summary>
		ALL_EDGES = 1,
		/// <summary>enum member</summary>
		BOUNDARY_EDGES = 0
	}

	/// <summary>
	/// Automatically generated type registration mechanics.
	/// </summary>
	public new const string MRFullTypeName = "Kitware.VTK.vtkTrimmedExtrusionFilter";

	/// <summary>
	/// Automatically generated type registration mechanics.
	/// </summary>
	public new static readonly string MRClassNameKey;

	/// <summary>
	/// Automatically generated type registration mechanics.
	/// </summary>
	static vtkTrimmedExtrusionFilter()
	{
		MRClassNameKey = "class vtkTrimmedExtrusionFilter";
		Methods.RegisterType(Assembly.GetExecutingAssembly(), MRClassNameKey, Type.GetType("Kitware.VTK.vtkTrimmedExtrusionFilter"));
	}

	/// <summary>
	/// Automatically generated constructor - called from generated code.
	/// DO NOT call directly.
	/// </summary>
	public vtkTrimmedExtrusionFilter(IntPtr rawCppThis, bool callDisposalMethod, bool strong)
		: base(rawCppThis, callDisposalMethod, strong)
	{
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkTrimmedExtrusionFilter_New(ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	/// Create object with extrusion direction (0,0,1) and capping on.
	/// </summary>
	public new static vtkTrimmedExtrusionFilter New()
	{
		vtkTrimmedExtrusionFilter result = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkTrimmedExtrusionFilter_New(ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			result = (vtkTrimmedExtrusionFilter)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var _);
		}
		return result;
	}

	/// <summary>
	/// Create object with extrusion direction (0,0,1) and capping on.
	/// </summary>
	public vtkTrimmedExtrusionFilter()
		: base(IntPtr.Zero, callDisposalMethod: false, strong: false)
	{
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr rawCppThis = vtkTrimmedExtrusionFilter_New(ref mteStatus, ref mteIndex, ref rawRefCount);
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

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_CappingOff_01(HandleRef pThis);

	/// <summary>
	/// Turn on/off the capping of the extruded skirt.
	/// </summary>
	public virtual void CappingOff()
	{
		vtkTrimmedExtrusionFilter_CappingOff_01(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_CappingOn_02(HandleRef pThis);

	/// <summary>
	/// Turn on/off the capping of the extruded skirt.
	/// </summary>
	public virtual void CappingOn()
	{
		vtkTrimmedExtrusionFilter_CappingOn_02(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkTrimmedExtrusionFilter_GetCapping_03(HandleRef pThis);

	/// <summary>
	/// Turn on/off the capping of the extruded skirt.
	/// </summary>
	public virtual int GetCapping()
	{
		return vtkTrimmedExtrusionFilter_GetCapping_03(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkTrimmedExtrusionFilter_GetCappingStrategy_04(HandleRef pThis);

	/// <summary>
	/// Specify a strategy for capping. By default the points of the cap
	/// polygons are located where the extrusion intersects the capping surface.
	/// However, to preserve planarity, or to place the capping surface at the
	/// average/minimum/maximum distance of extrusion, different strategies can
	/// be used. By default the average distance is used.
	///
	/// Note if none of the extrusion rays intersect the trim surface, then
	/// capping is not performed, nor is an extrusion skirt sent to the
	/// output. Also note that if the capping strategy is set to INTERSECTION,
	/// and one of the extrusion rays of the generating primitive does not
	/// intersect the trim surface, then no output will be generated for that
	/// primitive. However if any other capping strategy is used, capping will
	/// succeed if at least one extrusion ray strikes the trim surface (although
	/// missed extrusion ray intersections will not factor into the
	/// determination of final cap location).
	///
	/// Finally, note that any capping strategy other than INTERSECTION may
	/// produce more points than expected because the output primitives may
	/// have to be "split apart" to satisy the capping constraint.
	/// </summary>
	public virtual int GetCappingStrategy()
	{
		return vtkTrimmedExtrusionFilter_GetCappingStrategy_04(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkTrimmedExtrusionFilter_GetExtrusionDirection_05(HandleRef pThis);

	/// <summary>
	/// Set/Get the extrusion direction.
	/// </summary>
	public virtual double[] GetExtrusionDirection()
	{
		IntPtr intPtr = vtkTrimmedExtrusionFilter_GetExtrusionDirection_05(GetCppThis());
		double[] array = null;
		if (IntPtr.Zero != intPtr)
		{
			array = new double[3];
			Marshal.Copy(intPtr, array, 0, array.Length);
		}
		return array;
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_GetExtrusionDirection_06(HandleRef pThis, IntPtr data);

	/// <summary>
	/// Set/Get the extrusion direction.
	/// </summary>
	public virtual void GetExtrusionDirection(IntPtr data)
	{
		vtkTrimmedExtrusionFilter_GetExtrusionDirection_06(GetCppThis(), data);
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkTrimmedExtrusionFilter_GetExtrusionStrategy_07(HandleRef pThis);

	/// <summary>
	/// Specify a strategy for extrusion. If the strategy is set to
	/// "BOUNDARY_EDGES" then the boundary edges of the input polygons and
	/// triangle strips are swept. (A boundary edge is an edge used by only one
	/// 2D primitive, e.g., polygon or triangle.) Alternatively, all edges can
	/// be swept. (This is particularly useful when only sinple disconnected
	/// polygons exist in the input and so boundary calculation can be avoided.)
	/// By default boundary edges are extruded.
	/// </summary>
	public virtual int GetExtrusionStrategy()
	{
		return vtkTrimmedExtrusionFilter_GetExtrusionStrategy_07(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkTrimmedExtrusionFilter_GetLocator_08(HandleRef pThis, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	/// Specify a cell locator. By default a vtkStaticCellLocator is
	/// used. The locator performs efficient searches to intersect cells.
	/// </summary>
	public virtual vtkAbstractCellLocator GetLocator()
	{
		vtkAbstractCellLocator vtkAbstractCellLocator2 = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkTrimmedExtrusionFilter_GetLocator_08(GetCppThis(), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			vtkAbstractCellLocator2 = (vtkAbstractCellLocator)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var found);
			if (found)
			{
				vtkAbstractCellLocator2.Register(null);
			}
		}
		return vtkAbstractCellLocator2;
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern long vtkTrimmedExtrusionFilter_GetNumberOfGenerationsFromBase_09(HandleRef pThis, string type);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public override long GetNumberOfGenerationsFromBase(string type)
	{
		return vtkTrimmedExtrusionFilter_GetNumberOfGenerationsFromBase_09(GetCppThis(), type);
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern long vtkTrimmedExtrusionFilter_GetNumberOfGenerationsFromBaseType_10(string type);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new static long GetNumberOfGenerationsFromBaseType(string type)
	{
		return vtkTrimmedExtrusionFilter_GetNumberOfGenerationsFromBaseType_10(type);
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkTrimmedExtrusionFilter_GetTrimSurface_11(HandleRef pThis, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	/// Return a pointer to the enclosing surface.
	/// </summary>
	public vtkPolyData GetTrimSurface()
	{
		vtkPolyData vtkPolyData2 = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkTrimmedExtrusionFilter_GetTrimSurface_11(GetCppThis(), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			vtkPolyData2 = (vtkPolyData)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var found);
			if (found)
			{
				vtkPolyData2.Register(null);
			}
		}
		return vtkPolyData2;
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkTrimmedExtrusionFilter_GetTrimSurface_12(HandleRef pThis, HandleRef sourceInfo, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	/// Return a pointer to the enclosing surface.
	/// </summary>
	public vtkPolyData GetTrimSurface(vtkInformationVector sourceInfo)
	{
		vtkPolyData vtkPolyData2 = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkTrimmedExtrusionFilter_GetTrimSurface_12(GetCppThis(), sourceInfo?.GetCppThis() ?? default(HandleRef), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			vtkPolyData2 = (vtkPolyData)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var found);
			if (found)
			{
				vtkPolyData2.Register(null);
			}
		}
		return vtkPolyData2;
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkTrimmedExtrusionFilter_IsA_13(HandleRef pThis, string type);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public override int IsA(string type)
	{
		return vtkTrimmedExtrusionFilter_IsA_13(GetCppThis(), type);
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkTrimmedExtrusionFilter_IsTypeOf_14(string type);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new static int IsTypeOf(string type)
	{
		return vtkTrimmedExtrusionFilter_IsTypeOf_14(type);
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkTrimmedExtrusionFilter_NewInstance_16(HandleRef pThis, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new vtkTrimmedExtrusionFilter NewInstance()
	{
		vtkTrimmedExtrusionFilter result = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkTrimmedExtrusionFilter_NewInstance_16(GetCppThis(), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			result = (vtkTrimmedExtrusionFilter)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var _);
		}
		return result;
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkTrimmedExtrusionFilter_SafeDownCast_17(HandleRef o, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new static vtkTrimmedExtrusionFilter SafeDownCast(vtkObjectBase o)
	{
		vtkTrimmedExtrusionFilter vtkTrimmedExtrusionFilter2 = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkTrimmedExtrusionFilter_SafeDownCast_17(o?.GetCppThis() ?? default(HandleRef), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			vtkTrimmedExtrusionFilter2 = (vtkTrimmedExtrusionFilter)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var found);
			if (found)
			{
				vtkTrimmedExtrusionFilter2.Register(null);
			}
		}
		return vtkTrimmedExtrusionFilter2;
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_SetCapping_18(HandleRef pThis, int _arg);

	/// <summary>
	/// Turn on/off the capping of the extruded skirt.
	/// </summary>
	public virtual void SetCapping(int _arg)
	{
		vtkTrimmedExtrusionFilter_SetCapping_18(GetCppThis(), _arg);
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_SetCappingStrategy_19(HandleRef pThis, int _arg);

	/// <summary>
	/// Specify a strategy for capping. By default the points of the cap
	/// polygons are located where the extrusion intersects the capping surface.
	/// However, to preserve planarity, or to place the capping surface at the
	/// average/minimum/maximum distance of extrusion, different strategies can
	/// be used. By default the average distance is used.
	///
	/// Note if none of the extrusion rays intersect the trim surface, then
	/// capping is not performed, nor is an extrusion skirt sent to the
	/// output. Also note that if the capping strategy is set to INTERSECTION,
	/// and one of the extrusion rays of the generating primitive does not
	/// intersect the trim surface, then no output will be generated for that
	/// primitive. However if any other capping strategy is used, capping will
	/// succeed if at least one extrusion ray strikes the trim surface (although
	/// missed extrusion ray intersections will not factor into the
	/// determination of final cap location).
	///
	/// Finally, note that any capping strategy other than INTERSECTION may
	/// produce more points than expected because the output primitives may
	/// have to be "split apart" to satisy the capping constraint.
	/// </summary>
	public virtual void SetCappingStrategy(int _arg)
	{
		vtkTrimmedExtrusionFilter_SetCappingStrategy_19(GetCppThis(), _arg);
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_SetCappingStrategyToAverageDistance_20(HandleRef pThis);

	/// <summary>
	/// Specify a strategy for capping. By default the points of the cap
	/// polygons are located where the extrusion intersects the capping surface.
	/// However, to preserve planarity, or to place the capping surface at the
	/// average/minimum/maximum distance of extrusion, different strategies can
	/// be used. By default the average distance is used.
	///
	/// Note if none of the extrusion rays intersect the trim surface, then
	/// capping is not performed, nor is an extrusion skirt sent to the
	/// output. Also note that if the capping strategy is set to INTERSECTION,
	/// and one of the extrusion rays of the generating primitive does not
	/// intersect the trim surface, then no output will be generated for that
	/// primitive. However if any other capping strategy is used, capping will
	/// succeed if at least one extrusion ray strikes the trim surface (although
	/// missed extrusion ray intersections will not factor into the
	/// determination of final cap location).
	///
	/// Finally, note that any capping strategy other than INTERSECTION may
	/// produce more points than expected because the output primitives may
	/// have to be "split apart" to satisy the capping constraint.
	/// </summary>
	public void SetCappingStrategyToAverageDistance()
	{
		vtkTrimmedExtrusionFilter_SetCappingStrategyToAverageDistance_20(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_SetCappingStrategyToIntersection_21(HandleRef pThis);

	/// <summary>
	/// Specify a strategy for capping. By default the points of the cap
	/// polygons are located where the extrusion intersects the capping surface.
	/// However, to preserve planarity, or to place the capping surface at the
	/// average/minimum/maximum distance of extrusion, different strategies can
	/// be used. By default the average distance is used.
	///
	/// Note if none of the extrusion rays intersect the trim surface, then
	/// capping is not performed, nor is an extrusion skirt sent to the
	/// output. Also note that if the capping strategy is set to INTERSECTION,
	/// and one of the extrusion rays of the generating primitive does not
	/// intersect the trim surface, then no output will be generated for that
	/// primitive. However if any other capping strategy is used, capping will
	/// succeed if at least one extrusion ray strikes the trim surface (although
	/// missed extrusion ray intersections will not factor into the
	/// determination of final cap location).
	///
	/// Finally, note that any capping strategy other than INTERSECTION may
	/// produce more points than expected because the output primitives may
	/// have to be "split apart" to satisy the capping constraint.
	/// </summary>
	public void SetCappingStrategyToIntersection()
	{
		vtkTrimmedExtrusionFilter_SetCappingStrategyToIntersection_21(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_SetCappingStrategyToMaximumDistance_22(HandleRef pThis);

	/// <summary>
	/// Specify a strategy for capping. By default the points of the cap
	/// polygons are located where the extrusion intersects the capping surface.
	/// However, to preserve planarity, or to place the capping surface at the
	/// average/minimum/maximum distance of extrusion, different strategies can
	/// be used. By default the average distance is used.
	///
	/// Note if none of the extrusion rays intersect the trim surface, then
	/// capping is not performed, nor is an extrusion skirt sent to the
	/// output. Also note that if the capping strategy is set to INTERSECTION,
	/// and one of the extrusion rays of the generating primitive does not
	/// intersect the trim surface, then no output will be generated for that
	/// primitive. However if any other capping strategy is used, capping will
	/// succeed if at least one extrusion ray strikes the trim surface (although
	/// missed extrusion ray intersections will not factor into the
	/// determination of final cap location).
	///
	/// Finally, note that any capping strategy other than INTERSECTION may
	/// produce more points than expected because the output primitives may
	/// have to be "split apart" to satisy the capping constraint.
	/// </summary>
	public void SetCappingStrategyToMaximumDistance()
	{
		vtkTrimmedExtrusionFilter_SetCappingStrategyToMaximumDistance_22(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_SetCappingStrategyToMinimumDistance_23(HandleRef pThis);

	/// <summary>
	/// Specify a strategy for capping. By default the points of the cap
	/// polygons are located where the extrusion intersects the capping surface.
	/// However, to preserve planarity, or to place the capping surface at the
	/// average/minimum/maximum distance of extrusion, different strategies can
	/// be used. By default the average distance is used.
	///
	/// Note if none of the extrusion rays intersect the trim surface, then
	/// capping is not performed, nor is an extrusion skirt sent to the
	/// output. Also note that if the capping strategy is set to INTERSECTION,
	/// and one of the extrusion rays of the generating primitive does not
	/// intersect the trim surface, then no output will be generated for that
	/// primitive. However if any other capping strategy is used, capping will
	/// succeed if at least one extrusion ray strikes the trim surface (although
	/// missed extrusion ray intersections will not factor into the
	/// determination of final cap location).
	///
	/// Finally, note that any capping strategy other than INTERSECTION may
	/// produce more points than expected because the output primitives may
	/// have to be "split apart" to satisy the capping constraint.
	/// </summary>
	public void SetCappingStrategyToMinimumDistance()
	{
		vtkTrimmedExtrusionFilter_SetCappingStrategyToMinimumDistance_23(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_SetExtrusionDirection_24(HandleRef pThis, double _arg1, double _arg2, double _arg3);

	/// <summary>
	/// Set/Get the extrusion direction.
	/// </summary>
	public virtual void SetExtrusionDirection(double _arg1, double _arg2, double _arg3)
	{
		vtkTrimmedExtrusionFilter_SetExtrusionDirection_24(GetCppThis(), _arg1, _arg2, _arg3);
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_SetExtrusionDirection_25(HandleRef pThis, IntPtr _arg);

	/// <summary>
	/// Set/Get the extrusion direction.
	/// </summary>
	public virtual void SetExtrusionDirection(IntPtr _arg)
	{
		vtkTrimmedExtrusionFilter_SetExtrusionDirection_25(GetCppThis(), _arg);
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_SetExtrusionStrategy_26(HandleRef pThis, int _arg);

	/// <summary>
	/// Specify a strategy for extrusion. If the strategy is set to
	/// "BOUNDARY_EDGES" then the boundary edges of the input polygons and
	/// triangle strips are swept. (A boundary edge is an edge used by only one
	/// 2D primitive, e.g., polygon or triangle.) Alternatively, all edges can
	/// be swept. (This is particularly useful when only sinple disconnected
	/// polygons exist in the input and so boundary calculation can be avoided.)
	/// By default boundary edges are extruded.
	/// </summary>
	public virtual void SetExtrusionStrategy(int _arg)
	{
		vtkTrimmedExtrusionFilter_SetExtrusionStrategy_26(GetCppThis(), _arg);
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_SetExtrusionStrategyToAllEdges_27(HandleRef pThis);

	/// <summary>
	/// Specify a strategy for extrusion. If the strategy is set to
	/// "BOUNDARY_EDGES" then the boundary edges of the input polygons and
	/// triangle strips are swept. (A boundary edge is an edge used by only one
	/// 2D primitive, e.g., polygon or triangle.) Alternatively, all edges can
	/// be swept. (This is particularly useful when only sinple disconnected
	/// polygons exist in the input and so boundary calculation can be avoided.)
	/// By default boundary edges are extruded.
	/// </summary>
	public void SetExtrusionStrategyToAllEdges()
	{
		vtkTrimmedExtrusionFilter_SetExtrusionStrategyToAllEdges_27(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_SetExtrusionStrategyToBoundaryEdges_28(HandleRef pThis);

	/// <summary>
	/// Specify a strategy for extrusion. If the strategy is set to
	/// "BOUNDARY_EDGES" then the boundary edges of the input polygons and
	/// triangle strips are swept. (A boundary edge is an edge used by only one
	/// 2D primitive, e.g., polygon or triangle.) Alternatively, all edges can
	/// be swept. (This is particularly useful when only sinple disconnected
	/// polygons exist in the input and so boundary calculation can be avoided.)
	/// By default boundary edges are extruded.
	/// </summary>
	public void SetExtrusionStrategyToBoundaryEdges()
	{
		vtkTrimmedExtrusionFilter_SetExtrusionStrategyToBoundaryEdges_28(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_SetLocator_29(HandleRef pThis, HandleRef locator);

	/// <summary>
	/// Specify a cell locator. By default a vtkStaticCellLocator is
	/// used. The locator performs efficient searches to intersect cells.
	/// </summary>
	public void SetLocator(vtkAbstractCellLocator locator)
	{
		vtkTrimmedExtrusionFilter_SetLocator_29(GetCppThis(), locator?.GetCppThis() ?? default(HandleRef));
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_SetTrimSurfaceConnection_30(HandleRef pThis, HandleRef algOutput);

	/// <summary>
	/// Specify the surface which trims the surface.  Note that the method
	/// SetTrimSurfaceData does not connect the pipeline. The algorithm will
	/// work on the input data as it is without updating the producer of the
	/// data.  The method SetTrimSurfaceConnection connects the pipeline.
	/// </summary>
	public void SetTrimSurfaceConnection(vtkAlgorithmOutput algOutput)
	{
		vtkTrimmedExtrusionFilter_SetTrimSurfaceConnection_30(GetCppThis(), algOutput?.GetCppThis() ?? default(HandleRef));
	}

	[DllImport("Kitware.VTK.FiltersModeling.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkTrimmedExtrusionFilter_SetTrimSurfaceData_31(HandleRef pThis, HandleRef pd);

	/// <summary>
	/// Specify the surface which trims the surface.  Note that the method
	/// SetTrimSurfaceData does not connect the pipeline. The algorithm will
	/// work on the input data as it is without updating the producer of the
	/// data.  The method SetTrimSurfaceConnection connects the pipeline.
	/// </summary>
	public void SetTrimSurfaceData(vtkPolyData pd)
	{
		vtkTrimmedExtrusionFilter_SetTrimSurfaceData_31(GetCppThis(), pd?.GetCppThis() ?? default(HandleRef));
	}
}