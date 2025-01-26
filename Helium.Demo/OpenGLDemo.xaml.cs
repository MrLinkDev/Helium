using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Helium.Controls.Window;

namespace HeliumDemo;

public partial class OpenGLDemo : HeWindow {
    private Dictionary<int, float[]> traceDataStorage = new Dictionary<int, float[]>();

    public OpenGLDemo() {
        InitializeComponent();
        
        // int traceId = Convert.ToInt32(TraceId.Text);
        // int points = Convert.ToInt32(Points.Text); 
        //
        // int startX = Convert.ToInt32(StartX.Text);
        // int stopX = Convert.ToInt32(StopX.Text);
        //
        // int startY = Convert.ToInt32(StartY.Text);
        // int stopY = Convert.ToInt32(StopY.Text);
        //
        // if (traceDataStorage.ContainsKey(traceId)) return;
        //
        // traceDataStorage[traceId] = Plot.AddTrace(traceId, points, startX, startY, stopX, stopY);
        //
        // float[] traceData = traceDataStorage[traceId];
        // float dx = (stopX - startX) / ((float)points - 1);
        // for (uint i = 0; i < points; i += 1) {
        //     traceData[i * 2 + 0] = startX + dx * i;
        //     traceData[i * 2 + 1] = MathF.Sin(2 * MathF.PI * 1 * i / points);
        // }

        Task.Run(() => {
            while (true) {
                foreach (var traceStoragePair in traceDataStorage) {
                    var traceData = traceStoragePair.Value;
        
                    float temp = traceData[1];
        
                    for (int i = 0; i < traceData.Length - 2; i += 2) {
                        traceData[i + 1] = traceData[i + 3];
                    }
        
                    traceData[^1] = temp;
                }
        
                Thread.Sleep(1000 / 30);
            }
        });
    }

    private void IncreaseTraceId_OnClick(object sender, RoutedEventArgs e) {
        TraceId.Text = Convert.ToString(Convert.ToInt32(TraceId.Text) + 1);
    }

    private void DecreaseTraceId_OnClick(object sender, RoutedEventArgs e) {
        TraceId.Text = Convert.ToString(Convert.ToInt32(TraceId.Text) - 1);
    }

    private void AddTrace_OnClick(object sender, RoutedEventArgs e) {
        int traceId = Convert.ToInt32(TraceId.Text);
        int points = Convert.ToInt32(Points.Text); 

        int startX = Convert.ToInt32(StartX.Text);
        int stopX = Convert.ToInt32(StopX.Text);

        int startY = Convert.ToInt32(StartY.Text);
        int stopY = Convert.ToInt32(StopY.Text);

        if (traceDataStorage.ContainsKey(traceId)) return;

        traceDataStorage[traceId] = Plot.AddTrace(traceId, points, startX, startY, stopX, stopY);

        float[] traceData = traceDataStorage[traceId];
        float dx = (stopX - startX) / ((float)points - 1);
        for (uint i = 0; i < points; i += 1) {
            traceData[i * 2 + 0] = startX + dx * i;
            traceData[i * 2 + 1] = MathF.Sin(2 * MathF.PI * 1 * i / points);
        }
    }

    private void SelectTrace_OnClick(object sender, RoutedEventArgs e) {
        int traceId = Convert.ToInt32(TraceId.Text);

        Plot.SelectTrace(traceId);
    }

    private void RemoveTrace_OnClick(object sender, RoutedEventArgs e) {
        int traceId = Convert.ToInt32(TraceId.Text);

        Plot.RemoveTrace(traceId);
        traceDataStorage.Remove(traceId);
    }

    private void IncreasePoints_OnClick(object sender, RoutedEventArgs e) {
        Points.Text = Convert.ToString(Convert.ToInt32(Points.Text) + 1);
    }

    private void DecreasePoints_OnClick(object sender, RoutedEventArgs e) {
        Points.Text = Convert.ToString(Convert.ToInt32(Points.Text) - 1);
    }

    private void IncreaseStartX_OnClick(object sender, RoutedEventArgs e) {
        StartX.Text = Convert.ToString(Convert.ToInt32(StartX.Text) + 1);
    }
    
    private void DecreaseStartX_OnClick(object sender, RoutedEventArgs e) {
        StartX.Text = Convert.ToString(Convert.ToInt32(StartX.Text) - 1);
    }

