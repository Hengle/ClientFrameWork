﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Component;
using Common.Tool;
using Framework.Common;
using Framework.Message;
using Framework.Queue;
using UnityEngine;

namespace Framework.Event
{
    public class EventDispatcher:Singleton<EventDispatcher>
    {
        private EventDispatchTool m_Handler;

        public EventDispatcher()
        {
            m_Handler = new EventDispatchTool();
        }
        public void Broadcast(int id, object param)
        {
            Broadcast(new EventElement(id, param));
        }
        public void Broadcast(EventElement eventBody)
        {
            m_Handler.Broadcast(eventBody);
        }
        public void BroadcastAsync(int id, object param)
        {
            BroadcastAsync(new EventElement(id, param));
        }
        public void BroadcastAsync(EventElement eventBody)
        {
            m_Handler.BroadcastAsync(eventBody);
        }
        public void RegistEvent(int id, Action<EventElement> eventCallback)
        {
            m_Handler.RegistEvent(id, eventCallback);
        }
        public void UnregistEvent(int id, Action<EventElement> eventCallback)
        {
            m_Handler.UnregistEvent(id, eventCallback);
        }
        public void UnregistEventAll(int id)
        {
            m_Handler.UnregistEventAll(id);
        }
        public void Update()
        {
            m_Handler.Update();
        }
    }
}