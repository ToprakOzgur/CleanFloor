
using UnityEditor;

[CustomEditor(typeof(ChangeRoomSize))]
public class ChangeRoomSizeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //  DrawDefaultInspector();
        ChangeRoomSize script = (ChangeRoomSize)target;
        script.ChangeSize();


    }
}



