CC = gcc
RM = rm
CFiles = $(wildcard *.c)
OFiles = $(wildcard *.o)
SOFiles = $(wildcard *.so)

.PHONY: all clean

all: *.so
	dotnet run

clean:
	$(RM) $(OFiles)
	$(RM) $(SOFiles)

*.o:
	gcc -c -fPIC $(CFiles)

*.so: *.o
	$(CC) *.o -shared