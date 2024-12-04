using System.Runtime.InteropServices;
using System.Text.Unicode;

namespace Helium.Plot;

internal static class AmethystApi {
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetTraceContainerPtr(IntPtr screenPtr);
    
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SetScreenUpdated(IntPtr screenPtr);

    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetTracePtr(IntPtr containerPtr, int traceId);

    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetSelectedTracePtr(IntPtr containerPtr);

    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void AddTrace(IntPtr containerPtr, int traceId, IntPtr dataPtr, uint points);

    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SelectTrace(IntPtr containerPtr, int traceId);

    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void RemoveTrace(IntPtr containerPtr, int traceId);

    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetData(IntPtr containerPtr, int traceId, IntPtr dataPtr, uint points);

    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetStartStopX(IntPtr container, int traceId, float startX, float stopX);

    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetStartStopY(IntPtr container, int traceId, float startY, float stopY);

    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetMarkerPtr(IntPtr containerPtr, int traceId, int markerId);

    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetSelectedMarkerPtr(IntPtr containerPtr, int traceId);

    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void AddMarker(IntPtr containerPtr, int traceId, int markerId, float x, float y);

    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SelectMarker(IntPtr containerPtr, int traceId, int markerId);

    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void RemoveMarker(IntPtr containerPtr, int traceId, int markerId);

    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void PlaceMarker(IntPtr containerPtr, int traceId, int markerId, float x, float y);

    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMarkerX(IntPtr containerPtr, int traceId, int markerId, float x);

    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMarkerY(IntPtr containerPtr, int traceId, int markerId, float y);
}
