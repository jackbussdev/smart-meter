# Firing multiple meters
For the purposes of demonstrating the software for the assignment including its ability to handle multiple connections at one given time, a script can be used to create multiple instances of the client with different Ids and location Ids. This is for use on Windows machines that you can run a batch file on.

Create a batch file `<name>.bat` with the following in:

```
@echo on
cd <directory where Client.exe is located>
start Client.exe 000001 1
start Client.exe 000002 1
start Client.exe 000003 2
start Client.exe 000004 2
start Client.exe 000005 3
start Client.exe 000006 3
start Client.exe 000007 4
start Client.exe 000008 4
start Client.exe 000009 5
start Client.exe 0000010 5
start Client.exe 0000011 6
start Client.exe 0000012 6
start Client.exe 0000013 7
start Client.exe 0000014 7
start Client.exe 0000015 8
PAUSE
```

You MUST provide both an Client Id (first number), and a location Id (second number) to correctly run the clients. Once the file is saved, right click and run it. This will  start 15 client instances with corresponding ids
