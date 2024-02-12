This application is 2 parts:
1) No Sleep with Running VM runs on the host and will prevent your host from entering sleep mode when a VM is running and also listens for volume adjustments sent from 2nd app running on client.
2) GuestKeyHooker runs on the client which monitors multimedia keyboard volume control input and passes them to the host.

Add "Microsoft Visual Studio Installer Projects" extension to Visual Studio so you can use the Setup projects.

Build "SetupNoSleep" project, then right-click the project and click install (or, if host will be a different computer, copy the setup.exe or SetupNoSleep.msi file to the intendend host and install).

Build "SetupGuestKeyHooker", then browse to the compiled Setup.exe or SetupGuestKeyHooker.msi file and copy/install it on client.
