using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Loam
{
    namespace Convo
    {
        public class ConvoMessages
        {
            [MessageMetadata(friendlyName: "Convo Started", description: "A conversation has been started", isVisible: true)]
            public class MsgConversationStarted : Message
            {
                public string DialogID; // This isn't all the raw dialog json, this is the name to look that all up
            }

        }
    }
}
