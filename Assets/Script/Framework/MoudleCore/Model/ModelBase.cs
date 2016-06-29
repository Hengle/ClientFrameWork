﻿using System;
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using Framework.Event;
using Framework.Tick;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

public class ModelBase
{
    protected EventDispatchTool             m_EventHandler;
    private bool                            m_bIsAutoNoticDataModify;
    private bool                            m_bIsNoticeRightnow;
    private Dictionary<int, Action<object>> m_DataOperationHandlerList;
    private Dictionary<int, object>         m_IdToDataMap;
    private List<int>                       m_ModifyList;
    private HashSet<object>                 m_PermissionList;
     
    #region public interface
    public ModelBase()
    {
        m_EventHandler = new EventDispatchTool();
        m_bIsAutoNoticDataModify = true;
        m_bIsNoticeRightnow = false;
        m_DataOperationHandlerList = new Dictionary<int, Action<object>>();
        m_IdToDataMap = new Dictionary<int, object>();
        m_ModifyList = new List<int>();
        m_PermissionList = new HashSet<object>();

        CustomTickTask.Instance.RegisterToUpdateList(Update);
        OnCreate();
    }
    public void RegisterEvent(int eventId, Action<EventElement> callBack)
    {
        m_EventHandler.RegistEvent(eventId,callBack);
        CustomTickTask.Instance.RegisterToUpdateList(m_EventHandler.Update);
    }
    public void UnregisterEvent(int eventId, Action<EventElement> callBack)
    {
        m_EventHandler.UnregistEvent(eventId, callBack);
        if (m_EventHandler.GetCallbackListCount() == 0)
        {
            CustomTickTask.Instance.UnRegisterFromUpdateList(m_EventHandler.Update);
        }
    }
    public void DataOperation(object key,int dataId, object param)
    {
        try
        {
            if (!m_PermissionList.Contains(key))
            {
                Debug.LogError("the handler do not have permission to modify data " + key.GetType().Name);
                return;
            }
            Action<object> handler = null;
            m_DataOperationHandlerList.TryGetValue(dataId, out handler);
            if (null == handler)
            {
                Debug.LogError("can't load data operation handler " + dataId);
                return;
            }
            handler(param);
            if (m_bIsAutoNoticDataModify)
            {
                if (m_bIsNoticeRightnow)
                {
                    BroadcastEvent(dataId, m_IdToDataMap[dataId]);
                }
                else
                {
                    // add to modify list & notic at next frame
                    if (!m_ModifyList.Contains(dataId))
                    {
                        m_ModifyList.Add(dataId);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error on exec data operation " + dataId);
            Debug.LogException(e);
        }
    }
    public void RegisterPermisionKey(object key)
    {
        m_PermissionList.Add(key);
    }
    public void UnRegisterPermissionKey(object key)
    {
        m_PermissionList.Remove(key);
    }
    #endregion

    #region internal function
    private void Update()
    {
        if (m_ModifyList.Count == 0)
        {
            return;
        }
        var list = m_ModifyList;
        m_ModifyList = new List<int>();
        for (int i = 0; i < list.Count; ++i)
        {
            int id = list[i];
            object param = m_IdToDataMap[id];
            BroadcastEvent(id,param);
        }
    }
    #endregion

    #region system function
    protected void BroadcastEvent(int eventId, object param)
    {
        m_EventHandler.Broadcast(eventId,param);
    }
    protected void BroidcastEventAsync(int eventId, object param)
    {
        m_EventHandler.BroadcastAsync(eventId, param);
    }
    protected void SetIsAutoNotifyDateModify(bool isAutoNodity)
    {
        m_bIsAutoNoticDataModify = isAutoNodity;
    }
    protected void SetIsNoticDataModifyRightnow(bool isNoticRightnow)
    {
        m_bIsNoticeRightnow = isNoticRightnow;
    }
    protected void RegisterDataHandler(int id, Action<object> handler)
    {
        if (m_DataOperationHandlerList.ContainsKey(id))
        {
            m_DataOperationHandlerList[id] = handler;
        }
        else
        {
            m_DataOperationHandlerList.Add(id,handler);
        }
    }
    protected void RegisterIdToData(int id, object data)
    {
        if (m_IdToDataMap.ContainsKey(id))
        {
            m_IdToDataMap[id] = data;
        }
        else
        {
            m_IdToDataMap.Add(id, data);
        }
    }
    #endregion

    #region function for override
    protected virtual void OnCreate()
    {
        // do sth
    }
    #endregion
}