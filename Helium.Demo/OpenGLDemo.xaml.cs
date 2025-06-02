using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Helium.Controls.Plot;
using Helium.Controls.Plot.Enums;
using Helium.Controls.Window;

namespace HeliumDemo;

public enum MarkerFunctions {
    Default,
    Max,
    Min
}

public partial class OpenGLDemo : HeWindow {
    private Dictionary<int, float[]> traceDataStorage = new Dictionary<int, float[]>();

    private bool isReversedState = false;

    private Task drawStressTestTask;
    private CancellationTokenSource drawStressTestTokenSource;

    public OpenGLDemo() {
        InitializeComponent();

        UnitsBoxX.ItemsSource = Enum.GetNames(typeof(Units));
        UnitsBoxY.ItemsSource = Enum.GetNames(typeof(Units));
        MarkerFunc.ItemsSource = Enum.GetNames(typeof(MarkerFunctions));
        
        Plot.MarkerXUpdated += (windowId, traceId, markerId, value) => Console.WriteLine($"TraceID = {traceId}; MarkerID = {markerId}; X = {value}");
        Plot.MarkerYUpdated += (windowId, traceId, markerId, value) => Console.WriteLine($"TraceID = {traceId}; MarkerID = {markerId}; Y = {value}");

        Plot.SelectedTraceUpdated += (windowId, traceId) => Console.WriteLine($"Selected trace id = {traceId} on window = {windowId}");
        Plot.SelectedMarkerUpdated += (windowId, traceId, markerId) => Console.WriteLine($"Selected marker id = {markerId} on trace = {traceId} on window = {windowId}");
        
        DrawStressTest_OnClick(null, null);
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
    
    private void SetUnitsX_OnClick(object sender, RoutedEventArgs e) {
        int traceId = Convert.ToInt32(TraceId.Text);
        int unitsId = UnitsBoxX.SelectedIndex;

        Plot.SetUnitsX(traceId, unitsId);
    }
    
    private void SetUnitsY_OnClick(object sender, RoutedEventArgs e) {
        int traceId = Convert.ToInt32(TraceId.Text);
        int unitsId = UnitsBoxY.SelectedIndex;

        Plot.SetUnitsY(traceId, unitsId);
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

        float startX = Convert.ToSingle(StartX.Text);
        float stopX = Convert.ToSingle(StopX.Text);

        float startY = Convert.ToSingle(StartY.Text);
        float stopY = Convert.ToSingle(StopY.Text);

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
    
    private void UpdateCamera_OnClick(object sender, RoutedEventArgs e) {
        int traceId = Convert.ToInt32(TraceId.Text);

        float startX = Convert.ToSingle(StartX.Text);
        float stopX = Convert.ToSingle(StopX.Text);

        float startY = Convert.ToSingle(StartY.Text);
        float stopY = Convert.ToSingle(StopY.Text);
        
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

        if (ApplyForTraceId.IsChecked.GetValueOrDefault()) {
            Plot.AddMarker(traceId, markerId);
        } else {
            Plot.AddMarker(markerId);
        }
    }

    private void SelectMarker_OnClick(object sender, RoutedEventArgs e) {
        int traceId = Convert.ToInt32(TraceId.Text);
        int markerId = Convert.ToInt32(MarkerId.Text);
        
        if (ApplyForTraceId.IsChecked.GetValueOrDefault()) {
            Plot.SelectMarker(traceId, markerId);
        } else {
            Plot.SelectMarker(markerId);
        }
    }
    
    private void RemoveMarker_OnClick(object sender, RoutedEventArgs e) {
        int traceId = Convert.ToInt32(TraceId.Text);
        int markerId = Convert.ToInt32(MarkerId.Text);
        
        if (ApplyForTraceId.IsChecked.GetValueOrDefault()) {
            Plot.RemoveMarker(traceId, markerId);
        } else {
            Plot.RemoveMarker(markerId);
        }
    }

    private void SetMarkerX_OnClick(object sender, RoutedEventArgs e) {
        int traceId = Convert.ToInt32(TraceId.Text);
        int markerId = Convert.ToInt32(MarkerId.Text);
        
        float markerX = Convert.ToSingle(MarkerX.Text);
        
        if (ApplyForTraceId.IsChecked.GetValueOrDefault()) {
            Plot.SetMarkerX(traceId, markerId, markerX);
        } else {
            Plot.SetMarkerX(markerId, markerX);
        }
    }

    private void SetMarkerFunc_OnClick(object sender, RoutedEventArgs e) {
        int traceId = Convert.ToInt32(TraceId.Text);
        int markerId = Convert.ToInt32(MarkerId.Text);
        
        int markerFunc = Convert.ToInt32(MarkerFunc.SelectedIndex);
        
        if (ApplyForTraceId.IsChecked.GetValueOrDefault()) {
            Plot.SetMarkerFunction(traceId, markerId, markerFunc);
        } else {
            Plot.SetMarkerFunction(markerId, markerFunc);
        }
    }

    private void AutoScaleTrace_OnClick(object sender, RoutedEventArgs e) {
        int traceId = Convert.ToInt32(TraceId.Text);
        
        Plot.AutoScale(traceId);
    }

    private void OpenExternalWindow_OnClick(object sender, RoutedEventArgs e) {
        GlExternalWindow window = new GlExternalWindow();
        window.Show();
    }

    private Timer stressTestTimer;
    private int counter;

    private void LeakStressTest_OnClick(object sender, RoutedEventArgs e) {
        counter = 20;
        stressTestTimer = new Timer(CreateWindow, null, 0, 200);
    }

    private void CreateWindow(object? obj) {
        Application.Current.Dispatcher.Invoke(() => {
            GlExternalWindow window = new GlExternalWindow(true);
            window.Show();
        });

        counter--;

        if (counter == 0) stressTestTimer.Dispose();
    }

    private void ReverseCheckBox_OnClick(object sender, RoutedEventArgs e) {
        Plot.ReverseDraw(ReverseCheckBox.IsChecked.Value);
    }

    private void DrawStressTest_OnClick(object sender, RoutedEventArgs e) {
        int points = Convert.ToInt32(Points.Text); 
        
        int startX = Convert.ToInt32(StartX.Text);
        int stopX = Convert.ToInt32(StopX.Text);
        
        int startY = Convert.ToInt32(StartY.Text);
        int stopY = Convert.ToInt32(StopY.Text);

        for (int traceId = 0; traceId < 8; traceId++) {
            traceDataStorage[traceId] = Plot.AddTrace(traceId, points, startX, startY, stopX, stopY);
            
            float[] traceData = traceDataStorage[traceId];
            float dx = (stopX - startX) / ((float)points - 1);
            for (uint i = 0; i < points; i += 1) {
                traceData[i * 2 + 0] = startX + dx * i;
                traceData[i * 2 + 1] = MathF.Sin(2 * MathF.PI * 1 * (i + traceId * points * 0.05f) / points) - 35;
            }
            
            Plot.SelectTrace(traceId);
            Plot.SetUnitsX(traceId, (int)Units.Frequency);
            Plot.SetUnitsY(traceId, (int)Units.PowerdB);
            Plot.SetStartStopX(traceId, -1, 3);
            Plot.SetStartStopY(traceId, -36, -33);

            for (int markerId = 0; markerId < 3; markerId++) {
                Plot.AddMarker(markerId);
                Plot.SelectMarker(markerId);
                Plot.SetMarkerFunction(markerId, markerId);
            }
        }

        drawStressTestTokenSource = new CancellationTokenSource();
        drawStressTestTask = Task.Run(() => {
            while (!drawStressTestTokenSource.Token.IsCancellationRequested) {
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

    private void ResetDraw_OnClick(object sender, RoutedEventArgs e) {
        drawStressTestTokenSource.Cancel();
        drawStressTestTask.Wait();
        
        for (int traceId = 0; traceId < 8; traceId++) {
            traceDataStorage.Clear();
            
            Plot.RemoveTrace(traceId);
        }
    }

    private void TrackCurrentMarker_OnClick(object sender, RoutedEventArgs e) {
        
    }
}
