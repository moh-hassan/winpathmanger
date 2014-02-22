/********************************************************************************************************
 * 
 * WinPath Manager
 * Copyright 2014 Mohamed Hassan 
 * Apache License 2.0 (Apache)
 * 
 * https://pathmanger.codeplex.com/
 * 
 ******************************************************************************************************/

WinPathManager
==================
Project Description
The program is a utility to help users to perform the edits of the window path variable and auto shorten path if needed.

The window path environment is a text separated by semicolon.
Editing the variable is error prone and may lead to problems.
The project WinPath manager is a utility to help users to perform the edits of the windows path environment variable, allow for automation and reduce the errors of typing.
Errors of typos in the path can cause fail of running programs.

The program help the users to:
-Resolve the errors such as "the value of the environment variable path is more than 1023" when installing new programs.
-Review window path environment and get rid of unnecessary entries.
- know the length of the path and be warned if path length is more than 1023 char.
- Remove(delete) the path of programs that no longer exist and the duplicates.
- Modify existing entries.
- Auto shorten the entries by using 8.3 naming in case path exceed 1023 char to allow install new programs.
- Arrange existing entries up/down.
- Add new path from within folder browser to avoid error. 

The application uses MVVMFX Framework.

How to use
============
Run the application 
The upper view displays the windows path text.
A label show the length of the path and number of entries.
If the path length is longer than 1023 char:
   A red label is displayed 
   The button Repair is enabled


The low view shows the list of path entries 
  All: show all entries
  Dublicated: show the dublicated pathes (if there are ones)
  Not Exist: show the entries which is no longer exist on the machine (if there are ones).


  If you press Repair button , the application will remove the duplicated and not exist pathes 
  It may shorten the name of some entries  to be total length is less than 1024 char.