// This file is part of the ASCOM.K8056.Switch project
// 
// Copyright © 2016-2016 Tigra Astronomy, all rights reserved.
// Licensed under the MIT license, see http://tigra.mit-license.org/
// 
// File: TransactionTests.cs  Last modified: 2016-06-28@00:52 by Tim Long

using System.Collections.Generic;
using ASCOM.K8056;
using FluentAssertions;
using Xunit;

namespace Namespace
    {
    public class ChecksumTests
        {
        [Fact]
        public void ChecksumComputationGivesExpectedResult()
            {
            var input = new List<byte> {0x0A, 0xAE, 0x00, 0x00, 0x46, 0x31, 0x30, 0x00, 0x41, 0x44, 0x43, 0x00, 0x00};
            byte expectedChecksum = 0xD9;
            var actualChecksum = NoReplyTransaction.ComputeChecksum(input);
            actualChecksum.Should().Be(expectedChecksum);
            }
        }
    }