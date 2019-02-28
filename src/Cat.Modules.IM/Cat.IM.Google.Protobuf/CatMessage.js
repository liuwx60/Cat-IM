/*eslint-disable block-scoped-var, id-length, no-control-regex, no-magic-numbers, no-prototype-builtins, no-redeclare, no-shadow, no-var, sort-vars*/
"use strict";

var $protobuf = require("protobufjs/minimal");

// Common aliases
var $Reader = $protobuf.Reader, $Writer = $protobuf.Writer, $util = $protobuf.util;

// Exported root namespace
var $root = $protobuf.roots["default"] || ($protobuf.roots["default"] = {});

$root.Cat = (function() {

    /**
     * Namespace Cat.
     * @exports Cat
     * @namespace
     */
    var Cat = {};

    Cat.Login = (function() {

        /**
         * Properties of a Login.
         * @memberof Cat
         * @interface ILogin
         * @property {string|null} [Token] Login Token
         */

        /**
         * Constructs a new Login.
         * @memberof Cat
         * @classdesc Represents a Login.
         * @implements ILogin
         * @constructor
         * @param {Cat.ILogin=} [properties] Properties to set
         */
        function Login(properties) {
            if (properties)
                for (var keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                    if (properties[keys[i]] != null)
                        this[keys[i]] = properties[keys[i]];
        }

        /**
         * Login Token.
         * @member {string} Token
         * @memberof Cat.Login
         * @instance
         */
        Login.prototype.Token = "";

        /**
         * Creates a new Login instance using the specified properties.
         * @function create
         * @memberof Cat.Login
         * @static
         * @param {Cat.ILogin=} [properties] Properties to set
         * @returns {Cat.Login} Login instance
         */
        Login.create = function create(properties) {
            return new Login(properties);
        };

        /**
         * Encodes the specified Login message. Does not implicitly {@link Cat.Login.verify|verify} messages.
         * @function encode
         * @memberof Cat.Login
         * @static
         * @param {Cat.ILogin} message Login message or plain object to encode
         * @param {$protobuf.Writer} [writer] Writer to encode to
         * @returns {$protobuf.Writer} Writer
         */
        Login.encode = function encode(message, writer) {
            if (!writer)
                writer = $Writer.create();
            if (message.Token != null && message.hasOwnProperty("Token"))
                writer.uint32(/* id 1, wireType 2 =*/10).string(message.Token);
            return writer;
        };

        /**
         * Encodes the specified Login message, length delimited. Does not implicitly {@link Cat.Login.verify|verify} messages.
         * @function encodeDelimited
         * @memberof Cat.Login
         * @static
         * @param {Cat.ILogin} message Login message or plain object to encode
         * @param {$protobuf.Writer} [writer] Writer to encode to
         * @returns {$protobuf.Writer} Writer
         */
        Login.encodeDelimited = function encodeDelimited(message, writer) {
            return this.encode(message, writer).ldelim();
        };

        /**
         * Decodes a Login message from the specified reader or buffer.
         * @function decode
         * @memberof Cat.Login
         * @static
         * @param {$protobuf.Reader|Uint8Array} reader Reader or buffer to decode from
         * @param {number} [length] Message length if known beforehand
         * @returns {Cat.Login} Login
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        Login.decode = function decode(reader, length) {
            if (!(reader instanceof $Reader))
                reader = $Reader.create(reader);
            var end = length === undefined ? reader.len : reader.pos + length, message = new $root.Cat.Login();
            while (reader.pos < end) {
                var tag = reader.uint32();
                switch (tag >>> 3) {
                case 1:
                    message.Token = reader.string();
                    break;
                default:
                    reader.skipType(tag & 7);
                    break;
                }
            }
            return message;
        };

        /**
         * Decodes a Login message from the specified reader or buffer, length delimited.
         * @function decodeDelimited
         * @memberof Cat.Login
         * @static
         * @param {$protobuf.Reader|Uint8Array} reader Reader or buffer to decode from
         * @returns {Cat.Login} Login
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        Login.decodeDelimited = function decodeDelimited(reader) {
            if (!(reader instanceof $Reader))
                reader = new $Reader(reader);
            return this.decode(reader, reader.uint32());
        };

        /**
         * Verifies a Login message.
         * @function verify
         * @memberof Cat.Login
         * @static
         * @param {Object.<string,*>} message Plain object to verify
         * @returns {string|null} `null` if valid, otherwise the reason why it is not
         */
        Login.verify = function verify(message) {
            if (typeof message !== "object" || message === null)
                return "object expected";
            if (message.Token != null && message.hasOwnProperty("Token"))
                if (!$util.isString(message.Token))
                    return "Token: string expected";
            return null;
        };

        /**
         * Creates a Login message from a plain object. Also converts values to their respective internal types.
         * @function fromObject
         * @memberof Cat.Login
         * @static
         * @param {Object.<string,*>} object Plain object
         * @returns {Cat.Login} Login
         */
        Login.fromObject = function fromObject(object) {
            if (object instanceof $root.Cat.Login)
                return object;
            var message = new $root.Cat.Login();
            if (object.Token != null)
                message.Token = String(object.Token);
            return message;
        };

        /**
         * Creates a plain object from a Login message. Also converts values to other types if specified.
         * @function toObject
         * @memberof Cat.Login
         * @static
         * @param {Cat.Login} message Login
         * @param {$protobuf.IConversionOptions} [options] Conversion options
         * @returns {Object.<string,*>} Plain object
         */
        Login.toObject = function toObject(message, options) {
            if (!options)
                options = {};
            var object = {};
            if (options.defaults)
                object.Token = "";
            if (message.Token != null && message.hasOwnProperty("Token"))
                object.Token = message.Token;
            return object;
        };

        /**
         * Converts this Login to JSON.
         * @function toJSON
         * @memberof Cat.Login
         * @instance
         * @returns {Object.<string,*>} JSON object
         */
        Login.prototype.toJSON = function toJSON() {
            return this.constructor.toObject(this, $protobuf.util.toJSONOptions);
        };

        return Login;
    })();

    Cat.Ping = (function() {

        /**
         * Properties of a Ping.
         * @memberof Cat
         * @interface IPing
         * @property {string|null} [Body] Ping Body
         */

        /**
         * Constructs a new Ping.
         * @memberof Cat
         * @classdesc Represents a Ping.
         * @implements IPing
         * @constructor
         * @param {Cat.IPing=} [properties] Properties to set
         */
        function Ping(properties) {
            if (properties)
                for (var keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                    if (properties[keys[i]] != null)
                        this[keys[i]] = properties[keys[i]];
        }

        /**
         * Ping Body.
         * @member {string} Body
         * @memberof Cat.Ping
         * @instance
         */
        Ping.prototype.Body = "";

        /**
         * Creates a new Ping instance using the specified properties.
         * @function create
         * @memberof Cat.Ping
         * @static
         * @param {Cat.IPing=} [properties] Properties to set
         * @returns {Cat.Ping} Ping instance
         */
        Ping.create = function create(properties) {
            return new Ping(properties);
        };

        /**
         * Encodes the specified Ping message. Does not implicitly {@link Cat.Ping.verify|verify} messages.
         * @function encode
         * @memberof Cat.Ping
         * @static
         * @param {Cat.IPing} message Ping message or plain object to encode
         * @param {$protobuf.Writer} [writer] Writer to encode to
         * @returns {$protobuf.Writer} Writer
         */
        Ping.encode = function encode(message, writer) {
            if (!writer)
                writer = $Writer.create();
            if (message.Body != null && message.hasOwnProperty("Body"))
                writer.uint32(/* id 1, wireType 2 =*/10).string(message.Body);
            return writer;
        };

        /**
         * Encodes the specified Ping message, length delimited. Does not implicitly {@link Cat.Ping.verify|verify} messages.
         * @function encodeDelimited
         * @memberof Cat.Ping
         * @static
         * @param {Cat.IPing} message Ping message or plain object to encode
         * @param {$protobuf.Writer} [writer] Writer to encode to
         * @returns {$protobuf.Writer} Writer
         */
        Ping.encodeDelimited = function encodeDelimited(message, writer) {
            return this.encode(message, writer).ldelim();
        };

        /**
         * Decodes a Ping message from the specified reader or buffer.
         * @function decode
         * @memberof Cat.Ping
         * @static
         * @param {$protobuf.Reader|Uint8Array} reader Reader or buffer to decode from
         * @param {number} [length] Message length if known beforehand
         * @returns {Cat.Ping} Ping
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        Ping.decode = function decode(reader, length) {
            if (!(reader instanceof $Reader))
                reader = $Reader.create(reader);
            var end = length === undefined ? reader.len : reader.pos + length, message = new $root.Cat.Ping();
            while (reader.pos < end) {
                var tag = reader.uint32();
                switch (tag >>> 3) {
                case 1:
                    message.Body = reader.string();
                    break;
                default:
                    reader.skipType(tag & 7);
                    break;
                }
            }
            return message;
        };

        /**
         * Decodes a Ping message from the specified reader or buffer, length delimited.
         * @function decodeDelimited
         * @memberof Cat.Ping
         * @static
         * @param {$protobuf.Reader|Uint8Array} reader Reader or buffer to decode from
         * @returns {Cat.Ping} Ping
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        Ping.decodeDelimited = function decodeDelimited(reader) {
            if (!(reader instanceof $Reader))
                reader = new $Reader(reader);
            return this.decode(reader, reader.uint32());
        };

        /**
         * Verifies a Ping message.
         * @function verify
         * @memberof Cat.Ping
         * @static
         * @param {Object.<string,*>} message Plain object to verify
         * @returns {string|null} `null` if valid, otherwise the reason why it is not
         */
        Ping.verify = function verify(message) {
            if (typeof message !== "object" || message === null)
                return "object expected";
            if (message.Body != null && message.hasOwnProperty("Body"))
                if (!$util.isString(message.Body))
                    return "Body: string expected";
            return null;
        };

        /**
         * Creates a Ping message from a plain object. Also converts values to their respective internal types.
         * @function fromObject
         * @memberof Cat.Ping
         * @static
         * @param {Object.<string,*>} object Plain object
         * @returns {Cat.Ping} Ping
         */
        Ping.fromObject = function fromObject(object) {
            if (object instanceof $root.Cat.Ping)
                return object;
            var message = new $root.Cat.Ping();
            if (object.Body != null)
                message.Body = String(object.Body);
            return message;
        };

        /**
         * Creates a plain object from a Ping message. Also converts values to other types if specified.
         * @function toObject
         * @memberof Cat.Ping
         * @static
         * @param {Cat.Ping} message Ping
         * @param {$protobuf.IConversionOptions} [options] Conversion options
         * @returns {Object.<string,*>} Plain object
         */
        Ping.toObject = function toObject(message, options) {
            if (!options)
                options = {};
            var object = {};
            if (options.defaults)
                object.Body = "";
            if (message.Body != null && message.hasOwnProperty("Body"))
                object.Body = message.Body;
            return object;
        };

        /**
         * Converts this Ping to JSON.
         * @function toJSON
         * @memberof Cat.Ping
         * @instance
         * @returns {Object.<string,*>} JSON object
         */
        Ping.prototype.toJSON = function toJSON() {
            return this.constructor.toObject(this, $protobuf.util.toJSONOptions);
        };

        return Ping;
    })();

    Cat.Chat = (function() {

        /**
         * Properties of a Chat.
         * @memberof Cat
         * @interface IChat
         * @property {string|null} [Id] Chat Id
         * @property {string|null} [Body] Chat Body
         * @property {string|null} [Sender] Chat Sender
         * @property {string|null} [Receiver] Chat Receiver
         * @property {string|null} [SendOn] Chat SendOn
         */

        /**
         * Constructs a new Chat.
         * @memberof Cat
         * @classdesc Represents a Chat.
         * @implements IChat
         * @constructor
         * @param {Cat.IChat=} [properties] Properties to set
         */
        function Chat(properties) {
            if (properties)
                for (var keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                    if (properties[keys[i]] != null)
                        this[keys[i]] = properties[keys[i]];
        }

        /**
         * Chat Id.
         * @member {string} Id
         * @memberof Cat.Chat
         * @instance
         */
        Chat.prototype.Id = "";

        /**
         * Chat Body.
         * @member {string} Body
         * @memberof Cat.Chat
         * @instance
         */
        Chat.prototype.Body = "";

        /**
         * Chat Sender.
         * @member {string} Sender
         * @memberof Cat.Chat
         * @instance
         */
        Chat.prototype.Sender = "";

        /**
         * Chat Receiver.
         * @member {string} Receiver
         * @memberof Cat.Chat
         * @instance
         */
        Chat.prototype.Receiver = "";

        /**
         * Chat SendOn.
         * @member {string} SendOn
         * @memberof Cat.Chat
         * @instance
         */
        Chat.prototype.SendOn = "";

        /**
         * Creates a new Chat instance using the specified properties.
         * @function create
         * @memberof Cat.Chat
         * @static
         * @param {Cat.IChat=} [properties] Properties to set
         * @returns {Cat.Chat} Chat instance
         */
        Chat.create = function create(properties) {
            return new Chat(properties);
        };

        /**
         * Encodes the specified Chat message. Does not implicitly {@link Cat.Chat.verify|verify} messages.
         * @function encode
         * @memberof Cat.Chat
         * @static
         * @param {Cat.IChat} message Chat message or plain object to encode
         * @param {$protobuf.Writer} [writer] Writer to encode to
         * @returns {$protobuf.Writer} Writer
         */
        Chat.encode = function encode(message, writer) {
            if (!writer)
                writer = $Writer.create();
            if (message.Id != null && message.hasOwnProperty("Id"))
                writer.uint32(/* id 1, wireType 2 =*/10).string(message.Id);
            if (message.Body != null && message.hasOwnProperty("Body"))
                writer.uint32(/* id 2, wireType 2 =*/18).string(message.Body);
            if (message.Sender != null && message.hasOwnProperty("Sender"))
                writer.uint32(/* id 3, wireType 2 =*/26).string(message.Sender);
            if (message.Receiver != null && message.hasOwnProperty("Receiver"))
                writer.uint32(/* id 4, wireType 2 =*/34).string(message.Receiver);
            if (message.SendOn != null && message.hasOwnProperty("SendOn"))
                writer.uint32(/* id 5, wireType 2 =*/42).string(message.SendOn);
            return writer;
        };

        /**
         * Encodes the specified Chat message, length delimited. Does not implicitly {@link Cat.Chat.verify|verify} messages.
         * @function encodeDelimited
         * @memberof Cat.Chat
         * @static
         * @param {Cat.IChat} message Chat message or plain object to encode
         * @param {$protobuf.Writer} [writer] Writer to encode to
         * @returns {$protobuf.Writer} Writer
         */
        Chat.encodeDelimited = function encodeDelimited(message, writer) {
            return this.encode(message, writer).ldelim();
        };

        /**
         * Decodes a Chat message from the specified reader or buffer.
         * @function decode
         * @memberof Cat.Chat
         * @static
         * @param {$protobuf.Reader|Uint8Array} reader Reader or buffer to decode from
         * @param {number} [length] Message length if known beforehand
         * @returns {Cat.Chat} Chat
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        Chat.decode = function decode(reader, length) {
            if (!(reader instanceof $Reader))
                reader = $Reader.create(reader);
            var end = length === undefined ? reader.len : reader.pos + length, message = new $root.Cat.Chat();
            while (reader.pos < end) {
                var tag = reader.uint32();
                switch (tag >>> 3) {
                case 1:
                    message.Id = reader.string();
                    break;
                case 2:
                    message.Body = reader.string();
                    break;
                case 3:
                    message.Sender = reader.string();
                    break;
                case 4:
                    message.Receiver = reader.string();
                    break;
                case 5:
                    message.SendOn = reader.string();
                    break;
                default:
                    reader.skipType(tag & 7);
                    break;
                }
            }
            return message;
        };

        /**
         * Decodes a Chat message from the specified reader or buffer, length delimited.
         * @function decodeDelimited
         * @memberof Cat.Chat
         * @static
         * @param {$protobuf.Reader|Uint8Array} reader Reader or buffer to decode from
         * @returns {Cat.Chat} Chat
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        Chat.decodeDelimited = function decodeDelimited(reader) {
            if (!(reader instanceof $Reader))
                reader = new $Reader(reader);
            return this.decode(reader, reader.uint32());
        };

        /**
         * Verifies a Chat message.
         * @function verify
         * @memberof Cat.Chat
         * @static
         * @param {Object.<string,*>} message Plain object to verify
         * @returns {string|null} `null` if valid, otherwise the reason why it is not
         */
        Chat.verify = function verify(message) {
            if (typeof message !== "object" || message === null)
                return "object expected";
            if (message.Id != null && message.hasOwnProperty("Id"))
                if (!$util.isString(message.Id))
                    return "Id: string expected";
            if (message.Body != null && message.hasOwnProperty("Body"))
                if (!$util.isString(message.Body))
                    return "Body: string expected";
            if (message.Sender != null && message.hasOwnProperty("Sender"))
                if (!$util.isString(message.Sender))
                    return "Sender: string expected";
            if (message.Receiver != null && message.hasOwnProperty("Receiver"))
                if (!$util.isString(message.Receiver))
                    return "Receiver: string expected";
            if (message.SendOn != null && message.hasOwnProperty("SendOn"))
                if (!$util.isString(message.SendOn))
                    return "SendOn: string expected";
            return null;
        };

        /**
         * Creates a Chat message from a plain object. Also converts values to their respective internal types.
         * @function fromObject
         * @memberof Cat.Chat
         * @static
         * @param {Object.<string,*>} object Plain object
         * @returns {Cat.Chat} Chat
         */
        Chat.fromObject = function fromObject(object) {
            if (object instanceof $root.Cat.Chat)
                return object;
            var message = new $root.Cat.Chat();
            if (object.Id != null)
                message.Id = String(object.Id);
            if (object.Body != null)
                message.Body = String(object.Body);
            if (object.Sender != null)
                message.Sender = String(object.Sender);
            if (object.Receiver != null)
                message.Receiver = String(object.Receiver);
            if (object.SendOn != null)
                message.SendOn = String(object.SendOn);
            return message;
        };

        /**
         * Creates a plain object from a Chat message. Also converts values to other types if specified.
         * @function toObject
         * @memberof Cat.Chat
         * @static
         * @param {Cat.Chat} message Chat
         * @param {$protobuf.IConversionOptions} [options] Conversion options
         * @returns {Object.<string,*>} Plain object
         */
        Chat.toObject = function toObject(message, options) {
            if (!options)
                options = {};
            var object = {};
            if (options.defaults) {
                object.Id = "";
                object.Body = "";
                object.Sender = "";
                object.Receiver = "";
                object.SendOn = "";
            }
            if (message.Id != null && message.hasOwnProperty("Id"))
                object.Id = message.Id;
            if (message.Body != null && message.hasOwnProperty("Body"))
                object.Body = message.Body;
            if (message.Sender != null && message.hasOwnProperty("Sender"))
                object.Sender = message.Sender;
            if (message.Receiver != null && message.hasOwnProperty("Receiver"))
                object.Receiver = message.Receiver;
            if (message.SendOn != null && message.hasOwnProperty("SendOn"))
                object.SendOn = message.SendOn;
            return object;
        };

        /**
         * Converts this Chat to JSON.
         * @function toJSON
         * @memberof Cat.Chat
         * @instance
         * @returns {Object.<string,*>} JSON object
         */
        Chat.prototype.toJSON = function toJSON() {
            return this.constructor.toObject(this, $protobuf.util.toJSONOptions);
        };

        return Chat;
    })();

    Cat.CatMessage = (function() {

        /**
         * Properties of a CatMessage.
         * @memberof Cat
         * @interface ICatMessage
         * @property {Cat.CatMessage.MessageType|null} [Type] CatMessage Type
         * @property {Cat.ILogin|null} [Login] CatMessage Login
         * @property {Cat.IPing|null} [Ping] CatMessage Ping
         * @property {Cat.IChat|null} [Chat] CatMessage Chat
         */

        /**
         * Constructs a new CatMessage.
         * @memberof Cat
         * @classdesc Represents a CatMessage.
         * @implements ICatMessage
         * @constructor
         * @param {Cat.ICatMessage=} [properties] Properties to set
         */
        function CatMessage(properties) {
            if (properties)
                for (var keys = Object.keys(properties), i = 0; i < keys.length; ++i)
                    if (properties[keys[i]] != null)
                        this[keys[i]] = properties[keys[i]];
        }

        /**
         * CatMessage Type.
         * @member {Cat.CatMessage.MessageType} Type
         * @memberof Cat.CatMessage
         * @instance
         */
        CatMessage.prototype.Type = 0;

        /**
         * CatMessage Login.
         * @member {Cat.ILogin|null|undefined} Login
         * @memberof Cat.CatMessage
         * @instance
         */
        CatMessage.prototype.Login = null;

        /**
         * CatMessage Ping.
         * @member {Cat.IPing|null|undefined} Ping
         * @memberof Cat.CatMessage
         * @instance
         */
        CatMessage.prototype.Ping = null;

        /**
         * CatMessage Chat.
         * @member {Cat.IChat|null|undefined} Chat
         * @memberof Cat.CatMessage
         * @instance
         */
        CatMessage.prototype.Chat = null;

        // OneOf field names bound to virtual getters and setters
        var $oneOfFields;

        /**
         * CatMessage Message.
         * @member {"Login"|"Ping"|"Chat"|undefined} Message
         * @memberof Cat.CatMessage
         * @instance
         */
        Object.defineProperty(CatMessage.prototype, "Message", {
            get: $util.oneOfGetter($oneOfFields = ["Login", "Ping", "Chat"]),
            set: $util.oneOfSetter($oneOfFields)
        });

        /**
         * Creates a new CatMessage instance using the specified properties.
         * @function create
         * @memberof Cat.CatMessage
         * @static
         * @param {Cat.ICatMessage=} [properties] Properties to set
         * @returns {Cat.CatMessage} CatMessage instance
         */
        CatMessage.create = function create(properties) {
            return new CatMessage(properties);
        };

        /**
         * Encodes the specified CatMessage message. Does not implicitly {@link Cat.CatMessage.verify|verify} messages.
         * @function encode
         * @memberof Cat.CatMessage
         * @static
         * @param {Cat.ICatMessage} message CatMessage message or plain object to encode
         * @param {$protobuf.Writer} [writer] Writer to encode to
         * @returns {$protobuf.Writer} Writer
         */
        CatMessage.encode = function encode(message, writer) {
            if (!writer)
                writer = $Writer.create();
            if (message.Type != null && message.hasOwnProperty("Type"))
                writer.uint32(/* id 1, wireType 0 =*/8).int32(message.Type);
            if (message.Login != null && message.hasOwnProperty("Login"))
                $root.Cat.Login.encode(message.Login, writer.uint32(/* id 2, wireType 2 =*/18).fork()).ldelim();
            if (message.Ping != null && message.hasOwnProperty("Ping"))
                $root.Cat.Ping.encode(message.Ping, writer.uint32(/* id 3, wireType 2 =*/26).fork()).ldelim();
            if (message.Chat != null && message.hasOwnProperty("Chat"))
                $root.Cat.Chat.encode(message.Chat, writer.uint32(/* id 4, wireType 2 =*/34).fork()).ldelim();
            return writer;
        };

        /**
         * Encodes the specified CatMessage message, length delimited. Does not implicitly {@link Cat.CatMessage.verify|verify} messages.
         * @function encodeDelimited
         * @memberof Cat.CatMessage
         * @static
         * @param {Cat.ICatMessage} message CatMessage message or plain object to encode
         * @param {$protobuf.Writer} [writer] Writer to encode to
         * @returns {$protobuf.Writer} Writer
         */
        CatMessage.encodeDelimited = function encodeDelimited(message, writer) {
            return this.encode(message, writer).ldelim();
        };

        /**
         * Decodes a CatMessage message from the specified reader or buffer.
         * @function decode
         * @memberof Cat.CatMessage
         * @static
         * @param {$protobuf.Reader|Uint8Array} reader Reader or buffer to decode from
         * @param {number} [length] Message length if known beforehand
         * @returns {Cat.CatMessage} CatMessage
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        CatMessage.decode = function decode(reader, length) {
            if (!(reader instanceof $Reader))
                reader = $Reader.create(reader);
            var end = length === undefined ? reader.len : reader.pos + length, message = new $root.Cat.CatMessage();
            while (reader.pos < end) {
                var tag = reader.uint32();
                switch (tag >>> 3) {
                case 1:
                    message.Type = reader.int32();
                    break;
                case 2:
                    message.Login = $root.Cat.Login.decode(reader, reader.uint32());
                    break;
                case 3:
                    message.Ping = $root.Cat.Ping.decode(reader, reader.uint32());
                    break;
                case 4:
                    message.Chat = $root.Cat.Chat.decode(reader, reader.uint32());
                    break;
                default:
                    reader.skipType(tag & 7);
                    break;
                }
            }
            return message;
        };

        /**
         * Decodes a CatMessage message from the specified reader or buffer, length delimited.
         * @function decodeDelimited
         * @memberof Cat.CatMessage
         * @static
         * @param {$protobuf.Reader|Uint8Array} reader Reader or buffer to decode from
         * @returns {Cat.CatMessage} CatMessage
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        CatMessage.decodeDelimited = function decodeDelimited(reader) {
            if (!(reader instanceof $Reader))
                reader = new $Reader(reader);
            return this.decode(reader, reader.uint32());
        };

        /**
         * Verifies a CatMessage message.
         * @function verify
         * @memberof Cat.CatMessage
         * @static
         * @param {Object.<string,*>} message Plain object to verify
         * @returns {string|null} `null` if valid, otherwise the reason why it is not
         */
        CatMessage.verify = function verify(message) {
            if (typeof message !== "object" || message === null)
                return "object expected";
            var properties = {};
            if (message.Type != null && message.hasOwnProperty("Type"))
                switch (message.Type) {
                default:
                    return "Type: enum value expected";
                case 0:
                case 1:
                case 2:
                    break;
                }
            if (message.Login != null && message.hasOwnProperty("Login")) {
                properties.Message = 1;
                {
                    var error = $root.Cat.Login.verify(message.Login);
                    if (error)
                        return "Login." + error;
                }
            }
            if (message.Ping != null && message.hasOwnProperty("Ping")) {
                if (properties.Message === 1)
                    return "Message: multiple values";
                properties.Message = 1;
                {
                    var error = $root.Cat.Ping.verify(message.Ping);
                    if (error)
                        return "Ping." + error;
                }
            }
            if (message.Chat != null && message.hasOwnProperty("Chat")) {
                if (properties.Message === 1)
                    return "Message: multiple values";
                properties.Message = 1;
                {
                    var error = $root.Cat.Chat.verify(message.Chat);
                    if (error)
                        return "Chat." + error;
                }
            }
            return null;
        };

        /**
         * Creates a CatMessage message from a plain object. Also converts values to their respective internal types.
         * @function fromObject
         * @memberof Cat.CatMessage
         * @static
         * @param {Object.<string,*>} object Plain object
         * @returns {Cat.CatMessage} CatMessage
         */
        CatMessage.fromObject = function fromObject(object) {
            if (object instanceof $root.Cat.CatMessage)
                return object;
            var message = new $root.Cat.CatMessage();
            switch (object.Type) {
            case "LOGIN":
            case 0:
                message.Type = 0;
                break;
            case "PING":
            case 1:
                message.Type = 1;
                break;
            case "CHAT":
            case 2:
                message.Type = 2;
                break;
            }
            if (object.Login != null) {
                if (typeof object.Login !== "object")
                    throw TypeError(".Cat.CatMessage.Login: object expected");
                message.Login = $root.Cat.Login.fromObject(object.Login);
            }
            if (object.Ping != null) {
                if (typeof object.Ping !== "object")
                    throw TypeError(".Cat.CatMessage.Ping: object expected");
                message.Ping = $root.Cat.Ping.fromObject(object.Ping);
            }
            if (object.Chat != null) {
                if (typeof object.Chat !== "object")
                    throw TypeError(".Cat.CatMessage.Chat: object expected");
                message.Chat = $root.Cat.Chat.fromObject(object.Chat);
            }
            return message;
        };

        /**
         * Creates a plain object from a CatMessage message. Also converts values to other types if specified.
         * @function toObject
         * @memberof Cat.CatMessage
         * @static
         * @param {Cat.CatMessage} message CatMessage
         * @param {$protobuf.IConversionOptions} [options] Conversion options
         * @returns {Object.<string,*>} Plain object
         */
        CatMessage.toObject = function toObject(message, options) {
            if (!options)
                options = {};
            var object = {};
            if (options.defaults)
                object.Type = options.enums === String ? "LOGIN" : 0;
            if (message.Type != null && message.hasOwnProperty("Type"))
                object.Type = options.enums === String ? $root.Cat.CatMessage.MessageType[message.Type] : message.Type;
            if (message.Login != null && message.hasOwnProperty("Login")) {
                object.Login = $root.Cat.Login.toObject(message.Login, options);
                if (options.oneofs)
                    object.Message = "Login";
            }
            if (message.Ping != null && message.hasOwnProperty("Ping")) {
                object.Ping = $root.Cat.Ping.toObject(message.Ping, options);
                if (options.oneofs)
                    object.Message = "Ping";
            }
            if (message.Chat != null && message.hasOwnProperty("Chat")) {
                object.Chat = $root.Cat.Chat.toObject(message.Chat, options);
                if (options.oneofs)
                    object.Message = "Chat";
            }
            return object;
        };

        /**
         * Converts this CatMessage to JSON.
         * @function toJSON
         * @memberof Cat.CatMessage
         * @instance
         * @returns {Object.<string,*>} JSON object
         */
        CatMessage.prototype.toJSON = function toJSON() {
            return this.constructor.toObject(this, $protobuf.util.toJSONOptions);
        };

        /**
         * MessageType enum.
         * @name Cat.CatMessage.MessageType
         * @enum {string}
         * @property {number} LOGIN=0 LOGIN value
         * @property {number} PING=1 PING value
         * @property {number} CHAT=2 CHAT value
         */
        CatMessage.MessageType = (function() {
            var valuesById = {}, values = Object.create(valuesById);
            values[valuesById[0] = "LOGIN"] = 0;
            values[valuesById[1] = "PING"] = 1;
            values[valuesById[2] = "CHAT"] = 2;
            return values;
        })();

        return CatMessage;
    })();

    return Cat;
})();

module.exports = $root;
