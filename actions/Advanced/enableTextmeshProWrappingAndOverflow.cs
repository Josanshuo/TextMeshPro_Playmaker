// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("TextMesh Pro Advanced")]
    [Tooltip("Enable and set Text Mesh Pro wrapping and overflow type.")]
    public class enableTextmeshProWrappingAndOverflow : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(TextMeshPro))]
        [Tooltip("Textmesh Pro component is required.")]
        public FsmOwnerDefault gameObject;

        [Tooltip("Check this box to preform this action every frame.")]
        public FsmBool enableTextOverflow;

        [ObjectType(typeof(TextOverflowModes))]
        [TitleAttribute("Wrapping and Overflow Type")]
        [Tooltip("Set wrapping and overflow type for Textmesh Pro.")]
        public FsmEnum wrapping;

        [Tooltip("Enable overflow and wrapping mode.")]
        public FsmBool everyFrame;

        private GameObject go;
        private TextMeshPro meshproScript;

        public override void Reset()
        {
            gameObject = null;
            wrapping = null;
            enableTextOverflow = false;
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

            meshproScript = go.GetComponent<TextMeshPro>();
            if (meshproScript == null)
            {
                Debug.LogError("No textmesh pro component was found on " + go);
                return;
            }

            meshproScript.overflowMode = (TextOverflowModes) wrapping.Value;
            meshproScript.enableWordWrapping = enableTextOverflow.Value;
        }
    }
}