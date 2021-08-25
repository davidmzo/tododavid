using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using tododavid.Functions.Functions;
using tododavid.Test.Helpers;
using tododavid.Tests.Helpers;
using Xunit;

namespace tododavid.Tests.Test
{
    
    public class ScheduledFunctionTest
    {
        [Fact]
        public void ScheduledFunction_Should_Log_Message()
        {
            // Arrage
            MockCloudTablesTodos mockTodos = new MockCloudTablesTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            ListLogger logger = (ListLogger)TestFactory.CreateLogger(LoggerTypes.List);

            // Act
            ScheduleFunction.Run(null, mockTodos, logger);
            string message = logger.Logs[0];

            // Assert
            Assert.Contains("Deleting completed", message);
        }
    }
}
