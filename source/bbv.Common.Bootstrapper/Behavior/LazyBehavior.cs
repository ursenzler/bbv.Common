//-------------------------------------------------------------------------------
// <copyright file="LazyBehavior.cs" company="bbv Software Services AG">
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

namespace bbv.Common.Bootstrapper.Behavior
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The lazy behavior is responsible for creating a behavior at the time of the behave call.
    /// </summary>
    /// <typeparam name="TExtension">The type of the extension.</typeparam>
    public class LazyBehavior<TExtension> : IBehavior<TExtension>
        where TExtension : IExtension
    {
        private readonly Func<IBehavior<TExtension>> behaviorProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="LazyBehavior&lt;TExtension&gt;"/> class.
        /// </summary>
        /// <param name="behaviorProvider">The behavior provider.</param>
        public LazyBehavior(Func<IBehavior<TExtension>> behaviorProvider)
        {
            this.behaviorProvider = behaviorProvider;
        }

        /// <inheritdoc />
        /// <remarks>Creates the behavior with the specified behavior provider and executes behave on the lazy initialized behavior.</remarks>
        public void Behave(IEnumerable<TExtension> extensions)
        {
            IBehavior<TExtension> behavior = this.behaviorProvider();

            behavior.Behave(extensions);
        }
    }
}