    private void IncreaseStopX_OnClick(object sender, RoutedEventArgs e) {
        StopX.Text = Convert.ToString(Convert.ToInt32(StopX.Text) + 1);
    }
    
    private void DecreaseStopX_OnClick(object sender, RoutedEventArgs e) {
        StopX.Text = Convert.ToString(Convert.ToInt32(StopX.Text) - 1);
    }
    
    private void IncreaseStartY_OnClick(object sender, RoutedEventArgs e) {
        StartY.Text = Convert.ToString(Convert.ToInt32(StartY.Text) + 1);
    }
    
    private void DecreaseStartY_OnClick(object sender, RoutedEventArgs e) {
        StartY.Text = Convert.ToString(Convert.ToInt32(StartY.Text) - 1);
    }

    private void IncreaseStopY_OnClick(object sender, RoutedEventArgs e) {
        StopY.Text = Convert.ToString(Convert.ToInt32(StopY.Text) + 1);
    }
    
    private void DecreaseStopY_OnClick(object sender, RoutedEventArgs e) {
        StopY.Text = Convert.ToString(Convert.ToInt32(StopY.Text) - 1);
    }

    private void UpdateData_OnClick(object sender, RoutedEventArgs e) {
        int traceId = Convert.ToInt32(TraceId.Text);
        uint size = Convert.ToUInt32(Points.Text) * 2; // ???

        int startX = Convert.ToInt32(StartX.Text);
        int stopX = Convert.ToInt32(StopX.Text);

        int startY = Convert.ToInt32(StartY.Text);
        int stopY = Convert.ToInt32(StopY.Text);

        if (!traceDataStorage.ContainsKey(traceId)) return;

        float[] traceData = new float[size];
        float dx = (stopX - startX) / (((float)size / 2) - 1);
        for (uint i = 0; i < size / 2; i += 1) {
            traceData[i * 2 + 0] = startX + dx * i;
            traceData[i * 2 + 1] = MathF.Sin(2 * MathF.PI * 1 * i * 2 / size);
        }
        
        Plot.SetData(traceId, traceData);
        traceDataStorage[traceId] = traceData;

        Plot.SetStartStopX(traceId, startX, stopX);
        Plot.SetStartStopY(traceId, startY, stopY);
    }

    private void IncreaseMarkerId_OnClick(object sender, RoutedEventArgs e) {
        MarkerId.Text = Convert.ToString(Convert.ToInt32(MarkerId.Text) + 1);
    }
    
    private void DecreaseMarkerId_OnClick(object sender, RoutedEventArgs e) {
        MarkerId.Text = Convert.ToString(Convert.ToInt32(MarkerId.Text) - 1);
    }

    private void IncreaseMarkerX_OnClick(object sender, RoutedEventArgs e) {
        MarkerX.Text = Convert.ToString(Convert.ToInt32(MarkerX.Text) + 1);
    }

    private void DecreaseMarkerX_OnClick(object sender, RoutedEventArgs e) {
        MarkerX.Text = Convert.ToString(Convert.ToInt32(MarkerX.Text) - 1);
    }

    private void AddMarker_OnClick(object sender, RoutedEventArgs e) {
        int traceId = Convert.ToInt32(TraceId.Text);
        int markerId = Convert.ToInt32(MarkerId.Text);
        
        Plot.AddMarker(markerId);
        
        MarkerX.Text = Plot.GetMarkerX(markerId).ToString();
    }

    private void SelectMarker_OnClick(object sender, RoutedEventArgs e) {
        int traceId = Convert.ToInt32(TraceId.Text);
        int markerId = Convert.ToInt32(MarkerId.Text);
        
        Plot.SelectMarker(markerId);
    }
    
    private void RemoveMarker_OnClick(object sender, RoutedEventArgs e) {
        int traceId = Convert.ToInt32(TraceId.Text);
        int markerId = Convert.ToInt32(MarkerId.Text);
        
        Plot.RemoveMarker(markerId);
    }

    private void SetMarkerX_OnClick(object sender, RoutedEventArgs e) {
        int traceId = Convert.ToInt32(TraceId.Text);
        int markerId = Convert.ToInt32(MarkerId.Text);
        
        float markerX = Convert.ToSingle(MarkerX.Text);
        
        Plot.SetMarkerX(markerId, markerX);
    }
}
