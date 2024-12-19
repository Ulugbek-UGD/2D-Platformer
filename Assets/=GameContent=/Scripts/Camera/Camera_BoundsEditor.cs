using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEditor;

namespace RedwoodTestTask
{
    [CustomEditor(typeof(Camera_Bounds))]
    public class Camera_BoundsEditor : Editor
    {
        private Camera_Bounds cameraBounds;
        private readonly BoxBoundsHandle boundsHandle = new();
        
        //============================================================
        public void OnSceneGUI()
        {
            cameraBounds = (Camera_Bounds)target;
            var handleMatrix = cameraBounds.transform.localToWorldMatrix;
            handleMatrix.SetRow(0, Vector4.Scale(handleMatrix.GetRow(0), new Vector4(1f, 1f, 0f, 1f)));
            handleMatrix.SetRow(1, Vector4.Scale(handleMatrix.GetRow(1), new Vector4(1f, 1f, 0f, 1f)));
            handleMatrix.SetRow(2, new Vector4(0f, 0f, 1f, cameraBounds.transform.position.z));
            
            using (new Handles.DrawingScope(handleMatrix))
            {
                boundsHandle.center = cameraBounds.offset;
                boundsHandle.size = cameraBounds.bound;
                boundsHandle.SetColor(Color.white);
                EditorGUI.BeginChangeCheck();
                boundsHandle.DrawHandle();
                
                var rect = new Rect(boundsHandle.center.x - (boundsHandle.size.x / 2),
                    boundsHandle.center.y - (boundsHandle.size.y / 2), boundsHandle.size.x, boundsHandle.size.y);
                
                Handles.DrawSolidRectangleWithOutline(rect, new Color(1, 1, 1, 0.1f), Color.yellow);
                
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(cameraBounds, $"Modify {ObjectNames.NicifyVariableName(cameraBounds.GetType().Name)}");
                    
                    var oldSize = cameraBounds.bound;
                    cameraBounds.bound = boundsHandle.size;
                    
                    if (cameraBounds.bound != oldSize)
                    {
                        cameraBounds.offset = boundsHandle.center;
                    }
                }
            }
        }
        //============================================================
    }
}