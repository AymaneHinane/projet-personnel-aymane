import { idText } from "typescript";

export {}

const user = {
  name: "Daniel",
  age: 26,
};

//
//console.log(user.location); // returns undefined

////////////////////////
const user2:any = {
  name: "Daniel",
  age: 26,
};

console.log(user2.location); // typescript ne vas pas verifier si la methode ou la propriete existe car on a utiliser any

////////////////////////

function greet(person: string, date: Date) : string{
  console.log(`Hello ${person}, today is ${date.toDateString()}!`);

  return person;
}
 
greet("Maddison", new Date());

//////////////////////

let Names:string[] = ["aymane","alie","joelle"]

console.log(Names);

let tab:number[] = [2,3]

//////////////////////

// The parameter's type annotation is an object type
function printCoord(pt: { x: number; y?: number }) {
  console.log("The coordinate's x value is " + pt.x);
  console.log("The coordinate's y value is " + pt.y); //undefined instead of error 
}
printCoord({ x:3,y:5});  //without y?
printCoord({ x:3}); //With y


////////////////////////

function f(x?: number) {
  // ...
}
f(); // OK
f(10); // OK

///////////////////////

//default parameter
function f2(x = 10) {
  // ...
}

///////////////////////

// The parameter's type annotation is an object type
function print2(value:string|number) {
    if(typeof value == "string")
       console.log(value.toUpperCase);
    else
      console.log(value);
}
print2(5);  
print2("hello"); 

/////////////////////////

function welcomePeople(x: string[] | string) {
  if (Array.isArray(x)) {
    // Here: 'x' is 'string[]'
    console.log("Hello, " + x.join(" and "));
  } else {
    // Here: 'x' is 'string'
    console.log("Welcome lone traveler " + x);
  }
}

//////////////////////////

// both arrays and strings have a slice method
function getFirstThree(x: number[] | string) {
  return x.slice(0, 3);
}


///////////////////////////

type Point = {
  x: number;
  y: number;
};
 
// Exactly the same as the earlier example
function printCoord3(pt: Point) {
  console.log("The coordinate's x value is " + pt.x);
  console.log("The coordinate's y value is " + pt.y);
}
 
printCoord3({ x: 100, y: 100 });

type id = number ;
type ID = number | string;
type UserInputSanitizedString = string;
type Mix = [number, string, boolean];
//////////////////////

type Student ={
  age:Number,
  Name:string
}


function test(student:Student)
{

}

test({age:22,Name:"aymane"})

/////////////////////////////////

type Dog = {
  haw:string
}

interface Human{
  speack:string
}

type DogOrHuman = Dog | Human;
type DogAndHuman = Dog & Human;

var DorOrHuman :DogOrHuman= {
  haw:"haw haw"
}

var DorAndHuman:DogAndHuman = {
  haw:"haw haw",
  speack:"hello"
}

//////////////////////////////////

//Extends type
type A = {age:number}
type B = A & {name:string};


////////////////

interface C {
  age:Number
}

// interface D extends C{
//   Name:string
// }

//var test2:D ={age:22,Name:"aymane"};

////////////////

//interface vs type
//https://dev.to/toluagboola/type-aliases-vs-interfaces-in-typescript-3ggg


////////////////


interface Options {
  width: number;
}
function configure(x: Options | "auto") {
  // ...
}
configure({ width: 100 });
configure("auto");
//configure("automatic");


///////////////////////////

function doSomething(x: string | null) {
  if (x === null) {
    // do nothing
  } else {
    console.log("Hello, " + x.toUpperCase());
  }
}

function liveDangerously(x?: number | null) {   //x? == undefined    
  // No error
  //normaly we should check if x are != null
  //if we a sure that x != null i can use !
  // !: variabale are not nullable
  //console.log(x!.toFixed());
}

//without x?
//liveDangerously(); //error

//with x?
liveDangerously(); // ? you can if you want not pass a value

liveDangerously(null); // can accepte null 



var e = {
  age:22
}

function verifyObject(e:object)
{
    
}

verifyObject(e);

////////////////////////////////////////
//typeof
// "string"
// "number"
// "bigint"
// "boolean"
// "symbol"
// "undefined"
// "object"
// "function"


var z:string[]=["ay"]

if(typeof z == "object")
   console.log(typeof z);


//string[] and null are object
function printAll(strs: string | string[] | null) {
  //if(strs) null return false but also empty string return false   sow the else if will not be check
    if (strs && typeof strs === "object") {
      for (const s of strs) {
       //Object is possibly 'null'.
         console.log(s);
       }
    } else if (typeof strs === "string") {
       console.log(strs);
    } else {
      // do nothing
    }
}


///////////////////////////

function testNUll1(a:undefined){}
testNUll1(undefined);

function testNUll2(a?:undefined){}
testNUll2();

//////////////////////////

