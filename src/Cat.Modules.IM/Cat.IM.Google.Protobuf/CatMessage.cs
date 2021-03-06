// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: CatMessage.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Cat.IM.Google.Protobuf {

  /// <summary>Holder for reflection information generated from CatMessage.proto</summary>
  public static partial class CatMessageReflection {

    #region Descriptor
    /// <summary>File descriptor for CatMessage.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static CatMessageReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChBDYXRNZXNzYWdlLnByb3RvEgNDYXQiRAoEQmFzZRIKCgJJZBgBIAEoCRIO",
            "CgZTZW5kZXIYAiABKAkSEAoIUmVjZWl2ZXIYAyABKAkSDgoGU2VuZE9uGAQg",
            "ASgJIhYKBUxvZ2luEg0KBVRva2VuGAEgASgJIi0KBENoYXQSFwoESW5mbxgB",
            "IAEoCzIJLkNhdC5CYXNlEgwKBEJvZHkYAiABKAkiigEKCkNhdE1lc3NhZ2US",
            "HgoEVHlwZRgBIAEoDjIQLkNhdC5NZXNzYWdlVHlwZRIZCgRCYXNlGAIgASgL",
            "MgkuQ2F0LkJhc2VIABIbCgVMb2dpbhgDIAEoCzIKLkNhdC5Mb2dpbkgAEhkK",
            "BENoYXQYBCABKAsyCS5DYXQuQ2hhdEgAQgkKB01lc3NhZ2UqUAoLTWVzc2Fn",
            "ZVR5cGUSCQoFTE9HSU4QABIICgRQSU5HEAESCAoEQ0hBVBACEgcKA0lNRxAD",
            "EggKBEZJTEUQBBIPCgpBRERfRlJJRU5EEOkHQhmqAhZDYXQuSU0uR29vZ2xl",
            "LlByb3RvYnVmYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Cat.IM.Google.Protobuf.MessageType), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Cat.IM.Google.Protobuf.Base), global::Cat.IM.Google.Protobuf.Base.Parser, new[]{ "Id", "Sender", "Receiver", "SendOn" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Cat.IM.Google.Protobuf.Login), global::Cat.IM.Google.Protobuf.Login.Parser, new[]{ "Token" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Cat.IM.Google.Protobuf.Chat), global::Cat.IM.Google.Protobuf.Chat.Parser, new[]{ "Info", "Body" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Cat.IM.Google.Protobuf.CatMessage), global::Cat.IM.Google.Protobuf.CatMessage.Parser, new[]{ "Type", "Base", "Login", "Chat" }, new[]{ "Message" }, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum MessageType {
    [pbr::OriginalName("LOGIN")] Login = 0,
    [pbr::OriginalName("PING")] Ping = 1,
    [pbr::OriginalName("CHAT")] Chat = 2,
    [pbr::OriginalName("IMG")] Img = 3,
    [pbr::OriginalName("FILE")] File = 4,
    [pbr::OriginalName("ADD_FRIEND")] AddFriend = 1001,
  }

  #endregion

  #region Messages
  public sealed partial class Base : pb::IMessage<Base> {
    private static readonly pb::MessageParser<Base> _parser = new pb::MessageParser<Base>(() => new Base());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Base> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Cat.IM.Google.Protobuf.CatMessageReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Base() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Base(Base other) : this() {
      id_ = other.id_;
      sender_ = other.sender_;
      receiver_ = other.receiver_;
      sendOn_ = other.sendOn_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Base Clone() {
      return new Base(this);
    }

    /// <summary>Field number for the "Id" field.</summary>
    public const int IdFieldNumber = 1;
    private string id_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Id {
      get { return id_; }
      set {
        id_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Sender" field.</summary>
    public const int SenderFieldNumber = 2;
    private string sender_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Sender {
      get { return sender_; }
      set {
        sender_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Receiver" field.</summary>
    public const int ReceiverFieldNumber = 3;
    private string receiver_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Receiver {
      get { return receiver_; }
      set {
        receiver_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "SendOn" field.</summary>
    public const int SendOnFieldNumber = 4;
    private string sendOn_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string SendOn {
      get { return sendOn_; }
      set {
        sendOn_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Base);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Base other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (Sender != other.Sender) return false;
      if (Receiver != other.Receiver) return false;
      if (SendOn != other.SendOn) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id.Length != 0) hash ^= Id.GetHashCode();
      if (Sender.Length != 0) hash ^= Sender.GetHashCode();
      if (Receiver.Length != 0) hash ^= Receiver.GetHashCode();
      if (SendOn.Length != 0) hash ^= SendOn.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Id.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Id);
      }
      if (Sender.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Sender);
      }
      if (Receiver.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Receiver);
      }
      if (SendOn.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(SendOn);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Id);
      }
      if (Sender.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Sender);
      }
      if (Receiver.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Receiver);
      }
      if (SendOn.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(SendOn);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Base other) {
      if (other == null) {
        return;
      }
      if (other.Id.Length != 0) {
        Id = other.Id;
      }
      if (other.Sender.Length != 0) {
        Sender = other.Sender;
      }
      if (other.Receiver.Length != 0) {
        Receiver = other.Receiver;
      }
      if (other.SendOn.Length != 0) {
        SendOn = other.SendOn;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Id = input.ReadString();
            break;
          }
          case 18: {
            Sender = input.ReadString();
            break;
          }
          case 26: {
            Receiver = input.ReadString();
            break;
          }
          case 34: {
            SendOn = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class Login : pb::IMessage<Login> {
    private static readonly pb::MessageParser<Login> _parser = new pb::MessageParser<Login>(() => new Login());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Login> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Cat.IM.Google.Protobuf.CatMessageReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Login() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Login(Login other) : this() {
      token_ = other.token_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Login Clone() {
      return new Login(this);
    }

    /// <summary>Field number for the "Token" field.</summary>
    public const int TokenFieldNumber = 1;
    private string token_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Token {
      get { return token_; }
      set {
        token_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Login);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Login other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Token != other.Token) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Token.Length != 0) hash ^= Token.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Token.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Token);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Token.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Token);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Login other) {
      if (other == null) {
        return;
      }
      if (other.Token.Length != 0) {
        Token = other.Token;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Token = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class Chat : pb::IMessage<Chat> {
    private static readonly pb::MessageParser<Chat> _parser = new pb::MessageParser<Chat>(() => new Chat());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Chat> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Cat.IM.Google.Protobuf.CatMessageReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Chat() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Chat(Chat other) : this() {
      info_ = other.info_ != null ? other.info_.Clone() : null;
      body_ = other.body_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Chat Clone() {
      return new Chat(this);
    }

    /// <summary>Field number for the "Info" field.</summary>
    public const int InfoFieldNumber = 1;
    private global::Cat.IM.Google.Protobuf.Base info_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Cat.IM.Google.Protobuf.Base Info {
      get { return info_; }
      set {
        info_ = value;
      }
    }

    /// <summary>Field number for the "Body" field.</summary>
    public const int BodyFieldNumber = 2;
    private string body_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Body {
      get { return body_; }
      set {
        body_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Chat);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Chat other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Info, other.Info)) return false;
      if (Body != other.Body) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (info_ != null) hash ^= Info.GetHashCode();
      if (Body.Length != 0) hash ^= Body.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (info_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Info);
      }
      if (Body.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Body);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (info_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Info);
      }
      if (Body.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Body);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Chat other) {
      if (other == null) {
        return;
      }
      if (other.info_ != null) {
        if (info_ == null) {
          info_ = new global::Cat.IM.Google.Protobuf.Base();
        }
        Info.MergeFrom(other.Info);
      }
      if (other.Body.Length != 0) {
        Body = other.Body;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (info_ == null) {
              info_ = new global::Cat.IM.Google.Protobuf.Base();
            }
            input.ReadMessage(info_);
            break;
          }
          case 18: {
            Body = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class CatMessage : pb::IMessage<CatMessage> {
    private static readonly pb::MessageParser<CatMessage> _parser = new pb::MessageParser<CatMessage>(() => new CatMessage());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CatMessage> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Cat.IM.Google.Protobuf.CatMessageReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CatMessage() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CatMessage(CatMessage other) : this() {
      type_ = other.type_;
      switch (other.MessageCase) {
        case MessageOneofCase.Base:
          Base = other.Base.Clone();
          break;
        case MessageOneofCase.Login:
          Login = other.Login.Clone();
          break;
        case MessageOneofCase.Chat:
          Chat = other.Chat.Clone();
          break;
      }

      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CatMessage Clone() {
      return new CatMessage(this);
    }

    /// <summary>Field number for the "Type" field.</summary>
    public const int TypeFieldNumber = 1;
    private global::Cat.IM.Google.Protobuf.MessageType type_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Cat.IM.Google.Protobuf.MessageType Type {
      get { return type_; }
      set {
        type_ = value;
      }
    }

    /// <summary>Field number for the "Base" field.</summary>
    public const int BaseFieldNumber = 2;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Cat.IM.Google.Protobuf.Base Base {
      get { return messageCase_ == MessageOneofCase.Base ? (global::Cat.IM.Google.Protobuf.Base) message_ : null; }
      set {
        message_ = value;
        messageCase_ = value == null ? MessageOneofCase.None : MessageOneofCase.Base;
      }
    }

    /// <summary>Field number for the "Login" field.</summary>
    public const int LoginFieldNumber = 3;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Cat.IM.Google.Protobuf.Login Login {
      get { return messageCase_ == MessageOneofCase.Login ? (global::Cat.IM.Google.Protobuf.Login) message_ : null; }
      set {
        message_ = value;
        messageCase_ = value == null ? MessageOneofCase.None : MessageOneofCase.Login;
      }
    }

    /// <summary>Field number for the "Chat" field.</summary>
    public const int ChatFieldNumber = 4;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Cat.IM.Google.Protobuf.Chat Chat {
      get { return messageCase_ == MessageOneofCase.Chat ? (global::Cat.IM.Google.Protobuf.Chat) message_ : null; }
      set {
        message_ = value;
        messageCase_ = value == null ? MessageOneofCase.None : MessageOneofCase.Chat;
      }
    }

    private object message_;
    /// <summary>Enum of possible cases for the "Message" oneof.</summary>
    public enum MessageOneofCase {
      None = 0,
      Base = 2,
      Login = 3,
      Chat = 4,
    }
    private MessageOneofCase messageCase_ = MessageOneofCase.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MessageOneofCase MessageCase {
      get { return messageCase_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearMessage() {
      messageCase_ = MessageOneofCase.None;
      message_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CatMessage);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CatMessage other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Type != other.Type) return false;
      if (!object.Equals(Base, other.Base)) return false;
      if (!object.Equals(Login, other.Login)) return false;
      if (!object.Equals(Chat, other.Chat)) return false;
      if (MessageCase != other.MessageCase) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Type != 0) hash ^= Type.GetHashCode();
      if (messageCase_ == MessageOneofCase.Base) hash ^= Base.GetHashCode();
      if (messageCase_ == MessageOneofCase.Login) hash ^= Login.GetHashCode();
      if (messageCase_ == MessageOneofCase.Chat) hash ^= Chat.GetHashCode();
      hash ^= (int) messageCase_;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Type != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Type);
      }
      if (messageCase_ == MessageOneofCase.Base) {
        output.WriteRawTag(18);
        output.WriteMessage(Base);
      }
      if (messageCase_ == MessageOneofCase.Login) {
        output.WriteRawTag(26);
        output.WriteMessage(Login);
      }
      if (messageCase_ == MessageOneofCase.Chat) {
        output.WriteRawTag(34);
        output.WriteMessage(Chat);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Type != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Type);
      }
      if (messageCase_ == MessageOneofCase.Base) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Base);
      }
      if (messageCase_ == MessageOneofCase.Login) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Login);
      }
      if (messageCase_ == MessageOneofCase.Chat) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Chat);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CatMessage other) {
      if (other == null) {
        return;
      }
      if (other.Type != 0) {
        Type = other.Type;
      }
      switch (other.MessageCase) {
        case MessageOneofCase.Base:
          if (Base == null) {
            Base = new global::Cat.IM.Google.Protobuf.Base();
          }
          Base.MergeFrom(other.Base);
          break;
        case MessageOneofCase.Login:
          if (Login == null) {
            Login = new global::Cat.IM.Google.Protobuf.Login();
          }
          Login.MergeFrom(other.Login);
          break;
        case MessageOneofCase.Chat:
          if (Chat == null) {
            Chat = new global::Cat.IM.Google.Protobuf.Chat();
          }
          Chat.MergeFrom(other.Chat);
          break;
      }

      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            type_ = (global::Cat.IM.Google.Protobuf.MessageType) input.ReadEnum();
            break;
          }
          case 18: {
            global::Cat.IM.Google.Protobuf.Base subBuilder = new global::Cat.IM.Google.Protobuf.Base();
            if (messageCase_ == MessageOneofCase.Base) {
              subBuilder.MergeFrom(Base);
            }
            input.ReadMessage(subBuilder);
            Base = subBuilder;
            break;
          }
          case 26: {
            global::Cat.IM.Google.Protobuf.Login subBuilder = new global::Cat.IM.Google.Protobuf.Login();
            if (messageCase_ == MessageOneofCase.Login) {
              subBuilder.MergeFrom(Login);
            }
            input.ReadMessage(subBuilder);
            Login = subBuilder;
            break;
          }
          case 34: {
            global::Cat.IM.Google.Protobuf.Chat subBuilder = new global::Cat.IM.Google.Protobuf.Chat();
            if (messageCase_ == MessageOneofCase.Chat) {
              subBuilder.MergeFrom(Chat);
            }
            input.ReadMessage(subBuilder);
            Chat = subBuilder;
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
