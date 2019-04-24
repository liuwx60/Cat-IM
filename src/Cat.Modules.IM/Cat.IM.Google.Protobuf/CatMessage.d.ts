import * as $protobuf from "protobufjs";
/** Namespace Cat. */
export namespace Cat {

    /** Properties of a Base. */
    interface IBase {

        /** Base Id */
        Id?: (string|null);

        /** Base Sender */
        Sender?: (string|null);

        /** Base Receiver */
        Receiver?: (string|null);

        /** Base SendOn */
        SendOn?: (string|null);
    }

    /** Represents a Base. */
    class Base implements IBase {

        /**
         * Constructs a new Base.
         * @param [properties] Properties to set
         */
        constructor(properties?: Cat.IBase);

        /** Base Id. */
        public Id: string;

        /** Base Sender. */
        public Sender: string;

        /** Base Receiver. */
        public Receiver: string;

        /** Base SendOn. */
        public SendOn: string;

        /**
         * Creates a new Base instance using the specified properties.
         * @param [properties] Properties to set
         * @returns Base instance
         */
        public static create(properties?: Cat.IBase): Cat.Base;

        /**
         * Encodes the specified Base message. Does not implicitly {@link Cat.Base.verify|verify} messages.
         * @param message Base message or plain object to encode
         * @param [writer] Writer to encode to
         * @returns Writer
         */
        public static encode(message: Cat.IBase, writer?: $protobuf.Writer): $protobuf.Writer;

        /**
         * Encodes the specified Base message, length delimited. Does not implicitly {@link Cat.Base.verify|verify} messages.
         * @param message Base message or plain object to encode
         * @param [writer] Writer to encode to
         * @returns Writer
         */
        public static encodeDelimited(message: Cat.IBase, writer?: $protobuf.Writer): $protobuf.Writer;

        /**
         * Decodes a Base message from the specified reader or buffer.
         * @param reader Reader or buffer to decode from
         * @param [length] Message length if known beforehand
         * @returns Base
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        public static decode(reader: ($protobuf.Reader|Uint8Array), length?: number): Cat.Base;

        /**
         * Decodes a Base message from the specified reader or buffer, length delimited.
         * @param reader Reader or buffer to decode from
         * @returns Base
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        public static decodeDelimited(reader: ($protobuf.Reader|Uint8Array)): Cat.Base;

        /**
         * Verifies a Base message.
         * @param message Plain object to verify
         * @returns `null` if valid, otherwise the reason why it is not
         */
        public static verify(message: { [k: string]: any }): (string|null);

        /**
         * Creates a Base message from a plain object. Also converts values to their respective internal types.
         * @param object Plain object
         * @returns Base
         */
        public static fromObject(object: { [k: string]: any }): Cat.Base;

        /**
         * Creates a plain object from a Base message. Also converts values to other types if specified.
         * @param message Base
         * @param [options] Conversion options
         * @returns Plain object
         */
        public static toObject(message: Cat.Base, options?: $protobuf.IConversionOptions): { [k: string]: any };

        /**
         * Converts this Base to JSON.
         * @returns JSON object
         */
        public toJSON(): { [k: string]: any };
    }

    /** Properties of a Login. */
    interface ILogin {

        /** Login Token */
        Token?: (string|null);
    }

    /** Represents a Login. */
    class Login implements ILogin {

        /**
         * Constructs a new Login.
         * @param [properties] Properties to set
         */
        constructor(properties?: Cat.ILogin);

        /** Login Token. */
        public Token: string;

        /**
         * Creates a new Login instance using the specified properties.
         * @param [properties] Properties to set
         * @returns Login instance
         */
        public static create(properties?: Cat.ILogin): Cat.Login;

        /**
         * Encodes the specified Login message. Does not implicitly {@link Cat.Login.verify|verify} messages.
         * @param message Login message or plain object to encode
         * @param [writer] Writer to encode to
         * @returns Writer
         */
        public static encode(message: Cat.ILogin, writer?: $protobuf.Writer): $protobuf.Writer;

