// (c) Eric Vander Wal, 2017 All rights reserved.
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using TMPro;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("TextMesh Pro UGUI Advanced")]
	[Tooltip("Enable Text Mesh Pro auto size text UGUI container.")]

	public class  enableTextmeshProUGUIAutoSizeTextContainer : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(TextMeshProUGUI))]
		[Tooltip("Textmesh Pro component is required.")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[TitleAttribute("Enable Auto Size Text Container")]
		[Tooltip("Enable Auto Size Text Container.")]
		public FsmBool autoSizeText;

		[Tooltip("Check this box to preform this action every frame.")]
		public FsmBool everyFrame;

        private GameObject go;
        private TextMeshProUGUI meshproScript;

		public override void Reset()
		{
			gameObject = null;
			autoSizeText = false;
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

			meshproScript.autoSizeTextContainer = autoSizeText.Value;
		}

	}
}