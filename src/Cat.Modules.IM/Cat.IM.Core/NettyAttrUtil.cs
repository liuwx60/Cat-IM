using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cat.IM.Core
{
    public static class NettyAttrUtil
    {
        private static readonly AttributeKey<string> ATTR_KEY_READER_TIME = AttributeKey<string>.ValueOf("ReaderTime");
        private static readonly AttributeKey<string> ATTR_KEY_USER_ID = AttributeKey<string>.ValueOf("UserId");

        public static void UpdateReaderTime(this IChannelHandlerContext channel, DateTime time)
        {
            channel.GetAttribute(ATTR_KEY_READER_TIME).Set(time.ToString());
        }

        public static DateTime? GetReaderTime(this IChannelHandlerContext channel)
        {
            var value = channel.GetAttribute(ATTR_KEY_READER_TIME).Get();

            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return Convert.ToDateTime(value);
        }

        public static void SetUserId(this IChannelHandlerContext channel, Guid userId)
        {
            channel.GetAttribute(ATTR_KEY_USER_ID).Set(userId.ToString());
        }

        public static Guid GetUserId(this IChannelHandlerContext channel)
        {
            var value = channel.GetAttribute(ATTR_KEY_USER_ID).Get();

            if (string.IsNullOrWhiteSpace(value))
            {
                return Guid.Empty;
            }

            return Guid.Parse(value);
        }
    }
}
