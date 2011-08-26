//-------------------------------------------------------------------------------
// <copyright file="IAssignExtensionProperties.cs" company="bbv Software Services AG">
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

namespace bbv.Common.Bootstrapper.Configuration
{
    /// <summary>
    /// Identifies the implemenator as a property assigner for extensions.
    /// </summary>
    public interface IAssignExtensionProperties
    {
        /// <summary>
        /// Automatically assigns the reflector property values on the provided extension properties if a match occurs..
        /// </summary>
        /// <param name="reflector">The reflector.</param>
        /// <param name="extension">The extension.</param>
        /// <param name="consumer">The configuration consumer.</param>
        /// <param name="callbackProvider">The callback provider.</param>
        void Assign(IReflectExtensionProperties reflector, IExtension extension, IConsumeConfiguration consumer, IHaveConversionCallbacks callbackProvider);
    }
}