type Fish = { swim: () => void };
type Bird = { fly: () => void };
 
function move(animal: Fish | Bird) {
  if ("swim" in animal) {
    return animal.swim();
  }
 
  return animal.fly();
}

///////////////////////////

function isFish(pet: Fish | Bird): pet is Fish {
  return (pet as Fish).swim !== undefined;
}

let fish:Fish={swim:()=>"hello"};

console.log(isFish(fish));
console.log(fish.swim());

if (isFish(fish)) {
  fish.swim();
  //https://bobbyhadz.com/blog/typescript-check-if-object-has-key
} else if("fly" in fish /*&& fish.fly !== undefined*/) {
   //fish.fly();
}

///////////////////////////

type Fish2 = { swim: () => void; name: string };
type Bird2 = { fly: () => void; name: string };

function getSmallPet2(): Fish2 | Bird2
{
  var fish:Fish2={swim:()=>console.log("swim"),name:"fish"}
  return fish;
}

function isFish2(pet: Fish | Bird): pet is Fish {
  return (pet as Fish).swim !== undefined;
}


const zoo: (Fish2 | Bird2)[] = [getSmallPet2(), getSmallPet2()];

const underWater2: Fish2[] = zoo.filter(isFish2) as Fish2[];


const underWater3: Fish2[] = zoo.filter((pet): pet is Fish2 => {
  if (pet.name === "sharkey") 
     return false;
  return isFish(pet);
});

////////////////////////////

function greeter(fn: (a: string) => void) {
  fn("Hello, World");
}
 
//or

// type GreetFunction = (a: string) => void;
// function greeter(fn: GreetFunction) {
//   // ...
// }


function printToConsole(s: string) {
  console.log(s);
}
 
greeter(printToConsole);

////////////////////////////

type DescribableFunction = {
  description: string;
  print: () => void;
  (someArg: number): boolean;
};


function doSomething3(fn: DescribableFunction) {
  console.log(fn.description + " returned " + fn(6));
}

/////////////////////////////

function firstElement1(arr: any[]) {
  return arr[0];
}

function firstElement2<Type>(arr: Type[]): Type | undefined {
  return arr[0];
}

// s is of type 'string'
const s = firstElement2(["a", "b", "c"]);
// n is of type 'number'
const n = firstElement2([1, 2, 3]);
// u is of type undefined
const u = firstElement2([]);

//////////////////////////////

function map<Input, Output>(arr: Input[], func: (arg: Input) => Output): Output[] {
  return arr.map(func);
}
 
// Parameter 'n' is of type 'string'
// 'parsed' is of type 'number[]'
const parsed = map(["1", "2", "3"], (n) => parseInt(n));

////////////////////////////////

function longest<Type extends { length: number }>(a: Type, b: Type) {
  if (a.length >= b.length) {
    return a;
  } else {
    return b;
  }
}
 
// longerArray is of type 'number[]'
const longerArray = longest([1, 2], [1, 2, 3]);
// longerString is of type 'alice' | 'bob'
const longerString = longest("alice", "bob");
// Error! Numbers don't have a 'length' property

//const notOK = longest(10, 100);
//Argument of type 'number' is not assignable to parameter of type '{ length: number; }'.

//////////////////////////////
function combine<Type>(arr1: Type[], arr2: Type[]): Type[] {
  return arr1.concat(arr2);
}

///////////////////////

function myForEach(arr: any[], callback: (arg: any, index?: number) => void) {
  for (let i = 0; i < arr.length; i++) {
    callback(arr[i], i);
  }
}

myForEach([1, 2, 3], (a) => console.log(a));
myForEach([1, 2, 3], (a, i) => console.log(a, i));

///////////////////////

function doSomething4(f: Function) {
  return f(1, 2, 3);
}

////////////////////////

function multiply(n: number, ...m: number[]) {
  return m.map((x) => n * x);
}
// 'a' gets value [10, 20, 30, 40]
const a = multiply(10, 1, 2, 3, 4);

const arr1 = [1, 2, 3];
const arr2 = [4, 5, 6];
arr1.push(...arr2);

////////////////////

//Parameter Destructuring

function sum1({ a, b, c }) {
  console.log(a + b + c);
}
sum1({ a: 10, b: 3, c: 9 });

/////

function sum2({ a, b, c }: { a: number; b: number; c: number }) {
  console.log(a + b + c);
}

//////
// Same as prior example
type ABC = { a: number; b: number; c: number };
function sum({ a, b, c }: ABC) {
  console.log(a + b + c);
}

//////////////////////
//Object Types

function greet3(person: { name: string; age: number }) {
  return "Hello " + person.name;
}

interface Person2 {
  name?: string;
  age: number;
}
 
function greet1(person: Person2) {
  return "Hello " + person.name;
}


type Person3 = {
  name?: string;
  age: number;
};
 
