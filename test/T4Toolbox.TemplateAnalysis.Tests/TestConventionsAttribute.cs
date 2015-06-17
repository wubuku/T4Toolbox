// <copyright file="TestConventionsAttribute.cs" company="Oleg Sych">
//  Copyright © Oleg Sych. All Rights Reserved.
// </copyright>

namespace T4Toolbox.TemplateAnalysis
{
    using System;
    using Ploeh.AutoFixture.AutoNSubstitute;
    using Ploeh.AutoFixture.Xunit2;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class TestConventionsAttribute : AutoDataAttribute
    {
        public TestConventionsAttribute()
        {
            this.Fixture.Customize(new AutoConfiguredNSubstituteCustomization());
        }
    }
}
