using System.Runtime.InteropServices;

namespace Helium.Plot;

public class PlotData : IDisposable {
    private GCHandle gcHandle;
    
    private uint size;

    public uint Size {
        get => size;
        set => size = value;
    }
    
    private uint points;

    public uint Points {
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

    public PlotData(uint size) {
        this.size = size;
        points = this.size / 2;

        data = new float[size];
        
        gcHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
        pointer = gcHandle.AddrOfPinnedObject();
    }
    
    public PlotData(float[] data) {
        gcHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
        pointer = gcHandle.AddrOfPinnedObject();

        this.data = data;
        
        size = (uint)data.Length;
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
