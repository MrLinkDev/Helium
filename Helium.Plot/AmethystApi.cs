using System.Runtime.InteropServices;
using System.Text.Unicode;

namespace Helium.Plot;

public static class AmethystApi {
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetScreenPtr(IntPtr activityPtr);
    
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void UpdateScreen(IntPtr screenPtr);
    
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void AddTrace(IntPtr screenPtr, uint traceId, [MarshalAs(UnmanagedType.LPArray)] float[] dataPtr, uint points);
    
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void RemoveTrace(IntPtr screenPtr, uint traceId);
    
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetStartStopX(IntPtr screenPtr, uint traceId, float startX, float stopX);
    
    [DllImport("Amethyst.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetStartStopY(IntPtr screenPtr, uint traceId, float startY, float stopY);
}
