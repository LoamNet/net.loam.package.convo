using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Loam;

namespace Loam
{
    namespace Convo
    {
        public class ConversationMediator : MonoBehaviour
        {
            [SerializeField] private ConversationManager _conversationManager;

            // Start is called before the first frame update
            void Start()
            {
                Postmaster.Instance.Subscribe<MsgConversationStarted>(StartConversation);
            }

            private void StartConversation(Message msg)
            {
                MsgConversationStarted message = msg as MsgConversationStarted;

                Debug.Log($"Convo started with ID: {message.DialogID}");
                _conversationManager.StartByName(message.DialogID);
            }
        }
    }
}