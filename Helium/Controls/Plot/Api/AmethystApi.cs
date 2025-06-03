using System.Runtime.InteropServices;

namespace Helium.Controls.Plot.Api;

internal static class AmethystApi {
    private const string DLL_NAME = "Alexander.Gorbunov.Amethyst.dll";

    #region TraceRegion

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void AddTrace(IntPtr screenPtr, int traceId, IntPtr dataPtr, int points);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SelectTrace(IntPtr screenPtr, int traceId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void RemoveTrace(IntPtr screenPtr, int traceId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetData(IntPtr screenPtr, int traceId, IntPtr dataPtr, int points);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void AutoScale(IntPtr screenPtr, int traceId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetStartStopX(IntPtr screenPtr, int traceId, float startX, float stopX);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetStartStopY(IntPtr screenPtr, int traceId, float startY, float stopY);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetStartX(IntPtr screenPtr, int traceId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetStopX(IntPtr screenPtr, int traceId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetStartY(IntPtr screenPtr, int traceId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetStopY(IntPtr screenPtr, int traceId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetUnits(IntPtr screenPtr, int traceId, int unitsX, int unitsY);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetUnitsX(IntPtr screenPtr, int traceId, int units);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetUnitsY(IntPtr screenPtr, int traceId, int units);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetIsDrawReversed(IntPtr screenPtr, bool isDrawReversed);

    #endregion

    #region MarkerRegion

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void AddMarkerWTrace(IntPtr screenPtr, int traceId, int markerId);
    
    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void AddMarker(IntPtr screenPtr, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SelectMarkerWTrace(IntPtr screenPtr, int traceId, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SelectMarker(IntPtr screenPtr, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void RemoveMarkerWTrace(IntPtr screenPtr, int traceId, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void RemoveMarker(IntPtr screenPtr, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMarkerXWTrace(IntPtr screenPtr, int traceId, int markerId, float x);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMarkerX(IntPtr screenPtr, int markerId, float x);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetMarkerXWTrace(IntPtr screenPtr, int traceId, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetMarkerX(IntPtr screenPtr, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMarkerYWTrace(IntPtr screenPtr, int traceId, int markerId, float y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMarkerY(IntPtr screenPtr, int markerId, float y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetMarkerYWTrace(IntPtr screenPtr, int traceId, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetMarkerY(IntPtr screenPtr, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMarkerFunctionWTrace(IntPtr screenPtr, int traceId, int markerId, int type);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMarkerFunction(IntPtr screenPtr, int markerId, int type);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void RemoveMarkerFunctionWTrace(IntPtr screenPtr, int traceId, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void RemoveMarkerFunction(IntPtr screenPtr, int markerId);
    
    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMarkerCoordsUpdatedDelegate(IntPtr screenPtr, IntPtr xDelegate, IntPtr yDelegate);
    
    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetSelectedTraceUpdatedDelegate(IntPtr screenPtr, IntPtr traceDelegate);
    
    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetSelectedMarkerUpdatedDelegate(IntPtr screenPtr, IntPtr markerDelegate);
    
    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetAutoScaleInvokedDelegate(IntPtr screenPtr, IntPtr autoScaleDelegate);

    #endregion
}
