# Firing multiple meters
For the purposes of demonstrating the software for the assignment including its ability to handle multiple connections at one given time, a script can be used to create multiple instances of it with the same IDs. This is for use on Windows machines that you can run a batch file on.

Create a batch file `<name>.bat` with the following in:

```
@echo on
cd <directory where Client.exe is located>
start Client.exe 626262
start Client.exe 636363
start Client.exe 656565
PAUSE
```

When you execute this, it will automatically start 3 instances of the client with the following IDs: `626262`, `636363`, and `656565`.
