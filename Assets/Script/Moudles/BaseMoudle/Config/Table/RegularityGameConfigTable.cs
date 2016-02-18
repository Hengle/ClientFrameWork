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
  public partial class RegularityGameConfigTable : TBase
  {
    private List<Config.RegularityGameConfig> _regularityConfigMap;

    public List<Config.RegularityGameConfig> RegularityConfigMap
    {
      get
      {
        return _regularityConfigMap;
      }
      set
      {
        __isset.regularityConfigMap = true;
        this._regularityConfigMap = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool regularityConfigMap;
    }

    public RegularityGameConfigTable() {
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
            if (field.Type == TType.List) {
              {
                RegularityConfigMap = new List<Config.RegularityGameConfig>();
                TList _list103 = iprot.ReadListBegin();
                for( int _i104 = 0; _i104 < _list103.Count; ++_i104)
                {
                  Config.RegularityGameConfig _elem105 = new Config.RegularityGameConfig();
                  _elem105 = new Config.RegularityGameConfig();
                  _elem105.Read(iprot);
                  RegularityConfigMap.Add(_elem105);
                }
                iprot.ReadListEnd();
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
      TStruct struc = new TStruct("RegularityGameConfigTable");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (RegularityConfigMap != null && __isset.regularityConfigMap) {
        field.Name = "regularityConfigMap";
        field.Type = TType.List;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.Struct, RegularityConfigMap.Count));
          foreach (Config.RegularityGameConfig _iter106 in RegularityConfigMap)
          {
            _iter106.Write(oprot);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("RegularityGameConfigTable(");
      sb.Append("RegularityConfigMap: ");
      sb.Append(RegularityConfigMap);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
