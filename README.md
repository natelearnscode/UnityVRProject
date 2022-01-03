# VR Final Project


## Description

This was a project created for CSCI 5619: Virtual Reality and 3D Interaction. Our project is VR Finger Painting application. Our project uses the Oculus SDK for unity as the XR Interaction Toolkit does not currently have support for hand tracking. This means that we had to learn and implement many of the Oculus specific tools such as the OVRCameraRig, OVRHand, etc. The OVR naming convention denotes things we have used from the Oculus SDK. Additionaly we created a menu system that is similar to how hand tracking works in Oculus Home. We have finger menus that the user can pinch to bring up a larger menu in the case of settings or reset the Canvas to white. If the settings menu is brought up the user can select the color used to draw using rgb sliders. On the hand there is a small line renderer that shows where the raycast is being performed on the index finger to draw. The user is able to move their finger towards the Wall to draw.

## Third Party Assets
	- Oculus Integration Package V34.0 (https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022)


## Instructions

This project is similar to the assingments in class, such that it uses unity and has a apk file. To properly use the application hand tracking must be enabled on the quest first. This can be done by following the instructions given by Oculus on the "To turn Hand Tracking on or off" section here: https://support.oculus.com/articles/headsets-and-accessories/controllers-and-hand-tracking/hand-tracking-quest-2/. Once the application is started the user's hands should be tracked. To paint simply move your index finger to the wall in front of you. To access the menus, face the palm of your hands towards your face. Pinching is used to select each menu option on the fingers. The right hand middle finger resets the canvas, while the left hand middle finger brings up the settings menu. Hold the left hand middle finger and move your left hand to reposition the settings menu. Once settings menu is up, use you're right hand to move a cursor on the UI and pinch to select.

## License

Material for [CSCI 5619 Fall 2021](https://canvas.umn.edu/courses/268490) by [Evan Suma Rosenberg](https://illusioneering.umn.edu/) is licensed under a [Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License](http://creativecommons.org/licenses/by-nc-sa/4.0/).

The intent of choosing CC BY-NC-SA 4.0 is to allow individuals and instructors at non-profit entities to use this content.  This includes not-for-profit schools (K-12 and post-secondary). For-profit entities (or people creating courses for those sites) may not use this content without permission (this includes, but is not limited to, for-profit schools and universities and commercial education sites such as Coursera, Udacity, LinkedIn Learning, and other similar sites).   