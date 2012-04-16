﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using FluentAssertions;
using FluentAssertions.Assertions;
using System.Diagnostics;

namespace FluentAssertions.Mvc3
{
    [DebuggerNonUserCode]
    public class RouteDataAssertions : ObjectAssertions
    {
        public RouteDataAssertions(RouteData subject)
            : base(subject)
        {
            Subject = subject;
        }

        public RouteDataAssertions HaveController(string expectedControllerName)
        {
            HaveController(expectedControllerName, string.Empty, null);
            return this;
        }

        public RouteDataAssertions HaveController(string expectedControllerName, string reason, params object[] reasonArgs)
        {
            HaveValue("controller", expectedControllerName, reason, reasonArgs);
            return this;
        }

        public RouteDataAssertions HaveAction(string expectedActionName)
        {
            HaveAction(expectedActionName, string.Empty, null);
            return this;
        }

        public RouteDataAssertions HaveAction(string expectedActionName, string reason, params object[] reasonArgs)
        {
            HaveValue("action", expectedActionName, reason, reasonArgs);
            return this;
        }

        public RouteDataAssertions HaveDataToken(string key, object expectedValue)
        {
            HaveDataToken(key, expectedValue, string.Empty, null);
            return this;
        }

        public RouteDataAssertions HaveDataToken(string key, object expectedValue, string reason, params object[] reasonArgs)
        {
            var subjectTyped = Subject as RouteData;

            Execute.Verification
                    .ForCondition(subjectTyped.DataTokens.ContainsKey(key))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith("RouteData.DataTokens does not contain key '{0}'", key);

            var actualValue = subjectTyped.DataTokens[key];
            actualValue.Should().Be(expectedValue);

            return this;
        }

        public RouteDataAssertions HaveValue(string key, object expectedValue)
        {
            HaveValue(key, expectedValue, string.Empty, null);
            return this;
        }

        public RouteDataAssertions HaveValue(string key, object expectedValue, string reason, params object[] reasonArgs)
        {
            var subjectTyped = Subject as RouteData;

            Execute.Verification
                    .ForCondition(subjectTyped.Values.ContainsKey(key))
                    .BecauseOf(reason, reasonArgs)
                    .FailWith("RouteData.Values does not contain key '{0}'", key);

            var actualValue = subjectTyped.Values[key];
            actualValue.Should().Be(expectedValue);

            return this;
        }
    }
}
