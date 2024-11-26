# Firing multiple meters
For the purposes of demonstrating the software for the assignment including its ability to handle multiple connections at one given time, a script can be used to create multiple instances of it with the same IDs. This is for use on Windows machines that you can run a batch file on.

Create a batch file `<name>.bat` with the following in:

```
@echo on
cd <directory where Client.exe is located>
start Client.exe 000001
start Client.exe 000002
start Client.exe 000003
start Client.exe 000004
start Client.exe 000005
start Client.exe 000006
start Client.exe 000007
start Client.exe 000008
start Client.exe 000009
start Client.exe 0000010
start Client.exe 0000011
start Client.exe 0000012
start Client.exe 0000013
start Client.exe 0000014
start Client.exe 0000015
PAUSE
```

When you execute this, it will automatically start 15 client instances with corresponding ids
