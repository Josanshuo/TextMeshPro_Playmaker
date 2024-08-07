// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("TextMesh Pro UGUI Shader")]
    [Tooltip("Set Text Mesh Pro UGUI face shaders.")]
    public class setTextmeshProUGUIShaderPropertiesFace : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(TextMeshProUGUI))]
        [Tooltip("Textmesh Pro component is required.")]
        public FsmOwnerDefault gameObject;

        [ActionSection("Color")]
        public FsmColor faceColor;

        [ActionSection("Texture")]
        public FsmTexture texture;

        [ActionSection("Settings")]
        public FsmVector2 textureTiling;

        public FsmVector2 textureOffset;

        [ActionSection("Speed")]
        [HasFloatSlider(-5, 5)]
        public FsmFloat speedX;

        [HasFloatSlider(-5, 5)]
        public FsmFloat speedY;

        [ActionSection("Extra Settings")]
        [HasFloatSlider(0, 1)]
        public FsmFloat softness;

        [HasFloatSlider(-1, 1)]
        public FsmFloat dilate;

        [Tooltip("Check this box to preform this action every frame.")]
        public FsmBool everyFrame;

        private GameObject go;
        private TextMeshProUGUI meshproScript;

        public override void Reset()
        {
            gameObject = null;
            faceColor = null;
            softness = null;
            dilate = null;
            speedX = null;
            speedY = null;
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

            meshproScript = go.GetComponent<TextMeshProUGUI>();
            if (meshproScript == null)
            {
                Debug.LogError("No textmesh pro ugui component was found on " + go);
                return;
            }

            meshproScript.fontSharedMaterial.SetColor("_FaceColor", faceColor.Value);
            meshproScript.fontSharedMaterial.SetFloat("_FaceDilate", dilate.Value);
            meshproScript.fontSharedMaterial.SetFloat("_OutlineSoftness", softness.Value);
            meshproScript.fontSharedMaterial.SetFloat("_FaceUVSpeedX", speedX.Value);
            meshproScript.fontSharedMaterial.SetFloat("_FaceUVSpeedY", speedY.Value);
            meshproScript.fontSharedMaterial.SetTexture("_FaceTex", texture.Value);
            meshproScript.fontSharedMaterial.SetTextureOffset("_FaceTex", textureOffset.Value);
            meshproScript.fontSharedMaterial.SetTextureScale("_FaceTex", textureTiling.Value);
        }
    }
}