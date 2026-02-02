# number_guesser
Number guess is a start to a simple game, it currently runs but is not optimized.
if you review the code of the audio engine you will see it needs to be simplified to abstract control of the audio flow.
Should be updated for a class for the library, the sound as instance, and the wrappers.

File hardcodes bas64 sounds, this should instead be external wav files, but this option is available for portable apps.

Portable apps has sounds created in the folder app if base64 is used, update needs to include file clean up on exit.

More exceptions, need to be done to catch any errors.

Variable naming convention can be improved..

Comments were removed as they were out of date from many changes, new comments needed. Especially summary on methods.