function greet2(person: Person3) {
  return "Hello " + person.name;
}

/////////////

interface Home {
  readonly resident: { name: string; age: number };
}

function visitForBirthday(home: Home) {
  // We can read and update properties from 'home.resident'.
  console.log(`Happy birthday ${home.resident.name}!`);
  home.resident.age++;
}
 
function evict(home: Home) {
  // But we can't write to the 'resident' property itself on a 'Home'.
       //Cannot assign to 'resident' because it is a read-only property.

  // home.resident = {
  //   name: "Victor the Evictor",
  //   age: 42,
  // };
}

//////////////////

//Index

interface StringArray {
  [index: number]: string;
  //  readonly [index: number]: string;
}
 
const myArray: StringArray = ["jan","han"];
const secondItem = myArray[1];

///////////////////

interface AddressWithUnit1 {
  name?: string;
  unit: string;
}

interface AddressWithUnit2 {
  name?: string;
  unit: string;
}

interface BasicAddress extends AddressWithUnit1,AddressWithUnit2 {
  country: string;
  postalCode?: string;
}
 
//////////////////

interface Colorful {
  color: string;
}
 
interface Circle {
  radius: number;
}
 
interface ColorfulCircle extends Colorful, Circle {}
 
const cc: ColorfulCircle = {
  color: "red",
  radius: 42,
};

/////////////////////

//Intersection Types

interface Colorful {
  color: string;
}
interface Circle {
  radius: number;
}
 
type ColorfulCircle2 = Colorful & Circle;

function draw(circle: Colorful & Circle) {
  console.log(`Color was ${circle.color}`);
  console.log(`Radius was ${circle.radius}`);
}
 
// okay
draw({ color: "blue", radius: 42 });
 
// oops
//draw({ color: "red", raidus: 42 });

///////////////////
///////////////////

interface Box {
  contents: unknown;
}
 
let x: Box = {
  contents: "hello world",
};
 
// we could check 'x.contents'
if (typeof x.contents === "string") {
  console.log(x.contents.toLowerCase());
}
 
// or we could use a type assertion
console.log((x.contents as string).toLowerCase());

/////////////////////////

interface Box2<Type> {
  contents: Type;
}

let box: Box2<string>;

function setContents<Type>(box: Box2<Type>, newContents: Type) {
  box.contents = newContents;
}

/////////////////////////

function doStuff(values: readonly string[]) {
  // We can read from 'values'...
  const copy = values.slice();
  console.log(`The first value is ${values[0]}`);
 
  // ...but we can't mutate 'values'.
  //values.push("hello!");
  //Property 'push' does not exist on type 'readonly string[]'.
}



//let x2:readonly string; //'readonly' type modifier is only permitted on array and tuple literal types.

let x2:readonly string[];


///////////////////////////
//typeof  

let s1 = "hello";
let n1: typeof s;
//let n: string

/////////

function f3() {
  return { x: 10, y: 3 };
}
type P = ReturnType<typeof f3>;
// type P = {
//   x: number;
//   y: number;
// }

///////////

type Person = { age: number; name: string; alive: boolean };
type Age = Person["age"];   
//type Age = number

///////////////////

const MyArray = [
  { name: "Alice", age: 15 },
  { name: "Bob", age: 23 },
  { name: "Eve", age: 38 },
];
 
type Person4 = typeof MyArray[number];
// type Person4 = {
//     name: string;
//     age: number;
// }

type Age41 = typeof MyArray[number]["age"];
     
type Age42 = number
// Or
type Age43 = Person["age"];
      
type Age44 = number

///////////////////
interface C {
  c(): void
}

// interface D extends B, C {
//   d(): void
// }

interface Mailable {
  send(email: string): boolean
  queue(email: string): boolean
}

class Control {
  private state: boolean;
}

interface StatefulControl extends Control {
  enable(): void
}


class Button extends Control implements StatefulControl {
  enable() { }
}

///////////////////
type Tree<T> = {
  value: T;
  children: Array<Tree<T>>;
};

///////////////////
//https://medium.com/@KevinBGreene/advanced-typescript-the-power-and-limitations-of-conditional-types-and-the-infer-keyword-26011edcdeb8
///////////////////

interface NameInput{
  Name:string
}
interface AgeInput{
  Age:Number
}

type ReturnGeneric<T extends Number | String> = T extends String ? NameInput:AgeInput;

function GetValue<T extends string|Number>(data:T):ReturnGeneric<T>{
    throw ("");
}


let c = GetValue(22); //function GetValue<22>(data: 22): AgeInput

////////////////////

declare function double<
  T extends 1 | 2 | 3
>(a: T): T extends 1
  ? 2
  : T extends 2
  ? 4
  : T extends 3
  ? 6
  : never;

var d = double(3); //6   if the type of T is 3 the return type will be 6
//var d = double(4); //type not valide

