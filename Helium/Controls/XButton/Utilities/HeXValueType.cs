namespace Helium.Controls.XButton.Utilities;

public enum HeXValueType {
    [Exp]
    NONE,
    
    [Units("ГГц", "МГц", "кГц")]
    [Exp(1e9, 1e6, 1e3)]
    FREQUENCY,
    
    [Exp(0.05, 0.1, 0.2, 0.5)]
    DBM
}
