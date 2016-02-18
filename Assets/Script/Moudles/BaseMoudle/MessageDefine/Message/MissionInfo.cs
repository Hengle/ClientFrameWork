/**
 * Autogenerated by Thrift Compiler (0.9.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace NetWork.Auto
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class MissionInfo : TBase
  {
    private int _missionId;
    private List<MissionStepInfo> _missionStepInfoList;
    private int _counter;

    public int MissionId
    {
      get
      {
        return _missionId;
      }
      set
      {
        __isset.missionId = true;
        this._missionId = value;
      }
    }

    public List<MissionStepInfo> MissionStepInfoList
    {
      get
      {
        return _missionStepInfoList;
      }
      set
      {
        __isset.missionStepInfoList = true;
        this._missionStepInfoList = value;
      }
    }

    public int Counter
    {
      get
      {
        return _counter;
      }
      set
      {
        __isset.counter = true;
        this._counter = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool missionId;
      public bool missionStepInfoList;
      public bool counter;
    }

    public MissionInfo() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 10:
            if (field.Type == TType.I32) {
              MissionId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.List) {
              {
                MissionStepInfoList = new List<MissionStepInfo>();
                TList _list21 = iprot.ReadListBegin();
                for( int _i22 = 0; _i22 < _list21.Count; ++_i22)
                {
                  MissionStepInfo _elem23 = new MissionStepInfo();
                  _elem23 = new MissionStepInfo();
                  _elem23.Read(iprot);
                  MissionStepInfoList.Add(_elem23);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              Counter = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("MissionInfo");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.missionId) {
        field.Name = "missionId";
        field.Type = TType.I32;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(MissionId);
        oprot.WriteFieldEnd();
      }
      if (MissionStepInfoList != null && __isset.missionStepInfoList) {
        field.Name = "missionStepInfoList";
        field.Type = TType.List;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, MissionStepInfoList.Count));
          foreach (MissionStepInfo _iter24 in MissionStepInfoList)
          {
            _iter24.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (__isset.counter) {
        field.Name = "counter";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Counter);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("MissionInfo(");
      sb.Append("MissionId: ");
      sb.Append(MissionId);
      sb.Append(",MissionStepInfoList: ");
      sb.Append(MissionStepInfoList);
      sb.Append(",Counter: ");
      sb.Append(Counter);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
