 using UnityEditor;
 using UnityEngine;
 
 [CustomEditor(typeof(VRMenuTrigger)), CanEditMultipleObjects]
 public class PropertyHolderEditor : Editor {
     
     public SerializedProperty 
         LoadingShape,
         LoadingSpeed,
         TriggerItems,
         UsageType,
         NameOfScene,
		 Object,
		 Animator,
         SetFloat,
         FloatValue,
         ToActive;

		 
     
     void OnEnable () {
         // Setup the SerializedProperties
         LoadingShape = serializedObject.FindProperty ("LoadingShape");
         LoadingSpeed = serializedObject.FindProperty("loadingSpeed");
         TriggerItems = serializedObject.FindProperty ("itemsToTrigger");

         UsageType = serializedObject.FindProperty ("usageType");
         NameOfScene = serializedObject.FindProperty ("SceneToActive");
		 Object = serializedObject.FindProperty ("ObjectToActive");
         Animator = serializedObject.FindProperty ("AnimatorToActive"); 
         SetFloat = serializedObject.FindProperty ("AnimatorFloat"); 
         FloatValue = serializedObject.FindProperty ("FloatValue");  
         ToActive = serializedObject.FindProperty ("Active");
     }
     
     public override void OnInspectorGUI() {
         serializedObject.Update ();
         
		 
         VRMenuTrigger.Type useType = (VRMenuTrigger.Type)UsageType.enumValueIndex;

            
            EditorGUILayout.PropertyField( LoadingShape );
            EditorGUILayout.PropertyField( LoadingSpeed );
			EditorGUILayout.PropertyField( UsageType );
					
				switch( useType ) {
				case VRMenuTrigger.Type.Scene:            
					EditorGUILayout.PropertyField( NameOfScene, new GUIContent("SceneName") );
					break;
		
				case VRMenuTrigger.Type.Animate:            
					EditorGUILayout.PropertyField( Animator, new GUIContent("Animator") );
                    EditorGUILayout.PropertyField( SetFloat, new GUIContent("SetFloatName") );
                    EditorGUILayout.PropertyField( FloatValue, new GUIContent("SetFloatValue") );
					break;
		
				case VRMenuTrigger.Type.GameObject:            
					EditorGUILayout.PropertyField( Object, new GUIContent("GameObject") );
                    EditorGUILayout.PropertyField( ToActive, new GUIContent("Active") );
					break;
					
				}
         
         serializedObject.ApplyModifiedProperties ();
     }

	
 }