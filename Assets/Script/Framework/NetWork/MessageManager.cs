﻿using System;
using UnityEngine;
using System.Collections.Generic;

public class MessageObject
{
    public object   msgValue;
    public int      msgId;

    public MessageObject()
    {
    }
    public MessageObject(int msgId, object mv)
    {
        this.msgValue = mv;
        this.msgId = msgId;
    }
}
public class MessageManager : Singleton<MessageManager>
{
    private Dictionary<int, List<Action<MessageObject>>>        m_MsgCallbackStore;
    private List<MessageObject>                                 m_MsgList;
    private List<MessageObject>                                 m_DelayMsgList;
    private Dictionary<int, List<Action<MessageObject>>>        m_UnRegisterList;
    private List<Action<MessageObject>>                         m_AllMessageListenerList; 
    private List<Action<MessageObject>>                         m_AllRemovingMessageListenorList; 
    private bool                                                m_bIsProcessingMsgList;

    public void Initialize()
    {
        m_MsgCallbackStore      = new Dictionary<int, List<Action<MessageObject>>>();
        m_MsgList               = new List<MessageObject>();
        m_DelayMsgList          = new List<MessageObject>();
        m_UnRegisterList        = new Dictionary<int, List<Action<MessageObject>>>();
        m_AllMessageListenerList = new List<Action<MessageObject>>();
        m_AllRemovingMessageListenorList = new List<Action<MessageObject>>();
        m_bIsProcessingMsgList  = false;

        //register message
        MessageDefine.Instance.RegisterMessage();
    }
    public void Update()
    {
        lock (this)
        {
            if (m_MsgList.Count == 0)
            {
                foreach (MessageObject eb in m_DelayMsgList)
                {
                    m_MsgList.Add(eb);
                }
                m_DelayMsgList.Clear();
                return;
            }
            m_bIsProcessingMsgList = true;

            //process msglist message
            foreach (MessageObject elem in m_MsgList)
            {
                try
                {
                    for (int i = 0; i < m_AllMessageListenerList.Count; ++i)
                    {
                        m_AllMessageListenerList[i](elem);
                    }

                    if (m_MsgCallbackStore.ContainsKey(elem.msgId))
                    {
                        foreach (Action<MessageObject> fun in m_MsgCallbackStore[elem.msgId])
                        {
                            if (null != fun)
                            {
                                fun(elem);
                            }
                            else
                            {
                                //log error                        
                                Debuger.LogError("null of call back fun" + elem.msgId.ToString());
                            }
                        }
                    }
                    else
                    {
                        //empty msg list                    
                        Debuger.LogError("empty msg list  " + elem.msgId.ToString());
                    }
                }
                catch (Exception e)
                {
                    //log error
                    Debuger.LogError("Wrong msg callback" + elem.msgId.ToString() + "error log: " + e.Message);
                }
            }
            m_MsgList.Clear();
            m_bIsProcessingMsgList = false;
            DoUnregister();
        }
    }
    public void AddToMessageQueue(MessageObject msgBody)
    {
        lock (this)
        {
            //process msg
            try
            {
                if (!m_MsgCallbackStore.ContainsKey(msgBody.msgId))
                {
                    return;
                }
                if (m_bIsProcessingMsgList)
                {
                    m_DelayMsgList.Add(msgBody);
                }
                else
                {
                    m_MsgList.Add(msgBody);
                }
            }
            catch
            {
                Debuger.LogError("Don't exit msg id " + msgBody.msgId.ToString());
            }
        }
    }
    public void RegisterAllMessageListener(Action<MessageObject> msgCallBack)
    {
        for (int i = 0; i < m_AllMessageListenerList.Count; ++i)
        {
            if (msgCallBack == m_AllMessageListenerList[i])
            {
                return;
            }
        }
        m_AllMessageListenerList.Add(msgCallBack);
    }
    public void UnRegisterAllMesssageListener(Action<MessageObject> msgCallBack)
    {
        if (!m_bIsProcessingMsgList)
        {
            m_AllMessageListenerList.Remove(msgCallBack);
        }
        else
        {
            for (int i = 0; i < m_AllMessageListenerList.Count; ++i)
            {
                if (msgCallBack == m_AllMessageListenerList[i])
                {
                    m_AllRemovingMessageListenorList.Add(m_AllMessageListenerList[i]);
                    return;
                }
            }
        }
    }
    public void RegistMessage(int msgId, Action<MessageObject> msgCallback)
    {
        if (null == msgCallback)
        {
            Debuger.LogError("msg call back can't be null !!!" + msgId.ToString());
        }
        if (!m_MsgCallbackStore.ContainsKey(msgId))
        {
            m_MsgCallbackStore.Add(msgId, new List<Action<MessageObject>>());
            m_MsgCallbackStore[msgId].Add(msgCallback);
        }
        else
        {
            for (int i = 0; i < m_MsgCallbackStore[msgId].Count; ++i)
            {
                if (m_MsgCallbackStore[msgId][i] == msgCallback)
                {
                    return;
                }
            }
            m_MsgCallbackStore[msgId].Add(msgCallback);
        }
    }
    public void UnregistMessage(int msgId, Action<MessageObject> msgCallback)
    {
        if (m_MsgCallbackStore.ContainsKey(msgId))
        {
            if (!m_bIsProcessingMsgList)
            {
                m_MsgCallbackStore[msgId].Remove(msgCallback);
            }
            else
            {
                bool hasKey = false;
                foreach (var elem in m_UnRegisterList)
                {
                    if (elem.Key == msgId)
                    {
                        hasKey = true;
                        var tmpList = elem.Value;
                        for (int i = 0; i < tmpList.Count; ++i)
                        {
                            if (tmpList[i] == msgCallback)
                            {
                                return;
                            }
                        }
                    }
                }
                // add to remove store
                if (!hasKey)
                {
                    m_UnRegisterList.Add(msgId, new List<Action<MessageObject>>());
                }
                m_UnRegisterList[msgId].Add(msgCallback);
            }
        }
    }
    public void UnregistMessageAll(int msgId)
    {
        if (m_MsgCallbackStore.ContainsKey(msgId))
        {
            m_MsgCallbackStore[msgId].Clear();
        }
    }
    private void DoUnregister()
    {
        if (m_UnRegisterList.Count != 0)
        {
            foreach (var elem in m_UnRegisterList)
            {
                var tmpList = elem.Value;
                var msgList = m_MsgCallbackStore[elem.Key];

                for (int i = 0; i < tmpList.Count; ++i)
                {
                    msgList.Remove(tmpList[i]);
                }
            }
            m_UnRegisterList.Clear();
        }
        if (m_AllRemovingMessageListenorList.Count != 0)
        {
            for (int i = 0; i < m_AllRemovingMessageListenorList.Count; ++i)
            {
                m_AllMessageListenerList.Remove(m_AllRemovingMessageListenorList[i]);
            }
            m_AllRemovingMessageListenorList.Clear();
        }
    }
}
