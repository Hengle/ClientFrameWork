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

namespace ActionEditor
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Runtime_CreateEffectFrameConfig : TBase
  {
    private string _effectName;
    private Common.Auto.ThriftVector3 _pos;
    private Common.Auto.ThriftVector3 _rot;
    private string _instanceId;
    private int _targetType;

    public string EffectName
    {
      get
      {
        return _effectName;
      }
      set
      {
        __isset.effectName = true;
        this._effectName = value;
      }
    }

    public Common.Auto.ThriftVector3 Pos
    {
      get
      {
        return _pos;
      }
      set
      {
        __isset.pos = true;
        this._pos = value;
      }
    }

    public Common.Auto.ThriftVector3 Rot
    {
      get
      {
        return _rot;
      }
      set
      {
        __isset.rot = true;
        this._rot = value;
      }
    }

    public string InstanceId
    {
      get
      {
        return _instanceId;
      }
      set
      {
        __isset.instanceId = true;
        this._instanceId = value;
      }
    }

    public int TargetType
    {
      get
      {
        return _targetType;
      }
      set
      {
        __isset.targetType = true;
        this._targetType = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool effectName;
      public bool pos;
      public bool rot;
      public bool instanceId;
      public bool targetType;
    }

    public Runtime_CreateEffectFrameConfig() {
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
            if (field.Type == TType.String) {
              EffectName = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.Struct) {
              Pos = new Common.Auto.ThriftVector3();
              Pos.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.Struct) {
              Rot = new Common.Auto.ThriftVector3();
              Rot.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.String) {
              InstanceId = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.I32) {
              TargetType = iprot.ReadI32();
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
      TStruct struc = new TStruct("Runtime_CreateEffectFrameConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (EffectName != null && __isset.effectName) {
        field.Name = "effectName";
        field.Type = TType.String;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(EffectName);
        oprot.WriteFieldEnd();
      }
      if (Pos != null && __isset.pos) {
        field.Name = "pos";
        field.Type = TType.Struct;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        Pos.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Rot != null && __isset.rot) {
        field.Name = "rot";
        field.Type = TType.Struct;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        Rot.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (InstanceId != null && __isset.instanceId) {
        field.Name = "instanceId";
        field.Type = TType.String;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(InstanceId);
        oprot.WriteFieldEnd();
      }
      if (__isset.targetType) {
        field.Name = "targetType";
        field.Type = TType.I32;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(TargetType);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("Runtime_CreateEffectFrameConfig(");
      sb.Append("EffectName: ");
      sb.Append(EffectName);
      sb.Append(",Pos: ");
      sb.Append(Pos== null ? "<null>" : Pos.ToString());
      sb.Append(",Rot: ");
      sb.Append(Rot== null ? "<null>" : Rot.ToString());
      sb.Append(",InstanceId: ");
      sb.Append(InstanceId);
      sb.Append(",TargetType: ");
      sb.Append(TargetType);
      sb.Append(")");
      return sb.ToString();
    }

  }

}