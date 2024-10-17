using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Helium.Controls.Window;
using Helium.Plot;

namespace HeliumDemo;

public partial class OpenGLDemo : HeWindow {

    private const uint points = 101;
    private const uint size = points * 2;
    
    private float[] data1;
    private float[] data2;
    private float[] data3;
    private float[] data4;

    private const float f = 2;
    private float c = 2 * Single.Pi * f;
    
    private float p = 0;
    private const float d = (int) (size / (f * 2));

    private uint markerId = 0;
    private float markerPos = -1f + ((float)2 / (points - 1));

    private float minPosX = -5e9f;
    private float maxPosX = -2e9f;
    
    private float minPosY = 2e9f;
    private float maxPosY = 5e9f;

    private float[] markersPos = new float[10];
    
    public OpenGLDemo() {
        InitializeComponent();

        Plot.OnReady = () => {
            data1 = new float[size];
            data2 = new float[size];
            data3 = new float[4];
            data4 = new float[4];
            
            GCHandle data1Handle = GCHandle.Alloc(data1, GCHandleType.Pinned);
            GCHandle data2Handle = GCHandle.Alloc(data2, GCHandleType.Pinned);
            GCHandle data3Handle = GCHandle.Alloc(data3, GCHandleType.Pinned);
            GCHandle data4Handle = GCHandle.Alloc(data4, GCHandleType.Pinned);

            IntPtr data1Ptr = data1Handle.AddrOfPinnedObject();
            IntPtr data2Ptr = data2Handle.AddrOfPinnedObject();
            IntPtr data3Ptr = data3Handle.AddrOfPinnedObject();
            IntPtr data4Ptr = data4Handle.AddrOfPinnedObject();
        
            Plot.AddTrace(0, data1Ptr, points);
            Plot.AddTrace(1, data2Ptr, points);
            Plot.AddTrace(2, data3Ptr, 2);
            Plot.AddTrace(3, data4Ptr, 2);
        
            AmethystApi.SetStartStopX(Plot.ScreenPtr, 0, minPosX, maxPosX);
            AmethystApi.SetStartStopY(Plot.ScreenPtr, 0, minPosY, maxPosY);
        
            AmethystApi.SetStartStopX(Plot.ScreenPtr, 1, -1, 1);
            AmethystApi.SetStartStopY(Plot.ScreenPtr, 1, -1, 1);
        
            AmethystApi.SetStartStopX(Plot.ScreenPtr, 2, minPosX, maxPosX);
            AmethystApi.SetStartStopY(Plot.ScreenPtr, 2, -1, 1);
            
            AmethystApi.SetStartStopX(Plot.ScreenPtr, 3, -1, 1);
            AmethystApi.SetStartStopY(Plot.ScreenPtr, 3, minPosY, maxPosY);
            
            data3[0] = minPosX;
            data3[1] = 0;
            data3[2] = maxPosX;
            data3[3] = 0;
                
            data4[0] = 0;
            data4[1] = minPosY;
            data4[2] = 0;
            data4[3] = maxPosY;

            Plot.OnUpdate = () => {
                float[] x = new float[points];
                
                for (int i = 0; i < points; ++i) {
                    data1[i * 2 + 0] = minPosX + i * ((maxPosX - minPosX) / (points - 1));
                    data1[i * 2 + 1] =  ((maxPosY + minPosY) / 2) + float.Sin(c * ((float) i / size) + p) * ((maxPosY - minPosY) / 2);
                
                    data2[i * 2 + 0] = -1.0f + i * ((float)2 / (points - 1));
                    data2[i * 2 + 1] = float.Sin(c * ((float) i / size) + p + d);

                    x[i] = data1[i * 2 + 1];

                    if (i == 25) {
                        //Plot.SetMarkerY(0, 0,  data1[i * 2 + 0],  data1[i * 2 + 1]);
                        Plot.PlaceMarker(0, 0, data1[i * 2 + 0],  data1[i * 2 + 1]);
                    }

                    // for (uint j = 0; j < 10; j++) {
                    //     if (Math.Abs(markersPos[j] - data1[i * 2 + 0]) < 0.0001) {
                    //         Plot.SetMarkerY(0, j,  data1[i * 2 + 1]);
                    //     }
                    // }
                }
                
                p += (f / size) * 10;
            
                AmethystApi.UpdateScreen(Plot.ScreenPtr);
            };
        };
    }

    private void AddMarker(object sender, RoutedEventArgs e) {
        Plot.AddMarker(0, 0, -0.5f, 0.0f);
    }
    
    private void RemoveMarker(object sender, RoutedEventArgs e) {
        Plot.RemoveMarker(0, --markerId);
        markerPos -= 0.1f;
    }

    private void FrameRateChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
        Plot.FrameRate = (int) e.NewValue;
    }
}

