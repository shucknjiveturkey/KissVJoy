KissVJoy
============

Use your transmitter as a joystick with Kiss FC and vJoy.
KissVJoy can also read the rates/expo settings on a KissFC and allows us to have the exact same rates/expo that are on a KissFC setup.

It uses vJoy as a virtual joystick driver and feeds it with RC data from a Kiss Flight controller.
A huge thanks to bitworking. I forked his repo (from: https://github.com/bitworking/MultiWiiVJoy) so most of the work is made by him.

1. Install vJoy https://sourceforge.net/projects/vjoystick/files/latest/download
2. Grab the KissVJoy executable from https://github.com/vever001/KissVJoy/releases (or get the sources and compile it), extract and run it.
3. Connect to the KISS FC with KissVJoy. (Choose the right COM-Port)
4. Turn on your transmitter (If you move the sticks you should see the movement)
5. Run your flying simulator and choose the joystick interface.
6. Calibrate/configure the joystick/transmitter as usual and FLY.


I tested the following sims:

FPV Event PE
------------
My favorite sim so far ;)
Use their USB Interface Utility to map vJoy axis as explained.
In game, hit "c" on your keyboard.
For the rates (deg/s) input corresponding values displayed in Kiss vJoy for each axis.
Apply the KissFC expo by making sure "Enable expo from FC" is ticked in Kiss vJoy. And set expo to 0% for all axis in the game.

FPV Freerider Recharged
-----------------------
In custom settings, change "Expo is on" to "Linear (experts only)".
Apply the KissFC expo by making sure "Enable expo from FC" is ticked in Kiss vJoy.

FPV Freerider (Classic)
-----------------------
Make sure you have the last version so you can disable the expo just like in Recharged (see above).

Hotprops
--------
For the rates get the values from Kiss vJoy - Rates (deg/sec) - and divide them by 2000. Input that in Hotprops in setup menu. Repeat for each axis.
Apply the KissFC expo by making sure "Enable expo from FC" is ticked in Kiss vJoy. And set all expo to 1 (= no expo) in Hotprops. 

Liftoff
-------
In game, hit ESC on your keyboard.
For the rates (deg/s) input corresponding values displayed in Kiss vJoy for each axis.
Apply the KissFC expo by making sure "Enable expo from FC" is ticked in Kiss vJoy. And set expo to 1 (linear) for all axis in the game.

DRL
---
Reverse pitch axis only, start the game with centered joysticks.


