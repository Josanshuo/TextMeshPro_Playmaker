// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("TextMesh Pro Shader")]
    [Tooltip("Set Text Mesh Pro bump map shaders.")]
    public class setTextmeshProShaderPropertiesBumpmap : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(TextMeshPro))]
        [Tooltip("Textmesh Pro component is required.")]
        public FsmOwnerDefault gameObject;

        [ActionSection("Texture")]
        public FsmTexture texture;

        [HasFloatSlider(0, 1)]
        public FsmFloat face;

        [HasFloatSlider(0, 1)]
        public FsmFloat outline;

        [Tooltip("Check this box to preform this action every frame.")]
        public FsmBool everyFrame;

        private GameObject go;
        private TextMeshPro meshproScript;

        public override void Reset()
        {
            gameObject = null;
            face = null;
            outline = null;
            texture = null;
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

            meshproScript.fontSharedMaterial.SetFloat("_BumpFace", face.Value);
            meshproScript.fontSharedMaterial.SetFloat("_BumpOutline", outline.Value);
            meshproScript.fontSharedMaterial.SetTexture("_BumpMap", texture.Value);
        }
    }
}