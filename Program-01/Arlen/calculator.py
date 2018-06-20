import os
import sys

a = 0
b = 0
c = 0
answer = 0

def chunk():
    os.system('cls')
    #os.system('clear')
def calculate(a,b,c):
	global answer
	if c == '+':
		answer = float(a) + float(b)
		chunk()
		print(str(a) + ' +  ' + str(b) + ' = ' + str(answer))
		input()
		ask()
	elif c == '-':
		answer = float(a) - float(b)
		chunk()
		print(str(a) + ' -  ' + str(b) + ' = ' + str(answer))
		input()
		ask()
	elif c == '*':
		answer = float(a) * float(b)
		chunk()
		print(str(a) + ' *  ' + str(b) + ' = ' + str(answer))
		input()
		ask()
	elif c == '/':
		try:
			answer = float(a) / float(b)
			print(str(a) + ' / ' + str(b) + ' = ' + str(answer))
			input()
			ask()
		except:
			if b == 0:
				chunk()
				print("You can't divide by zero.")
				input()
				ask()
			else:
				chunk()
				print("You're trying to do something strange")
				input()
				ask()
	else:
		chunk()
		print("You have selected an invalid function")
		print("Press ENTER to continue")
		input()
		chunk()
		ask()

def ask():
	global a
	global b
	global c
	chunk()
	a = input ("First value: ")
	chunk()
	b = input ("Second value: ")
	chunk()
	c = input ("+ - * /\n")
	chunk()
	calculate(a,b,c)
ask()
