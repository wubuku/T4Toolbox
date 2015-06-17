// <copyright file="SyntaxNodeTest.cs" company="Oleg Sych">
//  Copyright © Oleg Sych. All Rights Reserved.
// </copyright>

namespace T4Toolbox.TemplateAnalysis
{
    using System.ComponentModel;
    using System.Linq;
    using Microsoft.VisualStudio.Text;
    using NSubstitute;
    using Xunit;

    public static class SyntaxNodeTest
    {
        public static new class Equals
        {
            [Theory, TestConventions]
            internal static void ReturnsTrueWhenKindIsSame(SyntaxKind kind)
            {
                var left = Testable<SyntaxNode>(kind);
                var right = Testable<SyntaxNode>(kind);
                Assert.True(left.Equals(right));
            }

            [Theory, TestConventions]
            internal static void ReturnsFalseWhenKindIsDifferent(SyntaxKind kind1, SyntaxKind kind2)
            {
                var left = Testable<SyntaxNode>(kind1);
                var right = Testable<SyntaxNode>(kind2);
                Assert.False(left.Equals(right));
            }

            [Theory, TestConventions]
            internal static void ReturnsTrueWhenPositionIsSame(Position position)
            {
                var left = Testable<SyntaxNode>(position);
                var right = Testable<SyntaxNode>(position);
                Assert.True(left.Equals(right));
            }

            [Theory, TestConventions]
            internal static void ReturnsFalseWhenPositionIsDifferent(Position position1, Position position2)
            {
                var left = Testable<SyntaxNode>(position1);
                var right = Testable<SyntaxNode>(position2);
                Assert.False(left.Equals(right));
            }

            [Theory, TestConventions]
            internal static void ReturnsTrueWhenSpanIsSame(Span span)
            {
                var left = Testable<SyntaxNode>(span);
                var right = Testable<SyntaxNode>(span);
                Assert.True(left.Equals(right));
            }

            [Theory, TestConventions]
            internal static void ReturnsFalseWhenSpanIsDifferent(Span span1, Span span2)
            {
                var left = Testable<SyntaxNode>(span1);
                var right = Testable<SyntaxNode>(span2);
                Assert.False(left.Equals(right));
            }

            [Theory, TestConventions]
            internal static void ReturnsTrueWhenChildNodesAreSame(SyntaxKind kind)
            {
                var left = Testable<SyntaxNode>(Testable<SyntaxNode>(kind), Testable<SyntaxNode>(kind));
                var right = Testable<SyntaxNode>(Testable<SyntaxNode>(kind), Testable<SyntaxNode>(kind));
                Assert.True(left.Equals(right));
            }

            [Theory, TestConventions]
            internal static void ReturnsFalseWhenChildNodesAreDifferent(SyntaxNode child1, SyntaxNode child2)
            {
                var left = Testable<SyntaxNode>(child1);
                var right = Testable<SyntaxNode>(child2);
                Assert.False(left.Equals(right));
            }
        }

        public static new class GetHashCode
        {
            [Theory, TestConventions]
            internal static void GetHashCodeReturnsSameValuesForSamePositions(Position position)
            {
                var n1 = Testable<SyntaxNode>(position);
                var n2 = Testable<SyntaxNode>(position);
                Assert.Equal(n1.GetHashCode(), n2.GetHashCode());
            }

            [Theory, TestConventions]
            internal static void GetHashCodeReturnsDifferentValuesForDifferentPositions(Position position1, Position position2)
            {
                var n1 = Testable<SyntaxNode>(position1);
                var n2 = Testable<SyntaxNode>(position2);
                Assert.NotEqual(n1.GetHashCode(), n2.GetHashCode());
            }
        }

        public static class GetText
        {
            [Fact]
            public static void ReturnsSubstringOfTemplateBasedOnSpan()
            {
                var node = Testable<SyntaxNode>(new Span(4, 9));
                Assert.Equal("directive", node.GetText("<#@ directive #>"));
            }
        }

