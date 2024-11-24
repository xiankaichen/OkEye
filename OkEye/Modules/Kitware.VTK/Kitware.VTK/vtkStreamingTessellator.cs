using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Kitware.mummy.Runtime;

namespace Kitware.VTK;

/// <summary>
///    vtkStreamingTessellator
/// </summary>
/// <remarks>
///    An algorithm that refines an initial simplicial tessellation using edge subdivision
///
/// This class is a simple algorithm that takes a single starting simplex -- a
/// tetrahedron, triangle, or line segment -- and calls a function you
/// pass it with (possibly many times) tetrahedra, triangles, or lines
/// adaptively sampled from the one you specified. It
/// uses an algorithm you specify to control the level of adaptivity.
///
/// This class does not create vtkUnstructuredGrid output because it is
/// intended for use in mappers as well as filters. Instead, it
/// calls the registered function with simplices as they are
/// created.
///
/// The subdivision algorithm should change the vertex
/// coordinates (it must change both geometric and, if desired, parametric
/// coordinates) of the midpoint. These coordinates need not be
/// changed unless the EvaluateLocationAndFields() member returns true.
/// The vtkStreamingTessellator itself has no way of creating
/// a more accurate midpoint vertex.
///
/// Here's how to use this class:
/// - Call AdaptivelySample1Facet, AdaptivelySample2Facet, or
///   AdaptivelySample3Facet, with an edge, triangle, or
///   tetrahedron you want tessellated.
/// - The adaptive tessellator classifies each edge by passing
///   the midpoint values to the vtkEdgeSubdivisionCriterion.
/// - After each edge is classified, the tessellator subdivides
///   edges as required until the subdivision criterion is
///   satisfied or the maximum subdivision depth has been
///   reached.
/// - Edges, triangles, or tetrahedra connecting the vertices
///   generated by the subdivision algorithm are processed by
///   calling the user-defined callback functions (set with
///   SetTetrahedronCallback(), SetTriangleCallback(),
///   or SetEdgeCallback() ).
///
/// @warning
/// Note that the vertices passed to AdaptivelySample3Facet, AdaptivelySample2Facet,
/// or AdaptivelySample1Facet must be at least 6, 5, or 4 entries long, respectively!
/// This is because the &amp;lt;r,s,t&amp;gt;, &amp;lt;r,s&amp;gt;, or &amp;lt;r&amp;gt;
/// parametric coordinates of the vertices are maintained as the
/// facet is subdivided. This information is often
/// required by the subdivision algorithm in order to compute
/// an error metric. You may change the number of parametric coordinates
/// associated with each vertex using vtkStreamingTessellator::SetEmbeddingDimension().
///
/// @par Interpolating Field Values:
/// If you wish, you may also use \p vtkStreamingTessellator to interpolate field
/// values at newly created vertices. Interpolated field values are stored just beyond
/// the parametric coordinates associated with a vertex. They will always be \p double
/// values; it does not make sense to interpolate a boolean or string value and your
/// output and subdivision subroutines may always cast to a \p float or use \p floor() to
/// truncate an interpolated value to an integer.
///
/// </remarks>
/// <seealso>
///
/// vtkEdgeSubdivisionCriterion
/// </seealso>
public class vtkStreamingTessellator : vtkObject
{
	/// <summary>
	///             Undocumented Block
	/// </summary>
	public enum MaxFieldSize_WrapperEnum
	{
		/// <summary>enum member</summary>
		MaxFieldSize = 18
	}

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public delegate void EdgeProcessorFunction(IntPtr arg0, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public delegate void TetrahedronProcessorFunction(IntPtr arg0, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public delegate void TriangleProcessorFunction(IntPtr arg0, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public delegate void VertexProcessorFunction(IntPtr arg0, IntPtr arg1, IntPtr arg2, IntPtr arg3);

	/// <summary>
	/// Automatically generated type registration mechanics.
	/// </summary>
	public new const string MRFullTypeName = "Kitware.VTK.vtkStreamingTessellator";

	/// <summary>
	/// Automatically generated type registration mechanics.
	/// </summary>
	public new static readonly string MRClassNameKey;

	/// <summary>
	/// Automatically generated type registration mechanics.
	/// </summary>
	static vtkStreamingTessellator()
	{
		MRClassNameKey = "class vtkStreamingTessellator";
		Methods.RegisterType(Assembly.GetExecutingAssembly(), MRClassNameKey, Type.GetType("Kitware.VTK.vtkStreamingTessellator"));
	}

	/// <summary>
	/// Automatically generated constructor - called from generated code.
	/// DO NOT call directly.
	/// </summary>
	public vtkStreamingTessellator(IntPtr rawCppThis, bool callDisposalMethod, bool strong)
		: base(rawCppThis, callDisposalMethod, strong)
	{
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkStreamingTessellator_New(ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new static vtkStreamingTessellator New()
	{
		vtkStreamingTessellator result = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkStreamingTessellator_New(ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			result = (vtkStreamingTessellator)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var _);
		}
		return result;
	}

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public vtkStreamingTessellator()
		: base(IntPtr.Zero, callDisposalMethod: false, strong: false)
	{
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr rawCppThis = vtkStreamingTessellator_New(ref mteStatus, ref mteIndex, ref rawRefCount);
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
	internal static extern void vtkStreamingTessellator_AdaptivelySample0Facet_01(HandleRef pThis, IntPtr v0);

	/// <summary>
	/// This will adaptively subdivide the tetrahedron (3-facet),
	/// triangle (2-facet), or edge (1-facet) until the subdivision
	/// algorithm returns false for every edge or the maximum recursion
	/// depth is reached.
	///
	/// Use \p SetMaximumNumberOfSubdivisions to change the maximum
	/// recursion depth.
	///
	/// The AdaptivelySample0Facet method is provided as a convenience.
	/// Obviously, there is no way to adaptively subdivide a vertex.
	/// Instead the input vertex is passed unchanged to the output
	/// via a call to the registered VertexProcessorFunction callback.
	///
	/// .SECTION Warning
	/// This assumes that you have called SetSubdivisionAlgorithm(),
	/// SetEdgeCallback(), SetTriangleCallback(), and SetTetrahedronCallback()
	/// with valid values!
	/// </summary>
	public void AdaptivelySample0Facet(IntPtr v0)
	{
		vtkStreamingTessellator_AdaptivelySample0Facet_01(GetCppThis(), v0);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_AdaptivelySample1Facet_02(HandleRef pThis, IntPtr v0, IntPtr v1);

	/// <summary>
	/// This will adaptively subdivide the tetrahedron (3-facet),
	/// triangle (2-facet), or edge (1-facet) until the subdivision
	/// algorithm returns false for every edge or the maximum recursion
	/// depth is reached.
	///
	/// Use \p SetMaximumNumberOfSubdivisions to change the maximum
	/// recursion depth.
	///
	/// The AdaptivelySample0Facet method is provided as a convenience.
	/// Obviously, there is no way to adaptively subdivide a vertex.
	/// Instead the input vertex is passed unchanged to the output
	/// via a call to the registered VertexProcessorFunction callback.
	///
	/// .SECTION Warning
	/// This assumes that you have called SetSubdivisionAlgorithm(),
	/// SetEdgeCallback(), SetTriangleCallback(), and SetTetrahedronCallback()
	/// with valid values!
	/// </summary>
	public void AdaptivelySample1Facet(IntPtr v0, IntPtr v1)
	{
		vtkStreamingTessellator_AdaptivelySample1Facet_02(GetCppThis(), v0, v1);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_AdaptivelySample1FacetLinear_03(HandleRef pThis, IntPtr v0, IntPtr v1);

	/// <summary>
	/// This will adaptively subdivide the tetrahedron (3-facet),
	/// triangle (2-facet), or edge (1-facet) until the subdivision
	/// algorithm returns false for every edge or the maximum recursion
	/// depth is reached.
	///
	/// Use \p SetMaximumNumberOfSubdivisions to change the maximum
	/// recursion depth.
	///
	/// The AdaptivelySample0Facet method is provided as a convenience.
	/// Obviously, there is no way to adaptively subdivide a vertex.
	/// Instead the input vertex is passed unchanged to the output
	/// via a call to the registered VertexProcessorFunction callback.
	///
	/// .SECTION Warning
	/// This assumes that you have called SetSubdivisionAlgorithm(),
	/// SetEdgeCallback(), SetTriangleCallback(), and SetTetrahedronCallback()
	/// with valid values!
	/// </summary>
	public void AdaptivelySample1FacetLinear(IntPtr v0, IntPtr v1)
	{
		vtkStreamingTessellator_AdaptivelySample1FacetLinear_03(GetCppThis(), v0, v1);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_AdaptivelySample2Facet_04(HandleRef pThis, IntPtr v0, IntPtr v1, IntPtr v2);

	/// <summary>
	/// This will adaptively subdivide the tetrahedron (3-facet),
	/// triangle (2-facet), or edge (1-facet) until the subdivision
	/// algorithm returns false for every edge or the maximum recursion
	/// depth is reached.
	///
	/// Use \p SetMaximumNumberOfSubdivisions to change the maximum
	/// recursion depth.
	///
	/// The AdaptivelySample0Facet method is provided as a convenience.
	/// Obviously, there is no way to adaptively subdivide a vertex.
	/// Instead the input vertex is passed unchanged to the output
	/// via a call to the registered VertexProcessorFunction callback.
	///
	/// .SECTION Warning
	/// This assumes that you have called SetSubdivisionAlgorithm(),
	/// SetEdgeCallback(), SetTriangleCallback(), and SetTetrahedronCallback()
	/// with valid values!
	/// </summary>
	public void AdaptivelySample2Facet(IntPtr v0, IntPtr v1, IntPtr v2)
	{
		vtkStreamingTessellator_AdaptivelySample2Facet_04(GetCppThis(), v0, v1, v2);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_AdaptivelySample2FacetLinear_05(HandleRef pThis, IntPtr v0, IntPtr v1, IntPtr v2);

	/// <summary>
	/// This will adaptively subdivide the tetrahedron (3-facet),
	/// triangle (2-facet), or edge (1-facet) until the subdivision
	/// algorithm returns false for every edge or the maximum recursion
	/// depth is reached.
	///
	/// Use \p SetMaximumNumberOfSubdivisions to change the maximum
	/// recursion depth.
	///
	/// The AdaptivelySample0Facet method is provided as a convenience.
	/// Obviously, there is no way to adaptively subdivide a vertex.
	/// Instead the input vertex is passed unchanged to the output
	/// via a call to the registered VertexProcessorFunction callback.
	///
	/// .SECTION Warning
	/// This assumes that you have called SetSubdivisionAlgorithm(),
	/// SetEdgeCallback(), SetTriangleCallback(), and SetTetrahedronCallback()
	/// with valid values!
	/// </summary>
	public void AdaptivelySample2FacetLinear(IntPtr v0, IntPtr v1, IntPtr v2)
	{
		vtkStreamingTessellator_AdaptivelySample2FacetLinear_05(GetCppThis(), v0, v1, v2);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_AdaptivelySample3Facet_06(HandleRef pThis, IntPtr v0, IntPtr v1, IntPtr v2, IntPtr v3);

	/// <summary>
	/// This will adaptively subdivide the tetrahedron (3-facet),
	/// triangle (2-facet), or edge (1-facet) until the subdivision
	/// algorithm returns false for every edge or the maximum recursion
	/// depth is reached.
	///
	/// Use \p SetMaximumNumberOfSubdivisions to change the maximum
	/// recursion depth.
	///
	/// The AdaptivelySample0Facet method is provided as a convenience.
	/// Obviously, there is no way to adaptively subdivide a vertex.
	/// Instead the input vertex is passed unchanged to the output
	/// via a call to the registered VertexProcessorFunction callback.
	///
	/// .SECTION Warning
	/// This assumes that you have called SetSubdivisionAlgorithm(),
	/// SetEdgeCallback(), SetTriangleCallback(), and SetTetrahedronCallback()
	/// with valid values!
	/// </summary>
	public void AdaptivelySample3Facet(IntPtr v0, IntPtr v1, IntPtr v2, IntPtr v3)
	{
		vtkStreamingTessellator_AdaptivelySample3Facet_06(GetCppThis(), v0, v1, v2, v3);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_AdaptivelySample3FacetLinear_07(HandleRef pThis, IntPtr v0, IntPtr v1, IntPtr v2, IntPtr v3);

	/// <summary>
	/// This will adaptively subdivide the tetrahedron (3-facet),
	/// triangle (2-facet), or edge (1-facet) until the subdivision
	/// algorithm returns false for every edge or the maximum recursion
	/// depth is reached.
	///
	/// Use \p SetMaximumNumberOfSubdivisions to change the maximum
	/// recursion depth.
	///
	/// The AdaptivelySample0Facet method is provided as a convenience.
	/// Obviously, there is no way to adaptively subdivide a vertex.
	/// Instead the input vertex is passed unchanged to the output
	/// via a call to the registered VertexProcessorFunction callback.
	///
	/// .SECTION Warning
	/// This assumes that you have called SetSubdivisionAlgorithm(),
	/// SetEdgeCallback(), SetTriangleCallback(), and SetTetrahedronCallback()
	/// with valid values!
	/// </summary>
	public void AdaptivelySample3FacetLinear(IntPtr v0, IntPtr v1, IntPtr v2, IntPtr v3)
	{
		vtkStreamingTessellator_AdaptivelySample3FacetLinear_07(GetCppThis(), v0, v1, v2, v3);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern long vtkStreamingTessellator_GetCaseCount_08(HandleRef pThis, int c);

	/// <summary>
	/// Reset/access the histogram of subdivision cases encountered.
	/// The histogram may be used to examine coverage during testing as well as characterizing the
	/// tessellation algorithm's performance.
	/// You should call ResetCounts() once, at the beginning of a stream of tetrahedra.
	/// It must be called before AdaptivelySample3Facet() to prevent uninitialized memory reads.
	///
	/// These functions have no effect (and return 0) when PARAVIEW_DEBUG_TESSELLATOR has not been
	///             defined.
	/// By default, PARAVIEW_DEBUG_TESSELLATOR is not defined, and your code will be fast and
	///             efficient. Really!
	/// </summary>
	public long GetCaseCount(int c)
	{
		return vtkStreamingTessellator_GetCaseCount_08(GetCppThis(), c);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkStreamingTessellator_GetConstPrivateData_09(HandleRef pThis);

	/// <summary>
	/// Get/Set a constant void pointer passed to the simplex output functions.
	/// </summary>
	public virtual IntPtr GetConstPrivateData()
	{
		return vtkStreamingTessellator_GetConstPrivateData_09(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern EdgeProcessorFunction vtkStreamingTessellator_GetEdgeCallback_10(HandleRef pThis);

	/// <summary>
	/// Get/Set the function called for each output line segment (1-facet).
	/// </summary>
	public virtual EdgeProcessorFunction GetEdgeCallback()
	{
		return vtkStreamingTessellator_GetEdgeCallback_10(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkStreamingTessellator_GetEmbeddingDimension_11(HandleRef pThis, int k);

	/// <summary>
	/// Get/Set the number of parameter-space coordinates associated with each input and output point.
	/// The default is \a k for \a k -facets. You may
	/// specify a different dimension, \a d, for each type of \a k -facet to be processed.
	/// For example, \p SetEmbeddingDimension( \p 2, \p 3 ) would associate \a r, \a s, and
	/// \a t coordinates with each input and output point generated by \p AdaptivelySample2Facet
	/// but does not say anything about input or output points generated by
	/// \p AdaptivelySample1Facet.
	/// Call \p SetEmbeddingDimension( \p -1, \a d ) to specify the same dimension for
	/// all possible \a k values.
	/// \a d may not exceed 8, as that would be plain silly.
	/// </summary>
	public int GetEmbeddingDimension(int k)
	{
		return vtkStreamingTessellator_GetEmbeddingDimension_11(GetCppThis(), k);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkStreamingTessellator_GetFieldSize_12(HandleRef pThis, int k);

	/// <summary>
	/// Get/Set the number of field value coordinates associated with each input and output point.
	/// The default is 0; no field values are interpolated.
	/// You may specify a different size, \a s, for each type of \a k -facet to be processed.
	/// For example, \p SetFieldSize( \p 2, \p 3 ) would associate 3 field value coordinates
	/// with each input and output point of an \p AdaptivelySample2Facet call,
	/// but does not say anything about input or output points of \p AdaptivelySample1Facet.
	/// Call \p SetFieldSize( \p -1, \a s ) to specify the same dimension for all possible \a k values.
	/// \a s may not exceed vtkStreamingTessellator::MaxFieldSize.
	/// This is a compile-time constant that defaults to 18, which is large enough for
	/// a scalar, vector, tensor, normal, and texture coordinate to be included at each point.
	///
	/// Normally, you will not call \a SetFieldSize() directly; instead, subclasses of
	/// vtkEdgeSubdivisionCriterion, such as vtkShoeMeshSubdivisionAlgorithm, will call it
	/// for you.
	///
	/// In any event, setting \a FieldSize to a non-zero value means you must pass field
	/// values to the \p AdaptivelySamplekFacet routines; For example,
	/// @verbatim
	/// vtkStreamingTessellator* t = vtkStreamingTessellator::New();
	/// t-&gt;SetFieldSize( 1, 3 );
	/// t-&gt;SetEmbeddingDimension( 1, 1 ); // not really required, this is the default
	/// double p0[3+1+3] = { x0, y0, z0, r0, fx0, fy0, fz0 };
	/// double p1[3+1+3] = { x1, y1, z1, r1, fx1, fy1, fz1 };
	/// t-&gt;AdaptivelySample1Facet( p0, p1 );
	/// @endverbatim
	/// This would adaptively sample an curve (1-facet) with geometry and
	/// a vector field at every output point on the curve.
	/// </summary>
	public int GetFieldSize(int k)
	{
		return vtkStreamingTessellator_GetFieldSize_12(GetCppThis(), k);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkStreamingTessellator_GetMaximumNumberOfSubdivisions_13(HandleRef pThis);

	/// <summary>
	/// Get/Set the maximum number of subdivisions that may occur.
	/// </summary>
	public int GetMaximumNumberOfSubdivisions()
	{
		return vtkStreamingTessellator_GetMaximumNumberOfSubdivisions_13(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern long vtkStreamingTessellator_GetNumberOfGenerationsFromBase_14(HandleRef pThis, string type);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public override long GetNumberOfGenerationsFromBase(string type)
	{
		return vtkStreamingTessellator_GetNumberOfGenerationsFromBase_14(GetCppThis(), type);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern long vtkStreamingTessellator_GetNumberOfGenerationsFromBaseType_15(string type);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new static long GetNumberOfGenerationsFromBaseType(string type)
	{
		return vtkStreamingTessellator_GetNumberOfGenerationsFromBaseType_15(type);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkStreamingTessellator_GetPrivateData_16(HandleRef pThis);

	/// <summary>
	/// Get/Set a void pointer passed to the triangle and edge output functions.
	/// </summary>
	public virtual IntPtr GetPrivateData()
	{
		return vtkStreamingTessellator_GetPrivateData_16(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern long vtkStreamingTessellator_GetSubcaseCount_17(HandleRef pThis, int casenum, int sub);

	/// <summary>
	/// Reset/access the histogram of subdivision cases encountered.
	/// The histogram may be used to examine coverage during testing as well as characterizing the
	/// tessellation algorithm's performance.
	/// You should call ResetCounts() once, at the beginning of a stream of tetrahedra.
	/// It must be called before AdaptivelySample3Facet() to prevent uninitialized memory reads.
	///
	/// These functions have no effect (and return 0) when PARAVIEW_DEBUG_TESSELLATOR has not been
	///             defined.
	/// By default, PARAVIEW_DEBUG_TESSELLATOR is not defined, and your code will be fast and
	///             efficient. Really!
	/// </summary>
	public long GetSubcaseCount(int casenum, int sub)
	{
		return vtkStreamingTessellator_GetSubcaseCount_17(GetCppThis(), casenum, sub);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkStreamingTessellator_GetSubdivisionAlgorithm_18(HandleRef pThis, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	/// Get/Set the algorithm used to determine whether an edge should be
	/// subdivided or left as-is. This is used once for each call to
	/// AdaptivelySample1Facet (which is recursive and will call itself
	/// resulting in additional edges to be checked) or three times for
	/// each call to AdaptivelySample2Facet (also recursive).
	/// </summary>
	public virtual vtkEdgeSubdivisionCriterion GetSubdivisionAlgorithm()
	{
		vtkEdgeSubdivisionCriterion vtkEdgeSubdivisionCriterion2 = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkStreamingTessellator_GetSubdivisionAlgorithm_18(GetCppThis(), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			vtkEdgeSubdivisionCriterion2 = (vtkEdgeSubdivisionCriterion)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var found);
			if (found)
			{
				vtkEdgeSubdivisionCriterion2.Register(null);
			}
		}
		return vtkEdgeSubdivisionCriterion2;
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern TetrahedronProcessorFunction vtkStreamingTessellator_GetTetrahedronCallback_19(HandleRef pThis);

	/// <summary>
	/// Get/Set the function called for each output tetrahedron (3-facet).
	/// </summary>
	public virtual TetrahedronProcessorFunction GetTetrahedronCallback()
	{
		return vtkStreamingTessellator_GetTetrahedronCallback_19(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern TriangleProcessorFunction vtkStreamingTessellator_GetTriangleCallback_20(HandleRef pThis);

	/// <summary>
	/// Get/Set the function called for each output triangle (2-facet).
	/// </summary>
	public virtual TriangleProcessorFunction GetTriangleCallback()
	{
		return vtkStreamingTessellator_GetTriangleCallback_20(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern VertexProcessorFunction vtkStreamingTessellator_GetVertexCallback_21(HandleRef pThis);

	/// <summary>
	/// Get/Set the function called for each output line segment (1-facet).
	/// </summary>
	public virtual VertexProcessorFunction GetVertexCallback()
	{
		return vtkStreamingTessellator_GetVertexCallback_21(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkStreamingTessellator_IsA_22(HandleRef pThis, string type);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public override int IsA(string type)
	{
		return vtkStreamingTessellator_IsA_22(GetCppThis(), type);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int vtkStreamingTessellator_IsTypeOf_23(string type);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new static int IsTypeOf(string type)
	{
		return vtkStreamingTessellator_IsTypeOf_23(type);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkStreamingTessellator_NewInstance_25(HandleRef pThis, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new vtkStreamingTessellator NewInstance()
	{
		vtkStreamingTessellator result = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkStreamingTessellator_NewInstance_25(GetCppThis(), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			result = (vtkStreamingTessellator)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var _);
		}
		return result;
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_ResetCounts_26(HandleRef pThis);

	/// <summary>
	/// Reset/access the histogram of subdivision cases encountered.
	/// The histogram may be used to examine coverage during testing as well as characterizing the
	/// tessellation algorithm's performance.
	/// You should call ResetCounts() once, at the beginning of a stream of tetrahedra.
	/// It must be called before AdaptivelySample3Facet() to prevent uninitialized memory reads.
	///
	/// These functions have no effect (and return 0) when PARAVIEW_DEBUG_TESSELLATOR has not been
	///             defined.
	/// By default, PARAVIEW_DEBUG_TESSELLATOR is not defined, and your code will be fast and
	///             efficient. Really!
	/// </summary>
	public void ResetCounts()
	{
		vtkStreamingTessellator_ResetCounts_26(GetCppThis());
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr vtkStreamingTessellator_SafeDownCast_27(HandleRef o, ref uint mteStatus, ref uint mteIndex, ref uint rawRefCount);

	/// <summary>
	///             Undocumented Block
	/// </summary>
	public new static vtkStreamingTessellator SafeDownCast(vtkObjectBase o)
	{
		vtkStreamingTessellator vtkStreamingTessellator2 = null;
		uint mteStatus = 0u;
		uint mteIndex = uint.MaxValue;
		uint rawRefCount = 0u;
		IntPtr intPtr = vtkStreamingTessellator_SafeDownCast_27(o?.GetCppThis() ?? default(HandleRef), ref mteStatus, ref mteIndex, ref rawRefCount);
		if (IntPtr.Zero != intPtr)
		{
			vtkStreamingTessellator2 = (vtkStreamingTessellator)Methods.CreateWrappedObject(mteStatus, mteIndex, rawRefCount, intPtr, callDisposalMethod: true, out var found);
			if (found)
			{
				vtkStreamingTessellator2.Register(null);
			}
		}
		return vtkStreamingTessellator2;
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_SetConstPrivateData_28(HandleRef pThis, IntPtr ConstPrivate);

	/// <summary>
	/// Get/Set a constant void pointer passed to the simplex output functions.
	/// </summary>
	public virtual void SetConstPrivateData(IntPtr ConstPrivate)
	{
		vtkStreamingTessellator_SetConstPrivateData_28(GetCppThis(), ConstPrivate);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_SetEdgeCallback_29(HandleRef pThis, EdgeProcessorFunction arg0);

	/// <summary>
	/// Get/Set the function called for each output line segment (1-facet).
	/// </summary>
	public virtual void SetEdgeCallback(EdgeProcessorFunction arg0)
	{
		vtkStreamingTessellator_SetEdgeCallback_29(GetCppThis(), arg0);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_SetEmbeddingDimension_30(HandleRef pThis, int k, int d);

	/// <summary>
	/// Get/Set the number of parameter-space coordinates associated with each input and output point.
	/// The default is \a k for \a k -facets. You may
	/// specify a different dimension, \a d, for each type of \a k -facet to be processed.
	/// For example, \p SetEmbeddingDimension( \p 2, \p 3 ) would associate \a r, \a s, and
	/// \a t coordinates with each input and output point generated by \p AdaptivelySample2Facet
	/// but does not say anything about input or output points generated by
	/// \p AdaptivelySample1Facet.
	/// Call \p SetEmbeddingDimension( \p -1, \a d ) to specify the same dimension for
	/// all possible \a k values.
	/// \a d may not exceed 8, as that would be plain silly.
	/// </summary>
	public virtual void SetEmbeddingDimension(int k, int d)
	{
		vtkStreamingTessellator_SetEmbeddingDimension_30(GetCppThis(), k, d);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_SetFieldSize_31(HandleRef pThis, int k, int s);

	/// <summary>
	/// Get/Set the number of field value coordinates associated with each input and output point.
	/// The default is 0; no field values are interpolated.
	/// You may specify a different size, \a s, for each type of \a k -facet to be processed.
	/// For example, \p SetFieldSize( \p 2, \p 3 ) would associate 3 field value coordinates
	/// with each input and output point of an \p AdaptivelySample2Facet call,
	/// but does not say anything about input or output points of \p AdaptivelySample1Facet.
	/// Call \p SetFieldSize( \p -1, \a s ) to specify the same dimension for all possible \a k values.
	/// \a s may not exceed vtkStreamingTessellator::MaxFieldSize.
	/// This is a compile-time constant that defaults to 18, which is large enough for
	/// a scalar, vector, tensor, normal, and texture coordinate to be included at each point.
	///
	/// Normally, you will not call \a SetFieldSize() directly; instead, subclasses of
	/// vtkEdgeSubdivisionCriterion, such as vtkShoeMeshSubdivisionAlgorithm, will call it
	/// for you.
	///
	/// In any event, setting \a FieldSize to a non-zero value means you must pass field
	/// values to the \p AdaptivelySamplekFacet routines; For example,
	/// @verbatim
	/// vtkStreamingTessellator* t = vtkStreamingTessellator::New();
	/// t-&gt;SetFieldSize( 1, 3 );
	/// t-&gt;SetEmbeddingDimension( 1, 1 ); // not really required, this is the default
	/// double p0[3+1+3] = { x0, y0, z0, r0, fx0, fy0, fz0 };
	/// double p1[3+1+3] = { x1, y1, z1, r1, fx1, fy1, fz1 };
	/// t-&gt;AdaptivelySample1Facet( p0, p1 );
	/// @endverbatim
	/// This would adaptively sample an curve (1-facet) with geometry and
	/// a vector field at every output point on the curve.
	/// </summary>
	public virtual void SetFieldSize(int k, int s)
	{
		vtkStreamingTessellator_SetFieldSize_31(GetCppThis(), k, s);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_SetMaximumNumberOfSubdivisions_32(HandleRef pThis, int num_subdiv_in);

	/// <summary>
	/// Get/Set the maximum number of subdivisions that may occur.
	/// </summary>
	public virtual void SetMaximumNumberOfSubdivisions(int num_subdiv_in)
	{
		vtkStreamingTessellator_SetMaximumNumberOfSubdivisions_32(GetCppThis(), num_subdiv_in);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_SetPrivateData_33(HandleRef pThis, IntPtr Private);

	/// <summary>
	/// Get/Set a void pointer passed to the triangle and edge output functions.
	/// </summary>
	public virtual void SetPrivateData(IntPtr Private)
	{
		vtkStreamingTessellator_SetPrivateData_33(GetCppThis(), Private);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_SetSubdivisionAlgorithm_34(HandleRef pThis, HandleRef arg0);

	/// <summary>
	/// Get/Set the algorithm used to determine whether an edge should be
	/// subdivided or left as-is. This is used once for each call to
	/// AdaptivelySample1Facet (which is recursive and will call itself
	/// resulting in additional edges to be checked) or three times for
	/// each call to AdaptivelySample2Facet (also recursive).
	/// </summary>
	public virtual void SetSubdivisionAlgorithm(vtkEdgeSubdivisionCriterion arg0)
	{
		vtkStreamingTessellator_SetSubdivisionAlgorithm_34(GetCppThis(), arg0?.GetCppThis() ?? default(HandleRef));
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_SetTetrahedronCallback_35(HandleRef pThis, TetrahedronProcessorFunction arg0);

	/// <summary>
	/// Get/Set the function called for each output tetrahedron (3-facet).
	/// </summary>
	public virtual void SetTetrahedronCallback(TetrahedronProcessorFunction arg0)
	{
		vtkStreamingTessellator_SetTetrahedronCallback_35(GetCppThis(), arg0);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_SetTriangleCallback_36(HandleRef pThis, TriangleProcessorFunction arg0);

	/// <summary>
	/// Get/Set the function called for each output triangle (2-facet).
	/// </summary>
	public virtual void SetTriangleCallback(TriangleProcessorFunction arg0)
	{
		vtkStreamingTessellator_SetTriangleCallback_36(GetCppThis(), arg0);
	}

	[DllImport("Kitware.VTK.FiltersCore.Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void vtkStreamingTessellator_SetVertexCallback_37(HandleRef pThis, VertexProcessorFunction arg0);

	/// <summary>
	/// Get/Set the function called for each output line segment (1-facet).
	/// </summary>
	public virtual void SetVertexCallback(VertexProcessorFunction arg0)
	{
		vtkStreamingTessellator_SetVertexCallback_37(GetCppThis(), arg0);
	}
}
