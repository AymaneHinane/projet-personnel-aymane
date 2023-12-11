"use strict";
exports.__esModule = true;
var user = {
    name: "Daniel",
    age: 26
};
//
//console.log(user.location); // returns undefined
////////////////////////
var user2 = {
    name: "Daniel",
    age: 26
};
console.log(user2.location); // typescript ne vas pas verifier si la methode ou la propriete existe car on a utiliser any
////////////////////////
function greet(person, date) {
    console.log("Hello ".concat(person, ", today is ").concat(date.toDateString(), "!"));
    return person;
}
greet("Maddison", new Date());
//////////////////////
var Names = ["aymane", "alie", "joelle"];
console.log(Names);
var tab = [2, 3];
//////////////////////
// The parameter's type annotation is an object type
function printCoord(pt) {
    console.log("The coordinate's x value is " + pt.x);
    console.log("The coordinate's y value is " + pt.y); //undefined instead of error 
}
printCoord({ x: 3, y: 5 }); //without y?
printCoord({ x: 3 }); //With y
////////////////////////
function f(x) {
    // ...
}
f(); // OK
f(10); // OK
///////////////////////
//default parameter
function f2(x) {
    if (x === void 0) { x = 10; }
    // ...
}
///////////////////////
// The parameter's type annotation is an object type
function print2(value) {
    if (typeof value == "string")
        console.log(value.toUpperCase);
    else
        console.log(value);
}
print2(5);
print2("hello");
/////////////////////////
function welcomePeople(x) {
    if (Array.isArray(x)) {
        // Here: 'x' is 'string[]'
        console.log("Hello, " + x.join(" and "));
    }
    else {
        // Here: 'x' is 'string'
        console.log("Welcome lone traveler " + x);
    }
}
//////////////////////////
// both arrays and strings have a slice method
function getFirstThree(x) {
    return x.slice(0, 3);
}
// Exactly the same as the earlier example
function printCoord3(pt) {
    console.log("The coordinate's x value is " + pt.x);
    console.log("The coordinate's y value is " + pt.y);
}
printCoord3({ x: 100, y: 100 });
function test(student) {
}
test({ age: 22, Name: "aymane" });
var DorOrHuman = {
    haw: "haw haw"
};
var DorAndHuman = {
    haw: "haw haw",
    speack: "hello"
};
var test2 = { age: 22, Name: "aymane" };
function configure(x) {
    // ...
}
configure({ width: 100 });
configure("auto");
//configure("automatic");
///////////////////////////
function doSomething(x) {
    if (x === null) {
        // do nothing
    }
    else {
        console.log("Hello, " + x.toUpperCase());
    }
}
function liveDangerously(x) {
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
    age: 22
};
function verifyObject(e) {
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
var z = ["ay"];
if (typeof z == "object")
    console.log(typeof z);
//string[] and null are object
function printAll(strs) {
    //if(strs) null return false but also empty string return false   sow the else if will not be check
    if (strs && typeof strs === "object") {
        for (var _i = 0, strs_1 = strs; _i < strs_1.length; _i++) {
            var s_1 = strs_1[_i];
            //Object is possibly 'null'.
            console.log(s_1);
        }
    }
    else if (typeof strs === "string") {
        console.log(strs);
    }
    else {
        // do nothing
    }
}
///////////////////////////
function testNUll1(a) { }
testNUll1(undefined);
function testNUll2(a) { }
testNUll2();
function move(animal) {
    if ("swim" in animal) {
        return animal.swim();
    }
    return animal.fly();
}
///////////////////////////
function isFish(pet) {
    return pet.swim !== undefined;
}
var fish = { swim: function () { return "hello"; } };
console.log(isFish(fish));
console.log(fish.swim());
if (isFish(fish)) {
    fish.swim();
    //https://bobbyhadz.com/blog/typescript-check-if-object-has-key
}
else if ("fly" in fish /*&& fish.fly !== undefined*/) {
    //fish.fly();
}
function getSmallPet2() {
    var fish = { swim: function () { return console.log("swim"); }, name: "fish" };
    return fish;
}
function isFish2(pet) {
    return pet.swim !== undefined;
}
var zoo = [getSmallPet2(), getSmallPet2()];
var underWater2 = zoo.filter(isFish2);
var underWater3 = zoo.filter(function (pet) {
    if (pet.name === "sharkey")
        return false;
    return isFish(pet);
});
////////////////////////////
function greeter(fn) {
    fn("Hello, World");
}
//or
// type GreetFunction = (a: string) => void;
// function greeter(fn: GreetFunction) {
//   // ...
// }
function printToConsole(s) {
    console.log(s);
}
greeter(printToConsole);
function doSomething3(fn) {
    console.log(fn.description + " returned " + fn(6));
}
/////////////////////////////
function firstElement1(arr) {
    return arr[0];
}
function firstElement2(arr) {
    return arr[0];
}
// s is of type 'string'
var s = firstElement2(["a", "b", "c"]);
// n is of type 'number'
var n = firstElement2([1, 2, 3]);
// u is of type undefined
var u = firstElement2([]);
//////////////////////////////
function map(arr, func) {
    return arr.map(func);
}
// Parameter 'n' is of type 'string'
// 'parsed' is of type 'number[]'
var parsed = map(["1", "2", "3"], function (n) { return parseInt(n); });
////////////////////////////////
function longest(a, b) {
    if (a.length >= b.length) {
        return a;
    }
    else {
        return b;
    }
}
// longerArray is of type 'number[]'
var longerArray = longest([1, 2], [1, 2, 3]);
// longerString is of type 'alice' | 'bob'
var longerString = longest("alice", "bob");
// Error! Numbers don't have a 'length' property
//const notOK = longest(10, 100);
//Argument of type 'number' is not assignable to parameter of type '{ length: number; }'.
//////////////////////////////
function combine(arr1, arr2) {
    return arr1.concat(arr2);
}
///////////////////////
function myForEach(arr, callback) {
    for (var i = 0; i < arr.length; i++) {
        callback(arr[i], i);
    }
}
myForEach([1, 2, 3], function (a) { return console.log(a); });
myForEach([1, 2, 3], function (a, i) { return console.log(a, i); });
///////////////////////
function doSomething4(f) {
    return f(1, 2, 3);
}
////////////////////////
function multiply(n) {
    var m = [];
    for (var _i = 1; _i < arguments.length; _i++) {
        m[_i - 1] = arguments[_i];
    }
    return m.map(function (x) { return n * x; });
}
// 'a' gets value [10, 20, 30, 40]
var a = multiply(10, 1, 2, 3, 4);
var arr1 = [1, 2, 3];
var arr2 = [4, 5, 6];
arr1.push.apply(arr1, arr2);
////////////////////
//Parameter Destructuring
function sum1(_a) {
    var a = _a.a, b = _a.b, c = _a.c;
    console.log(a + b + c);
}
sum1({ a: 10, b: 3, c: 9 });
/////
function sum2(_a) {
    var a = _a.a, b = _a.b, c = _a.c;
    console.log(a + b + c);
}
function sum(_a) {
    var a = _a.a, b = _a.b, c = _a.c;
    console.log(a + b + c);
}
//////////////////////
//Object Types
function greet3(person) {
    return "Hello " + person.name;
}
function greet1(person) {
    return "Hello " + person.name;
}
function greet2(person) {
    return "Hello " + person.name;
}
function visitForBirthday(home) {
    // We can read and update properties from 'home.resident'.
    console.log("Happy birthday ".concat(home.resident.name, "!"));
    home.resident.age++;
}
function evict(home) {
    // But we can't write to the 'resident' property itself on a 'Home'.
    //Cannot assign to 'resident' because it is a read-only property.
    // home.resident = {
    //   name: "Victor the Evictor",
    //   age: 42,
    // };
}
var myArray = ["jan", "han"];
var secondItem = myArray[1];
var cc = {
    color: "red",
    radius: 42
};
function draw(circle) {
    console.log("Color was ".concat(circle.color));
    console.log("Radius was ".concat(circle.radius));
}
// okay
draw({ color: "blue", radius: 42 });
var x = {
    contents: "hello world"
};
// we could check 'x.contents'
if (typeof x.contents === "string") {
    console.log(x.contents.toLowerCase());
}
// or we could use a type assertion
console.log(x.contents.toLowerCase());
var box;
function setContents(box, newContents) {
    box.contents = newContents;
}
/////////////////////////
function doStuff(values) {
    // We can read from 'values'...
    var copy = values.slice();
    console.log("The first value is ".concat(values[0]));
    // ...but we can't mutate 'values'.
    //values.push("hello!");
    //Property 'push' does not exist on type 'readonly string[]'.
}
//let x2:readonly string; //'readonly' type modifier is only permitted on array and tuple literal types.
var x2;
///////////////////////////
//typeof  
var s1 = "hello";
var n1;
//let n: string
/////////
function f3() {
    return { x: 10, y: 3 };
}
//type Age = number
///////////////////
var MyArray = [
    { name: "Alice", age: 15 },
    { name: "Bob", age: 23 },
    { name: "Eve", age: 38 },
];
function GetValue(data) {
    throw ("");
}
var c = GetValue(22);
