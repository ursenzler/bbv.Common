//-------------------------------------------------------------------------------
// <copyright file="CsvParser.cs" company="bbv Software Services AG">
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

namespace bbv.Common.Data
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Parser for CSV files.
    /// </summary>
    public class CsvParser
    {
        /// <summary>
        /// The state the parser is in.
        /// </summary>
        private enum State : byte
        {
            /// <summary>Start state</summary>
            Start,

            /// <summary>A string contained in " detected.</summary>
            ColumnStartString,

            /// <summary>A simple value detected</summary>
            ColumnStartValue,

            /// <summary>Parsed a quote.</summary>
            Quote,

            /// <summary>End of column reached.</summary>
            ColumnEnd,

            /// <summary>Parse error.</summary>
            Error
        }

        /// <summary>
        /// Parses a csv string line.
        /// </summary>
        /// <param name="line">A csv line.</param>
        /// <returns>A string array with the parsed values.</returns>
        public string[] Parse(string line)
        {
            return this.Parse(line, ',');
        }

        /// <summary>
        /// Parses a csv string line.
        /// <code>
        ///                                              ┌────────┐
        ///                   "┌─────────────────────────│ Start  │──────┐*
        ///      ┌──┐          │                         └────────┘      │        ┌──┐ 
        ///      │  │*         │                             │           │        │  │*
        ///      ▼  │          ▼                             │           ▼        ▼  │ 
        ///     ┌───────────────────┐      "                 │      ┌──────────────────┐
        ///     │ ColumnStartString │◄───────────────────┐   │      │ ColumnStartValue │
        ///     └───────────────────┘                    │   │      └──────────────────┘
        ///      │              ▲                        │   │                  ▲
        ///      │EOL|EOF       │"                       │   │,|EOL|EOF         │
        ///      ▼              ▼                        │   ▼                  │*
        /// ┌────────┐   *    ┌─────────────┐,|EOL|EOF ┌───────────┐◄───────────┘
        /// │ Error  │◄────── │ " in string │─────────►│ ColumnEnd │,|EOL|EOF
        /// └────────┘        └─────────────┘          └───────────┘  
        ///                                          Null│      │ ▲
        ///                                              ▼      │ │,|EOL|EOF
        ///                                          ┌────────┐ └─┘
        ///                                          │ Finish │
        ///                                          └────────┘
        /// </code>
        /// </summary>
        /// <param name="line">A csv line.</param>
        /// <param name="separator">The separator of this line. As example coma.</param>
        /// <returns>A string array with the parsed values.</returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1631:DocumentationMustMeetCharacterPercentage", Justification = "Reviewed. ASCII Art.")]
        public string[] Parse(string line, char separator)
        {
            State state = State.Start;
            List<string> row = new List<string>();
            StringBuilder column = new StringBuilder(line.Length);
            int position = 0; // remember position in line for error messages
            foreach (char c in line)
            {
                position++;

                switch (state)
                {
                    case State.Start:
                        if (c == '"')
                        {
                            state = State.ColumnStartString;
                        }
                        else if (c == separator)
                        {
                            state = State.ColumnEnd;
                        }
                        else
                        {
                            state = State.ColumnStartValue;
                            column.Append(c);
                        }

                        break;

                    case State.ColumnStartString:
                        if (c == '"')
                        {
                            state = State.Quote;
                        }
                        else
                        {
                            column.Append(c);
                        }

                        break;

                    case State.ColumnStartValue:
                        if (c == separator)
                        {
                            state = State.ColumnEnd;
                        }
                        else
                        {
                            column.Append(c);
                        }

                        break;

                    case State.Quote:
                        if (c == '"')
                        {
                            column.Append(c);
                            state = State.ColumnStartString;
                        }
                        else if (c == separator)
                        {
                            state = State.ColumnEnd;
                        }
                        else
                        {
                            state = State.Error;
                        }

                        break;

                    case State.ColumnEnd:
                        if (c == '"')
                        {
                            state = State.ColumnStartString;
                        }
                        else if (c == separator)
                        {
                            state = State.ColumnEnd;
                        }
                        else
                        {
                            state = State.ColumnStartValue;
                            column.Append(c);
                        }

                        break;

                    case State.Error:
                        throw new CsvParseException(
                            line, position, "A string must be followed by a separator, EOL or EOF");
                }

                if (state == State.ColumnEnd)
                {
                    row.Add(column.ToString());
                    column.Length = 0;
                }
            }

            // state == State.ColumnEnd means the line ended with a seperator, column not empty means line ended with an unquoted value
            if (state == State.ColumnEnd || column.Length > 0)
            {
                row.Add(column.ToString());
            }

            if (state == State.ColumnStartString)
            {
                throw new CsvParseException(line, position, "String must be closed by a quote.");
            }

            return row.ToArray();
        }
    }
}