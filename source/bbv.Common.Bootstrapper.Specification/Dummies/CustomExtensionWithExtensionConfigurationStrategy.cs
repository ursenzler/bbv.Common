//-------------------------------------------------------------------------------
// <copyright file="CustomExtensionWithExtensionConfigurationStrategy.cs" company="bbv Software Services AG">
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

namespace bbv.Common.Bootstrapper.Specification.Dummies
{
    using bbv.Common.Bootstrapper.Configuration;
    using bbv.Common.Bootstrapper.Syntax;

    public class CustomExtensionWithExtensionConfigurationStrategy : AbstractStrategy<ICustomExtensionWithExtensionConfiguration>
    {
        protected override void DefineRunSyntax(ISyntaxBuilder<ICustomExtensionWithExtensionConfiguration> builder)
        {
            builder.Begin.With(new ExtensionConfigurationSectionBehavior());
        }

        protected override void DefineShutdownSyntax(ISyntaxBuilder<ICustomExtensionWithExtensionConfiguration> builder)
        {
        }
    }
}