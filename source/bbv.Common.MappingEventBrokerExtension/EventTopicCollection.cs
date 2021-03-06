//-------------------------------------------------------------------------------
// <copyright file="EventTopicCollection.cs" company="bbv Software Services AG">
//   Copyright (c) 2008-2011 bbv Software Services AG
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace bbv.Common.MappingEventBrokerExtension
{
    using System.Collections.ObjectModel;

    using bbv.Common.EventBroker.Internals;

    /// <summary>
    /// Specialized keyed collection which used the <see cref="IEventTopicInfo.Uri"/> as key.
    /// </summary>
    public class EventTopicCollection : KeyedCollection<string, IEventTopicInfo>
    {
        /// <summary>
        /// When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <returns>
        /// The key for the specified element.
        /// </returns>
        /// <param name="item">The element from which to extract the key.
        /// </param>
        protected override string GetKeyForItem(IEventTopicInfo item)
        {
            Ensure.ArgumentNotNull(item, "item");

            return item.Uri;
        }
    }
}