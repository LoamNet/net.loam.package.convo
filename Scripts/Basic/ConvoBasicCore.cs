using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Loam.Convo
{
    /// <summary>
    /// A basic core to start and wrangle a conversation system via a dialog.
    /// This is fine for testing or very simple uses, but the basic system 
    /// is best rewritten if more advanced features are needed.
    ///
    /// Expected external usage:
    /// 
    /// public class SomeSomething : MonoBehaviour
    /// {
    ///     [SerializeField] private ConversationBasicCore _convoCore;
    ///     [SerializeField] private string _dialogName;
    /// 
    ///     private void StartDialogue()
    ///     {
    ///         _convoCore.StartByName(_dialogName);
    ///     }
    /// }
    /// </summary>
    public class ConvoBasicCore : MonoBehaviour
    {
        [Header("Debug References")]
        [SerializeField] private TextAsset _debugConvo;
        [SerializeField] private Button _debugStartButton;

        [Header("Dialog UI")]
        [SerializeField] private ConvoBasicDialogUI _dialog;
        [SerializeField] private bool _logConvoMessages = true;

        [Header("Data")]
        [SerializeField] private List<TextAsset> _conversations;

        // TODO: Hook up to a real messaging system instead of a generic logging thing
        private void ProcessMessage(string input)
        {
            if (_logConvoMessages)
            {
                Debug.Log(input);
            }
        }
        public void Awake()
        {
            _dialog.Hide();
        }

        public void Start()
        {
            _dialog.ConversationSystem.OnEnd += EndConversation;
            _dialog.ConversationSystem.OnMessage += ProcessMessage;

            EndConversation();

            // DEBUG - Lambdas in this style are discouraged.
            _dialog.ConversationSystem.OnEnd += () =>
            {
                if (_debugStartButton != null)
                {
                    _debugStartButton.gameObject.SetActive(true);
                }
            };

            if (_debugStartButton != null)
            {
                _debugStartButton.onClick.AddListener(() =>
                {
                    _debugStartButton.gameObject.SetActive(false);
                    StartConversation(_debugConvo.text);
                });
            }

        }

        public void StartByName(string convoName)
        {
            for (int i = 0; i < _conversations.Count; ++i)
            {
                string name = _conversations[i].name;
                if (convoName.Equals(name))
                {
                    StartConversation(_conversations[i].text);
                    return;
                }
            }
        }

        public void StartConversation(string conversationJSON)
        {
            _dialog.Show(conversationJSON);
        }

        private void EndConversation()
        {
            _dialog.Hide();
        }
    }
}