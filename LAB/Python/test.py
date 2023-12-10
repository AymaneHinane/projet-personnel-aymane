print("Hello, World!")



if 5>2:
    print("you have two")


x= str(3)
y= int(3)
z= float(3)

print(x,y,z) #3 3 3.0

print(type(z)) #<class 'float'>

x,y,z=1,2,3
print(x,y,z) #1 2 3

x=x=y=z=3
print(x,y,z) #3 3 3

#Unpack a Collection
num=[4,5,6]
a,b,c=num
print(a,b,c) #4 5 6

#-----------------------------------

#Global Variables: variable that are declared outside a function
x=10

def give1():
    print(x)

def give2():
    x=7
    print(x)

give1() #10
give2() #7

#The global Keyword
def give():
    global d
    d=5

give()
print(d) #5

#-----------------------------------

#Built-in Data Types

#Text Type:	str
#Numeric Types:	int, float, complex
#Sequence Types:	list, tuple, range
#Mapping Type:	dict
#Set Types:	set, frozenset
#Boolean Type:	bool
#Binary Types:	bytes, bytearray, memoryview
#None Type:	NoneType

x=5
print(type(5)) #<class 'int'>


x = "Hello World"	#str	
x = 20	#int	
x = 20.5	#float	
x = 1j	#complex	
x = ["apple", "banana", "cherry"]	#list	
x = ("apple", "banana", "cherry")	#tuple	
x = range(6)	#range	
x = {"name" : "John", "age" : 36}	#dict	
x = {"apple", "banana", "cherry"}	#set	
x = frozenset({"apple", "banana", "cherry"})	#frozenset	
x = True	#bool	
x = b"Hello"	#bytes	
x = bytearray(5)	#bytearray	
x = memoryview(bytes(5))	#memoryview	
x = None	#NoneType	


#Setting the Specific Data Type: specify the data type, you can use the following constructor functions:
x = str("Hello World")	#str	
x = int(20)	#int	
x = float(20.5)	#float	
x = complex(1j)	#complex	
x = list(("apple", "banana", "cherry"))	#list	
x = tuple(("apple", "banana", "cherry"))	#tuple	
x = range(6)	#range	
x = dict(name="John", age=36)	#dict	
x = set(("apple", "banana", "cherry"))	#set	
x = frozenset(("apple", "banana", "cherry"))	#frozenset	
x = bool(5)	#bool	
x = bytes(5)	#bytes	
x = bytearray(5)	#bytearray	
x = memoryview(bytes(5))	#memoryview


#----------------------------

#Python Numbers

#There are three numeric types in Python:
#int
#float
#complex

x = 1    # int
y = 2.8  # float
z = 1j   # complex

#Type Conversion
x = 1    # int
y = 2.8  # float
z = 1j   # complex

#convert from int to float:
a = float(x)

#convert from float to int:
b = int(y)

#convert from int to complex:
c = complex(x)


#Random Number

import random
#display random number between 1 and 9
print(random.randrange(1,10)) # 2

#----------------------------------

#Python Casting
x = int(1)   # x will be 1
y = int(2.8) # y will be 2
z = int("3") # z will be 3

x = float(1)     # x will be 1.0
y = float(2.8)   # y will be 2.8
z = float("3")   # z will be 3.0
w = float("4.2") # w will be 4.2

x = str("s1") # x will be 's1'
y = str(2)    # y will be '2'
z = str(3.0)  # z will be '3.0'

#----------------------------------

chaine = "hello world"

print(chaine[0])

for c in chaine:
    print(c) # h e l l o w o l r d

print(len(chaine)) #11

#Check String

print("hello" in chaine) #True

if("hello" in chaine):
  print("exists") #exists


if("hello" not in chaine):
  print("not exists")

#Slicing
#chaine --> hello world
print(chaine[2:5]) #llo

#Slice From the Start
print(chaine[:5]) #hello

#Slice from end
print(chaine[5:]) # world

#Modify Strings
print(chaine.upper()) #HELLO WORLD

print(chaine.upper().lower()) #hello world

#Remove Whitespace
print("  hello world   ".strip()) #hello world

#Replace String
print(chaine.replace("o","a"))  #hella warld
print(chaine.replace("wo","a")) #hello arld

