# OSI-Collimation-Modified-190708
some Modifications to make the OSI(OffScreenIndicator) Plugin more functional

scenes/NewRadar.unity



default 5 cubes 
E to initialize new "Addedcube"

check the view in Vive then editor scene, check the indicator plane and you will understand how i did it. Quite tricky way and far away from flawless.
i'm still working on this, but here is my process.

basicly, i duplicate the Steamvr camera(head) as left/right eye, and the camera(eye)s are the render cameras(steamvr feature). Another(3rd) camera(head) as maincamera.

camera(head)s both tracking as hmd, childs(eye) add the indicator script. specify the left/right eye in scripts in inspector, modify the camera clearflag, culling mask(left/right eye) and depth bigger than maincamera(overlay on any other elements).
the maincamera culling mask uncheck the left/right.

one debugging script on CameraRig object just like DemoScript but initialize two offscreenindicators.

you can check this with one eye open and the other closed, or just change the indicator color for each eye.


if there's anything unclear open an issue or just contact me
