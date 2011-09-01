//-------------------------------------------------------------------------------
// <copyright file="CustomExtensionBase.cs" company="bbv Software Services AG">
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
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    public class CustomExtensionBase : ICustomExtension
    {
        private static readonly Queue<string> sequenceQueue = new Queue<string>();

        /// <summary>
        /// Gets cleared when accessed.
        /// </summary>
        public static IEnumerable<string> Sequence
        {
            get
            {
                var result = sequenceQueue.ToList();
                sequenceQueue.Clear();

                return result;
            }
        }

        public IDictionary<string, string> RunConfiguration
        {
            get; private set;
        }

        public IDictionary<string, string> ShutdownConfiguration
        {
            get;
            private set;
        }

        public string Registered
        {
            get; private set;
        }

        public string Unregistered
        {
            get;
            private set;
        }

        public void Start()
        {
            this.Dump(MethodBase.GetCurrentMethod().Name);
        }

        public void Configure(IDictionary<string, string> configuration)
        {
            this.Dump(MethodBase.GetCurrentMethod().Name);

            this.RunConfiguration = configuration;
        }

        public void Initialize()
        {
            this.Dump(MethodBase.GetCurrentMethod().Name);
        }

        public void Register(string magic)
        {
            this.Dump(MethodBase.GetCurrentMethod().Name);

            this.Registered = magic;
        }

        public void Unregister(string magic)
        {
            this.Dump(MethodBase.GetCurrentMethod().Name);

            this.Unregistered = magic;
        }

        public void DeConfigure(IDictionary<string, string> configuration)
        {
            this.Dump(MethodBase.GetCurrentMethod().Name);

            this.ShutdownConfiguration = configuration;
        }

        public void Stop()
        {
            this.Dump(MethodBase.GetCurrentMethod().Name);
        }

        public void Dispose()
        {
            this.Dump(MethodBase.GetCurrentMethod().Name);
        }

        internal static void DumpAction(string actionName)
        {
            sequenceQueue.Enqueue(string.Format(CultureInfo.InvariantCulture, "Action: {0}", actionName));
        }

        private void Dump(string methodName)
        {
            sequenceQueue.Enqueue(string.Format(CultureInfo.InvariantCulture, "{0}: {1}", this.GetType().Name, methodName));
        }
    }
}