#Split String
a = "Hello, World!"
print(a.split(",")) # returns ['Hello', ' World!']

#String Concatenation
a = "Hello"
b = "World"
c = a + " " + b
print(c)

#Format - Strings

age = 36
txt = "My name is John, and I am {}"
print(txt.format(age)) #My name is John, and I am 36

name="aymane"

txt= "my name is {0} and age are {1}"
print(txt.format(name,age)) #my name is aymane and age are 36

#Escape Character
txt = "We are the so-called \"Vikings\" from the north."
print(txt) #We are the so-called "Vikings" from the north.


#String find() Method
txt = "Hello, welcome to my world."
x = txt.find("welcome")
print(x) #7


#---------------------------
#Python Booleans

#Most Values are True
#Almost any value is evaluated to True if it has some sort of content.

#Any string is True, except empty strings.

#Any number is True, except 0.

#Any list, tuple, set, and dictionary are True, except empty ones.

print(bool("Hello")) #True
print(bool(15)) #True
print(bool([1,2,3])) #True
print(bool(("a",1))) #True

print(bool("")) #False
print(bool(0)) #False
print(bool([])) #False
print(bool(())) #False
print(bool({})) #False


def myFunction() :
  return True

if myFunction():
  print("YES!")
else:
  print("NO!")

#determine if an object is of a certain data type
x = 200
print(isinstance(x, int))


#-------------------------------

#Python Lists
mylist = ["apple", "banana", "cherry"]
print(len(mylist)) #3

list1 = ["abc", 34, True, 40, "male"]

#The list() Constructor
thislist = list(("apple", "banana", "cherry"))

print(thislist[1]) #banana

thislist = ["apple", "banana", "cherry", "orange", "kiwi", "melon", "mango"]
print(thislist[2:5]) #['cherry', 'orange', 'kiwi']

thislist = ["apple", "banana", "cherry"]
if "apple" in thislist:
   print("yes")

#Change Item Value
thislist = ["apple", "banana", "cherry"]
thislist[1] = "blackcurrant"

thislist = ["apple", "banana", "cherry", "orange", "kiwi", "mango"]
thislist[1:3] = ["blackcurrant", "watermelon"]
print(thislist)

#Insert Items
#To insert a list item at a specified index
thislist = ["apple", "banana", "cherry"]
thislist.insert(2, "watermelon")
print(thislist) #['apple', 'banana', 'watermelon', 'cherry']

#Add List Items
thislist = ["apple", "banana", "cherry"]
thislist.append("orange")
print(thislist) #['apple', 'banana', 'cherry', 'orange']

#Extend List
thislist = ["apple", "banana", "cherry"]
tropical = ["mango", "pineapple", "papaya"]
thislist.extend(tropical)
print(thislist) #['apple', 'banana', 'cherry', 'mango', 'pineapple', 'papaya']

#The extend() method does not have to append lists, you can add any iterable object (tuples, sets, dictionaries etc.).
thislist = ["apple", "banana", "cherry"]
thistuple = ("kiwi", "orange")
thislist.extend(thistuple)
print(thislist) #['apple', 'banana', 'cherry', 'kiwi', 'orange']

#Remove Specified Item
thislist = ["apple", "banana", "cherry"]
thislist.remove("banana")
print(thislist) #['apple', 'cherry']

#Remove Specified Index
thislist = ["apple", "banana", "cherry"]
thislist.pop(1)
print(thislist) #['apple', 'cherry']

#Del the entire list
thislist = ["apple", "banana", "cherry"]
del thislist

#Clear the List
thislist = ["apple", "banana", "cherry"]
thislist.clear()
print(thislist) #[]

#Loop Through a List
thislist = ["apple", "banana", "cherry"]
for x in thislist:
  print(x)

#Loop Through the Index Numbers
thislist = ["apple", "banana", "cherry"]
for x in range(len(thislist)):
  print(x) # 0 1 2

#Using a While Loop
thislist = ["apple", "banana", "cherry"]
i = 0
while i < len(thislist):
  print(thislist[i])
  i = i + 1

