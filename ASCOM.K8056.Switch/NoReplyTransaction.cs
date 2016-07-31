// This file is part of the TA.VellemanK8056 project
// 
// Copyright © 2015-2016 Tigra Networks., all rights reserved.
// 
// File: NoReplyTransaction.cs  Last modified: 2016-07-31@03:37 by Tim Long

using System;
using System.Collections.Generic;
using System.Text;
using TA.Ascom.ReactiveCommunications;

namespace ASCOM.K8056
    {
    public class NoReplyTransaction : DeviceTransaction
        {
        public NoReplyTransaction(string command) : base(command)
            {
            Timeout = TimeSpan.FromMilliseconds(1); // Very short, as no response is expected.
            }

        public override void ObserveResponse(IObservable<char> source)
            {
            // No reply is expected, so instead of observing the response stream, we immediately complete.
            OnCompleted();
            }

        /// <summary>
        ///     Computes the checksum of the supplied bytes.
        /// </summary>
        /// <param name="bytes">The bytes in the data packet.</param>
        protected internal static byte ComputeChecksum(IEnumerable<byte> bytes)
            {
            byte total = 0;
            foreach (var item in bytes)
                {
                unchecked
                    {
                    total += item;
                    }
                }
            var compliment = (byte) (0x0100 - total);
            return compliment;
            }

        /// <summary>
        ///     Builds a command string for a relay operation complete with checksum.
        /// </summary>
        /// <param name="cardAddress">The card address.</param>
        /// <param name="instruction">The single letter instruction code.</param>
        /// <param name="relayNumber">The relay number, counting from zero.</param>
        /// <returns>A string containing a packet ready to be sent to the serial port (including checksum).</returns>
        protected static string CreateCommand(byte cardAddress, char instruction, ushort relayNumber)
            {
            var command = new List<byte> {0x0D, cardAddress, (byte) instruction, (byte) ('1' + relayNumber)};
            command.Add(ComputeChecksum(command));
            return Encoding.ASCII.GetString(command.ToArray());
            }
        }
    }