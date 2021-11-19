using UnityEngine;

public class ___FpS : MonoBehaviour
{
    string FpS;
    float  FPS, DeltaTime = 0.0f;
    LFC    LFCO;

    private void Start()
    {
        Application.targetFrameRate = 3000;
        QualitySettings.vSyncCount = 0; // V Sync OFF!

        LFCO = FindObjectOfType<LFC>();
    }

    void Update() { DeltaTime += (Time.unscaledDeltaTime - DeltaTime) * 0.1f; }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 5 / 100;
        style.normal.textColor = Color.yellow; new Color(1, 1, 1, 1);
        float msec = DeltaTime * 1000.0f;
        float fps = 1.0f / DeltaTime;
        FPS += fps > FPS ? (fps-FPS)*.5f : (FPS-fps)*-.001f;
        FpS = "Lite Frustrum Culling\nRendered objects "+ LFCO.VisibleObjects + " out of "+ LFCO.TotalObjects + "\nFPS: "+(int)FPS+" ("+msec+") ms";
        GUI.Label(rect, FpS, style);
    }
}