#Looping Using List Comprehension
thislist = ["apple", "banana", "cherry"]
[print(x) for x in thislist] # apple banana cherry

#List Comprehension

#normal syntaxe
fruits = ["apple", "banana", "cherry", "kiwi", "mango"]
newlist = []

for x in fruits:
  if "a" in x:
    newlist.append(x)

print(newlist)

names = ["aymane","yohane","nina"]

namesFilter = [x for x in names if 'e' in x]
print(namesFilter) #['aymane', 'yohane']

[print(x) for x in names if 'e' in x] # aymane yohane
[print(x) for x in names if x != 'aymane'] # yohane nina

newlist = [x for x in fruits]
print(newlist) #['apple', 'banana', 'cherry', 'kiwi', 'mango']

newlist = [x for x in range(10) if x < 5]
print(newlist) #[0, 1, 2, 3, 4]

#Set the values in the new list to upper case
newlist = [x.upper() for x in fruits]
print(newlist) #['APPLE', 'BANANA', 'CHERRY', 'KIWI', 'MANGO']

#Set all values in the new list to 'hello':
newlist = ['hello' for x in fruits]

#Sort List Alphanumerically
thislist = ["orange", "mango", "kiwi", "pineapple", "banana"]
thislist.sort()
print(thislist) #['banana', 'kiwi', 'mango', 'orange', 'pineapple']

thislist = [100, 50, 65, 82, 23]
thislist.sort()
print(thislist) #[23, 50, 65, 82, 100]

#Copy a List
#You cannot copy a list simply by typing list2 = list1, because: list2 will only be a reference to list1, and changes made in list1 will automatically also be made in list2.

thislist = ["apple", "banana", "cherry"]
mylist = thislist.copy()
print(mylist)

#or

thislist = ["apple", "banana", "cherry"]
mylist = list(thislist)
print(mylist)

#Join Two Lists
list1 = ["a", "b", "c"]
list2 = [1, 2, 3]

list3 = list1 + list2
print(list3)

#or

list1 = ["a", "b" , "c"]
list2 = [1, 2, 3]

for x in list2:
  list1.append(x)

print(list1)

#or

list1 = ["a", "b" , "c"]
list2 = [1, 2, 3]

list1.extend(list2)
print(list1)

#append()	Adds an element at the end of the list
#clear()	Removes all the elements from the list
#copy()	Returns a copy of the list
#count()	Returns the number of elements with the specified value
#extend()	Add the elements of a list (or any iterable), to the end of the current list
#index()	Returns the index of the first element with the specified value
#insert()	Adds an element at the specified position
#pop()	Removes the element at the specified position
#remove()	Removes the item with the specified value
#reverse()	Reverses the order of the list
#sort()	Sorts the list

#-------------------------------

#Python Tuples

#NOT a tuple
thistuple = ("apple")
print(type(thistuple)) #<class 'str'>

thistuple = ("apple",)
print(type(thistuple)) #<class 'tuple'>

tuple1 = ("abc", 34, True, 40, "male")

print(thistuple[0]) #apple

#Range of Indexes
thistuple = ("apple", "banana", "cherry", "orange", "kiwi", "melon", "mango")
print(thistuple[2:5])

#Check if Item Exists
thistuple = ("apple", "banana", "cherry")
if "apple" in thistuple:
  print("Yes, 'apple' is in the fruits tuple")

#####
# NB:  Tuples are unchangeable, or immutable as it also is called.
#####

#Change Tuple Values
#Convert the tuple into a list to be able to change it:
x = ("apple", "banana", "cherry")
y = list(x)
y[1] = "kiwi"
x = tuple(y)
print(x) #('apple', 'kiwi', 'cherry')

#Add Items
thistuple = ("apple", "banana", "cherry")
y = list(thistuple)
y.append("orange")
thistuple = tuple(y)
print(thistuple) #('apple', 'banana', 'cherry', 'orange')


#Remove Items
thistuple = ("apple", "banana", "cherry")
y = list(thistuple)
y.remove("apple")
thistuple = tuple(y)

#thistuple = ("apple", "banana", "cherry")
#del thistuple
#print(thistuple) #this will raise an error because the tuple no longer exists

#Unpack Tuples
fruits = ("apple", "banana", "cherry")

