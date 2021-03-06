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
  public partial class BidEvent : TBase
  {
    private long _chatId;
    private int _offerId;

    public long ChatId
    {
      get
      {
        return _chatId;
      }
      set
      {
        __isset.chatId = true;
        this._chatId = value;
      }
    }

    public int OfferId
    {
      get
      {
        return _offerId;
      }
      set
      {
        __isset.offerId = true;
        this._offerId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool chatId;
      public bool offerId;
    }

    public BidEvent() {
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
            if (field.Type == TType.I64) {
              ChatId = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.I32) {
              OfferId = iprot.ReadI32();
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
      TStruct struc = new TStruct("BidEvent");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.chatId) {
        field.Name = "chatId";
        field.Type = TType.I64;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(ChatId);
        oprot.WriteFieldEnd();
      }
      if (__isset.offerId) {
        field.Name = "offerId";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(OfferId);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("BidEvent(");
      sb.Append("ChatId: ");
      sb.Append(ChatId);
      sb.Append(",OfferId: ");
      sb.Append(OfferId);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
