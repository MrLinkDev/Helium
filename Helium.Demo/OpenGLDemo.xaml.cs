using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using Helium.Controls.Window;
using Helium.Plot;

namespace HeliumDemo;

public partial class OpenGLDemo : HeWindow {

    private const uint points = 101;
    private const uint size = points * 2;
    
    private float[] data1;
    private float[] data2;

    private const float f = 2;
    private float c = 2 * Single.Pi * f;
    
    private float p = 0;
    private const float d = (int) (size / (f * 2));

    public OpenGLDemo() {
        InitializeComponent();

        Plot.OnReady = () => {
            data1 = new float[size];
            data2 = new float[size];
        
            Plot.AddTrace(0, data1, points);
            Plot.AddTrace(1, data2, points);
        
            AmethystApi.SetStartStopX(Plot.ScreenPtr, 0, -1, 1);
            AmethystApi.SetStartStopY(Plot.ScreenPtr, 0, -1, 1);
        
            AmethystApi.SetStartStopX(Plot. ScreenPtr, 1, -1, 1);
            AmethystApi.SetStartStopY(Plot. ScreenPtr, 1, -1, 1);

            Plot.OnUpdate = () => {
                for (int i = 0; i < points; ++i) {
                    data1[i * 2 + 0] = -1.0f + i * ((float)2 / (points - 1));
                    data1[i * 2 + 1] = float.Sin(c * ((float) i / size) + p);
                
                    data2[i * 2 + 0] = -1.0f + i * ((float)2 / (points - 1));
                    data2[i * 2 + 1] = float.Sin(c * ((float) i / size) + p + d);
                }

                p += (f / size) * 10;
            
                AmethystApi.UpdateScreen(Plot.ScreenPtr);
            };
        };
    }

    private void AddTrace(object sender, RoutedEventArgs e) {
        //Plot.AddTrace();
    }
    
    private void RemoveTrace(object sender, RoutedEventArgs e) {
        //Plot.RemoveTrace();
    }

    private void FrameRateChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
        Plot.FrameRate = (int) e.NewValue;
    }
}

