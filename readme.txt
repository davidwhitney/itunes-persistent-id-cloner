The iTunes Persistent Id Cloner!

Small command line app to:

1) Extract the persistent Id from an iTunes library (this is the thing that your device is bound to)
2) Patch up an iTunes library with a persistent Id you supply (I bet you can see where this is going).

Usage:

Compile.

1) Quit iTunes on machine that you want to be considered your "master" persistent Id.
    I'd suggest the one you've already got your iPod / iPhone registered on.
    
2) Run itunes-persistent-id-cloner.exe -extract
    Write down the Persistent Id it gives you.
    
3) Install a fresh copy of iTunes on another machine
    Run it once, and quit iTunes.
    
3) Run itunes-persistent-id-cloner.exe -patch on another machine
    When prompted, enter the persistent Id supplied by the other Id.
    Ensure iTunes isn't running.
    Hit enter.
    
    
No friendly error messages or error handling at the moment.
Don't make typos, things might crash. Worse case, you can run / patch a second time.