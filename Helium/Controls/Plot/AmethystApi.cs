using System.Runtime.InteropServices;

namespace Helium.Controls.Plot;

internal static class AmethystApi {
    private const string DLL_NAME = "Alexander.Gorbunov.Amethyst.dll";
    
    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetTraceContainerPtr(IntPtr screenPtr);
    
    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SetScreenUpdated(IntPtr screenPtr);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetTracePtr(IntPtr containerPtr, int traceId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetSelectedTracePtr(IntPtr containerPtr);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void AddTrace(IntPtr containerPtr, int traceId, IntPtr dataPtr, int points);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SelectTrace(IntPtr containerPtr, int traceId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void RemoveTrace(IntPtr containerPtr, int traceId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetData(IntPtr containerPtr, int traceId, IntPtr dataPtr, int points);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetStartStopX(IntPtr container, int traceId, float startX, float stopX);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetStartStopY(IntPtr container, int traceId, float startY, float stopY);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetMarkerPtr(IntPtr containerPtr, int traceId, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetSelectedMarkerPtr(IntPtr containerPtr, int traceId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern float AddMarker(IntPtr containerPtr, int traceId, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SelectMarker(IntPtr containerPtr, int traceId, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void RemoveMarker(IntPtr containerPtr, int traceId, int markerId);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void PlaceMarker(IntPtr containerPtr, int traceId, int markerId, float x, float y);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMarkerX(IntPtr containerPtr, int traceId, int markerId, float x);

    [DllImport(DLL_NAME, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMarkerY(IntPtr containerPtr, int traceId, int markerId, float y);
}