(green, yellow, red) = fruits

print(green)
print(yellow)
print(red)

fruits = ("apple", "banana", "cherry", "strawberry", "raspberry")

(green, yellow, *red) = fruits

print(green)
print(yellow)
print(red) #['cherry', 'strawberry', 'raspberry']

#Loop Tuples
thistuple = ("apple", "banana", "cherry")
for x in thistuple:
  print(x) #apple banana cherry

#Loop Through the Index Numbers
thistuple = ("apple", "banana", "cherry")
for i in range(len(thistuple)):
  print(thistuple[i])

#Join Two Tuples
tuple1 = ("a", "b" , "c")
tuple2 = (1, 2, 3)

tuple3 = tuple1 + tuple2
print(tuple3) #('a', 'b', 'c', 1, 2, 3)

#count()	Returns the number of times a specified value occurs in a tuple
#index()	Searches the tuple for a specified value and returns the position of where it was found

#-------------------------
#Python Sets

myset = {"apple", "banana", "cherry"}

#Duplicates Not Allowed
#Sets cannot have two items with the same value.
thisset = {"apple", "banana", "cherry", "apple"}
print(thisset) #{'banana', 'cherry', 'apple'}
#Get the Length of a Set
print(len(thisset)) #3

set1 = {"abc", 34, True, 40, "male"}
print(type(myset)) #<class 'set'>

#####
#Python Collections (Arrays)
#There are four collection data types in the Python programming language:

#List is a collection which is ordered and changeable. Allows duplicate members.
#Tuple is a collection which is ordered and unchangeable. Allows duplicate members. (read only)
#Set is a collection which is unordered, unchangeable*, and unindexed. No duplicate members.
#Dictionary is a collection which is ordered** and changeable. No duplicate members.
####


thisset = {"apple", "banana", "cherry"}
print("banana" in thisset) #True


thisset = {"apple", "banana", "cherry"}
thisset.add("orange")
print(thisset) #{'orange', 'apple', 'cherry', 'banana'}

#update
thisset = {"apple", "banana", "cherry"}
tropical = {"pineapple", "mango", "papaya"}
thisset.update(tropical)
print(thisset) #{'pineapple', 'papaya', 'apple', 'banana', 'cherry', 'mango'}

thisset = {"apple", "banana", "cherry"}
mylist = ["kiwi", "orange"]
thisset.update(mylist)
print(thisset) #{'banana', 'cherry', 'orange', 'kiwi', 'apple'}

#Remove Item
thisset = {"apple", "banana", "cherry"}
thisset.remove("banana")
print(thisset) #{'apple', 'cherry'}

thisset = {"apple", "banana", "cherry"}
del thisset

#Join Sets
set1 = {"a", "b" , "c"}
set2 = {1, 2, 3}

set1.update(set2) 
print(set1) #{'a', 1, 'b', 2, 3, 'c'}
#NB: the lement are not sorted

#------------------------------------

#Python Dictionaries
#Dictionaries are used to store data values in key:value pairs.
#A dictionary is a collection which is ordered*, changeable and do not allow duplicates.

thisdict = {
  "brand": "Ford",
  "model": "Mustang",
  "year": 1964
}
print(thisdict) #{'brand': 'Ford', 'model': 'Mustang', 'year': 1964}
print(thisdict["brand"]) #Ford

#Python Collections (Arrays)
#There are four collection data types in the Python programming language:

#List is a collection which is ordered and changeable. Allows duplicate members.
#Tuple is a collection which is ordered and unchangeable. Allows duplicate members.
#Set is a collection which is unordered, unchangeable*, and unindexed. No duplicate members.
#Dictionary is a collection which is ordered** and changeable. No duplicate members.

#Accessing Items
thisdict = {
  "brand": "Ford",
  "model": "Mustang",
  "year": 1964
}
x = thisdict["model"]

#Get Keys
#The keys() method will return a list of all the keys in the dictionary.
print(thisdict.keys()) #dict_keys(['brand', 'model', 'year'])

#Add a new item
car = {
"brand": "Ford",
"model": "Mustang",
"year": 1964
}

car["color"] = "white"

print(x) #after the change

