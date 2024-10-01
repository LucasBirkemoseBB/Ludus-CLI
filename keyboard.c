#include <stdio.h>
#include <Windows.h>
#include <conio.h>

#define uint32_t unsigned int

char getKeys() 
{

  char c = '\0';
  if(kbhit())
  {
    c = getch();
  }

  return c;
} 