using System.Runtime.InteropServices;

namespace Helium.Controls.Plot.Api;

public class PlotData : IDisposable {
    private GCHandle gcHandle;
    
    private int size;

    public int Size {
        get => size;
        set => size = value;
    }
    
    private int points;

    public int Points {
        get => points;
        set => points = value;
    }

    private float[] data;

    public float[] Data {
        get => data;
        set => data = value ?? throw new ArgumentNullException(nameof(value));
    }

    private IntPtr pointer;

    public IntPtr Pointer {
        get => pointer;
        set => pointer = value;
    }

    public PlotData(int points) {
        this.points = points;
        size  = points * 2;

        data = new float[size];
        
        gcHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
        pointer = gcHandle.AddrOfPinnedObject();
    }
    
    public PlotData(float[] data) {
        gcHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
        pointer = gcHandle.AddrOfPinnedObject();

        this.data = data;
        
        size = data.Length;
        points = size / 2;
    }

    ~PlotData() {
        ReleaseUnmanagedResources();
    }

    private void ReleaseUnmanagedResources() {
        gcHandle.Free();
    }

    public void Dispose() {
        ReleaseUnmanagedResources();
        
        GC.SuppressFinalize(this);
        GC.Collect();
    }
}
