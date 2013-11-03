using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SunlightAPI;
using SunlightAPI.CapitolWords;

namespace SunlightAPITests
{
    [TestClass]
    public class EquatableTests
    {
        [TestMethod]
        public void LikeObjectsAreEqualBecausePropertyValues()
        {
            var l = new PhraseResult()
            {
                count = 10,
                ngram = "hi",
                tfidf = 0.0001
            };

            var r = new PhraseResult()
            {
                count = 10,
                ngram = "hi",
                tfidf = 0.0001
            };

            Assert.AreEqual(l, r);
        }

        [TestMethod]
        public void UnlikeObjectsAreNotEqualBecausePropertyValues()
        {
            var l = new PhraseResult()
            {
                count = 10,
                ngram = "hi",
                tfidf = 0.0001
            };

            var r = new PhraseResult()
            {
                count = 10,
                ngram = "ho",
                tfidf = 0.0001
            };

            Assert.AreNotEqual(l, r);
        }

        [TestMethod]
        public void LikeObjectsAreEqualBecauseSameReference()
        {
            var l = new PhraseResult()
            {
                count = 10,
                ngram = "hi",
                tfidf = 0.0001
            };

            Assert.AreEqual(l, l);
        }

        [TestMethod]
        public void UnlikeObjectsAreNotEqualBecauseOfType()
        {
            var l = new PhraseResult()
            {
                count = 10,
            };
            var r = new VolumeResult()
            {
                count = 10,
            };
            Assert.AreNotEqual(l, r);
        }

        [TestMethod]
        public void AnInstanceIsNotEqualToNull()
        {
            var l = new PhraseResult()
            {
                count = 10,
            };

            Assert.AreNotEqual(l, null);
        }

        public void LikeObjectsHaveSameHash()
        {
            var l = new PhraseResult()
            {
                count = 10,
                ngram = "hi",
                tfidf = 0.0001
            };

            var r = new PhraseResult()
            {
                count = 10,
                ngram = "hi",
                tfidf = 0.0001
            };

            Assert.AreEqual(l.GetHashCode(), r.GetHashCode());
        }

        [TestMethod]
        public void UnlikeObjectsHaveDifferentHash()
        {
            var l = new PhraseResult()
            {
                count = 10,
                ngram = "hi",
                tfidf = 0.0001
            };

            var r = new PhraseResult()
            {
                count = 10,
                ngram = "ho",
                tfidf = 0.0001
            };

            Assert.AreNotEqual(l.GetHashCode(), r.GetHashCode());
        }
    }
}
