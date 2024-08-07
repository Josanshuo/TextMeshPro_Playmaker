// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("TextMesh Pro UGUI Advanced")]
    [Tooltip("Set Text Mesh Pro Texture Mapping Options UGUI.")]
    public class setTextmeshProUGUIUvMappingOptions : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(TextMeshProUGUI))]
        [Tooltip("Textmesh Pro component is required.")]
        public FsmOwnerDefault gameObject;


        [ObjectType(typeof(TextureMappingOptions))]
        [TitleAttribute("Mapping Options Horizontal")]
        [Tooltip("Texture Mapping Options Horizontal")]
        public FsmEnum UvMappingOne;

        [ObjectType(typeof(TextureMappingOptions))]
        [TitleAttribute("Mapping Options Vertical")]
        [Tooltip("Texture Mapping Options Vertical")]
        public FsmEnum UvMappingTwo;

        [Tooltip("Enable overflow and wrapping mode.")]
        public FsmBool everyFrame;

        private GameObject go;
        private TextMeshProUGUI meshproScript;

        public override void Reset()
        {
            gameObject = null;
            UvMappingOne = null;
            UvMappingTwo = null;
            everyFrame = false;
        }

        public override void OnEnter()
        {
            DoMeshChange();

            if (!everyFrame.Value)
            {
                Finish();
            }
        }

        public override void OnUpdate()
        {
            DoMeshChange();
        }

        void DoMeshChange()
        {
            go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {
                return;
            }

            meshproScript = go.GetComponent<TextMeshProUGUI>();
            if (meshproScript == null)
            {
                Debug.LogError("No textmesh pro ugui component was found on " + go);
                return;
            }

            meshproScript.horizontalMapping = (TextureMappingOptions) UvMappingOne.Value;
            meshproScript.verticalMapping = (TextureMappingOptions) UvMappingTwo.Value;
        }
    }
}