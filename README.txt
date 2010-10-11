This is a _very_ simple C# binary to upload a file to Rackspace Cloud Files.

Build:

Windows:
    install nant http://nant.sourceforge.net/ and run nant.exe in the directory

Linux (mono):
    
    apt-get install nant (or other method of your distro but that will work for sure in debian/ubuntu).
    nant on the source directory

Run:

Syntax is simple as :

UploadToCFCLI.exe $RCLOUD_API_USER $RCLOUD_API_KEY ${CONTAINER_TO_UPLOAD} ${FILE_TO_UPLOAD}

This is straightfoward enough to don't need a long README.


