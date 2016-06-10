// This file is part of the ASCOM.K8056.Switch project
// 
// Copyright © 2015-2016 Tigra Networks., all rights reserved.
// 
// File: CommandSpecs.cs  Last modified: 2016-06-10@08:53 by Tim Long

using Machine.Specifications;

namespace ASCOM.K8056.Switch.Specifications
    {
    [Subject(typeof(Command), "Checksum")]
    class when_computing_a_checksum_for_a_command_that_is_all_zeroes
        {
        static Command cmd;
        Establish context = () => { };
        Because of = () => cmd = new Command();
        It should_do_something;
        It should_do_something_else;
        }

    class Command {}
    }