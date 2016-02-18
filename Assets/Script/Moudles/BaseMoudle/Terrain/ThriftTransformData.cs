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

namespace TerrainEditor
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class ThriftTransformData : TBase
  {
    private Common.Auto.ThriftVector3 _pos;
    private Common.Auto.ThriftVector3 _rot;

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


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool pos;
      public bool rot;
    }

    public ThriftTransformData() {
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
            if (field.Type == TType.Struct) {
              Pos = new Common.Auto.ThriftVector3();
              Pos.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.Struct) {
              Rot = new Common.Auto.ThriftVector3();
              Rot.Read(iprot);
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
      TStruct struc = new TStruct("ThriftTransformData");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Pos != null && __isset.pos) {
        field.Name = "pos";
        field.Type = TType.Struct;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        Pos.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Rot != null && __isset.rot) {
        field.Name = "rot";
        field.Type = TType.Struct;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        Rot.Write(oprot);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("ThriftTransformData(");
      sb.Append("Pos: ");
      sb.Append(Pos== null ? "<null>" : Pos.ToString());
      sb.Append(",Rot: ");
      sb.Append(Rot== null ? "<null>" : Rot.ToString());
      sb.Append(")");
      return sb.ToString();
    }

  }

}
