ASCOM Switch Driver for Velleman K8056 Relay Module
===================================================

**This driver has been developed by [Tigra Astronomy][tigra], in collaboration with [University of Oxford Department of Astrophysics][uoastro]** as part of an online tutorial on developing ASCOM drivers. I would like to thank Katherine Blundell and Steven Lee of Oxford University for their support and entrusting me with their relay module for the duration of the development.

This driver and its source code are licenesd under the [Tigra MIT license][license]. Essentially, anyone can do anything at all with this software, including commercially, without restriction. Anything you do is your responsibility and not mine.

For further information, please visit the [Project Home Page][project] or the [BitBucket Source Repository][source].

Installation
------------
The installer has a minimal user interface but is fully functional. Upgrades can be installed 'on top of' existing versions and we expect that settings will be preserved in that situation.

The installer has two versions, one for 32-bit (x86) computers and another for 64-bit (x64) computers. The installer checks that it is running on the right type of system and will not allow installation to proceed if it finds a mismatch. This allows our ASCOM drivers to function correctly in all situations and they are compatible with operating systems and applications of all varieties.

==End users should install the `Release` version of the driver. `Debug` versions are for diagnostic use and will have much worse performance than the release build.==

Driver Configuration
--------------------

The driver currently allows configuration only of the Comm Port Name (typically "COM1") via the Setup Dialog. Other serial parameters are configurable but there is no user interface. They can be edited using the *ASCOM Profile Explorer* utility.

Diagnostics
-----------

The driver emits diagnostic information using NLog. It is configured by default to emit verbose diagnostics to the Trace channel. The output can be viewed with a utility such as SysInternals' DebugView, or Binary Fortress' Log Fusion.

Alternatively, the NLog configuration file `NLog.dll.nlog` can be edited to emit logging information to any NLog target, including a file or database. See the [NLog wiki][nlog] for information on configuring NLog.

Feeback and Bugs
----------------

There is a bug tracker at the [BitBucket source repository][source]. Please submit any bug reports and feature requests there.

It would be most helpful if you could quote the full version number of the driver (shown at the bottom of the SetupDialog) when reporting any issues.

Get Involved
------------

There are probably many ways in which this driver could be improved. If you would like to contribute, then we would be delighted to accept your pull request at our [BitBucket source repository][source]. Any source code that you contribute will be covered by the original [Tigra MIT License][license].

If you want to get involved but are not sure what to do, please check the [bug tracker][source] to see if there are any outstanding issues or feature requests that you could work on.

Buy Me a Cup of Coffee
----------------------

Software development is powered by coffee! If you've found this driver useful, or you're just feeling benevolent, then you might consider [buying me a cup of coffee][coffee] (or several cups) using the link at the bottom of my web site. Thank you!

August 2016, Tim Long <Tim@tigra-astronomy.com>

[license]: https://tigra.mit-license.org/		                   "Tigra Astronomy Open Source License"
[project]: http://tigra-astronomy.com/oss/k8056-switch-driver      "Project Home Page at Tigra Astronomy"
[source]:  https://bitbucket.org/tigra-astronomy/ta.vellemank8056  "BitBucket Git Source Control"
[tigra]:   http://tigra-astronomy.com                              "Tigra Astronomy Web Site"
[uoastro]: http://www-astro.physics.ox.ac.uk						"University of Oxford"
[nlog]:    https://github.com/nlog/nlog/wiki/Configuration-file#targets "NLog Targets"
[coffee]:  http://tigra-astronomy.com/#coffee                      "Buy me a cup of coffee"