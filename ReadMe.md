Pre-release Software
====================
ASCOM Driver for Velleman K8056 Relay Module
--------------------------------------------

**This driver has been developed by [Tigra Astronomy][tigra], in collaboration with [University of Oxford Department of Astrophysics][uoastro]** as part of an online tutorial on developing ASCOM drivers.

The driver and its source code is licenesd under the MIT license, for details please see the [Tigra Astronomy MIT License][license].

For further information, please visit the [Project Home Page][project] or the [BitBucket Source Repository][source].

This is pre-release alpha quality software. It may:
- Be incomplete
- Contain bugs
- Have missing features
- Crash

Installation
------------
The installer currently has limited user interface but is otherwise fully functional. Upgrades can be installed 'on top of' existing versions and we expect that settings will be preserved in that situation.

The installer has two versions, one for 32-bit (x86) computers and another for 64-bit (x64) computers. The installer checks that it is running on the right type of system and will not allow installation to proceed if it finds a mismatch. This allows our ASCOM drivers to function correctly in all situations and they are compatible with operating systems and applications of all varieties.

Driver Configuration
--------------------

The driver currently has a rudimentary user interface for configuration (the ASCOM "Setup Dialog") but it is not really functional in this build. The driver defaults to using COM1 and serial parameters that are appropriate for the Velleman module (2400 baud, 8 bit, no parity, etc.). If this setting needs to be changed, the simplest way to do that currently is to run the ASCOM Profile Explorer and eddit the value of the `ConnectionString` setting. The `CommPortName` setting currently doesn't do anything.

[license]: https://tigra.mit-license.org/		                   "Tigra Astronomy Open Source License"
[project]: http://tigra-astronomy.com/oss/k8056-switch-driver      "Project Home Page at Tigra Astronomy"
[source]:  https://bitbucket.org/tigra-astronomy/ta.vellemank8056  "BitBucket Git Source Control"
[tigra]:   http://tigra-astronomy.com                              "Tigra Astronomy Web Site"
[uoastro]: http://www-astro.physics.ox.ac.uk						"University of Oxford"