#Get Items
#The items() method will return each item in a dictionary, as tuples in a list.

print(thisdict.items()) #dict_items([('brand', 'Ford'), ('model', 'Mustang'), ('year', 1964)])

#Check if Key Exists
thisdict = {
  "brand": "Ford",
  "model": "Mustang",
  "year": 1964
}
if "model" in thisdict:
  print("Yes, 'model' is one of the keys in the thisdict dictionary")


#Change Values
thisdict = {
  "brand": "Ford",
  "model": "Mustang",
  "year": 1964
}
thisdict["year"] = 2018

#Adding Items
thisdict = {
  "brand": "Ford",
  "model": "Mustang",
  "year": 1964
}
thisdict["color"] = "red"
print(thisdict) #{'brand': 'Ford', 'model': 'Mustang', 'year': 1964, 'color': 'red'}

#Remove Dictionary Items
thisdict = {
  "brand": "Ford",
  "model": "Mustang",
  "year": 1964
}
thisdict.pop("model")
print(thisdict) #{'brand': 'Ford', 'year': 1964}


#Loop Through a Dictionary
for x in thisdict:
  print(x) #brand  year
  print(thisdict[x]) #Ford 1964

for x in thisdict.values():
  print(x) #Ford 1964

for x in thisdict.keys():
  print(x) #brand year


#Copy a Dictionary
thisdict = {
  "brand": "Ford",
  "model": "Mustang",
  "year": 1964
}
mydict = thisdict.copy()
print(mydict)


#----------------------------------
#Python If ... Else

a = 200
b = 33
if b > a:
  print("b is greater than a")
elif a == b:
  print("a and b are equal")
else:
  print("a is greater than b")


a = 200
b = 33
c = 500

if a > b and c > a:
  print("Both conditions are True")

if a > b or a > c:
  print("At least one of the conditions is True")

if not a > b:
  print("a is NOT greater than b")

#---------------------------------

#Creating a Function
def my_function():
  print("Hello from a function")


#Default Parameter Value
def my_function(country = "Norway"):
  print("I am from " + country)

my_function("India") #I am from India
my_function() #I am from Norway

#Passing a List as an Argument
def my_function(food):
  for x in food:
    print(x)

fruits = ["apple", "banana", "cherry"]

my_function(fruits)

#-------------------------------------
#Lambda

x = lambda a : a + 10
print(x(5))

x = lambda a, b : a * b
print(x(5, 6))

#anonymous function inside another function
def myfunc(n):
  return lambda a : a * n

mydoubler = myfunc(2)
print(mydoubler(11)) #22

#-------------------------------------

#Classes and Objects

#Almost everything in Python is an object, with its properties and methods.

class Person:
  def __init__(self, name, age):
    self.name = name
    self.age = age

  def __str__(self):
    return f"{self.name}({self.age})"
  
  def myfunc(self):
    print("Hello my name is " + self.name)


p1 = Person("John", 36)
print(p1) #John(36)   invoke __str__ function
print(p1.name) #John
print(p1.age) #36
p1.myfunc() #Hello my name is John

#Modify Object
p1.age = 40


#Python Inheritance


class Human:
   def __init__(self,name,age):
    self.name = name
    self.age = age 

class Player(Human):
  def __init__(self,name,age,rank):
    self.rank=rank
    #Human.__init__(self,name,age)
    super().__init__(name,age) 

  def __str__(self) -> str:
    return f"{name} {self.age} --> {self.rank}"
  

player = Player("yohane",23,9)
print(player) #aymane 36 --> 9


#--------------------------------
#Class Polymorphism

class Car:
  def __init__(self, brand, model):
    self.brand = brand
    self.model = model

  def move(self):
    print("Drive!")

class Boat:
  def __init__(self, brand, model):
    self.brand = brand
    self.model = model

  def move(self):
    print("Sail!")




car1 = Car("Ford", "Mustang")       #Create a Car class
boat1 = Boat("Ibiza", "Touring 20") #Create a Boat class

for x in (car1, boat1):
  x.move()


#-----------------------------
#Exception

try:
 x = "hello"
 if not type(x) is int:
   raise TypeError("Only integers are allowed")
except:
  print("Something went wrong")

