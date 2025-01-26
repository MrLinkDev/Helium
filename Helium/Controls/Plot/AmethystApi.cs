using System.Runtime.InteropServices;

namespace Helium.Controls.Plot;

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
    public static extern void SetStartStopX(IntPtr screenPtr, int traceId, float startX, float stopX);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetStartStopY(IntPtr screenPtr, int traceId, float startY, float stopY);

    #endregion

    #region MarkerRegion

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern float AddMarker(IntPtr screenPtr, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SelectMarker(IntPtr screenPtr, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void RemoveMarker(IntPtr screenPtr, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMarkerX(IntPtr screenPtr, int markerId, float x);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetMarkerX(IntPtr screenPtr, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMarkerY(IntPtr screenPtr, int traceId, int markerId, float y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern float GetMarkerY(IntPtr screenPtr, int markerId);

    #endregion
}