        public static class TryGetDescription
        {
            [Theory, TestConventions]
            internal static void ReturnsEmptyDescriptionAndSpanGivenPositionOutsideOfItsSpan(Span span)
            {
                var target = Testable<SyntaxNode>(span);
                string description;
                Span applicableTo;
                Assert.False(target.TryGetDescription(span.End + 1, out description, out applicableTo));
                Assert.Empty(description);
                Assert.Equal(default(Span), applicableTo);
            }

            [Theory, TestConventions]
            internal static void ReturnsEmptyDescriptionAndSpanWhenNodeHasNoDescriptionAttributeAndNoChildren(Span span)
            {
                var target = Testable<SyntaxNode>(span);
                string description;
                Span applicableTo;
                Assert.False(target.TryGetDescription(span.Start, out description, out applicableTo));
                Assert.Empty(description);
                Assert.Equal(default(Span), applicableTo);
            }

            [Theory, TestConventions]
            internal static void ReturnsDescriptionAndSpanOfNodeWhenNodeHasNoChildren(Span span)
            {
                var target = Testable<SyntaxNodeWithDescription>(span);
                var attribute = typeof(SyntaxNodeWithDescription).GetCustomAttributes(false).OfType<DescriptionAttribute>().Single();
                string description;
                Span applicableTo;
                Assert.True(target.TryGetDescription(span.Start, out description, out applicableTo));
                Assert.Equal(attribute.Description, description);
                Assert.Equal(span, applicableTo);
            }

            [Theory, TestConventions]
            internal static void ReturnsDescriptionAndSpanOfChildNodeWhoseSpanContainsGivenPosition(Span span)
            {
                var child = Testable<SyntaxNodeWithDescription>(span);
                var parent = Testable<SyntaxNode>(child);

                string description;
                Span applicableTo;
                Assert.True(parent.TryGetDescription(span.Start, out description, out applicableTo));

                var childAttribute = typeof(SyntaxNodeWithDescription).GetCustomAttributes(false).OfType<DescriptionAttribute>().Single();
                Assert.Equal(childAttribute.Description, description);
                Assert.Equal(child.Span, applicableTo);
            }

            [Theory, TestConventions]
            internal static void ReturnsDescriptionAndSpanOfParentIfChildsDescriptionIsEmpty(Span span)
            {
                var child = Testable<SyntaxNode>(span);
                var parent = Testable<SyntaxNodeWithDescription>(child);

                string description;
                Span applicableTo;
                Assert.True(parent.TryGetDescription(span.Start, out description, out applicableTo));

                var parentAttribute = typeof(SyntaxNodeWithDescription).GetCustomAttributes(false).OfType<DescriptionAttribute>().Single();
                Assert.Equal(parentAttribute.Description, description);
                Assert.Equal(parent.Span, applicableTo);
            }
        }

        private static T Testable<T>(SyntaxKind kind) where T : SyntaxNode
        {
            T node = Substitute.ForPartsOf<T>();
            node.Kind.Returns(kind);
            return node;
        }

        private static T Testable<T>(Position position) where T : SyntaxNode
        {
            T node = Substitute.ForPartsOf<T>();
            node.Position.Returns(position);
            return node;
        }

        private static T Testable<T>(Span span) where T : SyntaxNode
        {
            T node = Substitute.ForPartsOf<T>();
            node.Span.Returns(span);
            return node;
        }

        private static T Testable<T>(params SyntaxNode[] childNodes) where T : SyntaxNode
        {
            T node = Testable<T>(Span.FromBounds(childNodes.First().Span.Start, childNodes.Last().Span.End));
            node.ChildNodes().Returns(childNodes);
            return node;
        }

        [Description("Description of TestableSyntaxNodeWithDescription")]
        internal abstract class SyntaxNodeWithDescription : SyntaxNode
        {
        }
    }
}