        /**
         * Encodes the specified Login message, length delimited. Does not implicitly {@link Cat.Login.verify|verify} messages.
         * @param message Login message or plain object to encode
         * @param [writer] Writer to encode to
         * @returns Writer
         */
        public static encodeDelimited(message: Cat.ILogin, writer?: $protobuf.Writer): $protobuf.Writer;

        /**
         * Decodes a Login message from the specified reader or buffer.
         * @param reader Reader or buffer to decode from
         * @param [length] Message length if known beforehand
         * @returns Login
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        public static decode(reader: ($protobuf.Reader|Uint8Array), length?: number): Cat.Login;

        /**
         * Decodes a Login message from the specified reader or buffer, length delimited.
         * @param reader Reader or buffer to decode from
         * @returns Login
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        public static decodeDelimited(reader: ($protobuf.Reader|Uint8Array)): Cat.Login;

        /**
         * Verifies a Login message.
         * @param message Plain object to verify
         * @returns `null` if valid, otherwise the reason why it is not
         */
        public static verify(message: { [k: string]: any }): (string|null);

        /**
         * Creates a Login message from a plain object. Also converts values to their respective internal types.
         * @param object Plain object
         * @returns Login
         */
        public static fromObject(object: { [k: string]: any }): Cat.Login;

        /**
         * Creates a plain object from a Login message. Also converts values to other types if specified.
         * @param message Login
         * @param [options] Conversion options
         * @returns Plain object
         */
        public static toObject(message: Cat.Login, options?: $protobuf.IConversionOptions): { [k: string]: any };

        /**
         * Converts this Login to JSON.
         * @returns JSON object
         */
        public toJSON(): { [k: string]: any };
    }

    /** Properties of a Chat. */
    interface IChat {

        /** Chat Info */
        Info?: (Cat.IBase|null);

        /** Chat Body */
        Body?: (string|null);
    }

    /** Represents a Chat. */
    class Chat implements IChat {

        /**
         * Constructs a new Chat.
         * @param [properties] Properties to set
         */
        constructor(properties?: Cat.IChat);

        /** Chat Info. */
        public Info?: (Cat.IBase|null);

        /** Chat Body. */
        public Body: string;

        /**
         * Creates a new Chat instance using the specified properties.
         * @param [properties] Properties to set
         * @returns Chat instance
         */
        public static create(properties?: Cat.IChat): Cat.Chat;

        /**
         * Encodes the specified Chat message. Does not implicitly {@link Cat.Chat.verify|verify} messages.
         * @param message Chat message or plain object to encode
         * @param [writer] Writer to encode to
         * @returns Writer
         */
        public static encode(message: Cat.IChat, writer?: $protobuf.Writer): $protobuf.Writer;

        /**
         * Encodes the specified Chat message, length delimited. Does not implicitly {@link Cat.Chat.verify|verify} messages.
         * @param message Chat message or plain object to encode
         * @param [writer] Writer to encode to
         * @returns Writer
         */
        public static encodeDelimited(message: Cat.IChat, writer?: $protobuf.Writer): $protobuf.Writer;

        /**
         * Decodes a Chat message from the specified reader or buffer.
         * @param reader Reader or buffer to decode from
         * @param [length] Message length if known beforehand
         * @returns Chat
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        public static decode(reader: ($protobuf.Reader|Uint8Array), length?: number): Cat.Chat;

        /**
         * Decodes a Chat message from the specified reader or buffer, length delimited.
         * @param reader Reader or buffer to decode from
         * @returns Chat
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        public static decodeDelimited(reader: ($protobuf.Reader|Uint8Array)): Cat.Chat;

        /**
         * Verifies a Chat message.
         * @param message Plain object to verify
         * @returns `null` if valid, otherwise the reason why it is not
         */
        public static verify(message: { [k: string]: any }): (string|null);

        /**
         * Creates a Chat message from a plain object. Also converts values to their respective internal types.
         * @param object Plain object
         * @returns Chat
         */
        public static fromObject(object: { [k: string]: any }): Cat.Chat;

