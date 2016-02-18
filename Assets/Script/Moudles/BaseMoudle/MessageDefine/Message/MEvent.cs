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
  public partial class MEvent : TBase
  {
    private short _actionType;
    private OpenChatEvent _openChat;
    private CloseChatEvent _closeChat;
    private ChatInfoEvent _chatMessage;
    private AcceptBidEvent _acceptBid;
    private RefuseBidEvent _refuseBid;
    private CloseSaleEvent _closeSale;
    private BidEvent _bid;

    public short ActionType
    {
      get
      {
        return _actionType;
      }
      set
      {
        __isset.actionType = true;
        this._actionType = value;
      }
    }

    public OpenChatEvent OpenChat
    {
      get
      {
        return _openChat;
      }
      set
      {
        __isset.openChat = true;
        this._openChat = value;
      }
    }

    public CloseChatEvent CloseChat
    {
      get
      {
        return _closeChat;
      }
      set
      {
        __isset.closeChat = true;
        this._closeChat = value;
      }
    }

    public ChatInfoEvent ChatMessage
    {
      get
      {
        return _chatMessage;
      }
      set
      {
        __isset.chatMessage = true;
        this._chatMessage = value;
      }
    }

    public AcceptBidEvent AcceptBid
    {
      get
      {
        return _acceptBid;
      }
      set
      {
        __isset.acceptBid = true;
        this._acceptBid = value;
      }
    }

    public RefuseBidEvent RefuseBid
    {
      get
      {
        return _refuseBid;
      }
      set
      {
        __isset.refuseBid = true;
        this._refuseBid = value;
      }
    }

    public CloseSaleEvent CloseSale
    {
      get
      {
        return _closeSale;
      }
      set
      {
        __isset.closeSale = true;
        this._closeSale = value;
      }
    }

    public BidEvent Bid
    {
      get
      {
        return _bid;
      }
      set
      {
        __isset.bid = true;
        this._bid = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool actionType;
      public bool openChat;
      public bool closeChat;
      public bool chatMessage;
      public bool acceptBid;
      public bool refuseBid;
      public bool closeSale;
      public bool bid;
    }

    public MEvent() {
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
            if (field.Type == TType.I16) {
              ActionType = iprot.ReadI16();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.Struct) {
              OpenChat = new OpenChatEvent();
              OpenChat.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.Struct) {
              CloseChat = new CloseChatEvent();
              CloseChat.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.Struct) {
              ChatMessage = new ChatInfoEvent();
              ChatMessage.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 50:
            if (field.Type == TType.Struct) {
              AcceptBid = new AcceptBidEvent();
              AcceptBid.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.Struct) {
              RefuseBid = new RefuseBidEvent();
              RefuseBid.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 70:
            if (field.Type == TType.Struct) {
              CloseSale = new CloseSaleEvent();
              CloseSale.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 80:
            if (field.Type == TType.Struct) {
              Bid = new BidEvent();
              Bid.Read(iprot);
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
      TStruct struc = new TStruct("MEvent");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.actionType) {
        field.Name = "actionType";
        field.Type = TType.I16;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI16(ActionType);
        oprot.WriteFieldEnd();
      }
      if (OpenChat != null && __isset.openChat) {
        field.Name = "openChat";
        field.Type = TType.Struct;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        OpenChat.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (CloseChat != null && __isset.closeChat) {
        field.Name = "closeChat";
        field.Type = TType.Struct;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        CloseChat.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (ChatMessage != null && __isset.chatMessage) {
        field.Name = "chatMessage";
        field.Type = TType.Struct;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        ChatMessage.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (AcceptBid != null && __isset.acceptBid) {
        field.Name = "acceptBid";
        field.Type = TType.Struct;
        field.ID = 50;
        oprot.WriteFieldBegin(field);
        AcceptBid.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (RefuseBid != null && __isset.refuseBid) {
        field.Name = "refuseBid";
        field.Type = TType.Struct;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        RefuseBid.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (CloseSale != null && __isset.closeSale) {
        field.Name = "closeSale";
        field.Type = TType.Struct;
        field.ID = 70;
        oprot.WriteFieldBegin(field);
        CloseSale.Write(oprot);
        oprot.WriteFieldEnd();
      }
      if (Bid != null && __isset.bid) {
        field.Name = "bid";
        field.Type = TType.Struct;
        field.ID = 80;
        oprot.WriteFieldBegin(field);
        Bid.Write(oprot);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("MEvent(");
      sb.Append("ActionType: ");
      sb.Append(ActionType);
      sb.Append(",OpenChat: ");
      sb.Append(OpenChat== null ? "<null>" : OpenChat.ToString());
      sb.Append(",CloseChat: ");
      sb.Append(CloseChat== null ? "<null>" : CloseChat.ToString());
      sb.Append(",ChatMessage: ");
      sb.Append(ChatMessage== null ? "<null>" : ChatMessage.ToString());
      sb.Append(",AcceptBid: ");
      sb.Append(AcceptBid== null ? "<null>" : AcceptBid.ToString());
      sb.Append(",RefuseBid: ");
      sb.Append(RefuseBid== null ? "<null>" : RefuseBid.ToString());
      sb.Append(",CloseSale: ");
      sb.Append(CloseSale== null ? "<null>" : CloseSale.ToString());
      sb.Append(",Bid: ");
      sb.Append(Bid== null ? "<null>" : Bid.ToString());
      sb.Append(")");
      return sb.ToString();
    }

  }

}
