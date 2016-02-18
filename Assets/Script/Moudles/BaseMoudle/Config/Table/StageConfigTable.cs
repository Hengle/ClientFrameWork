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

namespace Config.Table
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class StageConfigTable : TBase
  {
    private Dictionary<int, Config.StageConfig> _stageConfigMap;

    public Dictionary<int, Config.StageConfig> StageConfigMap
    {
      get
      {
        return _stageConfigMap;
      }
      set
      {
        __isset.stageConfigMap = true;
        this._stageConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool stageConfigMap;
    }

    public StageConfigTable() {
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
          case 1:
            if (field.Type == TType.Map) {
              {
                StageConfigMap = new Dictionary<int, Config.StageConfig>();
                TMap _map50 = iprot.ReadMapBegin();
                for( int _i51 = 0; _i51 < _map50.Count; ++_i51)
                {
                  int _key52;
                  Config.StageConfig _val53;
                  _key52 = iprot.ReadI32();
                  _val53 = new Config.StageConfig();
                  _val53.Read(iprot);
                  StageConfigMap[_key52] = _val53;
                }
                iprot.ReadMapEnd();
              }
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
      TStruct struc = new TStruct("StageConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (StageConfigMap != null && __isset.stageConfigMap) {
        field.Name = "stageConfigMap";
        field.Type = TType.Map;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.Struct, StageConfigMap.Count));
          foreach (int _iter54 in StageConfigMap.Keys)
          {
            oprot.WriteI32(_iter54);
            StageConfigMap[_iter54].Write(oprot);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("StageConfigTable(");
      sb.Append("StageConfigMap: ");
      sb.Append(StageConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}