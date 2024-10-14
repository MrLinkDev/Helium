using System.Runtime.InteropServices;
using System.Text.Unicode;

namespace Helium.Plot;

public static class AmethystApi {
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetScreenPtr(IntPtr activityPtr);
    
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UpdateScreen(IntPtr screenPtr);
    
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void AddTrace(IntPtr screenPtr, uint traceId, IntPtr dataPtr, uint points);
    
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void RemoveTrace(IntPtr screenPtr, uint traceId);
    
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetStartStopX(IntPtr screenPtr, uint traceId, float startX, float stopX);
    
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetStartStopY(IntPtr screenPtr, uint traceId, float startY, float stopY);
    
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void AddMarker(IntPtr screenPtr, uint traceId, uint markerId, float x, float y);
    
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMarkerX(IntPtr screenPtr, uint traceId, uint markerId, float x);
    
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetMarkerY(IntPtr screenPtr, uint traceId, uint markerId, float y);
    
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void PlaceMarker(IntPtr screenPtr, uint traceId, uint markerId, float x, float y);
    
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void RemoveMarker(IntPtr screenPtr, uint traceId, uint markerId);
}
