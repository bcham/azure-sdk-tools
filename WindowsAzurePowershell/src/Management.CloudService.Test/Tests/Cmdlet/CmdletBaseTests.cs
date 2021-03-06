﻿// ----------------------------------------------------------------------------------
//
// Copyright 2011 Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Management.CloudService.Test.Tests.Cmdlet
{
    using System;
    using Cmdlets.Common;
    using Management.Utilities;
    using Microsoft.Samples.WindowsAzure.ServiceManagement;
    using Utilities;
    using VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CmdletBaseTests
    {
        [TestMethod]
        public void SafeWriteObjectWritesToWriter()
        {
            var writer = new FakeWriter();
            var cmd = new FakeCmdlet(writer);
            cmd.Write("Test");
            Assert.AreEqual("Test", writer.Messages[0]);
        }

    }

    public class FakeCmdlet : CloudBaseCmdlet<IServiceManagement>
    {
        public FakeCmdlet(IMessageWriter writer) : base(writer)
        {
            
        }

        public void Write(string message)
        {
            SafeWriteObject(message);
        }

        protected override IServiceManagement CreateChannel()
        {
            throw new NotImplementedException();
        }
    }
}
