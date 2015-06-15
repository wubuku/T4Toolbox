﻿// <copyright file="TemplateCompletionHandlerTest.cs" company="Oleg Sych">
//  Copyright © Oleg Sych. All Rights Reserved.
// </copyright>

namespace T4Toolbox.VisualStudio.Editor
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.OLE.Interop;
    using NSubstitute;
    using Xunit;

    public class TemplateCompletionHandlerTest
    {
        [Fact]
        public void TemplateCompletionHandlerIsInternalBecauseItIsOnlyMeantToBeImportedByVisualStudio()
        {
            Assert.False(typeof(TemplateCompletionHandler).IsPublic);
        }

        [Fact]
        public void TemplateCompletionHandlerIsSealedBecauseItIsNotMeantToHaveChildClasses()
        {
            Assert.True(typeof(TemplateCompletionHandler).IsSealed);
        }

        [Fact]
        public void TemplateCompletionHandlerImplementsIOleCommandTargetToInterceptKeystrokes()
        {
            Assert.Equal(typeof(IOleCommandTarget), typeof(TemplateCompletionHandler).GetInterfaces()[0]);
        }

        [Fact(Skip = "Not Implemented")]
        public void TestExecMethod()
        {
            // TODO: Test this
        }

        [SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "Microsoft.VisualStudio.OLE.Interop.IOleCommandTarget.QueryStatus(System.Guid@,System.UInt32,Microsoft.VisualStudio.OLE.Interop.OLECMD[],System.IntPtr)", Justification = "This test does not call QueryStatus, it only asserts it was called.")]
        [Fact]
        public void QueryStatusCallsNextCommandTargetToSupportDefaultCommandHandling()
        {
            var nextHandler = Substitute.For<IOleCommandTarget>();
            var handler = new TemplateCompletionHandler { NextHandler = nextHandler };

            Guid commandGroup = Guid.Empty;
            handler.QueryStatus(ref commandGroup, 0, null, IntPtr.Zero);

            nextHandler.Received().QueryStatus(ref commandGroup, 0, null, IntPtr.Zero);
        }
    }
}