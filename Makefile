CC = gcc
RM = del
CFiles = $(wildcard *.c)
OFiles = $(wildcard *.o)
SOFiles = $(wildcard *.so)

.PHONY: all clean

all:
	gcc -c -fPIC keyboard.c -o keyboard.o
	gcc keyboard.o -shared -o keyboard.so
	dotnet run /unsafe

clean:
#	$(RM) $(OFiles)
#	$(RM) $(SOFiles)

*.o:
	gcc -c -fPIC $(CFiles)

*.so: *.o
	$(CC) *.o -shared