﻿/* Copyright 2010-present MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using MongoDB.Driver.Core.Misc;

namespace MongoDB.Driver.Core.WireProtocol.Messages.Encoders.JsonEncoders
{
    internal sealed class CommandResponseMessageJsonEncoder : IMessageEncoder
    {
        // private fields
        private readonly CommandMessageJsonEncoder _wrappedEncoder;

        // constructors
        public CommandResponseMessageJsonEncoder(CommandMessageJsonEncoder wrappedEncoder)
        {
            _wrappedEncoder = Ensure.IsNotNull(wrappedEncoder, nameof(wrappedEncoder));
        }

        // public methods
        public CommandResponseMessage ReadMessage()
        {
            var wrappedMessage = (CommandMessage)_wrappedEncoder.ReadMessage();
            return new CommandResponseMessage(wrappedMessage);
        }

        public void WriteMessage(CommandResponseMessage message)
        {
            var wrappedMessage = message.WrappedMessage;
            _wrappedEncoder.WriteMessage(wrappedMessage);
        }

        // explicit interface implementations
        MongoDBMessage IMessageEncoder.ReadMessage()
        {
            return ReadMessage();
        }

        void IMessageEncoder.WriteMessage(MongoDBMessage message)
        {
            WriteMessage((CommandResponseMessage)message);
        }
    }
}