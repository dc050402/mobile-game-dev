# Mobile-Game-Dev

mobile game development module repository

## Android Keystore

Keystore file: zenrun-release.keystore Location: C:\Users\dylco\Documents\GameSecrets Alias: zenrun Validity: 50 years

The keystore is stored outside of the project directory. Passwords are stored securely in the password manager and are not included with this repository.

A backup of the keystore is stored in a second encrypted location.

## Build Instructions

Open Project in Unity Open File -> Build Profiles Select Android Release build profile Confirm that Android platform is selected Ensure package name and version is correct Ensure the release keystore is selected Click Build Save APK to Builds/ Using abd install, aok can be installed on a connecteed Android devid.

Development build use the android dev build profile.

## Repository Structure

Main branch is where all stable code will go for publishing/production. Develop branch will be used to merge new features from feature branches to be tested before hitting the stable release. All new features will be worked on in a seperate feature branch with a clear naming distinction of the branch being used.

## Release Artefacts

Release APKs are stored in the `/releases/` folder.

Example:

releases/MyGame-0.1.0.apk
