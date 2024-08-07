// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("TextMesh Pro Advanced")]
    [Tooltip("Set margins for Text Mesh Pro.")]
    public class setTextmeshProMargins : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(TextMeshPro))]
        [Tooltip("Textmesh Pro component is required.")]
        public FsmOwnerDefault gameObject;

        [Tooltip("Set Left Margin.")]
        public FsmFloat leftMargin;

        [Tooltip("Set Top Margin.")]
        public FsmFloat topMargin;

        [Tooltip("Set Right Margin.")]
        public FsmFloat rightMargin;

        [Tooltip("Set Bottom Margin.")]
        public FsmFloat bottomMargin;

        [Tooltip("Check this box to preform this action every frame.")]
        public FsmBool everyFrame;

        private Vector4 margin4;

        private GameObject go;
        private TextMeshPro meshproScript;

        public override void Reset()
        {
            gameObject = null;
            bottomMargin = null;
            rightMargin = null;
            leftMargin = null;
            topMargin = null;
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

            margin4.x = leftMargin.Value;
            margin4.y = topMargin.Value;
            margin4.z = rightMargin.Value;
            margin4.w = bottomMargin.Value;
            meshproScript.margin = margin4;
        }
    }
}