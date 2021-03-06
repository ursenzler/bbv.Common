//-------------------------------------------------------------------------------
// <copyright file="IFileAccess.cs" company="bbv Software Services AG">
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

namespace bbv.Common.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.AccessControl;
    using System.Text;

#pragma warning disable 1734

    /// <summary>
    /// Interface which simplifies the access to the file system.
    /// </summary>
    public interface IFileAccess
    {
        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.Delete(System.String)"]/*' />
        void Delete(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.Copy(System.String,System.String)"]/*' />
        void Copy(string sourceFileName, string destFileName);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.Copy(System.String,System.String,System.Boolean)"]/*' />
        void Copy(string sourceFileName, string destFileName, bool overwrite);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.CreateText(System.String)"]/*' />
        StreamWriter CreateText(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.GetAttributes(System.String)"]/*' />
        FileAttributes GetAttributes(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.SetLastWriteTime(System.String,System.DateTime)"]/*' />
        void SetLastWriteTime(string path, DateTime lastWriteTime);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.SetAttributes(System.String,System.IO.FileAttributes)"]/*' />
        void SetAttributes(string path, FileAttributes fileAttributes);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.Exists(System.String)"]/*' />
        bool Exists(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.ReadAllBytes(System.String)"]/*' />
        IEnumerable<byte> ReadAllBytes(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.ReadAllLines(System.String,System.Text.Encoding)"]/*' />
        IEnumerable<string> ReadAllLines(string path, Encoding encoding);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.ReadAllLines(System.String)"]/*' />
        IEnumerable<string> ReadAllLines(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.ReadAllText(System.String,System.Text.Encoding)"]/*' />
        string ReadAllText(string path, Encoding encoding);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.ReadAllText(System.String)"]/*' />
        string ReadAllText(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.WriteAllLines(System.String,System.String[],System.Text.Encoding)"]/*' />
        void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.WriteAllLines(System.String,System.String[])"]/*' />
        void WriteAllLines(string path, IEnumerable<string> contents);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.WriteAllText(System.String,System.String)"]/*' />
        void WriteAllText(string path, string contents);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.WriteAllText(System.String,System.String,System.Text.Encoding)"]/*' />
        void WriteAllText(string path, string contents, Encoding encoding);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.WriteAllBytes(System.String,System.Byte[])"]/*' />
        void WriteAllBytes(string path, IEnumerable<byte> bytes);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.Open(System.String,System.IO.FileMode)"]/*' />
        Stream Open(string path, FileMode mode);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.Open(System.String,System.IO.FileMode,System.IO.FileAccess)"]/*' />
        Stream Open(string path, FileMode mode, FileAccess access);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.Open(System.String,System.IO.FileMode,System.IO.FileAccess,System.IO.FileShare)"]/*' />
        Stream Open(string path, FileMode mode, FileAccess access, FileShare share);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.AppendAllText(System.String,System.String)"]/*' />
        void AppendAllText(string path, string contents);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.AppendAllText(System.String,System.String,System.Text.Encoding)"]/*' />
        void AppendAllText(string path, string contents, Encoding encoding);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.AppendText(System.String)"]/*' />
        StreamWriter AppendText(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.Create(System.String)"]/*' />
        Stream Create(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.Create(System.String,System.Int32)"]/*' />
        Stream Create(string path, int bufferSize);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.Create(System.String,System.Int32,System.IO.FileOptions)"]/*' />
        Stream Create(string path, int bufferSize, FileOptions options);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.Create(System.String,System.Int32,System.IO.FileOptions,System.Security.AccessControl.FileSecurity)"]/*' />
        Stream Create(string path, int bufferSize, FileOptions options, FileSecurity fileSecurity);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.Decrypt(System.String)"]/*' />
        void Decrypt(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.Encrypt(System.String)"]/*' />
        void Encrypt(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.GetAccessControl(System.String)"]/*' />
        FileSecurity GetAccessControl(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.GetAccessControl(System.String,System.Security.AccessControl.AccessControlSections)"]/*' />
        FileSecurity GetAccessControl(string path, AccessControlSections includeSections);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.GetCreationTime(System.String)"]/*' />
        DateTime GetCreationTime(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.GetCreationTimeUtc(System.String)"]/*' />
        DateTime GetCreationTimeUtc(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.GetLastAccessTime(System.String)"]/*' />
        DateTime GetLastAccessTime(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.GetLastAccessTimeUtc(System.String)"]/*' />
        DateTime GetLastAccessTimeUtc(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.GetLastWriteTime(System.String)"]/*' />
        DateTime GetLastWriteTime(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.GetLastWriteTimeUtc(System.String)"]/*' />
        DateTime GetLastWriteTimeUtc(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.Move(System.String,System.String)"]/*' />
        void Move(string sourceFileName, string destFileName);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.OpenRead(System.String)"]/*' />
        Stream OpenRead(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.OpenText(System.String)"]/*' />
        StreamReader OpenText(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.OpenWrite(System.String)"]/*' />
        Stream OpenWrite(string path);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.Replace(System.String,System.String,System.String)"]/*' />
        void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.Replace(System.String,System.String,System.String,System.Boolean)"]/*' />
        void Replace(
            string sourceFileName,
            string destinationFileName,
            string destinationBackupFileName,
            bool ignoreMetadataErrors);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.SetAccessControl(System.String,System.Security.AccessControl.FileSecurity)"]/*' />
        void SetAccessControl(string path, FileSecurity fileSecurity);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.SetCreationTime(System.String,System.DateTime)"]/*' />
        void SetCreationTime(string path, DateTime creationTime);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.SetCreationTimeUtc(System.String,System.DateTime)"]/*' />
        void SetCreationTimeUtc(string path, DateTime creationTimeUtc);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.SetLastAccessTime(System.String,System.DateTime)"]/*' />
        void SetLastAccessTime(string path, DateTime lastAccessTime);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.SetLastAccessTimeUtc(System.String,System.DateTime)"]/*' />
        void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);

        /// <include file='mscorlib.xml' path='/doc/members/member[@name="M:System.IO.File.SetLastWriteTimeUtc(System.String,System.DateTime)"]/*' />
        void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
    }

#pragma warning restore 1734
}