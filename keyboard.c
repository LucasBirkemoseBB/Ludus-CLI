#include <stdio.h>
#include <Windows.h>
#include <conio.h>

// Returns the last key pressed and if one is not pressed it returns \0
char getKeys() 
{
  char c = '\0';
  if(kbhit())
  {
    c = getch();
  }

  return c;
} 