        /**
         * Creates a plain object from a Chat message. Also converts values to other types if specified.
         * @param message Chat
         * @param [options] Conversion options
         * @returns Plain object
         */
        public static toObject(message: Cat.Chat, options?: $protobuf.IConversionOptions): { [k: string]: any };

        /**
         * Converts this Chat to JSON.
         * @returns JSON object
         */
        public toJSON(): { [k: string]: any };
    }

    /** MessageType enum. */
    enum MessageType {
        LOGIN = 0,
        PING = 1,
        CHAT = 2,
        IMG = 3,
        FILE = 4,
        ADD_FRIEND = 1001
    }

    /** Properties of a CatMessage. */
    interface ICatMessage {

        /** CatMessage Type */
        Type?: (Cat.MessageType|null);

        /** CatMessage Base */
        Base?: (Cat.IBase|null);

        /** CatMessage Login */
        Login?: (Cat.ILogin|null);

        /** CatMessage Chat */
        Chat?: (Cat.IChat|null);
    }

    /** Represents a CatMessage. */
    class CatMessage implements ICatMessage {

        /**
         * Constructs a new CatMessage.
         * @param [properties] Properties to set
         */
        constructor(properties?: Cat.ICatMessage);

        /** CatMessage Type. */
        public Type: Cat.MessageType;

        /** CatMessage Base. */
        public Base?: (Cat.IBase|null);

        /** CatMessage Login. */
        public Login?: (Cat.ILogin|null);

        /** CatMessage Chat. */
        public Chat?: (Cat.IChat|null);

        /** CatMessage Message. */
        public Message?: ("Base"|"Login"|"Chat");

        /**
         * Creates a new CatMessage instance using the specified properties.
         * @param [properties] Properties to set
         * @returns CatMessage instance
         */
        public static create(properties?: Cat.ICatMessage): Cat.CatMessage;

        /**
         * Encodes the specified CatMessage message. Does not implicitly {@link Cat.CatMessage.verify|verify} messages.
         * @param message CatMessage message or plain object to encode
         * @param [writer] Writer to encode to
         * @returns Writer
         */
        public static encode(message: Cat.ICatMessage, writer?: $protobuf.Writer): $protobuf.Writer;

        /**
         * Encodes the specified CatMessage message, length delimited. Does not implicitly {@link Cat.CatMessage.verify|verify} messages.
         * @param message CatMessage message or plain object to encode
         * @param [writer] Writer to encode to
         * @returns Writer
         */
        public static encodeDelimited(message: Cat.ICatMessage, writer?: $protobuf.Writer): $protobuf.Writer;

        /**
         * Decodes a CatMessage message from the specified reader or buffer.
         * @param reader Reader or buffer to decode from
         * @param [length] Message length if known beforehand
         * @returns CatMessage
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        public static decode(reader: ($protobuf.Reader|Uint8Array), length?: number): Cat.CatMessage;

        /**
         * Decodes a CatMessage message from the specified reader or buffer, length delimited.
         * @param reader Reader or buffer to decode from
         * @returns CatMessage
         * @throws {Error} If the payload is not a reader or valid buffer
         * @throws {$protobuf.util.ProtocolError} If required fields are missing
         */
        public static decodeDelimited(reader: ($protobuf.Reader|Uint8Array)): Cat.CatMessage;

        /**
         * Verifies a CatMessage message.
         * @param message Plain object to verify
         * @returns `null` if valid, otherwise the reason why it is not
         */
        public static verify(message: { [k: string]: any }): (string|null);

        /**
         * Creates a CatMessage message from a plain object. Also converts values to their respective internal types.
         * @param object Plain object
         * @returns CatMessage
         */
        public static fromObject(object: { [k: string]: any }): Cat.CatMessage;

        /**
         * Creates a plain object from a CatMessage message. Also converts values to other types if specified.
         * @param message CatMessage
         * @param [options] Conversion options
         * @returns Plain object
         */
        public static toObject(message: Cat.CatMessage, options?: $protobuf.IConversionOptions): { [k: string]: any };

        /**
         * Converts this CatMessage to JSON.
         * @returns JSON object
         */
        public toJSON(): { [k: string]: any };
    }
}
