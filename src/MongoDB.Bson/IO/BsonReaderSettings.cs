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

using System;

namespace MongoDB.Bson.IO
{
    /// <summary>
    /// Represents settings for a BsonReader.
    /// </summary>
    [Serializable]
    public abstract class BsonReaderSettings
    {
        // private fields
        private bool _isFrozen;

        // constructors
        /// <summary>
        /// Initializes a new instance of the BsonReaderSettings class.
        /// </summary>
        protected BsonReaderSettings()
        {
        }

        /// <summary>
        /// Gets whether the settings are frozen.
        /// </summary>
        public bool IsFrozen
        {
            get { return _isFrozen; }
        }

        // public methods
        /// <summary>
        /// Creates a clone of the settings.
        /// </summary>
        /// <returns>A clone of the settings.</returns>
        public BsonReaderSettings Clone()
        {
            return CloneImplementation();
        }

        /// <summary>
        /// Freezes the settings.
        /// </summary>
        /// <returns>The frozen settings.</returns>
        public BsonReaderSettings Freeze()
        {
            _isFrozen = true;
            return this;
        }

        /// <summary>
        /// Returns a frozen copy of the settings.
        /// </summary>
        /// <returns>A frozen copy of the settings.</returns>
        public BsonReaderSettings FrozenCopy()
        {
            if (_isFrozen)
            {
                return this;
            }
            else
            {
                return Clone().Freeze();
            }
        }

        // protected methods
        /// <summary>
        /// Creates a clone of the settings.
        /// </summary>
        /// <returns>A clone of the settings.</returns>
        protected abstract BsonReaderSettings CloneImplementation();

        /// <summary>
        /// Throws an InvalidOperationException when an attempt is made to change a setting after the settings are frozen.
        /// </summary>
        protected void ThrowFrozenException()
        {
            var message = string.Format("{0} is frozen.", this.GetType().Name);
            throw new InvalidOperationException(message);
        }
    }
}
