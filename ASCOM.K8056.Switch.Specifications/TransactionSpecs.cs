// This file is part of the ASCOM.K8056.Switch project
// 
// Copyright © 2016-2016 Tigra Astronomy, all rights reserved.
// Licensed under the MIT license, see http://tigra.mit-license.org/
// 
// File: TransactionSpecs.cs  Last modified: 2016-06-28@00:42 by Tim Long

using System.Collections.Generic;
using ASCOM.K8056;
using Machine.Specifications;

namespace Namespace
    {
    [Subject(typeof(NoReplyTransaction))]
    public class when_computing_a_twos_compliment_checksum_of_bytes
        {
        Establish context = () =>
            {
            input = new List<byte> {0x0A, 0xAE, 0x00, 0x00, 0x46, 0x31, 0x30, 0x00, 0x41, 0x44, 0x43, 0x00, 0x00};
            expectedChecksum = 0xD9;
            };

        Because of = () => actualChecksum = NoReplyTransaction.ComputeChecksum(input);

        It should_give_the_expected_checksum = () => actualChecksum.ShouldEqual(expectedChecksum);
        static byte actualChecksum;
        static int expectedChecksum;
        static List<byte> input;
        }
    }